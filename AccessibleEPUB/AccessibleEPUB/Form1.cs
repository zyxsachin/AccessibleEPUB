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

using mshtml;

using Gecko;

using IPrompt;

using ICSharpCode.AvalonEdit;

using Microsoft.Win32;

using GlobalHotKey;
using System.Windows.Input;






namespace AccessibleEPUB
{

    public partial class Form1 : Form
    {
        
        //ScintillaNET.Scintilla TextArea;
        ICSharpCode.AvalonEdit.TextEditor codeArea;

        //string initialPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
        string initialPath = Directory.GetCurrentDirectory();

        private IHTMLDocument2 doc;
        Dictionary<string, string> headings;
        string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string accessibleEpubFormText = "Accessible EPUB";
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

        string title;
        string author;
        string language;
        string publisher;
        bool newFileCorrect;

        bool refresh = true;

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



        string origWordCountLabel;
        string origCharacterCountLabel;
        string origDocumentLanguageLabel;
        string origLastSavedLabel;



        public Form1()
        {
         
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            filesTabControl.Padding = new System.Drawing.Point(21, 3);
            var hotKey = hkm.Register(System.Windows.Input.Key.S, System.Windows.Input.ModifierKeys.Control);
            //var globalReload = hkm.Register(System.Windows.Input.Key.None, System.Windows.Input.ModifierKeys.None);

            hkm.KeyPressed += keyPressSave;

            origWordCountLabel = wordCountLabel.Text;
            origCharacterCountLabel = characterCountLabel.Text;

            origDocumentLanguageLabel = documentLanguageLabel.Text;

            versionLabel.Text += String.Format("{0}.{1}",
                 Version.Major.ToString(), Version.Minor.ToString());

            origLastSavedLabel = lastSavedLabel.Text;
        }


      




        private void Form1_Load(object sender, EventArgs e)
        {
            //iconsToolStrip.Visible = false;
            //editToolStrip.Visible = false;
            //menuBar.Visible = false;
            //editToolStrip.Visible = true;
            //iconsToolStrip.Visible = true;
            //menuBar.Visible = true;
            iconsToolStrip.SendToBack();
            editToolStrip.SendToBack();
            menuBar.Dock = DockStyle.Top;



            HTMLEditor.DocumentText = @"<html><body></body></html>"; //This will get our HTML editor ready, inserting common HTML blocks into the document

            doc = HTMLEditor.Document.DomDocument as IHTMLDocument2;

            doc.designMode = "On";                                  //Make the web 'browser' an editable HTML field


            //What we just did was make our web browser editable!

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


            int halfWidth = splitContainer2.Width / 2;
            splitContainer2.SplitterDistance = halfWidth;

            //versionLabel.Alignment = ToolStripItemAlignment.Right;
            versionToolStrip.Location = new Point(toolStripContainer1.BottomToolStripPanel.Width - versionToolStrip.Width, versionToolStrip.Location.Y);

            languageToolStrip.Location = new Point(toolStripContainer1.BottomToolStripPanel.Width / 2 - languageToolStrip.Width / 2, languageToolStrip.Location.Y);
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

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile(sender, e);
        }



        //private void tabPage1_Click(object sender, EventArgs e)
        //{

        //}


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

            string absPath = Path.Combine(tempFolder, e.Node.FullPath);
            string fileName = e.Node.FullPath;
            FileAttributes attr = File.GetAttributes(absPath);
            if (attr.HasFlag(FileAttributes.Directory))
            {
                return;
            }

            treeView1.SelectedNode = null;
            //if (filesTabControl.Visible == false)
            //{
            //    openTab(absPath);
            //    return;
            //}

            if (openTabs == null || openTabs.Contains(fileName) == false)
            {

                if ((!fileName.EndsWith(".svg")) && (!fileName.EndsWith(".jpg")) && (!fileName.EndsWith(".png")))
                {
                    TabPage myTabPage = new TabPage(e.Node.Text);
                    myTabPage.Name = fileName;
                    filesTabControl.TabPages.Add(myTabPage);

                    //RichTextBox rtb = new RichTextBox();

                    System.Windows.Forms.Integration.ElementHost host = new System.Windows.Forms.Integration.ElementHost();
                    host.Dock = DockStyle.Fill;

                    codeArea = new ICSharpCode.AvalonEdit.TextEditor();



                    host.Child = codeArea;
                    myTabPage.Controls.Add(host);



                    //myTabPage.Controls.Add(rtb);

                    //rtb.Dock = System.Windows.Forms.DockStyle.Fill;
                    openTabs.Add(fileName);

                    openTextEditors.Add(codeArea);

                    tabsToTextEditors.Add(fileName, codeArea);

                    filesTabControl.SelectedTab = myTabPage;

                    lastTab = currentTab;
                    currentTab = fileName;
                }



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

            else
            {
                foreach (TabPage tab in filesTabControl.TabPages)
                {
                    if (tab.Name == fileName)
                    {
                        filesTabControl.SelectedTab = tab;
                        lastTab = currentTab;
                        currentTab = fileName;
                        openTab(absPath);
                    }
                }
            }







            //webBrowser1.Navigate(filePath);
            //richTextBox1.Text = geckoWebBrowser1.Text;
        }

        private void createManifest()
        {
            string searchFolder = Path.Combine(epubFolderName, "OEBPS");
            string manifestTagOpen = "<manifest>";
            string manifestTagClose = "</manifest>";

            string manifestContent = "";

            string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"));

            int firstIndex = metadata.IndexOf(manifestTagOpen);
            int endIndex = metadata.IndexOf(manifestTagClose);

            string manifestHead = metadata.Substring(0, firstIndex);
            string manifestEnd = metadata.Substring(endIndex + manifestTagClose.Length);




            manifestContent = loopManifest(manifestContent, searchFolder);
            //foreach (var subdirectory in Directory.GetDirectories(searchFolder))
            //{
            //    //Uri uri = new Uri(subdirectory);
            //    //string lastSegment = uri.Segments.Last();


            string manifest = manifestHead + manifestTagOpen + "\n" + manifestContent + manifestTagClose + manifestEnd;

            File.WriteAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"), manifest);


        }

        private string loopManifest(string manifestContentParameter, string searchFolder)
        {
            string initialFolder = Path.Combine(epubFolderName, "OEBPS");
            string manifestContent = manifestContentParameter;
            string navFileName = "nav.xhtml";

            foreach (var subdirectory in Directory.GetDirectories(searchFolder))
            {
                //Uri uri = new Uri(subdirectory);
                //string lastSegment = uri.Segments.Last();
                manifestContent = loopManifest(manifestContent, subdirectory.ToString());



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


                if (shortFileName == navFileName)
                {
                    manifestContent += "\t<item id=\"navid\" href=\"" + fullFileName.Substring(initialFolder.Length + 1) + "\" media-type=\"" + mediaType + "\" properties=\"nav\"/>\n";
                }
                else if (!fullFileName.EndsWith(".opf"))
                {
                    manifestContent += "\t<item id=\"" + shortFileName + "\" href=\"" + fullFileName.Substring(initialFolder.Length + 1) + "\" media-type=\"" + mediaType + "\"/>\n";
                }

                //r.Text = searchFolder;

            }


            return manifestContent;
        }


        private void openTab(string absPath)
        {
            if (absPath.EndsWith(".xhtml") || absPath.EndsWith(".html"))
            {
                //geckoWebBrowser2.Navigate("about:blank");
                //geckoWebBrowser3.Navigate("about:blank");

                //File.Delete(impairedContentFile);
                //File.Delete(blindContentFile);

                contentFile = absPath;

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
                geckoWebBrowser2.Navigate(impairedContentFile);
                geckoWebBrowser3.Navigate(blindContentFile);
                geckoWebBrowser4.Navigate(contentFile);
                //}




                //splitContainer2.Panel1Collapsed = false;
                //splitContainer2.Panel1.Show();

                //splitContainer2.Panel2Collapsed = false;
                //splitContainer2.Panel2.Show();
                //rtb.Text = File.ReadAllText(absPath);

                //if (filesTabControl.Visible == true)
                //{

                codeArea.Load(absPath);
                //codeArea.Text = File.ReadAllText(absPath);
                codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("HTML");

                //}

                //else
                //{
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

                codeArea.Load(absPath);
                //codeArea.Text = File.ReadAllText(absPath);
                codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("CSS");



            }

            else if (absPath.EndsWith(".js"))
            {

                //splitContainer2.Panel1Collapsed = false;
                //splitContainer2.Panel1.Show();

                ////splitContainer2.Panel2Collapsed = true;
                ////splitContainer2.Panel2.Hide();

                codeArea.Load(absPath);
                //codeArea.Text = File.ReadAllText(absPath);
                codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("JavaScript");


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

                codeArea.Load(absPath);
                //codeArea.Text = File.ReadAllText(absPath);

            }



        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFile(sender, e);
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



        private void openFile(object sender, EventArgs e)
        {
           

            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = homePath;
            openFileDialog1.Filter = "EPUB|*.epub|All Files|*.*";


            string epubFileName;       // Formerly tempFile
            string fileName = "";      // Formerly tempFile2
            string zipFileName = "";     // Formerly tempFile3 


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
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
                                MessageBox.Show("Temp folder is still in use. After pressing OK, the file opening process will stop.", "Folder still in use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                            isInUse = true;
                            MessageBox.Show("Folder in use. Please leave and then press OK.", "Folder in use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    } while (isInUse);

                }



                while (di.GetDirectories().Length != 0 || di.GetFiles().Length != 0)
                {
                    var result = MessageBox.Show("Could not delete all files in temp folder", "Error Title", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
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
            else if (File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Misc"), "script.js")))
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
            geckoWebBrowser4.Navigate(contentFile);

            htmlToWysiwyg();

            if (mode == (int)fileMode.singleFileJs)
            {
                string visibleCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "visible.css");
                string impairedCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "impaired.css");
                string blindCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Styles"), "blind.css");

                geckoWebBrowser1.Document.Head.Style.CssText = File.ReadAllText(visibleCss);
                geckoWebBrowser2.Document.Head.Style.CssText = File.ReadAllText(impairedCss);
                geckoWebBrowser3.Document.Head.Style.CssText = File.ReadAllText(blindCss);
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

            System.Windows.Forms.Integration.ElementHost host = new System.Windows.Forms.Integration.ElementHost();
            host.Dock = DockStyle.Fill;

            codeArea = new ICSharpCode.AvalonEdit.TextEditor();



            host.Child = codeArea;
            myTabPage.Controls.Add(host);


            //myTabPage.Controls.Add(rtb);

            //rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            openTabs.Add(tabPageName);

            openTextEditors.Add(codeArea);

            tabsToTextEditors.Add(tabPageName, codeArea);

            filesTabControl.SelectedTab = myTabPage;
            currentTab = tabPageName;
            openTab(contentFile);

            HTMLEditor.Focus();

            this.Text = Path.GetFileName(target) + " - " + accessibleEpubFormText;

            documentLanguageLabel.Text = origDocumentLanguageLabel + language;

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

       

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeFile(sender, e);

        }

        private void closeFile(object sender, EventArgs e)
        {
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



        private void newFileButton_Click(object sender, EventArgs e)
        {
            closeFile(sender, e);

            newSingleFile();

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



        public void newSingleFile()
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
                            MessageBox.Show(tempFolderStillInUseLong, tempFolderStillInUse, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        isInUse = true;
                        MessageBox.Show(tempFolderInUseLong, tempFolderInUse, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            string identifierStart = "<dc:identifier>";
            string identifierEnd = "</dc:identifier>";

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

            int identifierStartIndex = metadata.IndexOf(identifierStart);
            int identifierEndIndex = metadata.IndexOf(identifierEnd);

            int timeStartIndex = metadata.IndexOf(timeStart);
            int timeEndIndex = metadata.IndexOf(timeEnd);

            string languageShort;
            Console.WriteLine("languageSHORT:" + language);
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
            tagsList.Add(new Tuple<int, string, string>(identifierStartIndex, identifierStart, identifier));
            tagsList.Add(new Tuple<int, string, string>(identifierEndIndex, identifierEnd, ""));

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



            string first = metadata.Substring(0, tagsList[0].Item1 + tagsList[0].Item2.Length);
            string second = metadata.Substring(tagsList[1].Item1, tagsList[2].Item1 + tagsList[2].Item2.Length - tagsList[1].Item1);
            string third = metadata.Substring(tagsList[3].Item1, tagsList[4].Item1 + tagsList[4].Item2.Length - tagsList[3].Item1);
            string fourth = metadata.Substring(tagsList[5].Item1, tagsList[6].Item1 + tagsList[6].Item2.Length - tagsList[5].Item1);
            string fifth = metadata.Substring(tagsList[7].Item1, tagsList[8].Item1 + tagsList[8].Item2.Length - tagsList[7].Item1);
            string sixth = metadata.Substring(tagsList[9].Item1, tagsList[10].Item1 + tagsList[10].Item2.Length - tagsList[9].Item1);
            string seventh = metadata.Substring(tagsList[11].Item1);


            //string first = metadata.Substring(0, titleStartIndex + titleStart.Length);
            //string second = metadata.Substring(titleEndIndex, creatorStartIndex + creatorStart.Length - titleEndIndex);
            //string third = metadata.Substring(creatorEndIndex);




            string newMetaData = first + tagsList[0].Item3 + second + tagsList[2].Item3 + third + tagsList[4].Item3 +
                 fourth + tagsList[6].Item3 + fifth + tagsList[8].Item3 + sixth + tagsList[10].Item3 + seventh;

            File.WriteAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"), newMetaData);

            impairedContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile));
            blindContentFile = Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile));

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

            File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile)), impFile);
            File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile)), bliFile);


            determineLanguage();

            geckoWebBrowser1.Navigate(contentFile);
            geckoWebBrowser2.Navigate(impairedContentFile);
            geckoWebBrowser3.Navigate(blindContentFile);
            geckoWebBrowser4.Navigate(contentFile);
            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();

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
            Console.WriteLine("DETERMINED LANGUAGE: " + language);
        }

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
                        MessageBox.Show(tempFolderStillInUseLong, tempFolderStillInUse, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    isInUse = true;
                    MessageBox.Show(tempFolderInUseLong, tempFolderInUse, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } while (isInUse);
            //foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
            //foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);


        }

        private static void CloneDirectory(string root, string dest)
        {
            foreach (var directory in Directory.GetDirectories(root))
            {
                string dirName = Path.GetFileName(directory);
                if (!Directory.Exists(Path.Combine(dest, dirName)))
                {
                    Directory.CreateDirectory(Path.Combine(dest, dirName));
                }
                CloneDirectory(directory, Path.Combine(dest, dirName));
            }

            foreach (var file in Directory.GetFiles(root))
            {
                File.Copy(file, Path.Combine(dest, Path.GetFileName(file)));
            }
        }

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

        private void filesTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (filesTabControl.TabPages.Count >= 1)
            {
                filesTabControl.SelectedTab = e.TabPage;

                string absPath = Path.Combine(tempFolder, e.TabPage.Name);
                openTab(absPath);
            }


        }



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

        private void saveFile()
        {
            if (containsFile == false)
            {
                return;
            }
            if (filesTabControl.Visible == false)
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

            if (File.Exists(impairedContentFile))
            {
                File.Delete(impairedContentFile);
            }

            if (File.Exists(blindContentFile))
            {
                File.Delete(blindContentFile);
            }

            string zipFileName = epubFolderName + ".zip";
            File.Delete(zipFileName);
            ZipFile.CreateFromDirectory(epubFolderName, zipFileName);

            File.Copy(zipFileName, target, true);
            File.Delete(zipFileName);



            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add(TraverseDirectory(epubFolderName));
            createManifest();

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


            geckoWebBrowser1.Reload();
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

            filesTabControl.Visible = !filesTabControl.Visible;
            if (filesTabControl.Visible == false)
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
                filesTabControl.Focus();

                //splitContainer1.Panel1Collapsed = true;
                //splitContainer1.Panel1.Hide();
                //splitContainer1.Panel1Collapsed = false;
                //splitContainer1.Panel1.Show();
                wysiwygToHtml();

            }
        }

        private void htmlToWysiwyg()
        {
            string vis = "<div id=\"visible\" class=\"visible\">";
            string start = "<!--StartOfVisibleSection-->";
            string end = "<!--EndOfVisibleSection-->";

            foreach (KeyValuePair<string, ICSharpCode.AvalonEdit.TextEditor> ca in tabsToTextEditors)
            {
                //if (ca.Key == lastTab)
                //{
                //    ca.Value.Save(Path.Combine(accEpubFolderName, ca.Key));
                //}
                //ca.Value.Save(Path.Combine(accEpubFolderName, ca.Key));
                //File.WriteAllText(Path.Combine(accEpubFolderName, ca.Key), ca.Value.Document.Text);
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

        private void wysiwygToHtml()
        {
            string body = doc.body.innerHTML;

            if (body == null)
            {
                return;
            }

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
                    MessageBox.Show("Problem converting from WYSIWYG to HTML", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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


            foreach (KeyValuePair<string, ICSharpCode.AvalonEdit.TextEditor> ca in tabsToTextEditors)
            {
                ca.Value.Load(Path.Combine(accEpubFolderName, ca.Key));
            }


        }

        private void saveToEpub()
        {

        }

        private void addFilesToMeta()
        {
            string fileName = Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf");
            string content = File.ReadAllText(fileName);

            string startManifest = "<manifest>";
            string endManifest = "</manifest>";

            int startManiIndex = content.IndexOf(startManifest);
            int endManiIndex = content.IndexOf(endManifest);

            string defaultText = @"
                <item id=""ncx"" href=""toc.ncx"" media-type=""application/x-dtbncx+xml""/>
                <item id=""Content.xhtml"" href=""Text/Content.xhtml"" media-type=""application/xhtml+xml""/>
";

            //< item id = "Content.xhtml" href = "Text/Content.xhtml" media - type = "application/xhtml+xml" />

            //     < item id = "style.css" href = "Styles/style.css" media - type = "text/css" />

            //          < item id = "navid" href = "Text/nav.xhtml" media - type = "application/xhtml+xml" properties = "nav" /> "
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            IHTMLStyleSheet ss = doc.createStyleSheet("", 0);
            ss.cssText = @"html *
{
	/*font-family: ""Arial"", Helvetica, sans-serif !important;*/

}
        p {
  font-size:16px;
}

    figure {
	padding: 2px;
	max-width : 95%;
    border: double;
}

figcaption {
	word-wrap: break-word;
	max-width : 100%;
  font-size:16px;
}

img {
	max-width : 100%;
}


object {
  max-width : 100%; 
}

math {
  max-width : 100%;

}

table, th, td {
  border: 1px solid black;
  text-align: center;
}

.transparent {
  display: none;
  color: transparent;
}

body {
	width: 100%;
	margin-left: auto;
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



;"
;
            //splitContainer1.Panel1Collapsed = true;
            //splitContainer1.Panel1.Hide();

            HTMLEditor.Document.Body.KeyUp += new System.Windows.Forms.HtmlElementEventHandler(HTMLEditorBodyKeyDown);



            //HTMLEditor.Document.ExecCommand("FontName", false, "Arial");

            InitHeadingsList();
            InitFontList();
            InitFontSizeList();


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new System.EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            // 'Raise event
          if (containsFile == true && fileEdited == true)
            {
                refreshBrowsers();
                //HTMLEditor.Document.Focus();
            }

        }


        private void refreshBrowsers()
        {
            //Gecko.GeckoDocument.StyleSheetCollection styleSheets12 = geckoWebBrowser1.Document.StyleSheets;
            //GeckoStyleSheet styleSheet12 = geckoWebBrowser1.Document.StyleSheets.First();
            //Console.WriteLine("CSS Text1: " + GetCssText(styleSheet12) + "CSS End");


            if (refresh == false)
            {
                return;
            }

            if (fileEdited == false)
            {
                return;
            }


            wysiwygToHtml();


            if (mode == (int)fileMode.singleFileJs)
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

          
            geckoWebBrowser1.Navigate(contentFile);
            geckoWebBrowser2.Navigate(impairedContentFile);
            geckoWebBrowser3.Navigate(blindContentFile);
            geckoWebBrowser4.Navigate(contentFile);
            


            fileEdited = false;
        }

        private void HTMLEditorBodyKeyDown(object sender, System.Windows.Forms.HtmlElementEventArgs e)
        {
            fileEdited = true;
            fileNotSaved = true;
            //refreshBrowsers();

            //HTMLEditor.Document.Focus();

            if (containsFile == true)
            {
                var text = HTMLEditor.Document.Body.InnerText.Trim();
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
            headings.Add("Paragraph", "<p>");
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
            MathDialogBox mdb = new MathDialogBox(doc, getImageFolder());
            mdb.ShowDialog();

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






        private void orderedListButton_Click(object sender, EventArgs e)
        {
            insertOrderedList();
        }

        private void unorderedListButton_Click(object sender, EventArgs e)
        {
            insertUnorderedList();
        }

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

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.B)
            //{
            //    makeBold();
            //}
            //else if (e.Control && e.KeyCode == Keys.I)
            //{
            //    makeItalic();
            //}
            //else if (e.Control && e.KeyCode == Keys.U)
            //{
            //    makeUnderline();
            //}
            //else if (e.Control && e.KeyCode == Keys.I)
            //{
            //    makeItalic();
            //}


        }

        private void keyPressSave(object sender, KeyPressedEventArgs e)
        {
            if (e.HotKey.Key == Key.S)
            {
                saveFile();
            }

            //if (e.HotKey.Key == Key.None)
            //{
            //    geckoWebBrowser1.Reload();
            //}
        }

        private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeFile(sender, e);
            newSingleFile();
        }

        private void openFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFile(sender, e);
        }

        private void closeFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            closeFile(sender, e);
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
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Show();
            }

            else if (splitContainer1.Panel1Collapsed == false)
            {
                splitContainer1.Panel1Collapsed = true;
                splitContainer1.Panel1.Hide();
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
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Save the file before exiting?", "Save changes", MessageBoxButtons.YesNoCancel);
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
            newSingleFile();
        }

        private void openFileSplashButton_Click(object sender, EventArgs e)
        {
            openFile(sender, e);
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
        }

       
    }


}
