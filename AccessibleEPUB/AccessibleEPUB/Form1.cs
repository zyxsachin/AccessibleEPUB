using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Threading;

using System.IO;
using System.IO.Compression;
using System.Net;

using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;

using mshtml;

using Gecko;
using Gecko.Windows;


using ICSharpCode.AvalonEdit;

using Microsoft.Win32;

using GlobalHotKey;
using System.Windows.Input;

using Ionic;






namespace AccessibleEPUB
{

    public partial class Form1 : Form
    {
       
        //ScintillaNET.Scintilla TextArea;
        ICSharpCode.AvalonEdit.TextEditor codeArea;

        //string initialPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
        //string initialPath = Directory.GetCurrentDirectory();
        string initialPath = Application.StartupPath;

        private IHTMLDocument2 doc;
        Dictionary<string, string> headings;
        string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string accessibleEpubFormText = "Accessible EPUB";
        ICSharpCode.AvalonEdit.TextEditor codeEditor= new ICSharpCode.AvalonEdit.TextEditor();

        enum fileMode
        {
            singleFileCss = 1,
            singleFileJs = 2,
            onlyVis = 3,
            onlyBli = 4,
            onlyImp = 5,
            none = 6
        }

        int mode;
        string target;
        string targetFolder;
        bool containsFile = false;

        string currentTab = null;
        string lastTab = null;
        string currentEditorFile = null;

        string title;
        string author;
        string language;
        string publisher;
        bool newFileCorrect;

        bool refresh = true;
        bool mathmlManifestupdated = false;

        bool split1panel1Visible = false;


        string tempFolderStillInUseLong = "Temp folder is still in use. After pressing OK, the file opening process will stop.";
        string tempFolderStillInUse = "Folder still in use";
        string tempFolderInUseLong = "Folder in use. Please leave and then press OK.";
        string tempFolderInUse = "Folder in use";

        bool fileEdited = false;
        bool fileNotSaved = false;

        string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
       Environment.OSVersion.Platform == PlatformID.MacOSX)
? Environment.GetEnvironmentVariable("HOME")
: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

        string tempPath = Path.GetTempPath();


        string tempFolder;

        string contentFile;

        string impairedContentFile;
        string blindContentFile;

        string contentFileName = "Content.xhtml";

        string epubFolderName;

        DateTime lastSave;


        List<string> openTabs = new List<string>();
        List<ICSharpCode.AvalonEdit.TextEditor> openTextEditors = new List<ICSharpCode.AvalonEdit.TextEditor>();

        Dictionary<string, ICSharpCode.AvalonEdit.TextEditor> tabsToTextEditors = new Dictionary<string, TextEditor>();

        string accEpubFolderName = Path.Combine(Path.GetTempPath(), "AccessibleEPUB");

        GlobalHotKey.HotKeyManager hkm = new GlobalHotKey.HotKeyManager();

        string[] args;

        string origWordCountLabel;
        string origCharacterCountLabel;
        string origDocumentLanguageLabel;
        string origLastSavedLabel;


        /* Program startup */

        public Form1()
        {
            //string argss = "";

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());
            
            InitializeComponent();
            //foreach (string s in Environment.GetCommandLineArgs()) {
            //    argss = argss + s + " ";
            //}
            //MessageBox.Show(argss);
            // The issue with opening a file with parameters lies with Xpcom.Initialize("Firefox");
            //Xpcom.EnableProfileMonitoring = false;

            //args = Environment.GetCommandLineArgs();


            //if (args.Length > 1)
            //{            
            //    MessageBox.Show("ARG0: " + args[0]);
            //    MessageBox.Show("ARG1: " + args[1]);
            //}


            Xpcom.Initialize(Path.Combine(Application.StartupPath, "Firefox"));
                          
            //Xpcom.Initialize("Firefox");
           

            var hotKey = hkm.Register(System.Windows.Input.Key.S, System.Windows.Input.ModifierKeys.Control);
            //var globalReload = hkm.Register(System.Windows.Input.Key.None, System.Windows.Input.ModifierKeys.None);

            hkm.KeyPressed += keyPressSave;

            origWordCountLabel = wordCountLabel.Text;
            origCharacterCountLabel = characterCountLabel.Text;

            origDocumentLanguageLabel = documentLanguageLabel.Text;

            versionLabel.Text += String.Format("{0}.{1}." + Version.Build.ToString(),
                 Version.Major.ToString(), Version.Minor.ToString(), Version.MinorRevision.ToString());

            origLastSavedLabel = lastSavedLabel.Text;

          
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {
            filesTabControl.Padding = new System.Drawing.Point(21, 3);
            //iconsToolStrip.Visible = false;
            //editToolStrip.Visible = false;
            //menuBar.Visible = false;
            //editToolStrip.Visible = true;
            //iconsToolStrip.Visible = true;
            //menuBar.Visible = true;
            iconsToolStrip.SendToBack();
            editToolStrip.SendToBack();
            menuBar.Dock = DockStyle.Top;

            /* Steps needed to make the web browser editable */
            HTMLEditor.DocumentText = @"<html><body></body></html>"; //This will get our HTML editor ready, inserting common HTML blocks into the document

            doc = HTMLEditor.Document.DomDocument as IHTMLDocument2;

            doc.designMode = "On";                                  //Make the web 'browser' an editable HTML field


            /* Sets up web browser to have the newest version of internet explorer loaded. Only the newest ones support SVGs and advanced CSS features */
            int BrowserVer, RegVal;

            // get the installed IE version
            using (WebBrowser Wb = new WebBrowser())
                BrowserVer = Wb.Version.Major;

            // set the appropriate IE version
            if (BrowserVer >= 11)
                RegVal = 11001;
            else if (BrowserVer == 10)
                RegVal = 10001;
            else if (BrowserVer == 9)
                RegVal = 9999;
            else if (BrowserVer == 8)
                RegVal = 8888;
            else
                RegVal = 7000;

            // set the actual key
            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree))
                if (Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe") == null)
                    Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);


            /* Makes the editor and the preview split into two equal parts */
            int halfWidth = splitContainer2.Width / 2;
            splitContainer2.SplitterDistance = halfWidth;

            //versionLabel.Alignment = ToolStripItemAlignment.Right;
            versionToolStrip.Location = new Point(toolStripContainer1.BottomToolStripPanel.Width - versionToolStrip.Width, versionToolStrip.Location.Y);

            languageToolStrip.Location = new Point(toolStripContainer1.BottomToolStripPanel.Width / 2 - languageToolStrip.Width / 2, languageToolStrip.Location.Y);

            
        }

        /* Sets up the editor in the form of a WebBrowser when the window has finised loading */
        private void Form1_Shown(object sender, EventArgs e)
        {
            elementHost2.Child = codeEditor;
            
            IHTMLStyleSheet ss = doc.createStyleSheet("", 0);

            /* CSS of the initial editor */
            ss.cssText = @"html *
{
	font-family: ""Arial"", Helvetica, sans-serif !important;

        }
        p {
  font-size:16px;

word-wrap: break-word;
}

figure {
	padding: 2px;
	max-width : 95%;
    border: double 4px;
}

figcaption {
	word-wrap: break-word;
	max-width : 100%;
  font-size:16px;
}

img {
	max-width : 98%;
    margin: 5px
}


object {
  max-width : 100%; 
}

math {
  max-width : 100%;

}

table, th, td, tr, tbody {
      border-style: double;
    border-collapse: collapse;
    border-width:4px;
  text-align: center;
}

.transparent {
  display: none;
  color: transparent;
}

body {
	width: 100%;
	margin-left: 2px;
	margin-right: auto;
}

.math {

    display:none;
    height:0%;

}

.mathImpaired {

    display:none;
    height:0%;
}

.imageImpaired {
    display: none;
}

.imageOthers {
    max - width : 100 %;
    display: initial;
}


;"
;
            //splitContainer1.Panel1Collapsed = true;
            //splitContainer1.Panel1.Hide();

            /* Events of the editor document body. They cannot be added with GUI builder as it Document is only created after the window has been loaded. */
            HTMLEditor.Document.Body.KeyUp += new System.Windows.Forms.HtmlElementEventHandler(HTMLEditorBodyKeyUp);

            HTMLEditor.Document.Body.DoubleClick += new System.Windows.Forms.HtmlElementEventHandler(HTMLEditorDoubleClick);

            HTMLEditor.Document.Body.Click += new System.Windows.Forms.HtmlElementEventHandler(HTMLEditorClick);

            //HTMLEditor.Document.Body.MouseUp += new System.Windows.Forms.HtmlElementEventHandler(HTMLEditorBodyMouseUp);

            //HTMLEditor.Document.ExecCommand("FontName", false, "Arial");

            /* Sets up the drop down menus */
            InitHeadingsList();
            InitFontList();
            InitFontSizeList();


            /* The timer is required to refresh the preview every second or so */
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new System.EventHandler(timer_Tick);
            timer.Start();


            string[] args = Environment.GetCommandLineArgs();


            if (args.Length > 1)
            {
                parameterOpenFile(args[1]);              
            }
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void iconsToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{

        //}

        //private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        //{

        //}






        //private void tabPage1_Click(object sender, EventArgs e)
        //{

        //}

        /* Goes through the given path and return a node with all files as sub nodes. Subdirectories are recursively traversed. */
        private TreeNode TraverseDirectory(string path)
        {
            //int index = path.LastIndexOf('\\');
            string rhs = Path.GetFileName(path);
            //string rhs = path.Substring(index + 1);

            TreeNode result = new TreeNode(path);

            result.Text = rhs;

            foreach (var subdirectory in Directory.GetDirectories(path))
            {
                //Uri uri = new Uri(subdirectory);
                //string lastSegment = uri.Segments.Last();

                result.Nodes.Add(TraverseDirectory(subdirectory));


            }

            foreach (var file in Directory.GetFiles(path))
            {
                //int index2 = file.ToString().LastIndexOf('\\');
                //string rhs2 = file.ToString().Substring(index2 + 1);
                string rhs2 = Path.GetFileName(file.ToString());
                var r = result.Nodes.Add(file);
                r.Text = rhs2;
                //r.Text = path;

            }

            result.Expand();


            return result;
        }



        //private string GetRelativePath(string filespec, string folder)
        //{
        //    Uri pathUri = new Uri(filespec);
        //    // Folders must end in a slash
        //    if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
        //    {
        //        folder += Path.DirectorySeparatorChar;
        //    }
        //    Uri folderUri = new Uri(folder);
        //    return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        //}

        /* The next three methods handle what is done after a treeview element is clicked. */
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {


            //richTextBox1.Text = tempFolder + "\\" + e.Node.FullPath;
            //GeckoHtmlElement element = null;

            //var geckoDomElement = geckoWebBrowser1.Document.DocumentElement;
            //if (geckoDomElement is GeckoHtmlElement)
            //{
            //    element = (GeckoHtmlElement)geckoDomElement;
            //    var innerHtml = element.InnerHtml;
            //    richTextBox1.Text = innerHtml;
            //    geckoWebBrowser1.ViewSource();
            //}
            
           
            /* Gets the path of the file from the treeview. If a directory is selected nothing happens. */
            string absPath = Path.Combine(accEpubFolderName, e.Node.FullPath);
            string fileName = e.Node.FullPath;
            FileAttributes attr = File.GetAttributes(absPath);
            if (attr.HasFlag(FileAttributes.Directory))
            {
                return;
            }

            //treeView1.SelectedNode = null;
            //if (filesTabControl.Visible == false)
            //{
            //    openTab(absPath);
            //    return;
            //}

            /* Handles the various EPUB file types */
            if (openTabs == null || openTabs.Contains(fileName) == false)
            {

                if ((!fileName.EndsWith(".svg")) && (!fileName.EndsWith(".jpg")) && (!fileName.EndsWith(".png")))
                {
                    //TabPage myTabPage = new TabPage(e.Node.Text);
                    //myTabPage.Name = fileName;
                    //filesTabControl.TabPages.Add(myTabPage);

                    ////RichTextBox rtb = new RichTextBox();

                    //System.Windows.Forms.Integration.ElementHost host = new System.Windows.Forms.Integration.ElementHost();
                    //host.Dock = DockStyle.Fill;

                    //codeArea = new ICSharpCode.AvalonEdit.TextEditor();



                    ////host.Child = codeArea;
                    ////myTabPage.Controls.Add(host);
                 


                    ////myTabPage.Controls.Add(rtb);

                    ////rtb.Dock = System.Windows.Forms.DockStyle.Fill;
                    //openTabs.Add(fileName);

                    //openTextEditors.Add(codeArea);

                    //tabsToTextEditors.Add(fileName, codeArea);

                    //filesTabControl.SelectedTab = myTabPage;

                    //lastTab = currentTab;
                    //currentTab = fileName;
                }

                codeEditor.Save(currentEditorFile);
                currentEditorFile = absPath;
                openTab(absPath);




                //if (e.Node.Text.EndsWith(".xhtml") || e.Node.Text.EndsWith(".html"))
                //{
                //    geckoWebBrowser1.Navigate(absPath);
                //    splitContainer2.Panel1Collapsed = false;
                //    splitContainer2.Panel1.Show();

                //    splitContainer2.Panel2Collapsed = false;
                //    splitContainer2.Panel2.Show();
                //    //rtb.Text = File.ReadAllText(absPath);


                //    codeArea.Load(absPath);
                //    //codeArea.Text = File.ReadAllText(absPath);
                //    codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("HTML");

                //}

                //else if (e.Node.Text.EndsWith(".svg") || e.Node.Text.EndsWith(".jpg") || e.Node.Text.EndsWith(".png"))
                //{
                //    geckoWebBrowser1.Navigate(absPath);
                //    //splitContainer2.Panel1Collapsed = true;
                //    //splitContainer2.Panel1.Hide();

                //    splitContainer2.Panel2Collapsed = false;
                //    splitContainer2.Panel2.Show();


                //    //codeArea.Load(absPath);

                //    //ICSharpCode.AvalonEdit.Utils.FileReader.OpenFile(absPath);
                //}

                //else if (e.Node.Text.EndsWith(".css"))
                //{

                //    splitContainer2.Panel1Collapsed = false;
                //    splitContainer2.Panel1.Show();

                //    splitContainer2.Panel2Collapsed = true;
                //    splitContainer2.Panel2.Hide();

                //    codeArea.Load(absPath);
                //    //codeArea.Text = File.ReadAllText(absPath);
                //    codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("CSS");



                //}

                //else if (e.Node.Text.EndsWith(".js"))
                //{

                //    splitContainer2.Panel1Collapsed = false;
                //    splitContainer2.Panel1.Show();

                //    splitContainer2.Panel2Collapsed = true;
                //    splitContainer2.Panel2.Hide();
                //    codeArea.Text = File.ReadAllText(absPath);
                //    codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("JavaScript");



                //}

                //else if (e.Node.GetNodeCount(true) == 0)
                //{

                //    splitContainer2.Panel1Collapsed = false;
                //    splitContainer2.Panel1.Show();

                //    splitContainer2.Panel2Collapsed = true;
                //    splitContainer2.Panel2.Hide();
                //    codeArea.Text = File.ReadAllText(absPath);




                //}
            }

            //else
            //{
            //    /* If the file is already open in the code editor, then it just switches the tab. */
            //    foreach (TabPage tab in filesTabControl.TabPages)
            //    {
            //        if (tab.Name == fileName)
            //        {
            //            filesTabControl.SelectedTab = tab;
            //            lastTab = currentTab;
            //            currentTab = fileName;
            //            openTab(absPath);
            //        }
            //    }
            //}







            //webBrowser1.Navigate(filePath);
            //richTextBox1.Text = geckoWebBrowser1.Text;
        }

        /* The clicked header will have its HtmlElement found, and then is scrolled to. */
        private void headerTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string outerHtmlKey = e.Node.Name;
            foreach (HtmlElement el in HTMLEditor.Document.Body.Children)
            {
                if (outerHtmlKey == el.OuterHtml)
                {
                    el.ScrollIntoView(true);
                }
            }
        }

        /* The clicked figure will have its HtmlElement found, and then is scrolled to. */
        private void figureTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string outerHtmlKey = e.Node.Name;
            foreach (HtmlElement el in HTMLEditor.Document.Body.Children)
            {
                if (outerHtmlKey == el.OuterHtml)
                {
                    el.ScrollIntoView(true);
                }
            }
        }

        /* Creates a manifest section in the metadata file. */
        private void createManifest(string manifestFolderName)
        {
            string searchFolder = Path.Combine(manifestFolderName, "OEBPS");
            string manifestTagOpen = "<manifest>";
            string manifestTagClose = "</manifest>";

            string manifestContent = "";

            string metadata = File.ReadAllText(Path.Combine(Path.Combine(manifestFolderName, "OEBPS"), "content.opf"));

            int firstIndex = metadata.IndexOf(manifestTagOpen);
            int endIndex = metadata.IndexOf(manifestTagClose);

            string manifestHead = metadata.Substring(0, firstIndex);
            string manifestEnd = metadata.Substring(endIndex + manifestTagClose.Length);




            manifestContent = loopManifest(manifestContent, searchFolder, manifestFolderName);
            //foreach (var subdirectory in Directory.GetDirectories(searchFolder))
            //{
            //    //Uri uri = new Uri(subdirectory);
            //    //string lastSegment = uri.Segments.Last();


            string manifest = manifestHead + manifestTagOpen + "\n" + manifestContent + manifestTagClose + manifestEnd;

            File.WriteAllText(Path.Combine(Path.Combine(manifestFolderName, "OEBPS"), "content.opf"), manifest);


        }

        /* Updates the manifest section of the EPUB metadata file to reflect the changes */
        private string loopManifest(string manifestContentParameter, string searchFolder, string manifestFolderName)
        {
            string initialFolder = Path.Combine(manifestFolderName, "OEBPS");
            string manifestContent = manifestContentParameter;
            string navFileName = "nav.xhtml";
            string tocNcxFileName = "toc.ncx";

            foreach (var subdirectory in Directory.GetDirectories(searchFolder))
            {
                //Uri uri = new Uri(subdirectory);
                //string lastSegment = uri.Segments.Last();
                manifestContent = loopManifest(manifestContent, subdirectory.ToString(), manifestFolderName);



            }


            foreach (var file in Directory.GetFiles(searchFolder))
            {
                //int index2 = file.ToString().LastIndexOf('\\');
                //string rhs2 = file.ToString().Substring(index2 + 1);

                string fullFileName = file.ToString();
                string shortFileName = Path.GetFileName(file.ToString());
                string mediaType = "";
                // <item id="navid" href="Text/nav.xhtml" media-type="application/xhtml+xml" properties="nav"/>

                if (fullFileName.EndsWith(".xhtml"))
                {
                    mediaType = "application/xhtml+xml";
                }
                else if (fullFileName.EndsWith(".css"))
                {
                    mediaType = "text/css";
                }
                else if (fullFileName.EndsWith(".js"))
                {
                    mediaType = "application/javascript";
                }
                else if (fullFileName.EndsWith(".svg"))
                {
                    mediaType = "image/svg+xml";
                }
                else if (fullFileName.EndsWith(".jpg"))
                {
                    mediaType = "image/jpeg";
                }
                else if (fullFileName.EndsWith(".png"))
                {
                    mediaType = "image/png";
                }
                else if (fullFileName.EndsWith(".ncx"))
                {
                    mediaType = "application/x-dtbncx+xml";
                }

                //Console.WriteLine(fullFileName.Substring(initialFolder.Length + 1));
                string manifestFileName = fullFileName.Substring(initialFolder.Length + 1).Replace("\\","/");

                if (shortFileName == navFileName)
                {
                    manifestContent += "\t<item id=\"navid\" href=\"" + manifestFileName + "\" media-type=\"" + mediaType + "\" properties=\"nav\"/>\n";
                }          
                else if (shortFileName == tocNcxFileName)
                {
                    //<item id="toc.ncx" href="toc.ncx" media-type="application/x-dtbncx+xml"/>
                    manifestContent += "\t<item id=\"ncx\" href=\"" + manifestFileName + "\" media-type=\"" + "application/x-dtbncx+xml" + "\"/>\n";
                }
                else if (!fullFileName.EndsWith(".opf"))
                {
                    manifestContent += "\t<item id=\"" + shortFileName + "\" href=\"" + manifestFileName + "\" media-type=\"" + mediaType + "\"/>\n";
                }

                //r.Text = searchFolder;

            }


            return manifestContent;
        }

        //public void updateManifest()
        //{
        //    string searchFolder = Path.Combine(epubFolderName, "OEBPS");
        //    string manifestTagOpen = "<manifest>";
        //    string manifestTagClose = "</manifest>";

        //    string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"));

        //    int firstIndex = metadata.IndexOf(manifestTagOpen);
        //    int endIndex = metadata.IndexOf(manifestTagClose);

        //    string manifestHead = metadata.Substring(0, firstIndex);

        //    string manifestBody = metadata.Substring(firstIndex, endIndex - firstIndex);

        //    string manifestEnd = metadata.Substring(endIndex + manifestTagClose.Length);

        //    string jsManifestIdRef = "<item id=\"Content.xhtml\" href=\"Text/Content.xhtml\" media-type=\"application/xhtml+xml\" properties=\"script\"/>";
        //    string cssManifestIdRef = "<item id=\"Content.xhtml\" href=\"Text/Content.xhtml\" media-type=\"application/xhtml+xml\"/>";

        //    string jsMathml = "<item id=\"Content.xhtml\" href=\"Text/Content.xhtml\" media-type=\"application/xhtml+xml\" properties=\"script mathml\"/>";
        //    string cssMathml = "<item id=\"Content.xhtml\" href=\"Text/Content.xhtml\" media-type=\"application/xhtml+xml\" properties=\"mathml\"/>";

        //    string newJsIdRef = jsManifestIdRef.Replace("Content.xhtml", Path.GetFileName(contentFile));
        //    string newCssIdRef = cssManifestIdRef.Replace("Content.xhtml", Path.GetFileName(contentFile));

        //    string newJsMathml = jsMathml.Replace("Content.xhtml", Path.GetFileName(contentFile));
        //    string newCssMathml = cssMathml.Replace("Content.xhtml", Path.GetFileName(contentFile));

        //    metadata = metadata.Replace(newJsIdRef, newJsMathml);
        //    metadata = metadata.Replace(newCssIdRef, newCssMathml);


        //    File.WriteAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"), metadata);

        //    mathmlManifestupdated = true;
        //}


        /* Opens a file according to its file type. */
        private void openTab(string absPath)
        {
            if (absPath.EndsWith(".xhtml") || absPath.EndsWith(".html"))
            {
                //geckoWebBrowser2.Navigate("about:blank");
                //geckoWebBrowser3.Navigate("about:blank");

                //File.Delete(impairedContentFile);
                //File.Delete(blindContentFile);

                contentFile = absPath;

                if (mode == (int)fileMode.singleFileJs && contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml")))
                {
                    impairedContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile));
                    blindContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile));

                    string cssString = "style.css";
                    string impCssString = "impaired.css";
                    string bliCssString = "blind.css";

                    string impFile = File.ReadAllText(contentFile);
                    string bliFile = impFile;

                    impFile = impFile.Replace(cssString, impCssString);
                    bliFile = bliFile.Replace(cssString, bliCssString);

                    File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile)), impFile);
                    File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile)), bliFile);

                    geckoWebBrowser2.Navigate(impairedContentFile);
                    geckoWebBrowser3.Navigate(blindContentFile);
                }




                //if (geckoWebBrowser1.Url.ToString() == absPath)
                //{

                //    geckoWebBrowser1.Reload();
                //    geckoWebBrowser2.Reload();
                //    geckoWebBrowser3.Reload();
                //    geckoWebBrowser4.Reload();
                //}
                //else
                //{
                geckoWebBrowser1.Navigate(contentFile);
               
                geckoWebBrowser4.Navigate(contentFile);
                //}




                //splitContainer2.Panel1Collapsed = false;
                //splitContainer2.Panel1.Show();

                //splitContainer2.Panel2Collapsed = false;
                //splitContainer2.Panel2.Show();
                //rtb.Text = File.ReadAllText(absPath);

                //if (filesTabControl.Visible == true)
                //{


                //codeArea.Load(absPath);
                ////codeArea.Text = File.ReadAllText(absPath);
                //codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("HTML");

                codeEditor.Load(absPath);
                codeEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("HTML");

                //}

                //else
                //{


                //if (mode == (int)fileMode.singleFileJs)
                //{
                //    //if (contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml")))
                //    //{
                //        htmlToWysiwyg();
                //    //}
                //}

                //else
                //{
                //    htmlToWysiwyg();
                //}

                htmlToWysiwyg();

                //}

            }

            else if (absPath.EndsWith(".svg") || absPath.EndsWith(".jpg") || absPath.EndsWith(".png"))
            {
                geckoWebBrowser1.Navigate(absPath);
                geckoWebBrowser2.Navigate(absPath);
                geckoWebBrowser3.Navigate(absPath);
                geckoWebBrowser4.Navigate(absPath);
                //splitContainer2.Panel1Collapsed = true;
                //splitContainer2.Panel1.Hide();

                //splitContainer2.Panel2Collapsed = false;
                //splitContainer2.Panel2.Show();



                //codeArea.Load(absPath);

                //ICSharpCode.AvalonEdit.Utils.FileReader.OpenFile(absPath);
                return;

            }

            else if (absPath.EndsWith(".css"))
            {

                //splitContainer2.Panel1Collapsed = false;
                //splitContainer2.Panel1.Show();

                ////splitContainer2.Panel2Collapsed = true;
                ////splitContainer2.Panel2.Hide();

                //codeArea.Load(absPath);
                ////codeArea.Text = File.ReadAllText(absPath);
                //codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("CSS");

                codeEditor.Load(absPath);
                codeEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("CSS");



            }

            else if (absPath.EndsWith(".js"))
            {

                //splitContainer2.Panel1Collapsed = false;
                //splitContainer2.Panel1.Show();

                ////splitContainer2.Panel2Collapsed = true;
                ////splitContainer2.Panel2.Hide();

                //codeArea.Load(absPath);
                ////codeArea.Text = File.ReadAllText(absPath);
                //codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("JavaScript");


                codeEditor.Load(absPath);
                codeEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("JavaScript");
            }


            //else if (e.Node.GetNodeCount(true) == 0)
            //{

            //    splitContainer2.Panel1Collapsed = false;
            //    splitContainer2.Panel1.Show();

            //    splitContainer2.Panel2Collapsed = true;
            //    splitContainer2.Panel2.Hide();
            //    codeArea.Text = File.ReadAllText(absPath);

            //}

            else
            {

                //splitContainer2.Panel1Collapsed = false;
                //splitContainer2.Panel1.Show();

                //splitContainer2.Panel2Collapsed = true;
                //splitContainer2.Panel2.Hide();

                //codeArea.Load(absPath);
                //codeArea.Text = File.ReadAllText(absPath);

                codeEditor.Load(absPath);

            }



        }

        //private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        //{

        //}

        //void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    //try
        //    //{
        //    //    // Look for a file extension.
        //    //    if (e.Node.Text.Contains("."))
        //    //        System.Diagnostics.Process.Start(@"c:\" + e.Node.Text);
        //    //}
        //    //// If the file is not found, handle the exception and inform the user.
        //    //catch (System.ComponentModel.Win32Exception)
        //    //{
        //    //    MessageBox.Show("File not found.");
        //    //}

        //    geckoWebBrowser1.Navigate(tempFolder + "\\" + e.Node.FullPath);
        //    //richTextBox1.Text = tempFolder + "\\" + e.Node.FullPath;
        //    richTextBox1.Text = geckoWebBrowser1.Text;


        //}

        public void parameterOpenFile(string parameter)
        {          

            string epubFileName;       // Formerly tempFile
            string fileName = "";      // Formerly tempFile2
            string zipFileName = "";     // Formerly tempFile3 


            /* Checks if a file is open and asks if it should be saved before opening a new file. */
            if (containsFile == true || fileNotSaved == true)
            {
                //DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Save the file before exiting?", "Save changes", MessageBoxButtons.YesNoCancel);
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(Resource_MessageBox.saveLeavingContent, Resource_MessageBox.saveLeavingTitle, MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    saveFile();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }


            if (parameter.EndsWith(".epub"))
            {
                closeFile(new object(), new EventArgs());

                containsFile = true;
                string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                //tempFolder = Path.Combine(tempPath, "AccessibleEPUB");
                DirectoryInfo accEpubFolder = Directory.CreateDirectory(accEpubFolderName);

                //string accEpubFolderName = accEpubFolder.Name;

                System.IO.DirectoryInfo di = new DirectoryInfo(accEpubFolderName);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                int count = 0;

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    bool isInUse = false;
                    do
                    {
                        try
                        {
                            isInUse = false;
                            dir.Delete(true);
                        }
                        catch (IOException excep)
                        {
                            count++;
                            if (count == 3)
                            {
                                //MessageBox.Show("Temp folder is still in use. After pressing OK, the file opening process will stop.", "Folder still in use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(Resource_MessageBox.tempInUseLongContent, Resource_MessageBox.tempInUseLongTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            isInUse = true;
                            //MessageBox.Show("Folder in use. Please leave and then press OK.", "Folder in use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(Resource_MessageBox.tempInUseContent, Resource_MessageBox.tempInUseTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    } while (isInUse);

                }


                /* Checks if the Accessible EPUB temp folder is not in use */
                while (di.GetDirectories().Length != 0 || di.GetFiles().Length != 0)
                {
                    //var result = MessageBox.Show("Could not delete all files in temp folder.", "Unable to delete files in temp folder", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    var result = MessageBox.Show(Resource_MessageBox.notDeleteTempContent, Resource_MessageBox.notDeleteTempTitle, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Retry)
                    {
                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                    }
                    else
                    {
                        return;
                    }
                }



                //treeView1.Nodes.Clear();
                //richTextBox1.Clear();
                //geckoWebBrowser1.Navigate("");

                epubFileName = Path.Combine(accEpubFolderName, Path.GetFileName(parameter));
                target = parameter;
                File.Copy(parameter, epubFileName, true);


                if (epubFileName.Contains('.'))
                {
                    fileName = epubFileName.Substring(0, epubFileName.LastIndexOf('.'));
                    epubFolderName = fileName;
                    //contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), contentFileName);
                }


                zipFileName = fileName + ".zip";


                //using (File.Create(epubFileName)) ;
                //using (File.Create(tempFile2)) ;
                System.IO.File.Move(epubFileName, zipFileName);

                System.IO.Compression.ZipFile.ExtractToDirectory(zipFileName, fileName);

                /*FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() != DialogResult.OK) { return; }
                dialog.SelectedPath = tempFolder;*/
                this.treeView1.Nodes.Add(TraverseDirectory(fileName));

                //this.treeView1.CollapseAll();
                //foreach (TreeNode node in this.treeView1.Nodes)
                //{
                //    node.Collapse();
                //}



                //webBrowser1.Navigate(tempFile2 + "\\OEBPS\\Text\\Content.xhtml");
                //richTextBox1.Text = webBrowser1.DocumentText;

                //richTextBox1.LoadFile(tempFile2 + "\\OEBPS\\Styles\\style.css");



            }
            else
            {
                MessageBox.Show("Accessible EPUB cannot open this file", "Invalid file");
                return;
            }

            HTMLEditor.Visible = true;

            if (File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml")))
            {
                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml");
            }
            else
            {
                mode = (int)fileMode.none;
                string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"));
                string firstItem = "<itemref idref=\"";
                int firstIndex = metadata.IndexOf(firstItem) + firstItem.Length;
                string sub = metadata.Substring(firstIndex);
                int endIndex = sub.IndexOf("\"");
                string itemName = sub.Substring(0, endIndex);
                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), itemName);
            }


            determineLanguage();

            string body = File.ReadAllText(contentFile);

            string imp = "<div style=\"padding:none\" id=\"impaired\" class=\"impaired\">\n<!--StartOfImpairedSection-->\n";

            if (body.Contains(imp))
            {
                mode = (int)fileMode.singleFileCss;
            }
            else if (File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "VersionChanger.xhtml")))
            {
                mode = (int)fileMode.singleFileJs;
            }
            else
            {
                mode = (int)fileMode.none;
            }

            if (mode == (int)fileMode.singleFileCss)
            {
                TabControl1.Visible = false;
                geckoWebBrowser4.Visible = true;
            }
            else if (mode == (int)fileMode.singleFileJs)
            {
                TabControl1.Visible = true;
                geckoWebBrowser4.Visible = false;
            }
            else
            {
                TabControl1.Visible = false;
                geckoWebBrowser4.Visible = true;
            }



            //initializeHTMLeditor();

            if (mode == (int)fileMode.singleFileJs && contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml")))
            {


                string cssString = "style.css";
                string impCssString = "impaired.css";
                string bliCssString = "blind.css";

                string impFile = File.ReadAllText(contentFile);
                string bliFile = impFile;

                impFile = impFile.Replace(cssString, impCssString);
                bliFile = bliFile.Replace(cssString, bliCssString);

                File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile)), impFile);
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile)), bliFile);

                impairedContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile));
                blindContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile));

                geckoWebBrowser1.Navigate(contentFile);
                geckoWebBrowser2.Navigate(impairedContentFile);
                geckoWebBrowser3.Navigate(blindContentFile);
            }



            geckoWebBrowser4.Navigate(contentFile);

            htmlToWysiwyg();

            if (mode == (int)fileMode.singleFileJs)
            {
                string visibleCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "visible.css");
                string impairedCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "impaired.css");
                string blindCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "blind.css");

                //geckoWebBrowser1.Document.Head.Style.CssText = File.ReadAllText(visibleCss);
                //geckoWebBrowser2.Document.Head.Style.CssText = File.ReadAllText(impairedCss);
                //geckoWebBrowser3.Document.Head.Style.CssText = File.ReadAllText(blindCss);
            }

            showToolStrips();
            //splitContainer1.Panel1Collapsed = false;
            //splitContainer1.Panel1.Show();
            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();

            splashScreenPanel.Visible = false;

            TabPage myTabPage = new TabPage(Path.GetFileName(contentFile));

            string tabPageName = contentFile.Substring(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(contentFile)))).Length + 1);
            //Console.WriteLine(contentFile.Substring(Path.GetDirectoryName(Path.GetDirectoryName(contentFile)).Length));
            myTabPage.Name = tabPageName;
            filesTabControl.TabPages.Add(myTabPage);



            //RichTextBox rtb = new RichTextBox();

            //System.Windows.Forms.Integration.ElementHost host = new System.Windows.Forms.Integration.ElementHost();
            //host.Dock = DockStyle.Fill;

            //codeArea = new ICSharpCode.AvalonEdit.TextEditor();



            //host.Child = codeArea;
            //myTabPage.Controls.Add(host);


            //myTabPage.Controls.Add(rtb);

            //rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            //openTabs.Add(tabPageName);

            //openTextEditors.Add(codeArea);

            //tabsToTextEditors.Add(tabPageName, codeArea);

            //filesTabControl.SelectedTab = myTabPage;
            //currentTab = tabPageName;

            currentEditorFile = contentFile;
            openTab(contentFile);

            HTMLEditor.Focus();

            this.Text = Path.GetFileName(target) + " - " + accessibleEpubFormText;

            documentLanguageLabel.Text = origDocumentLanguageLabel + language;

            updateHeaderList();

            splitContainer1.Panel1Collapsed = false;
            elementTabControl.Visible = true;
            treeView1.Visible = false;

            HTMLEditor.Document.Focus();
            //openTab(contentFile);
        }


        /* Opens a EPUB file and sets up the view, editor, and preview */
        private void openFile(object sender, EventArgs e)
        {
           

            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = homePath;
            openFileDialog1.Filter = "EPUB|*.epub|All Files|*.*";


            string epubFileName;       // Formerly tempFile
            string fileName = "";      // Formerly tempFile2
            string zipFileName = "";     // Formerly tempFile3 


            /* Checks if a file is open and asks if it should be saved before opening a new file. */
            if (containsFile == true || fileNotSaved == true)
            {
                //DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Save the file before exiting?", "Save changes", MessageBoxButtons.YesNoCancel);
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(Resource_MessageBox.saveLeavingContent, Resource_MessageBox.saveLeavingTitle, MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    saveFile();
                }
                else if (dialogResult == DialogResult.No)
                {

                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }

        
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!openFileDialog1.FileName.EndsWith(".epub")){
                    MessageBox.Show(Resource_MessageBox.notEpubContent, Resource_MessageBox.notEpubTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                closeFile(sender, e);

                containsFile = true;
                string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                //tempFolder = Path.Combine(tempPath, "AccessibleEPUB");
                DirectoryInfo accEpubFolder = Directory.CreateDirectory(accEpubFolderName);

                //string accEpubFolderName = accEpubFolder.Name;

                System.IO.DirectoryInfo di = new DirectoryInfo(accEpubFolderName);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                int count = 0;

                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    bool isInUse = false;
                    do
                    {
                        try
                        {
                            isInUse = false;
                            dir.Delete(true);
                        }
                        catch (IOException excep)
                        {
                            count++;
                            if (count == 3)
                            {
                                //MessageBox.Show("Temp folder is still in use. After pressing OK, the file opening process will stop.", "Folder still in use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                MessageBox.Show(Resource_MessageBox.tempInUseLongContent, Resource_MessageBox.tempInUseLongTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            isInUse = true;
                            //MessageBox.Show("Folder in use. Please leave and then press OK.", "Folder in use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(Resource_MessageBox.tempInUseContent, Resource_MessageBox.tempInUseTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    } while (isInUse);

                }


                /* Checks if the Accessible EPUB temp folder is not in use */
                while (di.GetDirectories().Length != 0 || di.GetFiles().Length != 0)
                {
                    //var result = MessageBox.Show("Could not delete all files in temp folder.", "Unable to delete files in temp folder", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    var result = MessageBox.Show(Resource_MessageBox.notDeleteTempContent, Resource_MessageBox.notDeleteTempTitle, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Retry)
                    {
                        foreach (FileInfo file in di.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dir in di.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                    }
                    else
                    {
                        return;
                    }
                }



                //treeView1.Nodes.Clear();
                //richTextBox1.Clear();
                //geckoWebBrowser1.Navigate("");

                epubFileName = Path.Combine(accEpubFolderName, Path.GetFileName(openFileDialog1.FileName));
                target = openFileDialog1.FileName;
                File.Copy(openFileDialog1.FileName, epubFileName, true);


                if (epubFileName.Contains('.'))
                {
                    fileName = epubFileName.Substring(0, epubFileName.LastIndexOf('.'));
                    epubFolderName = fileName;
                    //contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), contentFileName);
                }


                zipFileName = fileName + ".zip";

               
                //using (File.Create(epubFileName)) ;
                //using (File.Create(tempFile2)) ;
                System.IO.File.Move(epubFileName, zipFileName);

                System.IO.Compression.ZipFile.ExtractToDirectory(zipFileName, fileName);

                /*FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() != DialogResult.OK) { return; }
                dialog.SelectedPath = tempFolder;*/
                this.treeView1.Nodes.Add(TraverseDirectory(fileName));

                //this.treeView1.CollapseAll();
                //foreach (TreeNode node in this.treeView1.Nodes)
                //{
                //    node.Collapse();
                //}



                //webBrowser1.Navigate(tempFile2 + "\\OEBPS\\Text\\Content.xhtml");
                //richTextBox1.Text = webBrowser1.DocumentText;

                //richTextBox1.LoadFile(tempFile2 + "\\OEBPS\\Styles\\style.css");



            }
            else
            {
                return;
            }

            HTMLEditor.Visible = true;

            if (File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml")))
            {
                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml");
            }
            else
            {
                mode = (int)fileMode.none;
                string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"));
                string firstItem = "<itemref idref=\"";
                int firstIndex = metadata.IndexOf(firstItem) + firstItem.Length;
                string sub = metadata.Substring(firstIndex);
                int endIndex = sub.IndexOf("\"");
                string itemName = sub.Substring(0, endIndex);
                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), itemName);
            }


            determineLanguage();

            string body = File.ReadAllText(contentFile);

            string imp = "<div style=\"padding:none\" id=\"impaired\" class=\"impaired\">\n<!--StartOfImpairedSection-->\n";

            if (body.Contains(imp))
            {
                mode = (int)fileMode.singleFileCss;
            }
            else if (File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "VersionChanger.xhtml")))
            {
                mode = (int)fileMode.singleFileJs;
            }
            else
            {
                mode = (int)fileMode.none;
            }

            if (mode == (int)fileMode.singleFileCss)
            {
                TabControl1.Visible = false;
                geckoWebBrowser4.Visible = true;
            }
            else if (mode == (int) fileMode.singleFileJs)
            {
                TabControl1.Visible = true;
                geckoWebBrowser4.Visible = false;
            }
            else
            {
                TabControl1.Visible = false;
                geckoWebBrowser4.Visible = true;
            }



            //initializeHTMLeditor();

            if (mode == (int)fileMode.singleFileJs && contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml")))
            {
                

                string cssString = "style.css";
                string impCssString = "impaired.css";
                string bliCssString = "blind.css";

                string impFile = File.ReadAllText(contentFile);
                string bliFile = impFile;

                impFile = impFile.Replace(cssString, impCssString);
                bliFile = bliFile.Replace(cssString, bliCssString);

                File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile)), impFile);
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile)), bliFile);

                impairedContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile));
                blindContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile));

                geckoWebBrowser1.Navigate(contentFile);
                geckoWebBrowser2.Navigate(impairedContentFile);
                geckoWebBrowser3.Navigate(blindContentFile);
            }

          
            
            geckoWebBrowser4.Navigate(contentFile);

            htmlToWysiwyg();

            if (mode == (int)fileMode.singleFileJs)
            {
                string visibleCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "visible.css");
                string impairedCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "impaired.css");
                string blindCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "blind.css");

                //geckoWebBrowser1.Document.Head.Style.CssText = File.ReadAllText(visibleCss);
                //geckoWebBrowser2.Document.Head.Style.CssText = File.ReadAllText(impairedCss);
                //geckoWebBrowser3.Document.Head.Style.CssText = File.ReadAllText(blindCss);
            }

            showToolStrips();
            //splitContainer1.Panel1Collapsed = false;
            //splitContainer1.Panel1.Show();
            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();

            splashScreenPanel.Visible = false;

            TabPage myTabPage = new TabPage(Path.GetFileName(contentFile));

            //string tabPageName = contentFile.Substring(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(contentFile)))).Length + 1);
            ////Console.WriteLine(contentFile.Substring(Path.GetDirectoryName(Path.GetDirectoryName(contentFile)).Length));
            //myTabPage.Name = tabPageName;
            //filesTabControl.TabPages.Add(myTabPage);

            ////RichTextBox rtb = new RichTextBox();

            //System.Windows.Forms.Integration.ElementHost host = new System.Windows.Forms.Integration.ElementHost();
            //host.Dock = DockStyle.Fill;

            //codeArea = new ICSharpCode.AvalonEdit.TextEditor();



            //host.Child = codeArea;
            //myTabPage.Controls.Add(host);


            ////myTabPage.Controls.Add(rtb);

            ////rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            //openTabs.Add(tabPageName);

            //openTextEditors.Add(codeArea);

            //tabsToTextEditors.Add(tabPageName, codeArea);

            //filesTabControl.SelectedTab = myTabPage;
            //currentTab = tabPageName;

            currentEditorFile = contentFile;
            openTab(contentFile);

            HTMLEditor.Focus();

            this.Text = Path.GetFileName(target) + " - " + accessibleEpubFormText;

            documentLanguageLabel.Text = origDocumentLanguageLabel + language;

            updateHeaderList();

            splitContainer1.Panel1Collapsed = false;
            elementTabControl.Visible = true;
            treeView1.Visible = false;

            HTMLEditor.Document.Focus();
            //openTab(contentFile);
        }

        //private void InitColors()
        //{

        //    TextArea.SetSelectionBackColor(true, IntToColor(0x000000));
        //    TextArea.SetSelectionForeColor(true, IntToColor(0xFFFFFF));

        //}

        //private void InitSyntaxColoring()
        //{

        //    // Configure the default style
        //    TextArea.StyleResetDefault();
        //    TextArea.Styles[Style.Default].Font = "Consolas";
        //    TextArea.Styles[Style.Default].Size = 10;
        //    TextArea.Styles[Style.Default].BackColor = IntToColor(0xFFFFFF);
        //    TextArea.Styles[Style.Default].ForeColor = IntToColor(0x000000);
        //    TextArea.StyleClearAll();

        //    TextArea.Styles[Style.Html.Number].ForeColor = IntToColor(0xFFFF00);
        //    TextArea.Styles[Style.Html.Tag].ForeColor = Color.Purple;
        //    TextArea.Styles[Style.Html.TagEnd].ForeColor = Color.Blue;
        //    //TextArea.Styles[Style.Html.TagUnknown].ForeColor = Color.Green;
        //    TextArea.Styles[Style.Html.Other].ForeColor = Color.Orange;
        //    TextArea.Styles[Style.Html.Attribute].ForeColor = Color.Red;
        //    TextArea.Styles[Style.Html.Comment].ForeColor = Color.Green;

        //    TextArea.Lexer = Lexer.Html;



        //}

       



        /* Closes the current file and resets the view to the initial one. */
        private void closeFile(object sender, EventArgs e)
        {
            splitContainer1.Panel1Collapsed = true;
          
            filesTabControl.TabPages.Clear();
            treeView1.Nodes.Clear();
            openTabs.Clear();
            openTextEditors.Clear();
            tabsToTextEditors.Clear();

            containsFile = false;

            HTMLEditor.Document.Body.InnerHtml = "";
            geckoWebBrowser1.Navigate("about:blank");
            geckoWebBrowser2.Navigate("about:blank");
            geckoWebBrowser3.Navigate("about:blank");
            geckoWebBrowser4.Navigate("about:blank");
            splitContainer2.Panel1Collapsed = false;
            splitContainer2.Panel1.Show();

            splitContainer2.Panel2Collapsed = true;
            splitContainer2.Panel2.Hide();

            splashScreenPanel.Visible = true;
            splashScreenPanel.BringToFront();

            hideToolStrips();

            this.Text = accessibleEpubFormText;

            wordCountLabel.Text = origWordCountLabel;
            characterCountLabel.Text = origCharacterCountLabel;

            documentLanguageLabel.Text = origDocumentLanguageLabel;
        }




        public void setMode(int modeNew)
        {
            mode = modeNew;
        }

        public void setAuthor(string authorNew)
        {
            author = authorNew;
        }

        public void setTitle(string titleNew)
        {
            title = titleNew;
        }

        public void setLanguage(string languageNew)
        {
            language = languageNew;
        }

        public void setNewFileCorrect(bool newFileCorrectNew)
        {
            newFileCorrect = newFileCorrectNew;
        }

        public void setPublisher(string publisherNew)
        {
            publisher = publisherNew;
        }



        private void newSingleFile(object sender, EventArgs e)
        {

            contentFileName = "Content.xhtml";

            //tempFolder = Path.Combine(tempPath, "AccessibleEPUB");


            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "EPUB|*.epub";
            saveFileDialog1.Title = "Create a new EPUB File";
            saveFileDialog1.InitialDirectory = homePath;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
            {
                return;
            }



            NewFileDialogBox nfd = new NewFileDialogBox(this);
            nfd.ShowDialog();



            if (newFileCorrect == false)
            {
                return;
            }

            if (saveFileDialog1.CheckFileExists)
            {
                File.Delete(saveFileDialog1.FileName);
            }

            closeFile(sender, e);

            containsFile = true;
            HTMLEditor.Visible = true;
            HTMLEditor.DocumentText = @"<html><body></body></html>";

            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();

            splashScreenPanel.Visible = false;
 

            target = saveFileDialog1.FileName;
            targetFolder = Path.GetDirectoryName(target);


            
            //DirectoryDelete(accEpubFolderName);

            DirectoryInfo accEpubFolder = Directory.CreateDirectory(accEpubFolderName);

       
            //string accEpubFolderName = accEpubFolder.Name;

            System.IO.DirectoryInfo di = new DirectoryInfo(accEpubFolderName);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            int count = 0;



            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                bool isInUse = false;
                do
                {
                    try
                    {
                        isInUse = false;
                        dir.Delete(true);
                    }
                    catch (IOException excep)
                    {
                        count++;
                        if (count == 3)
                        {
                            
                            //MessageBox.Show(tempFolderStillInUseLong, tempFolderStillInUse, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            MessageBox.Show(Resource_MessageBox.tempInUseLongContent, Resource_MessageBox.tempInUseLongTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        isInUse = true;
                        //MessageBox.Show(tempFolderInUseLong, tempFolderInUse, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show(Resource_MessageBox.tempInUseContent, Resource_MessageBox.tempInUseTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                } while (isInUse);

            }
           
            if (mode == (int)fileMode.singleFileCss)
            {
                //CloneDirectory(initialPath + "\\EmptyFiles\\empty_Single_File", accEpubFolderName);
                string emptySingleFileZip = Path.Combine("EmptyFiles", "SingleFile", "empty_Single_File.zip");
                string emptySingleFileEpub = Path.Combine("EmptyFiles", "SingleFile", "empty_Single_File.epub");
                File.Copy(Path.Combine(initialPath, emptySingleFileZip), Path.Combine(accEpubFolderName, "empty_Single_File.zip"), true);


                //CloneDirectory(initialPath + "\\EmptyFiles\\empty_Single_File", targetFolder);

                File.Copy(Path.Combine(initialPath, emptySingleFileEpub), target, true);

                //System.IO.Compression.ZipFile.CreateFromDirectory(targetFolder + "\\empty_Single_File", targetFolder + "\\empty_Single_File.zip");


                //File.Move(targetFolder + "\\empty_Single_File.zip", target);


                //Directory.Move(targetFolder + "\\empty_Single_File", targetFolder + "\\" + Path.GetFileName(target));

                //File.Copy(initialPath + "\\EmptyFiles\\empty_Single_File.zip", targetFolder);
                //File.Move(targetFolder + "\\empty_Single_File.zip", target)

                //target = accEpubFolderName + "\\" + IInputBox.Show("What should be the name of the EPUB file?", "New File Name" ).ToString();
                //System.IO.Compression.ZipFile.ExtractToDirectory(accEpubFolderName + "\\empty_Single_File.zip", accEpubFolderName + "\\" + Path.GetFileName(target));
                //Directory.Move(accEpubFolderName + "\\empty_Single_File", accEpubFolderName + Path.GetFileName(target));

                string epubFileName;       // Formerly tempFile
                string fileName = "";      // Formerly tempFile2
                string zipFileName = "";     // Formerly tempFile3 



                ////treeView1.Nodes.Clear();
                ////richTextBox1.Clear();
                ////geckoWebBrowser1.Navigate("");
                epubFileName = Path.Combine(accEpubFolderName, Path.GetFileName(target));



                if (epubFileName.Contains('.'))
                {
                    fileName = epubFileName.Substring(0, epubFileName.LastIndexOf('.'));
                    epubFolderName = fileName;
                }

                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), contentFileName);


                System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(accEpubFolderName, "empty_Single_File.zip"), fileName);


                zipFileName = fileName + ".zip";

                File.Delete(Path.Combine(accEpubFolderName + "empty_Single_File.zip"));
            }
            else if (mode == (int)fileMode.singleFileJs)
            {
                string setPath = Path.Combine(Path.Combine(Path.Combine("", "EmptyFiles"), "JsVersionChanger"), "emptyJsFile");

                //CloneDirectory(initialPath + "\\EmptyFiles\\empty_Single_File", accEpubFolderName);

                File.Copy(Path.Combine(initialPath, setPath + ".zip"), Path.Combine(accEpubFolderName, "empty_Single_File.zip"), true);


                //CloneDirectory(initialPath + "\\EmptyFiles\\empty_Single_File", targetFolder);

                File.Copy(Path.Combine(initialPath, setPath + ".epub"), target, true);

                //System.IO.Compression.ZipFile.CreateFromDirectory(targetFolder + "\\empty_Single_File", targetFolder + "\\empty_Single_File.zip");


                //File.Move(targetFolder + "\\empty_Single_File.zip", target);


                //Directory.Move(targetFolder + "\\empty_Single_File", targetFolder + "\\" + Path.GetFileName(target));

                //File.Copy(initialPath + "\\EmptyFiles\\empty_Single_File.zip", targetFolder);
                //File.Move(targetFolder + "\\empty_Single_File.zip", target)

                //target = accEpubFolderName + "\\" + IInputBox.Show("What should be the name of the EPUB file?", "New File Name" ).ToString();
                //System.IO.Compression.ZipFile.ExtractToDirectory(accEpubFolderName + "\\empty_Single_File.zip", accEpubFolderName + "\\" + Path.GetFileName(target));
                //Directory.Move(accEpubFolderName + "\\empty_Single_File", accEpubFolderName + Path.GetFileName(target));

                string epubFileName;       // Formerly tempFile
                string fileName = "";      // Formerly tempFile2
                string zipFileName = "";     // Formerly tempFile3 



                ////treeView1.Nodes.Clear();
                ////richTextBox1.Clear();
                ////geckoWebBrowser1.Navigate("");
                epubFileName = Path.Combine(accEpubFolderName, Path.GetFileName(target));



                if (epubFileName.Contains('.'))
                {
                    fileName = epubFileName.Substring(0, epubFileName.LastIndexOf('.'));
                    epubFolderName = fileName;
                }

                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), contentFileName);


                System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(accEpubFolderName, "empty_Single_File.zip"), fileName);


                zipFileName = fileName + ".zip";

                File.Delete(Path.Combine(accEpubFolderName, "empty_Single_File.zip"));
            }

            if (mode == (int)fileMode.singleFileCss)
            {
                splitContainer2.Panel2Collapsed = true;
                splitContainer2.Panel2.Hide();
                splitContainer2.Panel2.Visible = false;
                geckoWebBrowser4.Visible = true;
            }
            else
            {
                splitContainer2.Panel2Collapsed = false;
                splitContainer2.Panel2.Show();
                splitContainer2.Panel2.Visible = true;
                geckoWebBrowser4.Visible = false;
            }

            //using (File.Create(epubFileName)) ;
            //using (File.Create(tempFile2)) ;
            //System.IO.File.Move(epubFileName, zipFileName);

            //System.IO.Compression.ZipFile.ExtractToDirectory(zipFileName, fileName);

            /*FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK) { return; }
            dialog.SelectedPath = tempFolder; */
            this.treeView1.Nodes.Add(TraverseDirectory(epubFolderName));

            //this.treeView1.CollapseAll();
            //foreach (TreeNode node in this.treeView1.Nodes)
            //{
            //    node.Collapse();
            //}



            //webBrowser1.Navigate(tempFile2 + "\\OEBPS\\Text\\Content.xhtml");
            //richTextBox1.Text = webBrowser1.DocumentText;

            //richTextBox1.LoadFile(tempFile2 + "\\OEBPS\\Styles\\style.css");


            string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"));

            string titleStart = "<dc:title>";
            string titleEnd = "</dc:title>";

            string creatorStart = "<dc:creator>";
            string creatorEnd = "</dc:creator>";

            string languageStart = "<dc:language>";
            string languageEnd = "</dc:language>";

            string publisherStart = "<dc:publisher>";
            string publisherEnd = "</dc:publisher>";

            //string identifierStart = "<dc:identifier>";
            //string identifierEnd = "</dc:identifier>";

            string timeStart = "<meta property=\"dcterms:modified\">";
            string timeEnd = "</meta>";


            string time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string identifier = "AccessibleEPUB:" + DateTime.UtcNow.ToString("yyyy-MM-ddTZ");

            int titleStartIndex = metadata.IndexOf(titleStart);
            int titleEndIndex = metadata.IndexOf(titleEnd);

            int creatorStartIndex = metadata.IndexOf(creatorStart);
            int creatorEndIndex = metadata.IndexOf(creatorEnd);

            int languageStartIndex = metadata.IndexOf(languageStart);
            int languageEndIndex = metadata.IndexOf(languageEnd);

            int publisherStartIndex = metadata.IndexOf(publisherStart);
            int publisherEndIndex = metadata.IndexOf(publisherEnd);

            //int identifierStartIndex = metadata.IndexOf(identifierStart);
            //int identifierEndIndex = metadata.IndexOf(identifierEnd);

            int timeStartIndex = metadata.IndexOf(timeStart);
            int timeEndIndex = metadata.IndexOf(timeEnd);

            string languageShort;
     
            switch (language)
            {
                case "en":
                    languageShort = "en";
                    break;
                case "de":
                    languageShort = "de";
                    break;
                default:
                    languageShort = "en";
                    break;
            }

            List<int> order = new List<int>{
                 titleStartIndex, titleEndIndex, creatorStartIndex, creatorEndIndex, languageStartIndex, languageEndIndex };

            List<Tuple<int, string, string>> tagsList = new List<Tuple<int, string, string>>();

            tagsList.Add(new Tuple<int, string, string>(titleStartIndex, titleStart, title));
            tagsList.Add(new Tuple<int, string, string>(titleEndIndex, titleEnd, ""));
            tagsList.Add(new Tuple<int, string, string>(creatorStartIndex, creatorStart, author));
            tagsList.Add(new Tuple<int, string, string>(creatorEndIndex, creatorEnd, ""));
            tagsList.Add(new Tuple<int, string, string>(languageStartIndex, languageStart, languageShort));
            tagsList.Add(new Tuple<int, string, string>(languageEndIndex, languageEnd, ""));
            tagsList.Add(new Tuple<int, string, string>(publisherStartIndex, publisherStart, publisher));
            tagsList.Add(new Tuple<int, string, string>(publisherEndIndex, publisherEnd, ""));
            //tagsList.Add(new Tuple<int, string, string>(identifierStartIndex, identifierStart, identifier));
            //tagsList.Add(new Tuple<int, string, string>(identifierEndIndex, identifierEnd, ""));

            tagsList.Add(new Tuple<int, string, string>(timeStartIndex, timeStart, time));
            tagsList.Add(new Tuple<int, string, string>(timeEndIndex, timeEnd, ""));

    

            //SortedDictionary<int, string> tagsList = new SortedDictionary<int, string>();
            //tagsList.Add(titleStartIndex, titleStart);
            //tagsList.Add(titleEndIndex, titleEnd);
            //tagsList.Add(creatorStartIndex, creatorStart);
            //tagsList.Add(creatorEndIndex, creatorEnd);
            //tagsList.Add(languageStartIndex, languageStart);
            //tagsList.Add(languageEndIndex, languageEnd);

            tagsList = tagsList.OrderBy(x => x.Item1).ToList();
            tagsList.Sort();

            List<string> metaItems = new List<string>();

            //for (int i = 0; i < ((tagsList.Count / 2) + 1) ; i++) {
            //    if (i == 0)
            //    {
            //        metaItems.Add(metadata.Substring(0, tagsList[i * 2].Item1 + tagsList[i * 2].Item2.Length));
            //    } 
            //    else if (i == ((tagsList.Count / 2) + 1))
            //    {
            //        metaItems.Add(metadata.Substring(tagsList[i * 2 - 1].Item1));
            //    }
            //    else
            //    {
            //        metaItems.Add(metadata.Substring(tagsList[i * 2 - 1].Item1, tagsList[i * 2].Item1 + tagsList[i * 2].Item2.Length));
            //    }



            //}


            //string first = metaItems[0];
            //string second = metaItems[1];
            //string third = metaItems[2];
            //string fourth = metaItems[3];
            //string fifth = metaItems[4];
            //string sixth = metaItems[5];

            string first = metadata.Substring(0, tagsList[0].Item1 + tagsList[0].Item2.Length);
            string second = metadata.Substring(tagsList[1].Item1, tagsList[2].Item1 + tagsList[2].Item2.Length - tagsList[1].Item1);
            string third = metadata.Substring(tagsList[3].Item1, tagsList[4].Item1 + tagsList[4].Item2.Length - tagsList[3].Item1);
            string fourth = metadata.Substring(tagsList[5].Item1, tagsList[6].Item1 + tagsList[6].Item2.Length - tagsList[5].Item1);
            string fifth = metadata.Substring(tagsList[7].Item1, tagsList[8].Item1 + tagsList[8].Item2.Length - tagsList[7].Item1);
            string sixth = metadata.Substring(tagsList[9].Item1);
            //string sixth = metadata.Substring(tagsList[9].Item1, tagsList[10].Item1 + tagsList[10].Item2.Length - tagsList[9].Item1);
            //string seventh = metadata.Substring(tagsList[11].Item1);


            //string first = metadata.Substring(0, titleStartIndex + titleStart.Length);
            //string second = metadata.Substring(titleEndIndex, creatorStartIndex + creatorStart.Length - titleEndIndex);
            //string third = metadata.Substring(creatorEndIndex);




            string newMetaData = first + tagsList[0].Item3 + second + tagsList[2].Item3 + third + tagsList[4].Item3 +
                 fourth + tagsList[6].Item3 + fifth + tagsList[8].Item3 + sixth;
            //+ tagsList[10].Item3 + seventh;

            Guid uuid = Guid.NewGuid();
            string uuidString = uuid.ToString().Replace("-", "");

   

            if (publisher == "")
            {
                newMetaData = newMetaData.Replace(publisherStart, "");
                newMetaData = newMetaData.Replace(publisherEnd, "");
            }

            newMetaData = newMetaData.Replace("BookIdentificationNumber", uuidString);

            File.WriteAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"), newMetaData);
            
            if (mode == (int)fileMode.singleFileJs)
            {
                impairedContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile));
                blindContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile));
            }


            //geckoWebBrowser1.Navigate(contentFile);
            //geckoWebBrowser2.Navigate(impairedContentFile);
            //geckoWebBrowser3.Navigate(blindContentFile);
            //geckoWebBrowser4.Navigate(contentFile);

            string cssString = "style.css";
            string impCssString = "impaired.css";
            string bliCssString = "blind.css";

            string impFile = File.ReadAllText(contentFile);
            string bliFile = impFile;

            impFile = impFile.Replace(cssString, impCssString);
            bliFile = bliFile.Replace(cssString, bliCssString);

            if (mode == (int)fileMode.singleFileJs)
            {
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile)), impFile);
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile)), bliFile);
            }

            determineLanguage();

            geckoWebBrowser1.Navigate(contentFile);
            geckoWebBrowser2.Navigate(impairedContentFile);
            geckoWebBrowser3.Navigate(blindContentFile);
            geckoWebBrowser4.Navigate(contentFile);
            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();

            splitContainer1.Panel1Collapsed = false;
            elementTabControl.Visible = true;
            treeView1.Visible = false;

            showToolStrips();

            HTMLEditor.Focus();

            this.Text = Path.GetFileName(target) + " - " + accessibleEpubFormText;

            documentLanguageLabel.Text = origDocumentLanguageLabel + language;
        }

        private void determineLanguage()
        {
            string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"));

            string languageStart = "<dc:language>";
            string languageEnd = "</dc:language>";

            int languageStartIndex = metadata.IndexOf(languageStart);
            int languageEndIndex = metadata.IndexOf(languageEnd);
            
            language = metadata.Substring(languageStartIndex + languageStart.Length, languageEndIndex - languageStartIndex - languageStart.Length);
      
        }

        /* The next few methods handle special directory actions */
        /* Deletes the contents of an empty or not empty directory, but not the directory itself. */
        private void DirectoryDelete(string path)
        {

            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            bool isInUse = false;
            int count = 0;

            do
            {
                try
                {
                    isInUse = false;
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete(true);

                    }
                }
                catch (IOException excep)
                {
                    count++;
                    if (count == 3)
                    {
                       
                        //MessageBox.Show(tempFolderStillInUseLong, tempFolderStillInUse, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        MessageBox.Show(Resource_MessageBox.tempInUseLongContent, Resource_MessageBox.tempInUseLongTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    isInUse = true;
                    //MessageBox.Show(tempFolderInUseLong, tempFolderInUse, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show(Resource_MessageBox.tempInUseContent, Resource_MessageBox.tempInUseTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } while (isInUse);
            //foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            //foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);


        }

       
        //private static void CloneDirectory(string root, string dest)
        //{
        //    foreach (var directory in Directory.GetDirectories(root))
        //    {
        //        string dirName = Path.GetFileName(directory);
        //        if (!Directory.Exists(Path.Combine(dest, dirName)))
        //        {
        //            Directory.CreateDirectory(Path.Combine(dest, dirName));
        //        }
        //        CloneDirectory(directory, Path.Combine(dest, dirName));
        //    }

        //    foreach (var file in Directory.GetFiles(root))
        //    {
        //        File.Copy(file, Path.Combine(dest, Path.GetFileName(file)));
        //    }
        //}

        /* Copies the contents of the directory, but not the directory itself. */
        private static void DirectoryCopy(string sourceDirName, string destDirName)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temp = Path.Combine(destDirName, file.Name);
                //file.CopyTo(temp, false);
                file.CopyTo(temp, true);

            }

            // If copying subdirectories, copy them and their contents to new location.

            foreach (DirectoryInfo subdir in dirs)
            {
                string temp = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temp);
            }

        }

        /* Refreshes the code editor view to have the newest content. */
        private void filesTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (filesTabControl.TabPages.Count >= 1)
            {
                filesTabControl.SelectedTab = e.TabPage;

                string absPath = Path.Combine(accEpubFolderName, e.TabPage.Name);
                openTab(absPath);
            }
        }

        /* Generates the table of contents, but only for JavaScript version of Accessible EPUB */
        private void generateTableOfContents()
        {
            //string oebpsFolder = Path.Combine(epubFolderName, "OEBPS", "Text");

            //List<string> files = new List<string>();

            //foreach (string fileName in Directory.GetFiles(oebpsFolder))
            //{
            //    if (!(fileName.EndsWith("nav.xhtml") || fileName.EndsWith("VersionChanger.xhtml")) {
            //        files.Add(fileName);
            //    }
            //}

           
            if (!File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml")))
            {
                //MessageBox.Show("Table of Contents can only be generated if file was created in Accessible EPUB.", "Table of contents error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show(Resource_MessageBox.tocAccEpubContent, Resource_MessageBox.tocAccEpubTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (mode != (int)fileMode.singleFileJs)
            {
                //MessageBox.Show("Table of contents only supported in JavaScript Mode.", "Table of contents error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //MessageBox.Show(Resource_MessageBox.tocJsContent, Resource_MessageBox.tocJsTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //string oldContentFile = contentFile;
            //contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml");

            string fileToRead = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml");

            string contentBody = "";

            try
            {
                contentBody = System.IO.File.ReadAllText(fileToRead);
            }
            catch (Exception ex)
            {
                if (ex is DirectoryNotFoundException || ex is FileNotFoundException)
                {
                    //MessageBox.Show("Problem reading Content.xhtml", "Error reading Content.xhtml", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show(Resource_MessageBox.probReadContContent, Resource_MessageBox.probReadContTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }


            string bodyStart = "<body";
            //string bodyStart = "<nav epub:type=\"toc\" id=\"toc\">";
            string bodyEnd = "</body>";
            //string bodyEnd = "</nav>";
            int first = contentBody.IndexOf(bodyStart);

            int end = contentBody.IndexOf(bodyEnd);

            int bracketTerminateIndex = 0;
            bool endMode = true;
            for (int i = 1; i < end - first; i++)
            {

                if (contentBody[first + i] == '<')
                {
                    endMode = false;
                }

                if (contentBody[first + i] == '>')
                {

                    if (endMode == false)
                    {
                        endMode = true;
                    }
                    else
                    {
                        bracketTerminateIndex = i;
                    }
                }
            }

            string header = contentBody.Substring(0, first + bracketTerminateIndex + 1);
            string closer = contentBody.Substring(end);
            //Console.WriteLine(contentBody.Substring(first + bracketTerminateIndex + 1));
   
            //Console.WriteLine(contentBody.Substring(first + bracketTerminateIndex + 1, end - first));
            
            //string bodyContent = HTMLEditor.Document.Body.InnerHtml.ToLower();
            string bodyContent = contentBody.Substring(first + bracketTerminateIndex + 1, end - (first + bracketTerminateIndex + 1));

            string h1Regex = "<h[1-6][^>]*?>(?<TagText>.*?)</h[1-6]>";

            string hRegex = "<h[1-6]";

            
            MatchCollection mc = Regex.Matches(bodyContent, h1Regex, RegexOptions.Singleline);

            MatchCollection mc1 = Regex.Matches(bodyContent, hRegex, RegexOptions.Singleline);

            List<Tuple<string, string, string>> headersList = new List<Tuple<string, string, string>>();

            List<Tuple<string, string>> oldNew = new List<Tuple<string, string>>();

            int h1Count = Regex.Matches(bodyContent, h1Regex).Count;
            foreach (Match m in mc)
            {
                string TagText = m.Groups["TagText"].Value.Replace("<br/>", "").Trim();
                if (TagText != "")
                {
                    headersList.Add(new Tuple<string, string, string>(m.Value, m.Value.Substring(1, 2), m.Groups["TagText"].Value.Replace("<br/>", "").Trim()));
                }

            }

            if (headersList.Count == 0)
            {
                return;
            }

            string idString = " id=\"";
            
            for (int i = 0; i < headersList.Count; i++)
            {
                string newString = headersList[i].Item1;
                //Console.WriteLine(newString);
                //Console.WriteLine(Regex.Replace(newString, " id=\"[^\\s>]*", ""));

                newString = Regex.Replace(newString, " id=\"[^\\s>]*", "");


                newString = newString.Replace(newString.Substring(0, 3), newString.Substring(0, 3)
                    + " id=\"toc_" + i + "\"");

                oldNew.Add(new Tuple<string, string>(headersList[i].Item1, newString));

            }

            foreach (var entry in oldNew)
            {
                bodyContent = bodyContent.Replace(entry.Item1, entry.Item2);

            }

            //Console.WriteLine(bodyContent);
            File.WriteAllText(Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml"), header + bodyContent + closer);



            string tocTitle = "";

            if (language == "de")
            {
                tocTitle = "Inhaltsverzeichnis";
            }
            else if (language == "en")
            {
                tocTitle = "Table of Contents";
            }
            string tocContent = "";

            tocContent = tocContent + "<nav epub:type=\"toc\" id=\"toc\">";

            if (headersList.Count != 0)
            {
                tocContent = tocContent + "\t<h1>" + tocTitle + "</h1>\n";
                tocContent = tocContent + "\t<ol>\n";
            }


            string textFolder = "../Text/";

            //string longtextFolder = Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text").Replace("\\", "/") + "/";
            string tabs = "\t";
            for (int i = 0; i < headersList.Count; i++)
            {
                if (headersList[i].Item2 == "h1")
                {
                    string id = "id=\"";
                    int startId = oldNew[i].Item2.IndexOf(id) + id.Length;
                    string afterStart = oldNew[i].Item2.Substring(startId);
                    int endId = afterStart.IndexOf("\"");

                    afterStart = "#" + afterStart.Substring(0, endId);

                    //afterStart = "#" + afterStart;

                    tocContent = tocContent + "\t\t<li>\n";
                    tocContent = tocContent + "\t\t\t<a href=\"" + textFolder + Path.GetFileName(contentFile) + afterStart + "\">" + headersList[i].Item3 +"</a>\n";

                    //Console.WriteLine("afterStart: " + afterStart);
                    if (i == headersList.Count - 1)
                    {
                        tocContent = tocContent + "\t\t</li>\n";
                        break;
                    }
                    else if (headersList[i + 1].Item2 == "h1")
                    {
                        tocContent = tocContent + "\t\t</li>\n";
                    }
                    else
                    {
                        tocContent = tocContent + "\t\t\t<ol>\n";
                    }
                }
                else
                {
                    string id = "id=\"";
                    int startId = oldNew[i].Item2.IndexOf(id) + id.Length;
                    string afterStart = oldNew[i].Item2.Substring(startId);
                    int endId = afterStart.IndexOf("\"");

                    afterStart = "#" + afterStart.Substring(0, endId);

                    //afterStart = "#" + afterStart;

                    tocContent = tocContent + "\t\t\t\t<li>\n";
                    tocContent = tocContent + "\t\t\t\t\t<a href=\"" + textFolder + Path.GetFileName(contentFile) + afterStart + "\">" + headersList[i].Item3 + "</a>\n";

                    //Console.WriteLine("afterStart: " + afterStart);

                    tocContent = tocContent + "\t\t\t\t</li>\n";

                    if (i == headersList.Count - 1)
                    {
                        tocContent = tocContent + "\t\t\t\t</li>\n";
                        tocContent = tocContent + "\t\t\t</ol>\n";
                        tocContent = tocContent + "\t\t</li>\n";
                        break;
                    }

                    if (headersList[i + 1].Item2 == "h1")
                    {
                        tocContent = tocContent + "\t\t\t</ol>\n";
                        tocContent = tocContent + "\t\t</li>\n";
                    }

                    
                }
 
              
                //Console.WriteLine(headersList[i].Item1 + ": " + headersList[i].Item2 + "; " + headersList[i].Item3);
            }

            tocContent = tocContent + "\t</ol>\n";

            /*</nav>
    <nav epub:type="landmarks" id="landmarks" hidden="">
      <h2>Guide</h2>
      <ol>
      </ol>
    </nav>*/

            tocContent = tocContent + "</nav>\n<nav epub:type=\"landmarks\" id=\"landmarks\" hidden=\"\">\n<h2>Guide</h2>\n<ol>\n</ol></nav>";




            string navfileToRead = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "nav.xhtml");

            string navcontentBody = "";

            try
            {
                navcontentBody = System.IO.File.ReadAllText(navfileToRead);
            }
            catch (Exception ex)
            {
                if (ex is DirectoryNotFoundException || ex is FileNotFoundException)
                {
                    //MessageBox.Show("Problem reading nav.xhtml", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show(Resource_MessageBox.probReadNavContent, Resource_MessageBox.probReadNavTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }


            string navbodyStart = "<body";
            string navbodyEnd = "</body>";
            int navfirst = navcontentBody.IndexOf(navbodyStart);

            int navend = navcontentBody.IndexOf(navbodyEnd);

            int navbracketTerminateIndex = 0;
            bool navendMode = true;
            for (int i = 1; i < navend - navfirst; i++)
            {

                if (navcontentBody[navfirst + i] == '<')
                {
                    navendMode = false;
                }

                if (navcontentBody[navfirst + i] == '>')
                {

                    if (navendMode == false)
                    {
                        navendMode = true;
                    }
                    else
                    {
                        navbracketTerminateIndex = i;
                    }
                }
            }

            string navheader = navcontentBody.Substring(0, navfirst + navbracketTerminateIndex + 1);
            string navcloser = navcontentBody.Substring(navend);
            //Console.WriteLine(contentBody.Substring(first + bracketTerminateIndex + 1));

            //Console.WriteLine(contentBody.Substring(first + bracketTerminateIndex + 1, end - first));

            //string bodyContent = HTMLEditor.Document.Body.InnerHtml.ToLower();
            string navbodyContent = navheader + tocContent + navcloser;

            //Console.WriteLine(navheader);

            File.WriteAllText(Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "nav.xhtml"), navbodyContent);

            string tocSpineEntry = "<itemref idref=\"navid\"/>";
            string oldSpine = "<itemref idref=\"VersionChanger.xhtml\"/>\n";
            string newSpine = "<itemref idref=\"VersionChanger.xhtml\"/>\n\t<itemref idref=\"navid\"/>\n"; ;

            string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"));

            if (metadata.Contains(tocSpineEntry))
            {
                return;
            }
            


            metadata = metadata.Replace(oldSpine, newSpine);

            File.WriteAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"), metadata);

            //foreach (Match a in mc1)
            //{
            //    //Console.WriteLine(a.Value);
            //}
            //Console.WriteLine(h1Count);

            //Console.WriteLine(bodyContent);


            //contentFile = oldContentFile;
            //htmlToWysiwyg();
        }


        /* The XHTML div section splits for each section */
        string startOfContent = "<!--StartOfContent-->";
        string imp = "<div style=\"padding:none\" id=\"impaired\" class=\"impaired\">\n<!--StartOfImpairedSection-->\n";
        string impEnd = "<!--EndOfImpairedSection-->\n</div>\n";
        string bli = "<div id=\"blind\" class=\"blind\">\n<!--StartOfBlindSection-->\n";
        string bliEnd = "<!--EndOfBlindSection-->\n</div>\n";
        string vis = "<div id=\"visible\" class=\"visible\">\n<!--StartOfVisibleSection-->\n";
        string visEnd = "<!--EndOfVisibleSection-->\n</div>\n";

        //private void initializeHTMLeditor()
        //{
        //    string body = doc.body.innerHTML;
        //    string newContent = "";
        //    string contentBody = "";
        //    string textFolder = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"));
        //    try
        //    {
        //        contentBody = System.IO.File.ReadAllText(contentFile);

        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex is DirectoryNotFoundException || ex is FileNotFoundException)
        //        {
        //            MessageBox.Show("Problem initializing HTML editor", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        }

        //    }

        //    string bodyTag = "<body>";
        //    string bodyEnd = "</body>";
        //    //System.IO.File.WriteAllText(Path.Combine(textFolder, "Content.txt"), body);
        //    //System.IO.File.WriteAllText(Path.Combine(textFolder, "haha.txt"), contentBody.Substring(0, contentBody.IndexOf(imp) + imp.Length));
        //    //newContent = contentBody.Substring(0, contentBody.IndexOf(startOfContent) + startOfContent.Length) + "\n";



        //    newContent = newContent + imp + body + impEnd +
        //        bli + body + bliEnd +
        //        vis + body + visEnd + "</body>\n</html>\n";
        //    //newContent = contentBody.Substring(0, contentBody.IndexOf(bodyTag) + bodyTag.Length);
        //    //newContent = newContent +
        //    //    imp + body + impEnd +
        //    //    bli + body + bliEnd +
        //    //    vis + body + visEnd + contentBody.Substring(contentBody.IndexOf(bodyEnd) + bodyEnd.Length);

        //    string fileLocation = Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text");

        //    System.IO.File.WriteAllText(contentFile, newContent);


        //}

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        /* Zips up the EPUB as according to the EPUB standards. The mimetype file should not be compressed, so is added separately. */
        private void createEpubZip(string source, string dest)
        {
      

            // Creating ZIP file and writing mimetype
            using (Ionic.Zip.ZipOutputStream zs = new Ionic.Zip.ZipOutputStream(dest))
            {
                var o = zs.PutNextEntry("mimetype");
                o.CompressionLevel = Ionic.Zlib.CompressionLevel.None;

                byte[] mimetype = System.Text.Encoding.ASCII.GetBytes("application/epub+zip");
                zs.Write(mimetype, 0, mimetype.Length);
            }

            // Adding META-INF and OEPBS folders including files     
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(dest))
            {
                zip.AddDirectory(Path.Combine(source, "META-INF"), "META-INF");
                zip.AddDirectory(Path.Combine(source, "OEBPS"), "OEBPS");
                zip.Save();
            }
        }

        //private void Zipup(string source, string destination)
        //{
         
        //    using (FileStream fs = File.Open(destination, FileMode.Create, FileAccess.ReadWrite))
        //    {
        //        using (var output = new Ionic.Zip.ZipOutputStream(fs))
        //        {
        //            var e = output.PutNextEntry("mimetype");
        //            e.CompressionLevel = Ionic.Zlib.CompressionLevel.None;

        //            byte[] buffer = System.Text.Encoding.ASCII.GetBytes("application/epub+zip");
        //            output.Write(buffer, 0, buffer.Length);

        //            output.PutNextEntry("META-INF/container.xml");
        //            WriteExistingFile(output, "META-INF/container.xml");
        //            output.PutNextEntry("OPS/");  // another directory
        //            output.PutNextEntry("OPS/whatever.xhtml");
        //            WriteExistingFile(output, "OPS/whatever.xhtml");
        //            // ...
        //        }
        //    }
        //}

        //private void WriteExistingFile(Stream output, string filename)
        //{
        //    using (FileStream fs = File.Open(fileName, FileMode.Read))
        //    {
        //        int n = -1;
        //        byte[] buffer = new byte[2048];
        //        while ((n = fs.Read(buffer, 0, buffer.Length)) > 0)
        //        {
        //            output.Write(buffer, 0, n);
        //        }
        //    }
        //}

        private void saveFile()
        {
            if (containsFile == false)
            {
                return;
            }
            //if (filesTabControl.Visible == false)
            if (elementHost2.Visible == false)
            {
                wysiwygToHtml();
            }
            else
            {

                htmlToWysiwyg();

                //foreach (KeyValuePair<string, ICSharpCode.AvalonEdit.TextEditor> ca in tabsToTextEditors)
                //{
                //    ca.Value.Save(Path.Combine(accEpubFolderName, ca.Key));
                //}

                //foreach (TabPage tp in filesTabControl.TabPages)
                //{
                //    foreach (var ca in openTextEditors)
                //    {
                //        ca.S
                //        if (tp.Name == ca.Name)
                //        {
                //            System.IO.File.WriteAllText(tp.Name, ca.Text);
                //        }
                //    }

                //}
                //string fileLocation = Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text");

            }

            geckoWebBrowser2.Navigate("about:blank");
            geckoWebBrowser3.Navigate("about:blank");

            //contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml");

            impairedContentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "ImpContent.xhtml");
            blindContentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "BliContent.xhtml");
            if (File.Exists(impairedContentFile))
            {
                File.Delete(impairedContentFile);
            }


            if (File.Exists(blindContentFile))
            {
                File.Delete(blindContentFile);
            }

            if (mode == (int)fileMode.singleFileJs)
            {
                //impairedContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile));
                //blindContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile));
               


                //if (File.Exists(impairedContentFile))
                //{
                //    File.Delete(impairedContentFile);
                //}


                //if (File.Exists(blindContentFile))
                //{
                //    File.Delete(blindContentFile);
                //}

                generateTableOfContents();
            }

          

            string zipFileName = epubFolderName + ".zip";
            File.Delete(zipFileName);

            createEpubZip(epubFolderName, zipFileName);
            //ZipFile.CreateFromDirectory(epubFolderName, zipFileName);

            File.Copy(zipFileName, target, true);
            File.Delete(zipFileName);



            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add(TraverseDirectory(epubFolderName));

            //string searchFolder = Path.Combine(epubFolderName, "OEBPS");
            createManifest(epubFolderName);

            string cssString = "style.css";
            string impCssString = "impaired.css";
            string bliCssString = "blind.css";

            if (mode == (int)fileMode.singleFileJs)
            {
                string impFile = File.ReadAllText(contentFile);
                string bliFile = impFile;

                impFile = impFile.Replace(cssString, impCssString);
                bliFile = bliFile.Replace(cssString, bliCssString);

                //File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile)), impFile);
                //File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile)), bliFile);

                File.WriteAllText(impairedContentFile, impFile);
                File.WriteAllText(blindContentFile, bliFile);

                geckoWebBrowser1.Reload();
                geckoWebBrowser2.Navigate(impairedContentFile);
                geckoWebBrowser3.Navigate(blindContentFile);

            }



            //geckoWebBrowser1.Reload();
            //geckoWebBrowser2.Reload();
            //geckoWebBrowser3.Reload();
            geckoWebBrowser4.Reload();

            fileNotSaved = false;

            lastSave = DateTime.UtcNow;
          
        }


        private void toggleCode_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            elementHost2.Visible = !elementHost2.Visible;
            elementHost2.BringToFront();
            //filesTabControl.Visible = !filesTabControl.Visible;
            //if (filesTabControl.Visible == false)
            if (elementHost2.Visible == false)
            {
                //splitContainer1.Panel1Collapsed = false;
                //splitContainer1.Panel1.Show();
                //splitContainer2.Panel2Collapsed = false;
                //splitContainer2.Panel2.Show();
                HTMLEditor.Focus();
                htmlToWysiwyg();
            }
            else
            {
                elementHost2.Focus();
                //filesTabControl.Focus();
               

                ////splitContainer1.Panel1Collapsed = true;
                ////splitContainer1.Panel1.Hide();
                ////splitContainer1.Panel1Collapsed = false;
                ////splitContainer1.Panel1.Show();
                wysiwygToHtml();

            }
        }

        /* Converts code editor code to WYSIWYG editor suitable code. */
        private void htmlToWysiwyg()
        {
            string vis = "<div id=\"visible\" class=\"visible\">";
            string start = "<!--StartOfVisibleSection-->";
            string end = "<!--EndOfVisibleSection-->";

            //foreach (KeyValuePair<string, ICSharpCode.AvalonEdit.TextEditor> ca in tabsToTextEditors)
            //{
            //    //if (ca.Key == lastTab)
            //    //{
            //    //    ca.Value.Save(Path.Combine(accEpubFolderName, ca.Key));
            //    //}
            //    //ca.Value.Save(Path.Combine(accEpubFolderName, ca.Key));
            //    //File.WriteAllText(Path.Combine(accEpubFolderName, ca.Key), ca.Value.Document.Text);
            //}

            if (elementHost2.Visible == true)
            {
                codeEditor.Save(currentEditorFile);
            }

            string bodyStart = "<body";
            string bodyEnd = "</body>";

            bool singleFileMode = true;
            bool contentFileExists = true;
            string body = "";
            if (File.Exists(contentFile))
            {
                body = File.ReadAllText(contentFile);

                body = body.Replace(Path.Combine("..", ""), Path.Combine(epubFolderName, "OEBPS"));

                if (!body.Contains(start))
                {
                    if (!body.Contains(end))
                    {
                        singleFileMode = false;
                    }
                }
            }
            else
            {
                contentFileExists = false;
                singleFileMode = false;
            }

            //if (contentFileExists == false)
            //{
            //    string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"));
            //    string firstItem = "<itemref idref=\"";
            //    int firstIndex = metadata.IndexOf(firstItem) + firstItem.Length;
            //    string sub = metadata.Substring(firstIndex);
            //    int endIndex = sub.IndexOf("\"");
            //    string itemName = sub.Substring(0, endIndex);
            //    contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), itemName);
            //    body = File.ReadAllText(Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), itemName));
            //    body = body.Replace(Path.Combine("..", ""), Path.Combine(epubFolderName, "OEBPS"));

            //}

            if (singleFileMode)
            {
                int startIndex = body.IndexOf(start);
                int endIndex = body.IndexOf(end);

                if (body.IndexOf(vis) >= startIndex)
                {
                    return;
                }
                HTMLEditor.Document.Body.InnerHtml = body.Substring(startIndex + start.Length, endIndex - startIndex - start.Length);
            }
            else
            {
                int startIndex = body.IndexOf(bodyStart);
                int endIndex = body.IndexOf(bodyEnd);


                HTMLEditor.Document.Body.InnerHtml = body.Substring(startIndex, endIndex - startIndex + bodyEnd.Length);
            }




        }


        /* Converts the WYSIWYG browser content to regular XHTML. */
        private void wysiwygToHtml()
        {
            //if ((contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "nav.xhtml"))))
            //{
            //    return;
            //}

            //if ((contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "VersionChanger.xhtml"))))
            //{
            //    return;
            //}

            string body = doc.body.innerHTML;
            //Regex spanRegex = new Regex(@"(?<=span)(.*)(?=/span)");
            Regex spanRegex = new Regex(@"<span[^>]*>(.*?)<\/span>");
            //Console.WriteLine(body);
            MatchCollection spanMatches = spanRegex.Matches(body);
            Match sp = spanRegex.Match(body);
            //Console.WriteLine("LALA:" + sp.ToString());
            //Console.WriteLine("BABA:" + sp.Groups[1].ToString());
    

            foreach (Match span in spanMatches)
            {
                string replacementString = span.Groups[1].ToString();
                body = body.Replace(span.ToString(), replacementString);
               
            }
            if (body == null)
            {
                return;
            }

            //Console.WriteLine(contentFile);

            string newContent = "";
            string contentBody = "";

            string textFolder = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"));
            try
            {
                contentBody = System.IO.File.ReadAllText(contentFile);
            }
            catch (Exception ex)
            {
                if (ex is DirectoryNotFoundException || ex is FileNotFoundException)
                {
                    //MessageBox.Show("Problem converting from WYSIWYG to HTML", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show(Resource_MessageBox.conversionContent, Resource_MessageBox.conversionTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            body = body.Replace(Path.Combine(epubFolderName, "OEBPS"), "..");


            string annoStart = "<annotation encoding=\"application/x-tex\">";
            string annoEnd = "</annotation>";

            while (body.Contains(annoStart) && body.Contains(annoEnd))
            {
                int start = body.IndexOf(annoStart);
                int end = body.IndexOf(annoEnd) + annoEnd.Length;

                body = body.Replace(body.Substring(start, end - start), "");
            }

            if ((contentFile == Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml")
                && (mode == (int)fileMode.singleFileCss)))
            {

                //System.IO.File.WriteAllText(Path.Combine(textFolder, "ContentBla.txt"), contentBody);

                //System.IO.File.WriteAllText(Path.Combine(textFolder, "Content.txt"), body);
                //System.IO.File.WriteAllText(Path.Combine(textFolder, "haha.txt"), contentBody.Substring(0, contentBody.IndexOf(imp) + imp.Length));
                newContent = contentBody.Substring(0, contentBody.IndexOf(startOfContent) + startOfContent.Length) + "\n";



                string imagesFolder = getImageFolder();


                //string mstyleImpaired = "<mstyle scriptsizemultiplier=\"1\" lspace=\"20%\" rspace=\"20%\" mathvariant=\"sans-serif\">";
                //string bodyImpaired = body.Replace("<mstyle>", mstyleImpaired); ;

                newContent = newContent + imp + body + impEnd +
                    bli + body + bliEnd +
                    vis + body + visEnd + "</body>\n</html>\n";
                //newContent = contentBody.Substring(0, contentBody.IndexOf(bodyTag) + bodyTag.Length);
                //newContent = newContent +
                //    imp + body + impEnd +
                //    bli + body + bliEnd +
                //    vis + body + visEnd + contentBody.Substring(contentBody.IndexOf(bodyEnd) + bodyEnd.Length);

            }
            //else if (mode == (int)fileMode.singleFileJs)
            //{
            //    string bodyStart = "<body epub:type=\"bodymatter\" onload=\"storageCSS();\">";
            //    string bodyEnd = "</body>";
            //    int first = contentBody.IndexOf(bodyStart);
            //    string header = contentBody.Substring(0, first + bodyStart.Length);

            //    int end = contentBody.IndexOf(bodyEnd);

            //    string closer = contentBody.Substring(end);
            //    newContent = header + body + closer;
            //}
            else
            {

                string bodyStart = "<body";
                string bodyEnd = "</body>";
                int first = contentBody.IndexOf(bodyStart);

                int end = contentBody.IndexOf(bodyEnd);

                int bracketTerminateIndex = 0;
                bool endMode = true;
                for (int i = 1; i < end - first; i++)
                {

                    if (contentBody[first + i] == '<')
                    {
                        endMode = false;
                    }

                    if (contentBody[first + i] == '>')
                    {

                        if (endMode == false)
                        {
                            endMode = true;
                        }
                        else
                        {
                            bracketTerminateIndex = i;
                        }
                    }
                }
                //Console.WriteLine(contentFile);
                string header = contentBody.Substring(0, first + bracketTerminateIndex + 1);
                string closer = contentBody.Substring(end);
                newContent = header + body + closer;
            }


            //newContent = HtmlParser.Tidy(newContent).ToString();


            //TidyManaged.Document tm = TidyManaged.Document.FromString(newContent);
            //tm.OutputXhtml = true;

            //tm.OutputNumericEntities = true;

            //tm.InputCharacterEncoding = TidyManaged.EncodingType.Raw;
            //tm.CharacterEncoding = TidyManaged.EncodingType.Raw;
            //tm.OutputCharacterEncoding = TidyManaged.EncodingType.Raw;
            //tm.PreserveEntities = true;


            //tm.DocType = TidyManaged.DocTypeMode.Omit;
            ////tm.AddXmlDeclaration = true;
            ////tm.DropFontTags = true;
            ////tm.IndentSpaces = 4;
            //tm.AddTidyMetaElement = false;

            //tm.CleanAndRepair();


            //newContent = tm.Save();

            //HtmlAgilityPack.HtmlDocument hap = new HtmlAgilityPack.HtmlDocument();
            //hap.LoadHtml(newContent);
            //hap.OptionOutputAsXml = true;
            //newContent = hap.ParsedText;

            string xmlDecl = "<?xml version='1.0' encoding='utf-8'?>";
            string docType = "<!DOCTYPE html>";

            TextReader tr;
            tr = new StringReader(newContent);

            /* SgmlReader has to be used to convert the HTML to XHTML. */
            // setup SgmlReader
            Sgml.SgmlReader sgmlReader = new Sgml.SgmlReader();
            sgmlReader.DocType = "HTML";
            //sgmlReader.WhitespaceHandling = System.Xml.WhitespaceHandling.All;
            sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower;
            sgmlReader.InputStream = tr;

            // create document

            System.Xml.XmlDocument xdoc = new System.Xml.XmlDocument();

            xdoc.CreateXmlDeclaration("1.0", "UTF-8", null);

            xdoc.PreserveWhitespace = true;
            //xdoc.XmlResolver = null;

            xdoc.Load(sgmlReader);
            newContent = xdoc.InnerXml;

            newContent = newContent.Replace(" />", "/>");

            newContent = xmlDecl + docType + newContent;



            //HtmlAgilityPack.HtmlDocument hap = new HtmlAgilityPack.HtmlDocument();
            //hap.LoadHtml(newContent);
            //hap.OptionOutputAsXml = true;
            //newContent = hap.ParsedText;





            string fileLocation = Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text");

            System.IO.File.WriteAllText(contentFile, newContent);

            codeEditor.Load(contentFile);
            ///* Loads a file to a code editor. */
            //foreach (KeyValuePair<string, ICSharpCode.AvalonEdit.TextEditor> ca in tabsToTextEditors)
            //{
            //    ca.Value.Load(Path.Combine(accEpubFolderName, ca.Key));
            //}


        }


//        private void addFilesToMeta()
//        {
//            string fileName = Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf");
//            string content = File.ReadAllText(fileName);

//            string startManifest = "<manifest>";
//            string endManifest = "</manifest>";

//            int startManiIndex = content.IndexOf(startManifest);
//            int endManiIndex = content.IndexOf(endManifest);

//            string defaultText = @"
//                <item id=""ncx"" href=""toc.ncx"" media-type=""application/x-dtbncx+xml""/>
//                <item id=""Content.xhtml"" href=""Text/Content.xhtml"" media-type=""application/xhtml+xml""/>
//";

//            //< item id = "Content.xhtml" href = "Text/Content.xhtml" media - type = "application/xhtml+xml" />

//            //     < item id = "style.css" href = "Styles/style.css" media - type = "text/css" />

//            //          < item id = "navid" href = "Text/nav.xhtml" media - type = "application/xhtml+xml" properties = "nav" /> "
//        }

     

      

        private void HTMLEditorClick(object sender, HtmlElementEventArgs e)
        {
            int x = e.MousePosition.X;
            int y = e.MousePosition.Y;
            Point p = new Point(x, y);
      
            Point ScreenCoord = new Point(MousePosition.X, MousePosition.Y);

            Point BrowserCoord = HTMLEditor.PointToClient(ScreenCoord);

            HtmlElement elem = HTMLEditor.Document.GetElementFromPoint(BrowserCoord);

          
            
            dynamic currentSelection = doc.selection as IHTMLSelectionObject;
            
            if (elem.TagName == "IMG")
            {
                IHTMLElement current = doc.elementFromPoint(x, y) as IHTMLElement;
                IHTMLElement pare = current.parentElement;
                dynamic range = currentSelection.createRange() as IHTMLTxtRange;
                //    //HTMLEditor.Document.Body.               
                //    HTMLSelectElement bla = new HTMLSelectElement();


                foreach (IHTMLElement a in doc.all)
                {

                    if (a.outerHTML == pare.outerHTML)
                    {
                        //Console.WriteLine(a.outerHTML);
                        range.moveToElementText(pare);
                        range.select();
                    }
                }
            }

            updateFontFormat();
            updateHeaderList();

        }


        /* Gets the current heading style (p, h1, h2 and so on */
        private void updateFontFormat()
        {
            string elemOuter = "";

            IHTMLSelectionObject currentSelection = doc.selection;

            if (currentSelection != null)
            {
                IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;

                if (range != null)
                {
                    elemOuter = range.parentElement().outerHTML;
                    //Console.WriteLine(range.parentElement().outerHTML);
                    //MessageBox.Show(range.text);
                }
                else
                {
                    return;
                }
            }


            //Console.WriteLine("Print " + HTMLEditor.Document.Body.OuterHtml);



            //Point ScreenCoord = new Point(MousePosition.X, MousePosition.Y);

            //Point BrowserCoord = HTMLEditor.PointToClient(ScreenCoord);

            //HtmlElement elem = HTMLEditor.Document.GetElementFromPoint(BrowserCoord);

            //string elemOuter = elem.OuterHtml;

            //Console.WriteLine(elemOuter);
            //Console.WriteLine(HTMLEditor.Document.ActiveElement.OuterHtml.Substring(0,3));

            if (elemOuter.StartsWith("<p"))
            {
                formatComboBox.SelectedIndex = 0;
            }
            else if (elemOuter.StartsWith("<h1"))
            {
                formatComboBox.SelectedIndex = 1;
            }
            else if (elemOuter.StartsWith("<h2"))
            {
                formatComboBox.SelectedIndex = 2;
            }
            else if (elemOuter.StartsWith("<h3"))
            {
                formatComboBox.SelectedIndex = 3;
            }
            else if (elemOuter.StartsWith("<h4"))
            {
                formatComboBox.SelectedIndex = 4;
            }
            else if (elemOuter.StartsWith("<h5"))
            {
                formatComboBox.SelectedIndex = 5;
            }
            else if (elemOuter.StartsWith("<h6"))
            {
                formatComboBox.SelectedIndex = 6;
            }
        }

        /* Replaces only the first instance of a string */
        private string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        /* Finds the HtmlElement which has been double clicked on and passes the result to the method identifyElement. */
        private void HTMLEditorDoubleClick(object sender, HtmlElementEventArgs e)
        {
            int x = e.MousePosition.X;
            int y = e.MousePosition.Y;
            Point p = new Point(x, y);
            
            Point ScreenCoord = new Point(MousePosition.X, MousePosition.Y);

            Point BrowserCoord = HTMLEditor.PointToClient(ScreenCoord);
        
            HtmlElement elem = HTMLEditor.Document.GetElementFromPoint(BrowserCoord);       

            identifyElement(elem);

            //HtmlElementCollection elems = HTMLEditor.Document.GetElementsByTagName(elem.TagName);
            ////Console.WriteLine("HTMLelement " + HTMLEditor.Document.ActiveElement.TagName);
            ////Console.WriteLine("Point " + BrowserCoord.X + "," + BrowserCoord.Y + " outerHTML " + elem.OuterHtml);

            
            //bool isImage = false;
            //bool isMath = false;
            //bool isDiv = false;

            //string ulRegular = "<ul>";
            //string ulDisc = "<ul style=\"list-style-type:disc;\">";
            //string ulCircle = "<ul style=\"list-style-type:circle;\">";
            //string ulSquare = "<ul style=\"list-style-type:square;\">";

            //string ulDiscA = "<ul style=\"list-style-type: disc;\">";
            //string ulCircleA = "<ul style=\"list-style-type: circle;\">";
            //string ulSquareA = "<ul style=\"list-style-type: square;\">";


            //if (elem.OuterHtml.StartsWith("<ul"))
            //{
            //    string figElem = elem.OuterHtml;

            //    if (figElem.ToLower().StartsWith(ulRegular) || figElem.ToLower().StartsWith(ulDiscA))
            //    {
            //        //elem.OuterHtml = ReplaceFirst(figElem, ulRegular, ulCircle);
            //        elem.OuterHtml = ReplaceFirst(figElem.ToLower(), ulRegular, ulCircleA);
            //    }
            //    else if (figElem.ToLower().StartsWith(ulCircleA))
            //    {
            //        //elem.OuterHtml = ReplaceFirst(figElem, ulCircle, ulSquare);
            //        elem.OuterHtml = ReplaceFirst(figElem.ToLower(), ulCircleA, ulSquareA);
            //    }
            //    else if (figElem.ToLower().StartsWith(ulSquareA))
            //    {
            //        //elem.OuterHtml = ReplaceFirst(figElem, ulSquare, ulRegular);
            //        elem.OuterHtml = ReplaceFirst(figElem.ToLower(), ulSquareA, ulRegular);
            //    }

            //}

            //string olRegular = "<ol>";
            //string olTypeNum = "<ol type=\"1\">";
            //string olTypeUpper = "<ol type=\"A\">";
            //string olTypeLower = "<ol type=\"a\">";
            //string olTypeRomanU = "<ol type=\"I\">";
            //string olTypeRomanL = "<ol type=\"i\">";

            //if (elem.OuterHtml.StartsWith("<ol"))
            //{
            //    string figElem = elem.OuterHtml;
                
            //    if (figElem.StartsWith(olRegular) || figElem.StartsWith(olTypeNum)) {
            //        elem.OuterHtml = ReplaceFirst(figElem, olRegular, olTypeUpper);
            //    }
            //    else if (figElem.StartsWith(olTypeUpper))
            //    {
            //        elem.OuterHtml = ReplaceFirst(figElem, olTypeUpper, olTypeLower);
            //    }
            //    else if (figElem.StartsWith(olTypeLower))
            //    {
            //        elem.OuterHtml = ReplaceFirst(figElem, olTypeLower, olTypeRomanU);
            //    }
            //    else if (figElem.StartsWith(olTypeRomanU))
            //    {
            //        elem.OuterHtml = ReplaceFirst(figElem, olTypeRomanU, olTypeRomanL);
            //    }
            //    else if (figElem.StartsWith(olTypeRomanL))
            //    {
            //        elem.OuterHtml = ReplaceFirst(figElem, olTypeRomanL, olRegular);
            //    }
            //}
     


            

            //if (elem.OuterHtml.StartsWith("<figure") || elem.OuterHtml.StartsWith("<FIGURE"))
            //{
            //    HtmlElementCollection kids = elem.Children;

            //    foreach (HtmlElement child in kids)
            //    {

            //        if (child.TagName.ToLower().Equals("img"))
            //        {
            //            isImage = true;
            //        }
            //        if (child.TagName.ToLower().Equals("div"))
            //        {
            //            isDiv = true;
            //        }
            //        if (isDiv == true && child.OuterHtml.ToLower().Contains("<math"))
            //        {
            //            isMath = true;
            //        }
            //        //Console.WriteLine(child.OuterHtml);

            //    }
            //    //Console.WriteLine("Is Image: " + isImage + " Is Div:" + isDiv + " Is Math: " + isMath);



            //    if (isImage && !isDiv && !isMath)
            //    {
            //        string figCapt = "<figcaption";
            //        string figCaptEnd = "</figcaption>";

            //        string openTag = "&lt;";
            //        string endTag = "&gt;";

            //        string closeTag = ">";

            //        string titleStart = "title=\"";
            //        string titleEnd = "\" ";

            //        string heightStart = "height=\"";

            //        string widthStart = "width=\"";

            //        string srcStart = "src=\"";

            //        string width = "";
            //        string height = "";

            //        string figCaption = "";

            //        string tag = "";

            //        string altText = "";

            //        string title = "";

            //        string imgSrc = "";

            //        string altImgSrc = "";

            //        bool hasAltImg = true;

            //        string figElem = elem.OuterHtml;

                   
            //        if (figElem.Contains(heightStart) && System.Char.IsDigit(figElem.ElementAt(figElem.IndexOf(heightStart) + heightStart.Length)))
            //        {
                        
            //            for (int i = figElem.IndexOf(heightStart) + heightStart.Length; i < figElem.Length; i++)
            //            {
            //                if (System.Char.IsDigit(figElem.ElementAt(i))){
            //                    height = height + figElem.ElementAt(i);
            //                }
            //                else
            //                {
            //                    break;
            //                }
                                
            //            }
            //            //height = figElem.Substring(figElem.IndexOf(heightStart) + heightStart.Length, figElem.IndexOf(titleEnd) - figElem.IndexOf(heightStart) - heightStart.Length);
            //        }

            //        if (figElem.Contains(widthStart) && System.Char.IsDigit(figElem.ElementAt(figElem.IndexOf(widthStart) + widthStart.Length)))
            //        {

            //            for (int i = figElem.IndexOf(widthStart) + widthStart.Length; i < figElem.Length; i++)
            //            {
            //                if (System.Char.IsDigit(figElem.ElementAt(i)))
            //                {
            //                    width = width + figElem.ElementAt(i);
            //                }
            //                else
            //                {
            //                    break;
            //                }

            //            }
            //            //width = figElem.Substring(figElem.IndexOf(widthStart) + widthStart.Length, figElem.IndexOf(titleEnd) - figElem.IndexOf(widthStart) - widthStart.Length);
            //        }

                 
            //        string floatValue = "none";

            //        if (figElem.Contains("float : left") || figElem.Contains("float: left") || figElem.Contains("float :left") || figElem.Contains("float:left"))
            //        {
            //            Console.WriteLine(figElem);
            //            floatValue = "left";
                               
            //        }
            //        else if (figElem.Contains("float : right") || figElem.Contains("float: right") || figElem.Contains("float :right") || figElem.Contains("float:right"))
            //        {
            //            Console.WriteLine(figElem);
            //            floatValue = "right";

            //        }


            //        foreach (HtmlElement child in kids)
            //        {
            //            string s = child.OuterHtml;
            //            if (s.ToLower().Contains(figCapt))
            //            {
            //                int first = s.IndexOf(figCapt);

            //                int end = s.IndexOf(figCaptEnd);


            //                int bracketTerminateIndex = 0;
            //                bool endMode = true;
            //                for (int i = 0; i < end - first; i++)
            //                {
            //                    if (s[first + i] == '<')
            //                    {
            //                        endMode = false;
            //                    }

            //                    if (s[first + i] == '>')
            //                    {

            //                        if (endMode == false)
            //                        {
            //                            endMode = true;
            //                        }
            //                        else
            //                        {
            //                            bracketTerminateIndex = i;
            //                        }
            //                    }
            //                }



            //                figCaption = s.Substring(s.IndexOf(figCapt) + figCapt.Length + bracketTerminateIndex, s.IndexOf(figCaptEnd) - bracketTerminateIndex - s.IndexOf(figCapt) - figCapt.Length);
            //                figCaption = figCaption.Substring(figCaption.IndexOf(">") + 1);
            //                //figCaption = s.Substring(s.IndexOf(figCapt) + figCapt.Length, s.IndexOf(figCaptEnd) - s.IndexOf(figCapt) - figCapt.Length);                           
            //            }

            //            if (s.ToLower().Contains(openTag) && s.ToLower().Contains("<p"))
            //            {
            //                tag = s.Substring(s.IndexOf(openTag) + openTag.Length, s.IndexOf(endTag) - s.IndexOf(openTag) - openTag.Length);
            //                altText = s.Substring(s.IndexOf(endTag) + endTag.Length, s.LastIndexOf(openTag) - s.IndexOf(endTag) - endTag.Length);
            //            }

            //            //TODO proper ways of finding the end of src
            //            if (s.ToLower().Contains("<img") && s.Contains("imageOthers") && s.ToLower().Contains("src"))
            //            {
            //                imgSrc = s.Substring(s.IndexOf(srcStart) + srcStart.Length, s.Length - 2 - s.IndexOf(srcStart) - srcStart.Length);

            //                if (imgSrc.Contains("file:///"))
            //                {
            //                    imgSrc = imgSrc.Replace("file:///", "");
            //                }

            //                int titleStartIndex = s.IndexOf(titleStart);
            //                int titleEndIndex = 0;
            //                string shorterString = s;

            //                for (int i = titleStartIndex; i < s.Length + titleStartIndex; i++)
            //                {

            //                    if (s.Substring(i).StartsWith(titleEnd))
            //                    {
            //                        titleEndIndex = i;
            //                        break;
            //                    }

            //                }
 
            //                title = s.Substring(titleStartIndex + titleStart.Length, titleEndIndex - titleStartIndex - titleStart.Length);

            //                //title = s.Substring(s.IndexOf(titleStart) + titleStart.Length, s.IndexOf(titleEnd) - s.IndexOf(titleStart) - titleStart.Length);
            //            }
                        
            //            if (s.ToLower().Contains("<img") && s.Contains("imageImpaired"))
            //            {                  
            //                string impS = s.Substring(s.IndexOf("imageImpaired"));
                           
            //                altImgSrc = impS.Substring(impS.IndexOf(srcStart) + srcStart.Length, impS.Length - 2 - impS.IndexOf(srcStart) - srcStart.Length);
            //            }

            //        }
           
            //        if (imgSrc.Equals(altImgSrc))
            //        {
            //            hasAltImg = false;
            //            altImgSrc = "";
            //        }

            //        string oldElem = elem.OuterHtml;
            //        //elem.OuterHtml = "";
            //        HTMLEditor.Document.ExecCommand("Delete", false, null);



            //        HTMLEditor.Document.ExecCommand("formatBlock", false, "<p>");

            //        ImageDialogBox idb = new ImageDialogBox(doc, getImageFolder(), language, imgSrc, title, altText, figCaption, tag, altImgSrc, width, height, floatValue);
            //        idb.ShowDialog();
                    
            //        if (idb.DialogResult.Equals(DialogResult.Cancel))
            //        {
            //            dynamic currentLocation = doc.selection.createRange();
            //            currentLocation.pasteHTML(oldElem);
            //        }
            //        fileEdited = true;
            //        fileNotSaved = true;

            //        refreshBrowsers();

            //    }

            //    if (isImage && isDiv && isMath)
            //    {
            //        string figCapt = "<figcaption";
            //        string figCaptEnd = "</figcaption>";

            //        string titleStart = "title=\"";
            //        string titleEnd = "\" ";

            //        string figCaption = "";

            //        string mathCode = "";

            //        string title = "";

            //        string figElem = elem.OuterHtml;

            //        string floatValue = "none";

            //        if (figElem.Contains("float : left") || figElem.Contains("float: left") || figElem.Contains("float :left") || figElem.Contains("float:left"))
            //        {
            //            //Console.WriteLine(figElem);
            //            floatValue = "left";

            //        }
            //        else if (figElem.Contains("float : right") || figElem.Contains("float: right") || figElem.Contains("float :right") || figElem.Contains("float:right"))
            //        {
            //            //Console.WriteLine(figElem);
            //            floatValue = "right";

            //        }

            //        foreach (HtmlElement child in kids)
            //        {
            //            string s = child.OuterHtml;

            //            if (s.ToLower().Contains(figCapt))
            //            {
            //                int first = s.IndexOf(figCapt);

            //                int end = s.IndexOf(figCaptEnd);


            //                int bracketTerminateIndex = 0;
            //                bool endMode = true;
            //                for (int i = 0; i < end - first; i++)
            //                {
            //                    if (s[first + i] == '<')
            //                    {
            //                        endMode = false;
            //                    }

            //                    if (s[first + i] == '>')
            //                    {

            //                        if (endMode == false)
            //                        {
            //                            endMode = true;
            //                        }
            //                        else
            //                        {
            //                            bracketTerminateIndex = i;
            //                        }
            //                    }
            //                }



            //                figCaption = s.Substring(s.IndexOf(figCapt) + figCapt.Length + bracketTerminateIndex, s.IndexOf(figCaptEnd) - bracketTerminateIndex - s.IndexOf(figCapt) - figCapt.Length);
            //                figCaption = figCaption.Substring(figCaption.IndexOf(">") + 1);

            //            }

            //            if (s.ToLower().Contains("$") && s.ToLower().Contains("<p"))
            //            {
            //                mathCode = s.Substring(s.IndexOf(">") + 2, s.LastIndexOf("<") - s.IndexOf(">") - 3);
            //            }

            //            if (s.ToLower().Contains("<div class") && s.ToLower().Contains("title") && s.ToLower().Contains("class=\"math\""))
            //            {
            //                int titleStartIndex = s.IndexOf(titleStart);
            //                int titleEndIndex = 0;
            //                string shorterString = s;         

            //                for (int i = titleStartIndex; i < s.Length + titleStartIndex; i++)
            //                {

            //                    if (s.Substring(i).StartsWith(titleEnd))
            //                    {
            //                        titleEndIndex = i;
            //                        break;
            //                    }

            //                }

            //                //while  (continueTitleSearch)
            //                //{
            //                //    titleEndIndex = shorterString.IndexOf(titleEnd) + titleEndIndex;

            //                //    if (titleEndIndex > titleStartIndex)
            //                //    {                               
            //                //        continueTitleSearch = false;
            //                //    }
            //                //    else
            //                //    {
            //                //        shorterString = shorterString.Substring(shorterString.IndexOf(titleEnd) + titleEnd.Length);
            //                //    }
            //                //    Console.WriteLine(shorterString);
            //                //}
            //                //Console.WriteLine(s.Substring(titleStartIndex));
            //                title = s.Substring(titleStartIndex + titleStart.Length, titleEndIndex - titleStartIndex - titleStart.Length);
            //                //Console.WriteLine("TITLE " + s.Substring(titleStartIndex + titleStart.Length, titleEndIndex - titleStartIndex - titleStart.Length));
            //                //title = s.Substring(s.IndexOf(titleStart) + titleStart.Length, s.IndexOf(titleEnd) - s.IndexOf(titleStart) - titleStart.Length);
            //                //Console.WriteLine("title " + title);
            //            }

            //        }

            //        string oldElem = elem.OuterHtml;
            //        //elem.OuterHtml = "";
            //        HTMLEditor.Document.ExecCommand("Delete", false, null);



            //        HTMLEditor.Document.ExecCommand("formatBlock", false, "<p>");

            //        MathDialogBox mdb = new MathDialogBox(doc, getImageFolder(), mathCode, title, figCaption, floatValue);
            //        mdb.ShowDialog();

            //        if (mdb.DialogResult.Equals(DialogResult.Cancel))
            //        {
            //            dynamic currentLocation = doc.selection.createRange();
            //            currentLocation.pasteHTML(oldElem);
            //        }
            //        fileEdited = true;
            //        fileNotSaved = true;

            //        refreshBrowsers();
            //    }



            //    //Console.WriteLine(elem.FirstChild.OuterHtml);
            //    //Console.WriteLine(elemChild.OuterHtml);
            //    //while (elemChild.NextSibling != null) {
            //    //    HtmlElement nextChild = elemChild.NextSibling;
            //    //    Console.WriteLine(nextChild.OuterHtml);
            //    //    elemChild = elemChild.NextSibling;
            //    //}

            //    //if (elem.OuterHtml.StartsWith("<math") || elem.OuterHtml.StartsWith("<MATH"))
            //    //{
            //    //    Console.WriteLine(elem.FirstChild.OuterHtml);
            //    //}
            //}

            ////try
            ////{
            ////    HtmlElement elem = e.FromElement;
            ////    string bla = elem.Document.Body.InnerText;
            ////   // Console.WriteLine("DOUBLECLICKED: " + bla);
            ////   // HTMLAnchorElement anchor;

            ////}
            ////catch (Exception ee)
            ////{
            ////    Console.WriteLine("THIS IS AN DOUBLE CLICK EXCEPTION");
            ////    //Console.WriteLine(ee.ToString());
            ////}
        }

        /* Method is used to for editing images, math and tables. It also allows the bullet point style to chagne */
        private void identifyElement(HtmlElement elem)
        {
            HtmlElementCollection elems = HTMLEditor.Document.GetElementsByTagName(elem.TagName);
            //Console.WriteLine("HTMLelement " + HTMLEditor.Document.ActiveElement.TagName);
            //Console.WriteLine("Point " + BrowserCoord.X + "," + BrowserCoord.Y + " outerHTML " + elem.OuterHtml);


            bool isImage = false;
            bool isMath = false;
            bool isDiv = false;
            bool imageClicked = false;

            string ulRegular = "<ul>";

            //string ulDiscA = "<ul style=\"list-style-type:disc;\">";
            //string ulCircleA = "<ul style=\"list-style-type:circle;\">";
            //string ulSquareA = "<ul style=\"list-style-type:square;\">";

            string ulDisc = "<ul style=\"list-style-type: disc;\">";
            string ulCircle = "<ul style=\"list-style-type: circle;\">";
            string ulSquare = "<ul style=\"list-style-type: square;\">";


            if (elem.OuterHtml.StartsWith("<ul"))
            {
                string figElem = elem.OuterHtml;

                if (figElem.ToLower().StartsWith(ulRegular) || figElem.ToLower().StartsWith(ulDisc))
                {
                    //elem.OuterHtml = ReplaceFirst(figElem, ulRegular, ulCircle);
                    elem.OuterHtml = ReplaceFirst(figElem.ToLower(), ulRegular, ulCircle);
                }
                else if (figElem.ToLower().StartsWith(ulCircle))
                {
                    //elem.OuterHtml = ReplaceFirst(figElem, ulCircle, ulSquare);
                    elem.OuterHtml = ReplaceFirst(figElem.ToLower(), ulCircle, ulSquare);
                }
                else if (figElem.ToLower().StartsWith(ulSquare))
                {
                    //elem.OuterHtml = ReplaceFirst(figElem, ulSquare, ulRegular);
                    elem.OuterHtml = ReplaceFirst(figElem.ToLower(), ulSquare, ulRegular);
                }

            }

            string olRegular = "<ol>";
            string olTypeNum = "<ol type=\"1\">";
            string olTypeUpper = "<ol type=\"A\">";
            string olTypeLower = "<ol type=\"a\">";
            string olTypeRomanU = "<ol type=\"I\">";
            string olTypeRomanL = "<ol type=\"i\">";

            if (elem.OuterHtml.StartsWith("<ol"))
            {
                string figElem = elem.OuterHtml;

                if (figElem.StartsWith(olRegular) || figElem.StartsWith(olTypeNum))
                {
                    elem.OuterHtml = ReplaceFirst(figElem, olRegular, olTypeUpper);
                }
                else if (figElem.StartsWith(olTypeUpper))
                {
                    elem.OuterHtml = ReplaceFirst(figElem, olTypeUpper, olTypeLower);
                }
                else if (figElem.StartsWith(olTypeLower))
                {
                    elem.OuterHtml = ReplaceFirst(figElem, olTypeLower, olTypeRomanU);
                }
                else if (figElem.StartsWith(olTypeRomanU))
                {
                    elem.OuterHtml = ReplaceFirst(figElem, olTypeRomanU, olTypeRomanL);
                }
                else if (figElem.StartsWith(olTypeRomanL))
                {
                    elem.OuterHtml = ReplaceFirst(figElem, olTypeRomanL, olRegular);
                }
            }

            if (elem.TagName.StartsWith("TABLE"))
            {
                int rows = 0;
                int cols = 0;
                int rowCount = 0;
                int colCount = 0;

                string titleStart = "title=\"";
                string titleEnd = "\">";

                string oldElem = elem.OuterHtml;

                string s = elem.OuterHtml;

                int titleStartIndex = s.IndexOf(titleStart) + titleStart.Length;
                int titleEndIndex = 0;
                string shorterString = s;
                string title = "";

                if (elem.OuterHtml.Contains(titleStart))
                {
                    for (int i = titleStartIndex; i < s.Length + titleStart.Length; i++)
                    {
                        //Console.Write(s[i]);
                        if (s.Substring(i).StartsWith(titleEnd))
                        {
                            titleEndIndex = i;
                            break;
                        }
                    }
                    title = s.Substring(titleStartIndex, titleEndIndex - titleStartIndex);
                }
              

                //Console.WriteLine(s.Substring(titleStartIndex + titleStart.Length, titleEndIndex - titleStartIndex));
               
                //Console.WriteLine("TITLE: " + title);

                DataGridView table = new DataGridView();
                foreach (HtmlElement a in elem.FirstChild.Children)
                {                                     
                    foreach (HtmlElement b in a.Children)
                    {                   
                        cols++;
                    }

                    rows++;
                }

                cols = cols / rows;

                table.RowCount = rows;
                table.ColumnCount = cols;

                foreach (HtmlElement a in elem.FirstChild.Children)
                {

                    //Console.WriteLine(a.OuterHtml);
                    foreach (HtmlElement b in a.Children)
                    {
                        table.Rows[rowCount].Cells[colCount].Value = b.InnerHtml;
                        //Console.WriteLine(b.InnerHtml);
                        colCount++;
                    }
                    colCount = 0;
                    rowCount++;
                }
                elem.OuterHtml = "";
                HTMLEditor.Document.ExecCommand("Delete", false, null);

                HTMLEditor.Document.ExecCommand("formatBlock", false, "<p>");

                //for (int i = 0; i < rows; ++i)
                //{
                //    for (int j = 0; j < cols; ++j)
                //    {
                //       Console.WriteLine("Row: " + i + ", Col: " + j + ": " +table.Rows[i].Cells[j].Value);
                //    }
                //}

                //Console.WriteLine("Rows: " + rows);
                //Console.WriteLine("Cols: " + cols);

                TableDialogBox tdb = new TableDialogBox(doc, table, title);
                tdb.ShowDialog();


                if (tdb.DialogResult.Equals(DialogResult.Cancel))
                {
                   
                    dynamic currentLocation = doc.selection.createRange();
                    currentLocation.pasteHTML(oldElem);
                }

                fileEdited = true;
                fileNotSaved = true;

                refreshBrowsers();

            }


            if (elem.TagName.StartsWith("IMG"))
            {

                if (elem.Parent.TagName.StartsWith("FIGURE"))
                {
                    elem = elem.Parent;
                    imageClicked = true;   
                }
               
               
            }



            if (elem.OuterHtml.StartsWith("<figure") || elem.OuterHtml.StartsWith("<FIGURE"))
            {
                HtmlElementCollection kids = elem.Children;

                foreach (HtmlElement child in kids)
                {

                    if (child.TagName.ToLower().Equals("img"))
                    {
                        isImage = true;
                    }
                    if (child.TagName.ToLower().Equals("div"))
                    {
                        isDiv = true;
                    }
                    if (isDiv == true && child.OuterHtml.ToLower().Contains("<math"))
                    {
                        isMath = true;
                    }
                    //Console.WriteLine(child.OuterHtml);

                }
                //Console.WriteLine("Is Image: " + isImage + " Is Div:" + isDiv + " Is Math: " + isMath);



                if (isImage && !isDiv && !isMath)
                {
                    string figCapt = "<figcaption";
                    string figCaptEnd = "</figcaption>";

                    string openTag = "&lt;";
                    string endTag = "&gt;";

                    string closeTag = ">";

                    string titleStart = "title=\"";
                    string titleEnd = "\" ";
                    string titleEnd2 = "\"/";



                    string heightStart = "height=\"";

                    string widthStart = "width=\"";

                    string srcStart = "src=\"";

                    string width = "";
                    string height = "";

                    string figCaption = "";

                    string tag = "";

                    string altText = "";

                    string title = "";

                    string imgSrc = "";

                    string altImgSrc = "";

                    bool hasAltImg = true;

                    string figElem = elem.OuterHtml;


                    if (figElem.Contains(heightStart) && System.Char.IsDigit(figElem.ElementAt(figElem.IndexOf(heightStart) + heightStart.Length)))
                    {

                        for (int i = figElem.IndexOf(heightStart) + heightStart.Length; i < figElem.Length; i++)
                        {
                            if (System.Char.IsDigit(figElem.ElementAt(i)))
                            {
                                height = height + figElem.ElementAt(i);
                            }
                            else
                            {
                                break;
                            }

                        }
                        //height = figElem.Substring(figElem.IndexOf(heightStart) + heightStart.Length, figElem.IndexOf(titleEnd) - figElem.IndexOf(heightStart) - heightStart.Length);
                    }

                    if (figElem.Contains(widthStart) && System.Char.IsDigit(figElem.ElementAt(figElem.IndexOf(widthStart) + widthStart.Length)))
                    {

                        for (int i = figElem.IndexOf(widthStart) + widthStart.Length; i < figElem.Length; i++)
                        {
                            if (System.Char.IsDigit(figElem.ElementAt(i)))
                            {
                                width = width + figElem.ElementAt(i);
                            }
                            else
                            {
                                break;
                            }

                        }
                        //width = figElem.Substring(figElem.IndexOf(widthStart) + widthStart.Length, figElem.IndexOf(titleEnd) - figElem.IndexOf(widthStart) - widthStart.Length);
                    }


                    string floatValue = "none";

                    if (figElem.Contains("float : left") || figElem.Contains("float: left") || figElem.Contains("float :left") || figElem.Contains("float:left"))
                    {
                        //Console.WriteLine(figElem);
                        floatValue = "left";

                    }
                    else if (figElem.Contains("float : right") || figElem.Contains("float: right") || figElem.Contains("float :right") || figElem.Contains("float:right"))
                    {
                        //Console.WriteLine(figElem);
                        floatValue = "right";

                    }


                    foreach (HtmlElement child in kids)
                    {
                        string s = child.OuterHtml;
                        if (s.ToLower().Contains(figCapt))
                        {
                            int first = s.IndexOf(figCapt);

                            int end = s.IndexOf(figCaptEnd);


                            int bracketTerminateIndex = 0;
                            bool endMode = true;
                            for (int i = 0; i < end - first; i++)
                            {
                                if (s[first + i] == '<')
                                {
                                    endMode = false;
                                }

                                if (s[first + i] == '>')
                                {

                                    if (endMode == false)
                                    {
                                        endMode = true;
                                    }
                                    else
                                    {
                                        bracketTerminateIndex = i;
                                    }
                                }
                            }



                            figCaption = s.Substring(s.IndexOf(figCapt) + figCapt.Length + bracketTerminateIndex, s.IndexOf(figCaptEnd) - bracketTerminateIndex - s.IndexOf(figCapt) - figCapt.Length);
                            figCaption = figCaption.Substring(figCaption.IndexOf(">") + 1);
                            //figCaption = s.Substring(s.IndexOf(figCapt) + figCapt.Length, s.IndexOf(figCaptEnd) - s.IndexOf(figCapt) - figCapt.Length);                           
                        }

                        if (s.ToLower().Contains(openTag) && s.ToLower().Contains("<p"))
                        {
                            tag = s.Substring(s.IndexOf(openTag) + openTag.Length, s.IndexOf(endTag) - s.IndexOf(openTag) - openTag.Length);
                            altText = s.Substring(s.IndexOf(endTag) + endTag.Length, s.LastIndexOf(openTag) - s.IndexOf(endTag) - endTag.Length);
                        }

                        //TODO proper ways of finding the end of src
                        if (s.ToLower().Contains("<img") && s.Contains("imageOthers") && s.ToLower().Contains("src"))
                        {
                            imgSrc = s.Substring(s.IndexOf(srcStart) + srcStart.Length, s.Length - 2 - s.IndexOf(srcStart) - srcStart.Length);
  
                            if (imgSrc.Contains("file:///"))
                            {
                                imgSrc = imgSrc.Replace("file:///", "");
                            }
                           
                            int titleStartIndex = s.IndexOf(titleStart);
                            int titleEndIndex = 0;
                            string shorterString = s;

                            for (int i = titleStartIndex; i < s.Length + titleStartIndex; i++)
                            {

                                if (s.Substring(i).StartsWith(titleEnd) || s.Substring(i).StartsWith(titleEnd2))
                                {
                                    titleEndIndex = i;
                                    break;
                                }

                            }

                            title = s.Substring(titleStartIndex + titleStart.Length, titleEndIndex - titleStartIndex - titleStart.Length);
                       
                            //title = s.Substring(s.IndexOf(titleStart) + titleStart.Length, s.IndexOf(titleEnd) - s.IndexOf(titleStart) - titleStart.Length);
                        }

                        if (s.ToLower().Contains("<img") && s.Contains("imageImpaired"))
                        {
                            string impS = s.Substring(s.IndexOf("imageImpaired"));

                            altImgSrc = impS.Substring(impS.IndexOf(srcStart) + srcStart.Length, impS.Length - 2 - impS.IndexOf(srcStart) - srcStart.Length);
                        }

                    }

                    if (imgSrc.Equals(altImgSrc))
                    {
                        hasAltImg = false;
                        altImgSrc = "";
                    }


                    string oldElem = elem.OuterHtml;
                    //elem.OuterHtml = "";
                    //HTMLEditor.Document.ExecCommand("Delete", false, null);

                    if (imageClicked)
                    {
                        HTMLEditor.Document.ExecCommand("Delete", false, null);
                        elem.OuterHtml = "";
                    }
                    else
                    {
                        elem.OuterHtml = "";
                        HTMLEditor.Document.ExecCommand("Delete", false, null);
                    }

                  


                    //HTMLEditor.Document.ExecCommand("formatBlock", false, "<p>");

                    ImageDialogBox idb = new ImageDialogBox(doc, getImageFolder(), language, imgSrc, title, altText, figCaption, tag, altImgSrc, width, height, floatValue);
                    idb.ShowDialog();   

                    if (idb.DialogResult.Equals(DialogResult.Cancel))
                    {
                        HTMLEditor.Document.ExecCommand("Undo", false, null);
                        HTMLEditor.Document.ExecCommand("Undo", false, null);
                        //dynamic currentLocation = doc.selection.createRange();
                        //currentLocation.pasteHTML(oldElem);
                    }
                    fileEdited = true;
                    fileNotSaved = true;

                    refreshBrowsers();

                }

                if (isImage && isDiv && isMath)
                {
                    string figCapt = "<figcaption";
                    string figCaptEnd = "</figcaption>";

                    string titleStart = "title=\"";
                    string titleEnd = "\" ";
                    string titleEnd2 = "\"/";


                    string figCaption = "";

                    string mathCode = "";

                    string title = "";

                    string figElem = elem.OuterHtml;

                    string floatValue = "none";

                    if (figElem.Contains("float : left") || figElem.Contains("float: left") || figElem.Contains("float :left") || figElem.Contains("float:left"))
                    {
                        //Console.WriteLine(figElem);
                        floatValue = "left";

                    }
                    else if (figElem.Contains("float : right") || figElem.Contains("float: right") || figElem.Contains("float :right") || figElem.Contains("float:right"))
                    {
                        //Console.WriteLine(figElem);
                        floatValue = "right";

                    }

                    foreach (HtmlElement child in kids)
                    {
                        string s = child.OuterHtml;

                        if (s.ToLower().Contains(figCapt))
                        {
                            int first = s.IndexOf(figCapt);

                            int end = s.IndexOf(figCaptEnd);


                            int bracketTerminateIndex = 0;
                            bool endMode = true;
                            for (int i = 0; i < end - first; i++)
                            {
                                if (s[first + i] == '<')
                                {
                                    endMode = false;
                                }

                                if (s[first + i] == '>')
                                {

                                    if (endMode == false)
                                    {
                                        endMode = true;
                                    }
                                    else
                                    {
                                        bracketTerminateIndex = i;
                                    }
                                }
                            }



                            figCaption = s.Substring(s.IndexOf(figCapt) + figCapt.Length + bracketTerminateIndex, s.IndexOf(figCaptEnd) - bracketTerminateIndex - s.IndexOf(figCapt) - figCapt.Length);
                            figCaption = figCaption.Substring(figCaption.IndexOf(">") + 1);

                        }

                        if (s.ToLower().Contains("$") && s.ToLower().Contains("<p"))
                        {
                            mathCode = s.Substring(s.IndexOf(">") + 2, s.LastIndexOf("<") - s.IndexOf(">") - 3);
                        }

                        if (s.ToLower().Contains("<div class") && s.ToLower().Contains("title") && s.ToLower().Contains("class=\"math\""))
                        {
                            int titleStartIndex = s.IndexOf(titleStart);
                            int titleEndIndex = 0;
                            string shorterString = s;

                            for (int i = titleStartIndex; i < s.Length + titleStartIndex; i++)
                            {

                                if (s.Substring(i).StartsWith(titleEnd) || s.Substring(i).StartsWith(titleEnd2))
                                {
                                    titleEndIndex = i;
                                    break;
                                }

                            }

                            //while  (continueTitleSearch)
                            //{
                            //    titleEndIndex = shorterString.IndexOf(titleEnd) + titleEndIndex;

                            //    if (titleEndIndex > titleStartIndex)
                            //    {                               
                            //        continueTitleSearch = false;
                            //    }
                            //    else
                            //    {
                            //        shorterString = shorterString.Substring(shorterString.IndexOf(titleEnd) + titleEnd.Length);
                            //    }
                            //    Console.WriteLine(shorterString);
                            //}
                            //Console.WriteLine(s.Substring(titleStartIndex));
                            title = s.Substring(titleStartIndex + titleStart.Length, titleEndIndex - titleStartIndex - titleStart.Length);
                            //Console.WriteLine("TITLE " + s.Substring(titleStartIndex + titleStart.Length, titleEndIndex - titleStartIndex - titleStart.Length));
                            //title = s.Substring(s.IndexOf(titleStart) + titleStart.Length, s.IndexOf(titleEnd) - s.IndexOf(titleStart) - titleStart.Length);
                            //Console.WriteLine("title " + title);
                        }

                    }

                    string oldElem = elem.OuterHtml;


                    if (imageClicked)
                    {
                        HTMLEditor.Document.ExecCommand("Delete", false, null);
                        elem.OuterHtml = "";
                    }
                    else
                    {
                        elem.OuterHtml = "";
                        HTMLEditor.Document.ExecCommand("Delete", false, null);
                    }


                    HTMLEditor.Document.ExecCommand("formatBlock", false, "<p>");

                    MathDialogBox mdb = new MathDialogBox(doc, getImageFolder(), mathCode, title, figCaption, floatValue);
                    mdb.ShowDialog();

                    if (mdb.DialogResult.Equals(DialogResult.Cancel))
                    {
                        dynamic currentLocation = doc.selection.createRange();                      
                        currentLocation.pasteHTML(oldElem);
                    }
                    fileEdited = true;
                    fileNotSaved = true;

                    refreshBrowsers();
                }



                //Console.WriteLine(elem.FirstChild.OuterHtml);
                //Console.WriteLine(elemChild.OuterHtml);
                //while (elemChild.NextSibling != null) {
                //    HtmlElement nextChild = elemChild.NextSibling;
                //    Console.WriteLine(nextChild.OuterHtml);
                //    elemChild = elemChild.NextSibling;
                //}

                //if (elem.OuterHtml.StartsWith("<math") || elem.OuterHtml.StartsWith("<MATH"))
                //{
                //    Console.WriteLine(elem.FirstChild.OuterHtml);
                //}
            }

            //try
            //{
            //    HtmlElement elem = e.FromElement;
            //    string bla = elem.Document.Body.InnerText;
            //   // Console.WriteLine("DOUBLECLICKED: " + bla);
            //   // HTMLAnchorElement anchor;

            //}
            //catch (Exception ee)
            //{
            //    Console.WriteLine("THIS IS AN DOUBLE CLICK EXCEPTION");
            //    //Console.WriteLine(ee.ToString());
            //}
        }

        void timer_Tick(object sender, EventArgs e)
        {
            // 'Raise event
            if (containsFile == true && fileEdited == true)
            {
                refreshBrowsers();
                //HTMLEditor.Document.Focus();
                updateFontFormat();            
            }
        }
            

        private void updateHeaderList()
        {
            headerTreeView.Nodes.Clear();
            figureTreeView.Nodes.Clear();
            //List<HtmlElement> headerOrder = new List<HtmlElement>();
            //Dictionary<HtmlElement, string> headerMap = new Dictionary<HtmlElement, string>();
             
            foreach (HtmlElement el in HTMLEditor.Document.Body.Children)
            {
                if ((el.TagName == "H1") || (el.TagName == "H2") || (el.TagName == "H3") || (el.TagName == "H4") || (el.TagName == "H5") || (el.TagName == "H6"))
                {
                    //headerOrder.Add(el);
                    //headerMap.Add(el, el.InnerText);
                    headerTreeView.Nodes.Add(el.OuterHtml, el.InnerText);
                }
              

                if ((el.TagName == "FIGURE"))
                {
                    //Console.WriteLine(el.OuterHtml);

                    string s = el.OuterHtml;
                    string titleStart = "title=\"";
                    string titleEnd = "\" ";
                    string title = "";
                    int titleStartIndex = s.IndexOf(titleStart);
                    int titleEndIndex = 0;
                    string shorterString = s;

                    string tag = "";


                    string altBeg = "alttext=\"";
                    string altText = "";

                    string openTag = "&lt;";
                    string endTag = "&gt;";
                    string nodeValue = "";

                    if (s.ToLower().Contains(altBeg))
                    {
                        for (int i = s.IndexOf(altBeg) + altBeg.Length; s[i] != '\"'; i++ )
                        {
                            altText = altText + s[i];
                        }
                        
                        
                        nodeValue = altText;
                    }
                    else
                    {
                        for (int i = titleStartIndex; i < s.Length + titleStartIndex; i++)
                        {

                            if (s.Substring(i).StartsWith(titleEnd))
                            {
                                titleEndIndex = i;
                                break;
                            }

                        }

                        title = s.Substring(titleStartIndex + titleStart.Length, titleEndIndex - titleStartIndex - titleStart.Length);
                        nodeValue = title;
                    }

          
                    //Console.WriteLine(nodeValue);

                    figureTreeView.Nodes.Add(el.OuterHtml, nodeValue);
                }
                //el.ScrollIntoView(true);
            }
        }


        /* Updates the preview to reflect the editor's contents */
        private void refreshBrowsers()
        {
            //Gecko.GeckoDocument.StyleSheetCollection styleSheets12 = geckoWebBrowser1.Document.StyleSheets;
            //GeckoStyleSheet styleSheet12 = geckoWebBrowser1.Document.StyleSheets.First();
            //Console.WriteLine("CSS Text1: " + GetCssText(styleSheet12) + "CSS End");

            /* CSS style of browser which is slightly different to the Accessible EPUB standard */
            IHTMLStyleSheet ss = doc.createStyleSheet("", 0);
            ss.cssText = @"html *
{
	font-family: ""Arial"", Helvetica, sans-serif !important;

        }
        p {
  font-size:16px;

word-wrap: break-word;
}

figure {
	padding: 2px;
	max-width : 95%;
    border: double 4px;
}

figcaption {
	word-wrap: break-word;
	max-width : 100%;
  font-size:16px;
}

img {
	max-width : 100%;
    margin: 10px
}


object {
  max-width : 100%; 
}

math {
  max-width : 100%;

}

table, th, td, tr, tbody {
      border-style: double;
    border-collapse: collapse;
    border-width:4px;
  text-align: center;
}

.transparent {
  display: none;
  color: transparent;
}

body {
	width: 100%;
	margin-left: 2px;
	margin-right: auto;
}

.math {

    display:none;
    height:0%;

}

.mathImpaired {

    display:none;
    height:0%;
}

.imageImpaired {
    display: none;
}

.imageOthers {
    max - width : 100 %;
    display: initial;
}


;"
;
            if (refresh == false)
            {
                return;
            }

            if (fileEdited == false)
            {
                return;
            }


            wysiwygToHtml();

            //if (contentFile != Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml"))
            //{
            //    Console.WriteLine("Called");
            //    return;
            //}

            if (mode == (int)fileMode.singleFileJs && contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml")))
            {

                //Console.WriteLine(geckoWebBrowser1.Document.Head.InnerHtml);

                //File.Copy(contentFile, Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "ViContent.xhtml"));
                //File.Copy(contentFile, Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "ImpContent.xhtml"));
                //File.Copy(contentFile, Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "BliContent.xhtml"));



                if (File.Exists(impairedContentFile))
                {
                    File.Delete(impairedContentFile);
                }

                if (File.Exists(blindContentFile))
                {
                    File.Delete(blindContentFile);
                }



                string cssString = "style.css";
                string impCssString = "impaired.css";
                string bliCssString = "blind.css";

                string impFile = File.ReadAllText(contentFile);
                string bliFile = impFile;

                impFile = impFile.Replace(cssString, impCssString);
                bliFile = bliFile.Replace(cssString, bliCssString);

                File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile)), impFile);
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile)), bliFile);



                //geckoWebBrowser1.Document.Head.InnerHtml = geckoWebBrowser1.Document.Head.InnerHtml.Replace(styleCss, vCss);
                //geckoWebBrowser2.Document.Head.InnerHtml = geckoWebBrowser2.Document.Head.InnerHtml.Replace(styleCss, iCss);
                //geckoWebBrowser3.Document.Head.InnerHtml = geckoWebBrowser3.Document.Head.InnerHtml.Replace(styleCss, bCss);

                //string visibleCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "visible.css");
                //string impairedCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "impaired.css");
                //string blindCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "blind.css");

                //geckoWebBrowser1.Document.Head.Style.CssText = File.ReadAllText(visibleCss);
                //geckoWebBrowser2.Document.Head.Style.CssText = File.ReadAllText(impairedCss);
                //geckoWebBrowser3.Document.Head.Style.CssText = File.ReadAllText(blindCss);


                //string visContent = File.ReadAllText(visibleCss);
                //string impContent = File.ReadAllText(impairedCss);
                //string bliContent = File.ReadAllText(blindCss);


                //string visContent = File.ReadAllText(visibleCss);
                //string impContent = File.ReadAllText(impairedCss);
                //string bliContent = File.ReadAllText(blindCss);



                //string visContent = "@import url(\"file:///" + Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "visible.css") + "\");";
                //string impContent = "@import url(\"file:///" + Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "impaired.css") + "\");";
                //string bliContent = "@import url(\"file:///" + Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "blind.css") + "\");";

                //visContent = visContent.Replace("\\", "/");
                //impContent = impContent.Replace("\\", "/");
                //bliContent = bliContent.Replace("\\", "/");



                //Gecko.GeckoDocument.StyleSheetCollection styleSheets1 = geckoWebBrowser1.Document.StyleSheets;
                //GeckoStyleSheet styleSheet1 = geckoWebBrowser1.Document.StyleSheets.First();
                ////Console.WriteLine("CSS Text1: " + GetCssText(styleSheet1) + "CSS End");
                //styleSheet1.CssRules.Clear();
                ////styleSheet1.CssRules.Add(visContent);

                //styleSheet1.CssRules.Insert(0, visContent);





                ////SetCssText(visContent, styleSheet1);
                ////Console.WriteLine("CSS Text1 Changed: " + GetCssText(styleSheet1) + "CSS End");

                //Gecko.GeckoDocument.StyleSheetCollection styleSheets2 = geckoWebBrowser2.Document.StyleSheets;
                //GeckoStyleSheet styleSheet2 = geckoWebBrowser2.Document.StyleSheets.First();
                ////Console.WriteLine("CSS Text2: " + GetCssText(styleSheet2) + "CSS End");
                //styleSheet2.CssRules.Clear();
                ////styleSheet2.CssRules.Add(impContent);
                //styleSheet2.CssRules.Insert(0, impContent);

                //Gecko.GeckoDocument.StyleSheetCollection styleSheets2a = geckoWebBrowser2.Document.StyleSheets;
                //GeckoStyleSheet styleSheet2a = geckoWebBrowser2.Document.StyleSheets.First();

                ////Console.WriteLine("CSS Text2a: " + GetCssText(styleSheet2a) + "CSS End");

                ////SetCssText(impContent, styleSheet2);
                ////Console.WriteLine("CSS Text2 Changed: " + GetCssText(styleSheet2) + "CSS End");

                //Gecko.GeckoDocument.StyleSheetCollection styleSheets3 = geckoWebBrowser3.Document.StyleSheets;
                //GeckoStyleSheet styleSheet3 = geckoWebBrowser3.Document.StyleSheets.First();
                ////Console.WriteLine("CSS Text3: " + GetCssText(styleSheet3) + "CSS End");
                //styleSheet3.CssRules.Clear();
                ////styleSheet3.CssRules.Add(bliContent);
                //styleSheet3.CssRules.Insert(0, bliContent);



                //SetCssText(bliContent, styleSheet3);
                //Console.WriteLine("CSS Text3 Changed: " + GetCssText(styleSheet3) + "CSS End");




                //var stylesheet1 = geckoWebBrowser1.Document.StyleSheets.First(x => x.Href.EndsWith("style.css"));
                //stylesheet1.CssRules.Clear();

                //stylesheet1.CssRules.Add(File.ReadAllText(visibleCss));

                //var stylesheet2 = geckoWebBrowser2.Document.StyleSheets.First(x => x.Href.EndsWith("style.css"));
                //stylesheet2.CssRules.Clear();

                //stylesheet2.CssRules.Add(File.ReadAllText(impairedCss));

                //var stylesheet3 = geckoWebBrowser3.Document.StyleSheets.First(x => x.Href.EndsWith("style.css"));
                //stylesheet3.CssRules.Clear();

                //stylesheet3.CssRules.Add(File.ReadAllText(blindCss));

                //Console.WriteLine(stylesheet1.CssRules.ToString());
            }

            //Gecko.GeckoDocument.StyleSheetCollection styleSheets13 = geckoWebBrowser1.Document.StyleSheets;
            //GeckoStyleSheet styleSheet13 = geckoWebBrowser1.Document.StyleSheets.First();
            ////Console.WriteLine("CSS Text1: " + GetCssText(styleSheet13) + "CSS End");

            //geckoWebBrowser1.Reload();

            //Gecko.GeckoDocument.StyleSheetCollection styleSheets14 = geckoWebBrowser1.Document.StyleSheets;
            //GeckoStyleSheet styleSheet14 = geckoWebBrowser1.Document.StyleSheets.First();
            //Console.WriteLine("CSS Text1: " + GetCssText(styleSheet14) + "CSS End");



            //geckoWebBrowser1.Reload();
            //geckoWebBrowser2.Reload();
            //geckoWebBrowser3.Reload();
            //geckoWebBrowser4.Reload();

            if (mode == (int)fileMode.singleFileJs)
            {
                geckoWebBrowser1.Navigate(contentFile);
           
                geckoWebBrowser2.Navigate(impairedContentFile);
                geckoWebBrowser3.Navigate(blindContentFile);
            }
            geckoWebBrowser4.Navigate(contentFile);
            


            fileEdited = false;
        }

        //private void HTMLEditorBodyMouseUp(object sender, System.Windows.Forms.HtmlElementEventArgs e)
        //{
        //    if (containsFile == true && fileEdited == true)
        //    {
        //        refreshBrowsers();
        //        //HTMLEditor.Document.Focus();
        //        updateFontFormat();
        //    }

        //}


        private void HTMLEditorBodyKeyUp(object sender, System.Windows.Forms.HtmlElementEventArgs e)
        {
          

            fileEdited = true;
            fileNotSaved = true;
            //refreshBrowsers();

            //HTMLEditor.Document.Focus();




            string bodyText = "";

         
            bodyText = HTMLEditor.Document.Body.InnerText;


            //for (int i = 0; i < bodyText.Length; i++)
            //{

            //    if (bodyText[i] == ' ' || bodyText[i] == '\n' || bodyText[i] == '\t' || bodyText[i] == '\r')
            //    {
            //        bodyText = bodyText.Substring(0, i - 1) + bodyText.Substring(i + 1);
            //    }
            //}

          
            if (bodyText == "" || containsFile == false)
            {
                return;
            }

            try
            {
                if (containsFile == true)
                {
                    string text = HTMLEditor.Document.Body.InnerText;
                    int wordCount = 0, index = 0;

                    while (index < text.Length)
                    {
                        // check if current char is part of a word
                        while (index < text.Length && !char.IsWhiteSpace(text[index]))
                            index++;

                        wordCount++;

                        // skip whitespace until next word
                        while (index < text.Length && char.IsWhiteSpace(text[index]))
                            index++;
                    }


                wordCountLabel.Text = origWordCountLabel + wordCount;

                characterCountLabel.Text = origCharacterCountLabel + text.Length;
                }

            }
            catch (System.Reflection.TargetInvocationException tie)
            {
                return;
            }
            catch (System.NullReferenceException ne)
            {
                return;
            }

            DateTime time = DateTime.UtcNow;

            if (lastSave.Year == time.Year)
            {
                TimeSpan span = time.Subtract(lastSave);


                lastSavedLabel.Text = origLastSavedLabel + span.Minutes + " Min";
            }

          

        }



        private void SetCssText(string cssText, GeckoStyleSheet gss)
        {
            gss.CssRules.Clear();
            gss.CssRules.Add(cssText);
            //foreach (string rule in System.Text.RegularExpressions.Regex.Split(cssText, @"(?<=[}])"))
            //{
            //    // skip any trailing whitespace
            //    if (!(rule.Contains("}")))
            //        continue;
            //    gss.CssRules.Add(rule);
            //}
        }

        public string GetCssText(GeckoStyleSheet gss)
        {
            var text = new StringBuilder();
            foreach (GeckoStyleRule rule in gss.CssRules)
            {
                text.Append(rule.CssText);
            }
            return text.ToString();
        }

        private void InitHeadingsList()
        {
            headings = new Dictionary<string, string>();

            //List<Tuple<string, string>> headings = new List<Tuple<string, string>>();
            headings.Add("Standard (Paragraph)", "<p>");
            headings.Add("Heading 1", "<h1>");
            headings.Add("Heading 2", "<h2>");
            headings.Add("Heading 3", "<h3>");
            headings.Add("Heading 4", "<h4>");
            headings.Add("Heading 5", "<h5>");
            headings.Add("Heading 6", "<h6>");
            headings.Add("Address", "<address>");
            headings.Add("Preformat", "<pre>");

            foreach (var tuple in headings)
            {
                formatComboBox.Items.Add(tuple.Key);

            }
           

            formatComboBox.SelectedIndex = 0;

        }

        private void InitFontList()
        {
            foreach (var font in FontFamily.Families)
            {
                fontComboBox.Items.Add(font.Name);
            }

            int index = fontComboBox.Items.IndexOf("Arial");

            fontComboBox.SelectedIndex = index;

        }

        private void InitFontSizeList()
        {


            for (int x = 1; x <= 10; x++)
            {
                fontSizeComboBox.Items.Add(x);
            }

            int index = fontSizeComboBox.Items.IndexOf(3);

            fontSizeComboBox.SelectedIndex = index;

        }


        private void makeBold()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Bold", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }

        private void makeItalic()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Italic", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }

        private void makeUnderline()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Underline", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }

        private void makeStrikethrough()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("StrikeThrough", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }



        private void insertOrderedList()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("InsertOrderedList", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }

        private void insertUnorderedList()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("InsertUnorderedList", false, null);
            fileEdited = true;
            fileNotSaved = true;

        }

        private void changeFormat()
        {
            if (containsFile == false)
            {
                return;
            }
            string format;

            if (headings.TryGetValue(formatComboBox.SelectedItem.ToString(), out format))
            {
                HTMLEditor.Document.ExecCommand("formatBlock", false, format);
            }

            HTMLEditor.Document.Focus();
            fileEdited = true;
            fileNotSaved = true;
        }

        private void indent()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Indent", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }

        private void outdent()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Outdent", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }

        private void justifyLeft()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("JustifyLeft", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }

        private void justifyCenter()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("JustifyCenter", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }

        private void justifyRight()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("JustifyRight", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }

        private void justify()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("JustifyFull", false, null);
            fileEdited = true;
            fileNotSaved = true;
        }


        private void changeFont()
        {
            if (containsFile == false)
            {
                return;
            }
            //HTMLEditor.Document.ExecCommand("FontName", false, fontComboBox.SelectedItem.ToString());
            fileEdited = true;
            fileNotSaved = true;
            //ss.cssText = "html * {	font-family: 'Arial', Helvetica, sans-serif !important; }";
            //ss.cssText = "html * {	font-family: '" + fontComboBox.SelectedItem.ToString() + "', Helvetica, sans-serif !important; }";
        }


        private void changeFontColor()
        {
            if (containsFile == false)
            {
                return;
            }
            Color col = new Color();
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = false;
            // Sets the initial color select to the current text color.
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                col = MyDialog.Color;
            }

            string colorstr = string.Format("#{0:X2}{1:X2}{2:X2}", col.R, col.G, col.B);
            HTMLEditor.Document.ExecCommand("ForeColor", false, colorstr);
            fileEdited = true;
            fileNotSaved = true;
        }

        private void changeFontSize()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("FontSize", false, fontSizeComboBox.SelectedItem.ToString());
            fileEdited = true;
            fileNotSaved = true;
        }


        private void insertImage()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("formatBlock", false, "<p>");

            ImageDialogBox idb = new ImageDialogBox(doc, getImageFolder(), language);
            idb.ShowDialog();

            fileEdited = true;
            fileNotSaved = true;

            refreshBrowsers();

        }

        private void insertTable()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("formatBlock", false, "<p>");

            TableDialogBox tdb = new TableDialogBox(doc);
            tdb.ShowDialog();

            fileEdited = true;
            fileNotSaved = true;

            refreshBrowsers();
        }

        private void insertMath()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("formatBlock", false, "<p>");

            MathDialogBox mdb = new MathDialogBox(doc, getImageFolder());
            mdb.ShowDialog();

            if (mathmlManifestupdated == false)
            {
                //updateManifest();
            }
            

            fileEdited = true;
            fileNotSaved = true;

            refreshBrowsers();
        }



        private void boldButton_Click(object sender, EventArgs e)
        {
            makeBold();
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            makeItalic();
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            makeUnderline();
        }

        private void strikethroughButton_Click(object sender, EventArgs e)
        {
            makeStrikethrough();

        }






        //private void orderedListButton_Click(object sender, EventArgs e)
        //{
        //    insertOrderedList();
        //}


        //private void unorderedListButton_Click(object sender, EventArgs e)
        //{
        //    insertUnorderedList();
        //}

        private void formatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeFormat();
        }



        private void indentButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("Indent", false, null);
        }

        private void outdentButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("Outdent", false, null);
        }

        private void justifyLeftButton_Click(object sender, EventArgs e)
        {
            justifyLeft();
        }

        private void justifyCenterButton_Click(object sender, EventArgs e)
        {
            justifyCenter();
        }

        private void justifyRightButton_Click(object sender, EventArgs e)
        {
            justifyRight();
        }

        private void justifyButton_Click(object sender, EventArgs e)
        {
            justify();
        }

        private void fontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeFont();
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            changeFontColor();
        }

        private void fontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            changeFontSize();
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            insertImage();
        }

        private void tableButton_Click(object sender, EventArgs e)
        {
            insertTable();
        }

        private void mathButton_Click(object sender, EventArgs e)
        {
            insertMath();
        }

        private void keyPressSave(object sender, KeyPressedEventArgs e)
        {
            if (e.HotKey.Key == Key.S)
            {
                saveFile();
            }
        }

       



        private string getImageFolder()
        {
            return Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Images");
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            makeBold();
        }
        
        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            makeItalic();
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            makeUnderline();
        }

        private void justifyLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            justifyLeft();
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            justifyCenter();
        }

        private void justifyRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            justifyRight();
        }

        private void justifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            justify();
        }

        private void indentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            indent();
        }

        private void outdentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            outdent();
        }

        private void numberedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOrderedList();
        }

        private void bulletListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertUnorderedList();
        }

        private void insertImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertImage();
        }

        private void insertTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertTable();
        }

        private void insertMathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertMath();
        }

        private void togglePreviewButton_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel2Collapsed == true)
            {
                splitContainer2.Panel2Collapsed = false;
                splitContainer2.Panel2.Show();
            }

            else if (splitContainer2.Panel2Collapsed == false)
            {
                splitContainer2.Panel2Collapsed = true;
                splitContainer2.Panel2.Hide();
            }


            //splitContainer2.Panel1Collapsed = false;
            //splitContainer2.Panel1.Show();

            //splitContainer2.Panel2Collapsed = false;
            //splitContainer2.Panel2.Show();
        }

        private void toggleEditorButton_Click(object sender, EventArgs e)
        {
            if (splitContainer2.Panel1Collapsed == true)
            {
                splitContainer2.Panel1Collapsed = false;
                splitContainer2.Panel1.Show();
            }

            else if (splitContainer2.Panel2Collapsed == false)
            {
                splitContainer2.Panel1Collapsed = true;
                splitContainer2.Panel1.Hide();
            }
        }

        private void toggleFileExplorerButton_Click(object sender, EventArgs e)
        {           
            if (splitContainer1.Panel1Collapsed == true)
            {
                treeView1.Visible = true;
                elementTabControl.Visible = false;

                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Show();
                
            }
            else if (splitContainer1.Panel1Collapsed == false)
            {
                if (treeView1.Visible == false)
                {
                    treeView1.Visible = true;
                    elementTabControl.Visible = false;
                }
                else
                {
                    splitContainer1.Panel1Collapsed = true;
                    splitContainer1.Panel1.Hide();
                }
               
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Undo", false, null);
        }


        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Redo", false, null);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            SendKeys.Send("^(f)");
        }


        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Cut", false, null);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Copy", false, null);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Paste", false, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Delete", false, null);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }

            if (fileNotSaved == true)
            {
                //DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Save the file before exiting?", "Save changes", MessageBoxButtons.YesNoCancel);
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(Resource_MessageBox.saveLeavingContent, Resource_MessageBox.saveLeavingTitle, MessageBoxButtons.YesNoCancel);
                if (dialogResult == DialogResult.Yes)
                {
                    saveFile();
                }
                else if (dialogResult == DialogResult.No)
                {
                    
                }
                else if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
            HTMLEditor.Dispose();
            geckoWebBrowser1.Dispose();
            geckoWebBrowser2.Dispose();
            geckoWebBrowser3.Dispose();
            geckoWebBrowser4.Dispose();
            this.Dispose();
            Environment.Exit(0);
           
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Path.Combine(initialPath, "Help.html"));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialogBox abd = new AboutDialogBox();
            abd.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsDialogBox sdb = new SettingsDialogBox();
            sdb.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void strikethroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            makeStrikethrough();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "EPUB|*.epub";
            saveFileDialog1.Title = "Create a new EPUB File";
            saveFileDialog1.InitialDirectory = homePath;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
            {
                return;
            }

            if (saveFileDialog1.CheckFileExists)
            {
                File.Delete(saveFileDialog1.FileName);
            }


            target = saveFileDialog1.FileName;

            saveFile();
        }

        private void newFileSplashButton_Click(object sender, EventArgs e)
        {
            newSingleFile(sender, e);
        }


        private void newFileButton_Click(object sender, EventArgs e)
        {
            newSingleFile(sender, e);
        }

        private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newSingleFile(sender, e);
        }


        private void openFileSplashButton_Click(object sender, EventArgs e)
        {
            openFile(sender, e);
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFile(sender, e);
        }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile(sender, e);
        }


        private void openFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFile(sender, e);
        }

        private void closeFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            closeFile(sender, e);
        }

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeFile(sender, e);
        }

        private void playPauseRefreshButton_Click(object sender, EventArgs e)
        {
            refresh = !refresh;

            if (refresh == true)
            {
                playPauseRefreshButton.Image = Properties.Resources.Pause_16x_24;
            } 
            else if (refresh == false)
            {
                playPauseRefreshButton.Image = Properties.Resources.PlaybackPreview_16x_24;
            }
        }

        private void toggleRefreshPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh = !refresh;

            if (refresh == true)
            {
                playPauseRefreshButton.Image = Properties.Resources.Pause_16x_24;
                toggleRefreshPreviewToolStripMenuItem.Image = Properties.Resources.Pause_16x;
            }
            else if (refresh == false)
            {
                playPauseRefreshButton.Image = Properties.Resources.PlaybackPreview_16x_24;
                toggleRefreshPreviewToolStripMenuItem.Image = Properties.Resources.PlaybackPreview_16x;
            }
        }
    


        private static Version version = new Version(Application.ProductVersion);

        public static Version Version
        {
            get
            {
                return version;
            }
        }

        private void showToolStrips()
        {
            editToolStrip.Visible = true;
            toggleCodeButton.Visible = true;
            toggleEditorButton.Visible = true;
            toggleFileExplorerButton.Visible = true;
            togglePreviewButton.Visible = true;
            playPauseRefreshButton.Visible = true;
            toggleToolStripSeparator.Visible = true;
            toggleNavigationPaneButton.Visible = true;
        }

        private void hideToolStrips()
        {
            editToolStrip.Visible = false;
            toggleCodeButton.Visible = false;
            toggleEditorButton.Visible = false;
            toggleFileExplorerButton.Visible = false;
            togglePreviewButton.Visible = false;
            playPauseRefreshButton.Visible = false;
            toggleToolStripSeparator.Visible = false;
            toggleNavigationPaneButton.Visible = false;
        }

        private void editImageMath()
        {
            IHTMLElement ielem = null;
            HtmlElement elem;


            IHTMLSelectionObject currentSelection = doc.selection;
            if (currentSelection != null)
            {
                IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;
                IHTMLTxtRange oldRange = currentSelection.createRange() as IHTMLTxtRange;

                //if (range != null)
                //{
                //    range.moveToElementText(range.parentElement());
                //    //range.select();
                //    Console.WriteLine("RangeHTML: " + range.parentElement().parentElement.outerHTML);


                //    foreach (HtmlElement kid in HTMLEditor.Document.Body.Children)
                //    {
                //        Console.WriteLine("Kid: " + kid.OuterHtml);
                //        if (kid.OuterHtml.ToLower().StartsWith( @"<div style=""display:inline""> <figure"))
                //        {
                //            //Console.WriteLine("Kid: " + kid.OuterHtml);
                //        }
                //        //Console.WriteLine(kid.OuterHtml);
                //        if (kid.OuterHtml.ToLower().Contains(range.parentElement().parentElement.outerHTML.ToLower()))
                //        {
                //            if (kid.OuterHtml.ToLower().StartsWith("<figure"))
                //            {
                //                //Console.WriteLine("SAME");
                //                elem = kid;

                //                identifyElement(elem);
                //                oldRange.parentElement().outerHTML = oldRange.parentElement().innerHTML;
                //                return;
                //            }

                //        }
                //    }

                //    if (range.parentElement().outerHTML.ToLower().Contains("<figure"))
                //    {
                //        //ielem = range.parentElement();
                //        //Console.WriteLine(ielem.outerHTML);

                //        //foreach (HtmlElement kid in HTMLEditor.Document.Body.Children)
                //        //{
                //        //    if (kid.OuterHtml.ToLower().StartsWith("<figure"))
                //        //    {
                //        //        Console.WriteLine("Kid: " + kid.OuterHtml);
                //        //    }
                //        //    //Console.WriteLine(kid.OuterHtml);
                //        //    if (ielem.outerHTML.ToLower() == kid.OuterHtml.ToLower())
                //        //    {
                //        //        Console.WriteLine("SAME");
                //        //    }
                //        //}
                //    }

                //    if (range.htmlText.ToLower().StartsWith("<figure"))
                //    {
                //        return;
                //    }
                //    //if (ielem == null)
                //    //{
                //    //    return;
                //    //}

                //    if (!range.parentElement().outerHTML.ToLower().Contains("<math"))
                //    {
                //        return;
                //    }


                //MessageBox.Show(range.text);
                //range.select();



                //}

                if (range != null)
                {
                    //Console.WriteLine(range.htmlText);
                    //if (range.htmlText.EndsWith("</FIGCAPTION>"))
                    //{
                    //    return;
                    //}

                    range.moveToElementText(range.parentElement());
                    //range.select();
                    //Console.WriteLine("RangeHTML: " + range.parentElement().outerHTML);


                    foreach (HtmlElement kid in HTMLEditor.Document.Body.Children)
                    {
                        //Console.WriteLine("Kid: " + kid.OuterHtml);
                        if (kid.OuterHtml.ToLower().StartsWith(@"<div style=""display:inline""> <figure"))
                        {
                            //Console.WriteLine("Kid: " + kid.OuterHtml);
                        }
                        //Console.WriteLine(kid.OuterHtml);
                        if (kid.OuterHtml.ToLower().Contains(range.parentElement().outerHTML.ToLower()))
                        {
                            if (kid.OuterHtml.ToLower().StartsWith("<figure"))
                            {
                                //Console.WriteLine("SAME");
                                elem = kid;

                                identifyElement(elem);
                                oldRange.parentElement().outerHTML = oldRange.parentElement().innerHTML;
                                return;
                            }

                            else if (kid.OuterHtml.ToLower().StartsWith("<ol") || kid.OuterHtml.ToLower().StartsWith("<ul"))
                            {
                                elem = kid;
                                identifyElement(elem);
                                return;
                            }
                        }
                    }

                    if (range.parentElement().outerHTML.ToLower().Contains("<figure"))
                    {
                        //ielem = range.parentElement();
                        //Console.WriteLine(ielem.outerHTML);

                        //foreach (HtmlElement kid in HTMLEditor.Document.Body.Children)
                        //{
                        //    if (kid.OuterHtml.ToLower().StartsWith("<figure"))
                        //    {
                        //        Console.WriteLine("Kid: " + kid.OuterHtml);
                        //    }
                        //    //Console.WriteLine(kid.OuterHtml);
                        //    if (ielem.outerHTML.ToLower() == kid.OuterHtml.ToLower())
                        //    {
                        //        Console.WriteLine("SAME");
                        //    }
                        //}
                    }

                    //if (range.htmlText.ToLower().StartsWith("<figure"))
                    //{
                    //    return;
                    //}
                    //if (ielem == null)
                    //{
                    //    return;
                    //}




                    //MessageBox.Show(range.text);
                    //range.select();



                }
            }

        }

        private void HTMLEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            IHTMLElement ielem = null;
            HtmlElement elem;

            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                indent();
            }
            else if (e.KeyCode == Keys.Shift && e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                outdent();
            }
            //else if (e.Control && e.KeyCode == Keys.F3)
            //{

            //e.IsInputKey = true;

            //IHTMLSelectionObject currentSelection = doc.selection;
            //if (currentSelection != null)
            //{
            //    IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;
            //    IHTMLTxtRange oldRange = currentSelection.createRange() as IHTMLTxtRange;

            //    //if (range != null)
            //    //{
            //    //    range.moveToElementText(range.parentElement());
            //    //    //range.select();
            //    //    Console.WriteLine("RangeHTML: " + range.parentElement().parentElement.outerHTML);


            //    //    foreach (HtmlElement kid in HTMLEditor.Document.Body.Children)
            //    //    {
            //    //        Console.WriteLine("Kid: " + kid.OuterHtml);
            //    //        if (kid.OuterHtml.ToLower().StartsWith( @"<div style=""display:inline""> <figure"))
            //    //        {
            //    //            //Console.WriteLine("Kid: " + kid.OuterHtml);
            //    //        }
            //    //        //Console.WriteLine(kid.OuterHtml);
            //    //        if (kid.OuterHtml.ToLower().Contains(range.parentElement().parentElement.outerHTML.ToLower()))
            //    //        {
            //    //            if (kid.OuterHtml.ToLower().StartsWith("<figure"))
            //    //            {
            //    //                //Console.WriteLine("SAME");
            //    //                elem = kid;

            //    //                identifyElement(elem);
            //    //                oldRange.parentElement().outerHTML = oldRange.parentElement().innerHTML;
            //    //                return;
            //    //            }

            //    //        }
            //    //    }

            //    //    if (range.parentElement().outerHTML.ToLower().Contains("<figure"))
            //    //    {
            //    //        //ielem = range.parentElement();
            //    //        //Console.WriteLine(ielem.outerHTML);

            //    //        //foreach (HtmlElement kid in HTMLEditor.Document.Body.Children)
            //    //        //{
            //    //        //    if (kid.OuterHtml.ToLower().StartsWith("<figure"))
            //    //        //    {
            //    //        //        Console.WriteLine("Kid: " + kid.OuterHtml);
            //    //        //    }
            //    //        //    //Console.WriteLine(kid.OuterHtml);
            //    //        //    if (ielem.outerHTML.ToLower() == kid.OuterHtml.ToLower())
            //    //        //    {
            //    //        //        Console.WriteLine("SAME");
            //    //        //    }
            //    //        //}
            //    //    }

            //    //    if (range.htmlText.ToLower().StartsWith("<figure"))
            //    //    {
            //    //        return;
            //    //    }
            //    //    //if (ielem == null)
            //    //    //{
            //    //    //    return;
            //    //    //}

            //    //    if (!range.parentElement().outerHTML.ToLower().Contains("<math"))
            //    //    {
            //    //        return;
            //    //    }


            //        //MessageBox.Show(range.text);
            //        //range.select();



            //    //}

            //    if (range != null)
            //    {
            //        Console.WriteLine(range.htmlText);
            //        if (range.htmlText.EndsWith("</FIGCAPTION>"))
            //        {
            //            return;
            //        }

            //        range.moveToElementText(range.parentElement());
            //        //range.select();
            //        //Console.WriteLine("RangeHTML: " + range.parentElement().outerHTML);


            //        foreach (HtmlElement kid in HTMLEditor.Document.Body.Children)
            //        {
            //            //Console.WriteLine("Kid: " + kid.OuterHtml);
            //            if (kid.OuterHtml.ToLower().StartsWith(@"<div style=""display:inline""> <figure"))
            //            {
            //                //Console.WriteLine("Kid: " + kid.OuterHtml);
            //            }
            //            //Console.WriteLine(kid.OuterHtml);
            //            if (kid.OuterHtml.ToLower().Contains(range.parentElement().outerHTML.ToLower()))
            //            {
            //                if (kid.OuterHtml.ToLower().StartsWith("<figure"))
            //                {
            //                    //Console.WriteLine("SAME");
            //                    elem = kid;

            //                    identifyElement(elem);
            //                    oldRange.parentElement().outerHTML = oldRange.parentElement().innerHTML;
            //                    return;
            //                }

            //            }
            //        }

            //        if (range.parentElement().outerHTML.ToLower().Contains("<figure"))
            //        {
            //            //ielem = range.parentElement();
            //            //Console.WriteLine(ielem.outerHTML);

            //            //foreach (HtmlElement kid in HTMLEditor.Document.Body.Children)
            //            //{
            //            //    if (kid.OuterHtml.ToLower().StartsWith("<figure"))
            //            //    {
            //            //        Console.WriteLine("Kid: " + kid.OuterHtml);
            //            //    }
            //            //    //Console.WriteLine(kid.OuterHtml);
            //            //    if (ielem.outerHTML.ToLower() == kid.OuterHtml.ToLower())
            //            //    {
            //            //        Console.WriteLine("SAME");
            //            //    }
            //            //}
            //        }

            //        //if (range.htmlText.ToLower().StartsWith("<figure"))
            //        //{
            //        //    return;
            //        //}
            //        //if (ielem == null)
            //        //{
            //        //    return;
            //        //}




            //        //MessageBox.Show(range.text);
            //        //range.select();



            //    }
            //}

            //}

            if (containsFile == true && fileEdited == true)
            {
                refreshBrowsers();
                //HTMLEditor.Document.Focus();
                updateFontFormat();
                updateHeaderList();
            }

            HTMLEditor.Document.Focus();

            //updateFontFormat();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importText(sender, e);
        }

        private void importTextButton_Click(object sender, EventArgs e)
        {
            importText(sender, e);
        }

        private void importText(object sender, EventArgs e)
        {
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.InitialDirectory = documents;
            ofd.Filter = "Text files (txt,text,rtf)|*.txt;*.text;*.rtf|All files (*.*)|*.*";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //string line;
                //Encoding encod = GetEncoding(ofd.FileName);
                //string infile = File.ReadAllText(ofd.FileName, encod);
                string infile = File.ReadAllText(ofd.FileName);
                string finalString = "";
                finalString = infile;


                //System.IO.StreamReader file = new System.IO.StreamReader(ofd.FileName);

                //while ((line = file.ReadLine()) != null)
                //{
                //    finalString = ReplaceNonPrintableCharacters(line, '?');
                //    finalString = finalString + line + "\n";


                //}

                //string outfile = "";
                //StreamReader sr = new StreamReader(infile);
                //StreamWriter sw = new StreamWriter(outfile, false, Encoding.Default);

                //sw.WriteLine(sr.ReadToEnd());
                //sw.Close();
                //sr.Close();
                //Encoding encoding = GetEncoding(ofd.FileName);
                //Console.WriteLine(encoding);
                //byte[] encBytes = encoding.GetBytes(infile);
                //byte[] utf8Bytes = Encoding.Convert(encoding, Encoding.UTF8, encBytes);

                //string finalString = Encoding.UTF8.GetString(utf8Bytes);


                if (CheckNonPrintableCharacters(infile) == false)
                {
                    finalString = ReplaceNonPrintableCharacters(infile, '?');
                }


                finalString = finalString.Replace("\n\n", "</p><p>");

                finalString = "<p>" + finalString;
                //finalString = finalString + "finalString";
                dynamic currentLocation = doc.selection.createRange();
                currentLocation.pasteHTML(finalString);

            }

            fileEdited = true;
            fileNotSaved = true;

            refreshBrowsers();
        }

        bool CheckNonPrintableCharacters(string s)
        {
            //StringBuilder result = new StringBuilder();
            bool has = true;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                byte b = (byte)c;

                if (c == ' ' || c == '\n' || c == '\t' || c=='\r')
                {
                    //result.Append(c);
                    continue;
                }

                if (b < 32)
                {
                    //Console.WriteLine(c);
                    has = false;
                }
                //else
                    //result.Append(c);
            }
            return has;
        }

        string ReplaceNonPrintableCharacters(string s, char replaceWith)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                byte b = (byte)c;
               
                if (c == ' ' || c == '\n' || c == '\t')
                {
                    result.Append(c);
                    continue;
                }

                if (b < 32) { 
                    //Console.WriteLine(c);
                    result.Append(replaceWith);
                }
                else
                    result.Append(c);
            }
            return result.ToString();
        }

        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// </summary>
        /// <param name="filename">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.ASCII;
        }

        private void editImageMathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editImageMath();
        }

        private void numberedToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            insertOrderedList();           
        }

        private void alphabeticallyCapitalizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOrderedList();
            editImageMath();
         }

        private void alphabeticallyLowercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOrderedList();
            editImageMath();
            editImageMath();
        }

        private void romanUppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOrderedList();
            editImageMath();
            editImageMath();
            editImageMath();
        }

        private void romanLowercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOrderedList();
            editImageMath();
            editImageMath();
            editImageMath();
            editImageMath();
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertUnorderedList();
        }

        private void emptyCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertUnorderedList();
            editImageMath();
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertUnorderedList();
            editImageMath();
            editImageMath();
        }

        private void toggleNavigationPaneButton_Click(object sender, EventArgs e)
        {

            if (splitContainer1.Panel1Collapsed == true)
            {
                treeView1.Visible = false;
                elementTabControl.Visible = true;
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Show();

            }
            else if (splitContainer1.Panel1Collapsed == false)
            {
                if (elementTabControl.Visible == false)
                {
                    treeView1.Visible = false;
                    elementTabControl.Visible = true;
                } 
                else
                {
                    splitContainer1.Panel1Collapsed = true;
                    splitContainer1.Panel1.Hide();
                }

            }
        }

        private void toggleNavigationPaneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1Collapsed == true)
            {
                treeView1.Visible = false;
                elementTabControl.Visible = true;
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Show();

            }
            else if (splitContainer1.Panel1Collapsed == false)
            {
                if (elementTabControl.Visible == false)
                {
                    treeView1.Visible = false;
                    elementTabControl.Visible = true;
                }
                else
                {
                    splitContainer1.Panel1Collapsed = true;
                    splitContainer1.Panel1.Hide();
                }

            }
        }

        private void convertJsToCss()
        {

            /* Uncomment later until ...*/
            if (containsFile == false)
            {
                return;
            }
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "EPUB|*.epub";
            saveFileDialog1.Title = "Create a new EPUB File";
            saveFileDialog1.InitialDirectory = homePath;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
            {
                return;
            }

            if (saveFileDialog1.CheckFileExists)
            {
                File.Delete(saveFileDialog1.FileName);
            }

            string newTarget = saveFileDialog1.FileName;
            /* ... This part! */

            string tempFolderName = epubFolderName + "temp";
           
            string emptySingleFileZip = Path.Combine("EmptyFiles", "SingleFile", "empty_Single_File.zip");
      
            File.Copy(Path.Combine(initialPath, emptySingleFileZip), Path.Combine(accEpubFolderName, "empty_Single_File.zip"), true);

            System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(accEpubFolderName, "empty_Single_File.zip"), tempFolderName);

            File.Delete(Path.Combine(accEpubFolderName, "empty_Single_File.zip"));

            string tempImages = Path.Combine(Path.Combine(tempFolderName, "OEBPS"), "Images");

            DirectoryCopy(getImageFolder(), tempImages);


            createManifest(tempFolderName);        

            string contentBody = File.ReadAllText(contentFile);


            string tempFile = Path.Combine(Path.Combine(Path.Combine(tempFolderName, "OEBPS"), "Text"), "Content.xhtml");

            string tempBody = File.ReadAllText(tempFile);

    




            string bodyStart = "<body";
            //string bodyStart = "<nav epub:type=\"toc\" id=\"toc\">";
            string bodyEnd = "</body>";
            //string bodyEnd = "</nav>";
            int first = contentBody.IndexOf(bodyStart);

            int end = contentBody.IndexOf(bodyEnd);

            int bracketTerminateIndex = 0;
            bool endMode = true;
            for (int i = 1; i < end - first; i++)
            {             
                if (contentBody[first + i] == '<')
                {
                    endMode = false;
                }

                if (contentBody[first + i] == '>')
                {

                    if (endMode == false)
                    {
                        endMode = true;
                    }
                    else
                    {
                        bracketTerminateIndex = i;
                        break;

                    }
                }
            }

            //string header = contentBody.Substring(0, first + bracketTerminateIndex + 1);
            string body = contentBody.Substring(first + bracketTerminateIndex + 1, end - (first + bracketTerminateIndex + 1));
            //string closer = contentBody.Substring(end);

            string newContent;
            newContent = tempBody.Substring(0, tempBody.IndexOf(startOfContent) + startOfContent.Length) + "\n";


            newContent = newContent + imp + body + impEnd +
                  bli + body + bliEnd +
                  vis + body + visEnd + "</body>\n</html>\n";

            File.WriteAllText(tempFile, newContent);

            createEpubZip(tempFolderName, newTarget);
        }

        private void convertCssToJs()
        {

            /* Uncomment later until ...*/
            if (containsFile == false)
            {
                return;
            }
            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "EPUB|*.epub";
            saveFileDialog1.Title = "Create a new EPUB File";
            saveFileDialog1.InitialDirectory = homePath;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
            {
                return;
            }

            if (saveFileDialog1.CheckFileExists)
            {
                File.Delete(saveFileDialog1.FileName);
            }

            string newTarget = saveFileDialog1.FileName;
            /* ... This part! */

            string tempFolderName = epubFolderName + "temp";

            string emptySingleFileZip = Path.Combine("EmptyFiles", "JsVersionChanger", "emptyJsFile.zip");
           
            File.Copy(Path.Combine(initialPath, emptySingleFileZip), Path.Combine(accEpubFolderName, "emptyJsFile.zip"), true);

            System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(accEpubFolderName, "emptyJsFile.zip"), tempFolderName);

            File.Delete(Path.Combine(accEpubFolderName, "emptyJsFile.zip"));

            string tempImages = Path.Combine(Path.Combine(tempFolderName, "OEBPS"), "Images");

            DirectoryCopy(getImageFolder(), tempImages);


            createManifest(tempFolderName);

            string contentBody = File.ReadAllText(contentFile);


            string tempFile = Path.Combine(Path.Combine(Path.Combine(tempFolderName, "OEBPS"), "Text"), "Content.xhtml");

            string tempBody = File.ReadAllText(tempFile);


           


            string bodyStart = "<body";
          
            string bodyEnd = "</body>";

            int first = tempBody.IndexOf(bodyStart);

            int end = tempBody.IndexOf(bodyEnd);

            int bracketTerminateIndex = 0;
            bool endMode = true;
            for (int i = 1; i < end - first; i++)
            {
                if (tempBody[first + i] == '<')
                {
                    endMode = false;
                }

                if (tempBody[first + i] == '>')
                {

                    if (endMode == false)
                    {
                        endMode = true;
                    }
                    else
                    {
                        bracketTerminateIndex = i;
                        break;

                    }
                }
            }


            int impFirst = contentBody.IndexOf(imp);
            int impLast = contentBody.IndexOf(impEnd);

          

            string body = contentBody.Substring(impFirst + imp.Length, impLast - (impFirst + imp.Length));          

            string newContent;
            newContent = tempBody.Substring(0, first  + bracketTerminateIndex + 1);
            string closer = tempBody.Substring(end);

            newContent = newContent + body + closer;


          

            File.WriteAllText(tempFile, newContent);

            createEpubZip(tempFolderName, newTarget);
        }

        private void javaScriptToCSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mode == (int)fileMode.singleFileJs)
            {
                convertJsToCss();
            }
            else
            {
                MessageBox.Show(Resource_MessageBox.jsToCssContent, Resource_MessageBox.jsToCssTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                
        }

        private void cSSToJavaScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mode == (int)fileMode.singleFileCss)
            {
                convertCssToJs();
            }
            else
            {
                MessageBox.Show(Resource_MessageBox.cssToJsContent, Resource_MessageBox.cssToJsTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toggleBulletPointStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editImageMath();
        }

        private void orderedListButton_ButtonClick(object sender, EventArgs e)
        {
            insertOrderedList();
        }

        private void unorderedListButton_ButtonClick(object sender, EventArgs e)
        {
            insertUnorderedList();
        }
    }

    

}
