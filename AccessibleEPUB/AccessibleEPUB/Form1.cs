using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;

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

//using GlobalHotKey;
using System.Windows.Input;

using Ionic;






namespace AccessibleEPUB
{
    /// <summary>
    /// Form1 is the entry point of the program and where the editor and preview window are, and is therefore the most important component of the GUI
    /// </summary>
    public partial class Form1 : Form
    {
       
        //ScintillaNET.Scintilla TextArea;
        //ICSharpCode.AvalonEdit.TextEditor codeArea;

        //string initialPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
        //string initialPath = Directory.GetCurrentDirectory();

        /// <summary>
        /// The initial path is used to copy the empty EPUB files to the temp folder
        /// </summary>
        string initialPath = Application.StartupPath;
        
        /// <summary>
        /// The HTML document used by the <c>HTMLEditor</c>
        /// </summary>
        private IHTMLDocument2 doc;

        /// <summary>
        /// A dictionary (like a map) mapping the name as it appears in the <c>formatComboBox</c> to the proper tag used in HTML.
        /// </summary>
        Dictionary<string, string> headings;

        /// <summary>
        /// The initial position of where the <c>importText</c> function starts.
        /// </summary>
        string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// The name of the program as it appears at the top of the window.
        /// </summary>
        string accessibleEpubFormText = "Accessible EPUB";

        /// <summary>
        /// The text editor used for Accessible EPUB if a user wants to program HTML instead of using the editor. 
        /// AvalonEdit was picked as it had syntax highlighting for HTML compared to some of the other
        /// editors available.
        /// </summary>
        ICSharpCode.AvalonEdit.TextEditor codeEditor= new ICSharpCode.AvalonEdit.TextEditor();
        
        /// <summary>
        /// The various file modes which were intended to be available at the beginning. <c>fileMode</c> is used as identifiers  
        /// for the EPUB formats creatable by this editor. It is used frequently to make sure that CSS flavored EPUB file does
        /// not is of the correct format<c>singleFileCss</c> and therefore avoids errors that would take place if it were treated
        /// as anothed format. <c>singleFIleJs</c> are the only formats which can be created with the Accessible EPUB editor. 
        /// <c>onlyVis</c>, <c>onlyBli</c> and <c>onlyImp</c> stand for formats with only single components, which are
        /// regularly sighted, blind and visually impaired respectively.
        /// </summary>
        enum fileMode
        {
            singleFileCss = 1,
            singleFileJs = 2,
            onlyVis = 3,
            onlyBli = 4,
            onlyImp = 5,
            none = 6
        }

        /// <summary>
        /// The format of the currently opened EPUB file, described with values in <c>fileMode</c>.
        /// </summary>
        int mode;

        /// <summary>
        /// The file name of the currently opened EPUB document.
        /// </summary>
        string target;

        /// <summary>
        /// The folder where the currently open EPUB document is located.
        /// </summary>
        string targetFolder;

        /// <summary>
        /// Declares if a document is opened or not. It is used to avoid activating features, which 
        /// can not be used if there is a file. 
        /// </summary>
        bool containsFile = false;

        //string currentTab = null;
        //string lastTab = null;
        
        /// <summary>
        /// The title of the EPUB file, as specified by the Dublin Core Metadata Initiative.
        /// </summary>
        string title;

        /// <summary>
        /// The author of the EPUB file, as specified by the Dublin Core Metadata Initiative.
        /// </summary>
        string author;

        /// <summary>
        /// The language of the EPUB file, as specified by the Dublin Core Metadata Initiative. 
        /// The language is specfied by the ISO 639-1 codes which are two letter shortcuts.
        /// </summary>
        string language;

        /// <summary>
        /// The publisher of the EPUB file, as specified by the Dublin Core Metadata Initiative.
        /// </summary>
        string publisher;


        /// <summary>
        /// The <c>newFileCorrect</c> variable is set by the <c>NewFileDialogBox</c> to check 
        /// that a new file was created and the procedure was not canceled and no new file was 
        /// created. This could unfortunately not be done
        /// </summary>
        bool newFileCorrect;
        
        /// <summary>
        /// The <c>refresh</c> variable is used to control when the preview window and the editor refresh, 
        /// as too frequent refreshes slow down the program too much.
        /// </summary>
        bool refresh = true;


        //bool split1panel1Visible = false;


        //string tempFolderStillInUseLong = "Temp folder is still in use. After pressing OK, the file opening process will stop.";
        //string tempFolderStillInUse = "Folder still in use";
        //string tempFolderInUseLong = "Folder in use. Please leave and then press OK.";
        //string tempFolderInUse = "Folder in use";

        /// <summary>
        /// The <c>fileEdited</c> variable is used to check if the file has been edited since the last save, 
        /// so that the program knows when to ask if the user wants to quit without saving. 
        /// </summary>
        bool fileEdited = false;

        /// <summary>
        /// The <c>fileNotSaved</c> variable is used to check if the file has been edited since the last save, 
        /// so that the program knows when to ask if the user wants to quit without saving. 
        /// </summary>
        bool fileNotSaved = false;

        /// <summary>
        /// Used to check if the method <c>refreshBrowsers</c> occurred, so that the preview browsers can be scrolled 
        /// to the position of <c>scrollHeight</c>.
        /// </summary>
        bool shouldScroll = false;

        /// <summary>
        /// scrollHeight is the current vertical position of the WYSIWYG editor and this will be passed to the 
        /// preview browsers so that the user doesn't have to scroll to the bottom of the screen the whole time.
        /// </summary>
        int scrollHeight = 0;

        bool scrollLock = false;

        /// <summary>
        /// The default location of the open and save file dialogs. 
        /// </summary>
        string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
       Environment.OSVersion.Platform == PlatformID.MacOSX)
? Environment.GetEnvironmentVariable("HOME")
: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");


        /// <summary>
        /// The location of the temp path of the OS, which is also where the temporary Accessible EPUB files will 
        /// be located, like the unpacked EPUB files which will be worked on.
        /// </summary>
        string tempPath = Path.GetTempPath();

        //string tempFolder;

        /// <summary>
        /// The name of the <c>.opf</c> file.
        /// </summary>
        string packageDocumentFile;

        /// <summary>
        /// The name of the folder where content files are located, like HTML pages. The name usually is 
        /// either "EPUB" or "OEBPS".
        /// </summary>
        string rootFolderName;

        /// <summary>
        /// The name of the HTML/XHTML file in the code editor, but not the file in the word-processor-like editor. 
        /// This is used when other HTML files from the same EPUB have to be used.
        /// </summary>
        string currentEditorFile = null;


        /// <summary>
        /// The name of the HTML/XHTML file in the word-processor-like editor. 
        /// This is used when other HTML files from the same EPUB have to be used.
        /// </summary>
        string contentFile;

        /// <summary>
        /// The <c>impairedContentFile</c> has the same content as the HTML file saved under <c>contentFile</c>.
        /// The only difference is that it has a different CSS linked, so it can show the visually impaired 
        /// version of the EPUB.
        /// </summary>
        string impairedContentFile;

        /// <summary>
        /// The <c>blindContentFile</c> has the same content as the HTML file saved under <c>contentFile</c>.
        /// The only difference is that it has a different CSS linked, so it can show the blind
        /// version of the EPUB.
        /// </summary>
        string blindContentFile;

        /// <summary>
        /// The initial file name of the content file in Accessible EPUB. As all Accessible EPUB files
        /// should be structured the same, this value is hard coded in from the beginning.
        /// </summary>
        string contentFileName = "Content.xhtml";

        /// <summary>
        /// The name of the EPUB file, but without the extension, <c>.epub</c>. It is used to create 
        /// the folder in the temp folder where the EPUB contents are located.
        /// </summary>
        string epubFolderName;

        /// <summary>
        /// Time of the last save, which is used to tell the user when they last saved.
        /// </summary>
        DateTime lastSave;

        // The following three lines were used when there was support for tabs for the code editor. 
        // This proved to be very buggy, so it was abandoned and now only code editor is open at
        // any time.
        //List<string> openTabs = new List<string>();
        //List<ICSharpCode.AvalonEdit.TextEditor> openTextEditors = new List<ICSharpCode.AvalonEdit.TextEditor>();
        //Dictionary<string, ICSharpCode.AvalonEdit.TextEditor> tabsToTextEditors = new Dictionary<string, TextEditor>();

        /// <summary>
        /// The name of the folder in the <c>tempFolder</c>, which Accessible EPUB uses.
        /// </summary>
        string accEpubFolderName = Path.Combine(Path.GetTempPath(), "AccessibleEPUB");

        /// <summary>
        /// The HotKeyManager is used to capture global keyboard shortcuts, such as Ctrl + s for saving.
        /// </summary>
        //GlobalHotKey.HotKeyManager hkm = new GlobalHotKey.HotKeyManager();

        //string[] args;     

        /// <summary>
        /// The <c>origWordCountLabel</c> has the original value of the <c>wordCountLabel.Text</c> saved, without any numbers, 
        /// so that no extra string operations such as substring have to be used. 
        /// </summary>
        string origWordCountLabel;

        /// <summary>
        /// The <c>origCharacterCountLabel</c> has the original value of the <c>characterCountLabel.Text</c> saved, without any numbers, 
        /// so that no extra string operations such as substring have to be used. 
        /// </summary>
        string origCharacterCountLabel;

        /// <summary>
        /// The <c>origDocumentLanguageLabel</c> has the original value of the <c>documentLanguageLabel.Text</c> saved, without any numbers, 
        /// so that no extra string operations such as substring have to be used. 
        /// </summary>
        string origDocumentLanguageLabel;

        /// <summary>
        /// The <c>origLastSavedLabel</c> has the original value of the <c>lastSavedLabel.Text</c> saved, without any numbers, 
        /// so that no extra string operations such as substring have to be used. 
        /// </summary>
        string origLastSavedLabel;
        
        /// <summary>
        /// The <c>timer</c> is used to handle the refresh of several items, such as the preview browser, so that the user
        /// sees the changes done in real time.
        /// </summary>
        DispatcherTimer timer;

        /// <summary>
        /// The <c>timer</c> is used to handle the refresh of the headers and figures list.
        /// </summary>
        DispatcherTimer timerForHeaders;

        /// <summary>
        /// The current page number in the current EPUB file.
        /// </summary>
        int currentPageNumber = 1;

        /// <summary>
        /// Indicates if the current page number is counted as a roman numeral.
        /// </summary>
        bool isRomanPageNumber = false;



        /* Program startup */

        /// <summary>
        /// Constructor of <c>Form1</c>, which sets the language, initiates Firefox, the HotKeyManager and the labels.
        /// </summary>
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
           
           
            //var hotKey = hkm.Register(System.Windows.Input.Key.S, System.Windows.Input.ModifierKeys.Control);
            //var globalReload = hkm.Register(System.Windows.Input.Key.None, System.Windows.Input.ModifierKeys.None);

            //hkm.KeyPressed += keyPressSave;
            
            origWordCountLabel = wordCountLabel.Text;
            origCharacterCountLabel = characterCountLabel.Text;

            origDocumentLanguageLabel = documentLanguageLabel.Text;

            versionLabel.Text += String.Format("{0}.{1}." + Version.Build.ToString(),
                 Version.Major.ToString(), Version.Minor.ToString(), Version.MinorRevision.ToString());

            origLastSavedLabel = lastSavedLabel.Text;

          
        }
    
        /// <summary>
        /// Does some changes to the graphical user interface (GUI), which can only be done at run time, and
        /// initiates the Internet Explorer (IE) based browser to use the newest version of IE available.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            /* Some GUI changes which can only be done during run time. */
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
            /* This gets the editor, by inserting common HTML blocks into the document. */
            HTMLEditor.DocumentText = @"<html><body></body></html>"; 

            doc = HTMLEditor.Document.DomDocument as IHTMLDocument2;

            /* Makes the editor be an editable HTML field */
            doc.designMode = "On";                                  


            /* Sets up web browser to have the newest version of internet explorer loaded. Only the newest ones support SVGs and advanced CSS features */
            int BrowserVer, RegVal;

            /* Get the installed IE version */
            using (WebBrowser Wb = new WebBrowser())
                BrowserVer = Wb.Version.Major;

            /* Set the appropriate IE version */
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

            /* Set the actual key */
            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree))
                if (Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe") == null)
                    Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);


            /* Makes the editor and the preview split into two equal parts so that the splitter can be placed in the middle*/
            int halfWidth = splitContainer2.Width / 2;
            splitContainer2.SplitterDistance = halfWidth;

            //versionLabel.Alignment = ToolStripItemAlignment.Right;
            versionToolStrip.Location = new Point(toolStripContainer1.BottomToolStripPanel.Width - versionToolStrip.Width, versionToolStrip.Location.Y);

            languageToolStrip.Location = new Point(toolStripContainer1.BottomToolStripPanel.Width / 2 - languageToolStrip.Width / 2, languageToolStrip.Location.Y);

            
        }


        /// <summary>
        /// Sets up the editor in the form of a WebBrowser when the window has finised loading. 
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void Form1_Shown(object sender, EventArgs e)
        {
            /* Places the code editor in an element host, so it can appear in the Windows Forms. */
            elementHost2.Child = codeEditor;
            codeEditor.WordWrap = true;

            IHTMLStyleSheet ss = doc.createStyleSheet("", 0);

            /* CSS of the initial editor. */
            ss.cssText = @"html *
{
	font-family: ""Arial"", Helvetica, sans-serif !important;

        }
        p {
  font-size:initial;

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

            /* Events of the editor document body. They cannot be added with the GUI builder in the Designer.cs file as it is only created after the window has been loaded. */
            HTMLEditor.Document.Body.KeyUp += new System.Windows.Forms.HtmlElementEventHandler(HTMLEditorBodyKeyUp);

            HTMLEditor.Document.Body.DoubleClick += new System.Windows.Forms.HtmlElementEventHandler(HTMLEditorDoubleClick);

            HTMLEditor.Document.Body.Click += new System.Windows.Forms.HtmlElementEventHandler(HTMLEditorClick);
            
            //HTMLEditor.Document.Body.MouseDown += new System.Windows.Forms.HtmlElementEventHandler(HTMLEditorMouseDown);
            //HTMLEditor.Document.Body.MouseUp += new System.Windows.Forms.HtmlElementEventHandler(HTMLEditorMouseUp);

            //HTMLEditor.Document.ExecCommand("FontName", false, "Arial");

            /* Sets up the drop down menus */
            InitHeadingsList();
            //InitFontList();
            InitFontSizeList();


            /* The timer is required to refresh the preview every second or so */
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new System.EventHandler(timer_Tick);
            timer.Start();

            timerForHeaders = new DispatcherTimer();
            timerForHeaders.Interval = TimeSpan.FromSeconds(30);
            timerForHeaders.Tick += new System.EventHandler(timerForHeaders_Tick);
            timerForHeaders.Start();


            /* Sets up the arguments with which EPUB files can be opened directly with the "Open with" command if there is an argument */
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

      
        /// <summary>
        /// Goes through the given path and return a node with all files as sub nodes. Subdirectories are recursively traversed.
        /// </summary>
        /// <param name="path">The path of the directory which will be traversed and searched though.</param>
        /// <returns>A TreeNode with files as leaves and directories as nodes.</returns>
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
                
                /* Recursive callup. */
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
        /// <summary>
        /// Handles what hapens if a node (file or directory) in the directory view is selected. If it is a valid file, it will be opened.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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
            //string fileName = e.Node.FullPath;
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
            //if (openTabs == null || openTabs.Contains(fileName) == false)
            //{

                //if ((!fileName.EndsWith(".svg")) && (!fileName.EndsWith(".jpg")) && (!fileName.EndsWith(".png")))
                //{
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
                //}


            /* Saves the current file and opens the new file. */
            if (elementHost2.Visible == true && currentEditorFile != null)
            {
                codeEditor.Save(currentEditorFile);

            }
            //currentEditorFile = absPath;
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
            //}

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




        ///// <summary>
        ///// The clicked header will have its corresponding HtmlElement found, and then is scrolled to.
        ///// </summary>
        ///// <param name="sender">Not used.</param>
        ///// <param name="e">Not used.</param>
        private void headerTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

            string outerHtmlKey = e.Node.Name;
            foreach (HtmlElement el in HTMLEditor.Document.Body.Children)
            {
                if (outerHtmlKey == el.OuterHtml)
                {
                    el.ScrollIntoView(true);

                    e.Node.Expand();
                }

            }
        }


        /// <summary>
        /// The clicked figure will have its HtmlElement found, and then is scrolled to.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

 
        /// <summary>
        /// Creates a manifest section in the metadata file. 
        /// </summary>
        /// <param name="manifestFolderName">Location of where the metadata file will be created.</param>
        private void createManifest(string manifestFolderName)
        {
            string searchFolder = Path.Combine(manifestFolderName, rootFolderName);
            string manifestTagOpen = "<manifest>";
            string manifestTagClose = "</manifest>";

            /* The metadata file name is hard coded here as this is the default name expected in the Accessible EPUB standard. */
            string metadataFileName = "content.opf";

            string manifestContent = "";

           
            string metadata = File.ReadAllText(Path.Combine(Path.Combine(manifestFolderName, rootFolderName), metadataFileName));

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

            File.WriteAllText(Path.Combine(Path.Combine(manifestFolderName, rootFolderName), metadataFileName), manifest);
        }


        /// <summary>
        /// Updates the manifest section of the EPUB metadata file to reflect the changes. 
        /// </summary>
        /// <param name="manifestContentParameter">The current content of the manifest.</param>
        /// <param name="searchFolder">The folder which will be searched for files.</param>
        /// <param name="manifestFolderName">Location of where the metadata file will be created.</param>
        /// <returns>String with updated manifest.</returns>
        private string loopManifest(string manifestContentParameter, string searchFolder, string manifestFolderName)
        {
            string initialFolder = Path.Combine(manifestFolderName, rootFolderName);
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

        //}



        /// <summary>
        /// Opens a file in either the code editor or the web browser according to its file type.
        /// </summary>
        /// <param name="absPath">Path of the file to be opened.</param>
        private void openTab(string absPath)
        {
            if (absPath.EndsWith(".xhtml") || absPath.EndsWith(".html"))
            {
                //geckoWebBrowser2.Navigate("about:blank");
                //geckoWebBrowser3.Navigate("about:blank");

                //File.Delete(impairedContentFile);
                //File.Delete(blindContentFile);

                contentFile = absPath;

                /* If it is a JavaScript Accessible EPUB file, the content file can not be used to display each display mode. 
                 * As such, it was necessary to change the reference/link to the CSS file in the content file header to
                 * the CSS of the corresponding display mode. */
                if (mode == (int)fileMode.singleFileJs && contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml")))
                {
                    /*  */
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

                /* There is one web browser for the the CSS version and three for the JavaScript version, and each of them are updated
                 * periodically. */ 
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


                /* Updates the code in the code editor and sets the syxtax highlighting to be in HTML.  */            
                codeEditor.Load(absPath);
                codeEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("HTML");
                currentEditorFile = absPath;
                
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

                if (elementHost2.Visible == true)
                {
                    codeEditor.Load(absPath);
                    codeEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("CSS");
                    currentEditorFile = absPath;
                }


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

                if (elementHost2.Visible == true)
                {
                    codeEditor.Load(absPath);
                    codeEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("JavaScript");
                    currentEditorFile = absPath;
                }
            }


            //else if (e.Node.GetNodeCount(true) == 0)
            //{

            //    splitContainer2.Panel1Collapsed = false;
            //    splitContainer2.Panel1.Show();

            //    splitContainer2.Panel2Collapsed = true;
            //    splitContainer2.Panel2.Hide();
            //    codeArea.Text = File.ReadAllText(absPath);

            //}

            /* For all other files the file is loaded in the code editor, even if it cannot be shown correctly in an editor. */
            else
            {

                //splitContainer2.Panel1Collapsed = false;
                //splitContainer2.Panel1.Show();

                //splitContainer2.Panel2Collapsed = true;
                //splitContainer2.Panel2.Hide();

                //codeArea.Load(absPath);
                //codeArea.Text = File.ReadAllText(absPath);

                if (elementHost2.Visible == true)
                {
                    codeEditor.Load(absPath);
                    currentEditorFile = absPath;
                }
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

        /// <summary>
        /// Opens file which is opened with the "Open with" command in Windows.
        /// </summary>
        /// <param name="parameter">The location of the file to be opened.</param>
        public void parameterOpenFile(string parameter)
        {

            if (!File.Exists(parameter))
            {
                MessageBox.Show(Resource_MessageBox.fileDoesNotExistContent, Resource_MessageBox.fileDoesNotExistTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            /* The name of the EPUB file when located to the temp folder. */
            string epubFileName;       // Formerly tempFile

            /* The name of the EPUB file in the temp folder without the file extension. */
            string fileName = "";      // Formerly tempFile2

            /* The name of the EPUB file, but with .zip as extension instead. */
            string zipFileName = "";     // Formerly tempFile3 


            /* This part is not necessary as there can not be file open if it is opened with a parameter. */
            /* Checks if a file is open and asks if it should be saved before opening a new file. */
            //if (containsFile == true || fileNotSaved == true)
            //{
            //    //DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Save the file before exiting?", "Save changes", MessageBoxButtons.YesNoCancel);
            //    DialogResult dialogResult = System.Windows.Forms.MessageBox.Show(Resource_MessageBox.saveLeavingContent, Resource_MessageBox.saveLeavingTitle, MessageBoxButtons.YesNoCancel);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        saveFile();
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {

            //    }
            //    else if (dialogResult == DialogResult.Cancel)
            //    {
            //        return;
            //    }
            //}

            if (parameter.EndsWith(".epub"))
            {
                /* This part is not necessary as there can not be file open if it is opened with a parameter. */
                //closeFile(new object(), new EventArgs());

                containsFile = true;
                //string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                //tempFolder = Path.Combine(tempPath, "AccessibleEPUB");

                /* Creates the Accessible EPUB temp folder if it doesn't exist yet. */
                DirectoryInfo accEpubFolder = Directory.CreateDirectory(accEpubFolderName);

                //string accEpubFolderName = accEpubFolder.Name;

                System.IO.DirectoryInfo di = new DirectoryInfo(accEpubFolderName);

                /* Empties the files in the temp folder, but not its subfolders, before use.  */
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                int count = 0;

                /* Empties the temp folder before use.  */
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
                            /* Three IOExceptions are given out for every error, so count == 3 prevents the user from getting swarmed with MessagesBox windows. */
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


                /* Checks if the Accessible EPUB temp folder is not in use, and retries until the folder is cleared. */
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

                /* Copies the existing EPUB file to the temp folder. */
                File.Copy(parameter, epubFileName, true);


                if (epubFileName.Contains('.'))
                {
                    fileName = epubFileName.Substring(0, epubFileName.LastIndexOf('.'));
                    epubFolderName = fileName;
                    //contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), contentFileName);
                } 
                else
                {
                    //TODO invalid EPUB file should not be accepted
                }


                zipFileName = fileName + ".zip";


                //using (File.Create(epubFileName)) ;
                //using (File.Create(tempFile2)) ;
                System.IO.File.Move(epubFileName, zipFileName);

                System.IO.Compression.ZipFile.ExtractToDirectory(zipFileName, fileName);

                /* Attempts to the name of the root directory in the EPUB file, which is where all the content files are located. 
                 * It is usually named "OEBPS" or "EPUB".  */
                string[] rootDirectories = System.IO.Directory.GetDirectories(epubFolderName);

                if (rootDirectories.Length == 2)
                {
                    rootFolderName = "";
                }

                for (int i = 0; i < rootDirectories.Length; i++)
                {
                    string rootFolderNameTemp = rootDirectories[i].Substring(Path.GetDirectoryName(rootDirectories[i]).Length + 1);

                    if (rootFolderNameTemp != "META-INF")
                    {
                        rootFolderName = rootFolderNameTemp;
                    }


                }

                //FolderBrowserDialog dialog = new FolderBrowserDialog();
                //if (dialog.ShowDialog() != DialogResult.OK) { return; }
                //dialog.SelectedPath = tempFolder;

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
                //TODO (what is still TODO?)
                MessageBox.Show(Resource_MessageBox.invalidFileContent, Resource_MessageBox.invalidFileTitle);

                return;
            }

            HTMLEditor.Visible = true;

          
       
            if (File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml")))
            {
                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml");
            }
            else
            {
                /* Are these if-statements required? */
                //if (Directory.Exists(Path.Combine(epubFolderName, rootFolderName)))
                //{

                //}
                //else if (Directory.Exists(Path.Combine(epubFolderName, "Text")))
                //{

                //}
               
                /* Finds out how many package document files (OPF) are in the root folder */
                string[] opfFiles = System.IO.Directory.GetFiles(Path.Combine(epubFolderName, rootFolderName), "*.opf");
                //string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"));
                /* If there is no package document file, it is an invalid EPUB file.  */
                if (opfFiles.Length == 0)
                {
                    MessageBox.Show(Resource_MessageBox.noValidOpfContent, Resource_MessageBox.noValidOpfTitle);
                    return;
                }
                /* If there is more than one package document file, it is an invalid EPUB file. */
                else if (opfFiles.Length > 1)
                {
                    MessageBox.Show(Resource_MessageBox.tooManyOpfContent, Resource_MessageBox.tooManyOpfTitle);
                    return;
                }

                packageDocumentFile = opfFiles[0];

                /* If it does not have "Content.xhtml" it automatically cannot follow the Accessible EPUB standard. 
                 * The HTML file which appears first in the metadata is chosen to be the content file.  */
                mode = (int)fileMode.none;
                string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, rootFolderName), packageDocumentFile));
                string firstItem = "<itemref idref=\"";
                int firstIndex = metadata.IndexOf(firstItem) + firstItem.Length;
                string sub = metadata.Substring(firstIndex);
                int endIndex = sub.IndexOf("\"");
                string itemName = sub.Substring(0, endIndex);
                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), itemName);
            }

            if (mode == (int)fileMode.none)
            {

                string textFolder = Path.Combine(epubFolderName, rootFolderName);
                if (Directory.Exists(Path.Combine(textFolder, "Text")))
                {
                    textFolder = Path.Combine(textFolder, "Text");
                }
                else
                {
                    //TODO error when there is no text folder 
                    return;
                }

                string[] textDirectories = System.IO.Directory.GetFiles(textFolder);

                if (textDirectories.Length > 0)
                {
                    /* If there is no content file, the alphabetically first file is loaded into the editor. */
                    contentFile = textDirectories[0];
                }
            }

            determineLanguage();

            string body = File.ReadAllText(contentFile);

            /* Used to detect if EPUB file is a CSS Accessible EPUB file. */
            string imp = "<div style=\"padding:none\" id=\"impaired\" class=\"impaired\">\n<!--StartOfImpairedSection-->\n";

            if (body.Contains(imp))
            {
                mode = (int)fileMode.singleFileCss;
            }
            else if (File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "VersionChanger.xhtml")))
            {
                mode = (int)fileMode.singleFileJs;
            }
            else
            {
                mode = (int)fileMode.none;
            }

            /* Sets up the web browsers. Only the JavaScript files need to have the three preview browsers in TabControl1 visible.
             * All other files only need one preview browser. */
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

            /* Sets up the three preview browsers with each one showing a different display style. */
            if (mode == (int)fileMode.singleFileJs && contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml")))
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

            //if (mode == (int)fileMode.singleFileJs)
            //{
            //    string visibleCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Styles"), "visible.css");
            //    string impairedCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Styles"), "impaired.css");
            //    string blindCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Styles"), "blind.css");

            //    //geckoWebBrowser1.Document.Head.Style.CssText = File.ReadAllText(visibleCss);
            //    //geckoWebBrowser2.Document.Head.Style.CssText = File.ReadAllText(impairedCss);
            //    //geckoWebBrowser3.Document.Head.Style.CssText = File.ReadAllText(blindCss);
            //}

            showToolStrips();
            //splitContainer1.Panel1Collapsed = false;
            //splitContainer1.Panel1.Show();

            /* Changes from initial view to editor view. */
            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();

            splashScreenPanel.Visible = false;

            //TabPage myTabPage = new TabPage(Path.GetFileName(contentFile));

            //string tabPageName = contentFile.Substring(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(contentFile)))).Length + 1);
            //Console.WriteLine(contentFile.Substring(Path.GetDirectoryName(Path.GetDirectoryName(contentFile)).Length));
            //myTabPage.Name = tabPageName;
            //filesTabControl.TabPages.Add(myTabPage);



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


  
        /// <summary>
        /// Opens a EPUB file through the editor itself and sets up the view, editor, and preview.
        /// </summary>
        private void openFile()
        {
            string initialDirectory = Settings.Default.LastDirectory;
            if (initialDirectory == "")
            {
                initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }


            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = initialDirectory;
            openFileDialog1.Filter = "EPUB|*.epub|All Files|*.*";


            /* The name of the EPUB file when located to the temp folder. */
            string epubFileName;       // Formerly tempFile

            /* The name of the EPUB file in the temp folder without the file extension. */
            string fileName = "";      // Formerly tempFile2

            /* The name of the EPUB file, but with .zip as extension instead. */
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
                Settings.Default.LastDirectory = Path.GetDirectoryName(openFileDialog1.FileName);

                if (!openFileDialog1.FileName.EndsWith(".epub")){
                    MessageBox.Show(Resource_MessageBox.notEpubContent, Resource_MessageBox.notEpubTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                closeFile();

                containsFile = true;
                //string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                //tempFolder = Path.Combine(tempPath, "AccessibleEPUB");

                /* Creates the Accessible EPUB temp folder if it doesn't exist yet. */
                DirectoryInfo accEpubFolder = Directory.CreateDirectory(accEpubFolderName);

                //string accEpubFolderName = accEpubFolder.Name;

                System.IO.DirectoryInfo di = new DirectoryInfo(accEpubFolderName);

                /* Empties the files in the temp folder, but not its subfolders, before use.  */
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }

                int count = 0;

                /* Empties the temp folder before use. */
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

                            /* Three IOExceptions are given out for every error, so count == 3 prevents the user from getting swarmed with MessagesBox windows. */
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

                /* Copies the existing EPUB file to the temp folder. */
                File.Copy(openFileDialog1.FileName, epubFileName, true);

                if (epubFileName.Contains('.'))
                {
                    fileName = epubFileName.Substring(0, epubFileName.LastIndexOf('.'));
                    epubFolderName = fileName;
                    //contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), contentFileName);
                }
                else
                {
                    //TODO invalid EPUB file should not be accepted
                }

                zipFileName = fileName + ".zip";

               
                //using (File.Create(epubFileName)) ;
                //using (File.Create(tempFile2)) ;
                System.IO.File.Move(epubFileName, zipFileName);

                System.IO.Compression.ZipFile.ExtractToDirectory(zipFileName, fileName);

                /* Attempts to the name of the root directory in the EPUB file, which is where all the content files are located. 
                 * It is usually named "OEBPS" or "EPUB".  */
                string[] rootDirectories = System.IO.Directory.GetDirectories(epubFolderName);

                if (rootDirectories.Length > 2)
                {
                    rootFolderName = "";
                }

                for (int i = 0; i < rootDirectories.Length; i++)
                {
                    string rootFolderNameTemp = rootDirectories[i].Substring(Path.GetDirectoryName(rootDirectories[i]).Length + 1);

                    if (rootFolderNameTemp != "META-INF")
                    {
                        rootFolderName = rootFolderNameTemp;
                    }


                }

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
                //TODO (what is still TODO?)
                //MessageBox.Show(Resource_MessageBox.invalidFileContent, Resource_MessageBox.invalidFileTitle);

                return;
            }

          
            HTMLEditor.Visible = true;

            if (File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml")))
            {
                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml");
            }
            else
            {
                /* Finds out how many package document files (OPF) are in the root folder. */
                string[] opfFiles = System.IO.Directory.GetFiles(Path.Combine(epubFolderName, rootFolderName), "*.opf");
                //string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"));
                /* If there is no package document file, it is an invalid EPUB file.  */
                if (opfFiles.Length == 0)
                {
                    MessageBox.Show("No valid package document file (opf)");
                    return;
                }
                /* If there is more than one package document file, it is an invalid EPUB file. */
                else if (opfFiles.Length > 1)
                {
                    MessageBox.Show("Too many package document files (opf)");
                    return;
                }

                packageDocumentFile = opfFiles[0];

                /* If it does not have "Content.xhtml" it automatically cannot follow the Accessible EPUB standard. 
                 * The HTML file which appears first in the metadata is chosen to be the content file.  */
                mode = (int)fileMode.none;
                string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, rootFolderName), packageDocumentFile));
                string firstItem = "<itemref idref=\"";
                int firstIndex = metadata.IndexOf(firstItem) + firstItem.Length;
                string sub = metadata.Substring(firstIndex);
                int endIndex = sub.IndexOf("\"");
                string itemName = sub.Substring(0, endIndex);
                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), itemName);
            }

            if (mode == (int)fileMode.none)
            {

                string textFolder = Path.Combine(epubFolderName, rootFolderName);
                if (Directory.Exists(Path.Combine(textFolder, "Text")))
                {
                    textFolder = Path.Combine(textFolder, "Text");
                }
                else
                {
                    //TODO error when there is no text folder 
                    return;
                }

                string[] textDirectories = System.IO.Directory.GetFiles(textFolder);

                if (textDirectories.Length > 0)
                {
                    /* If there is no content file, the alphabetically first file is loaded into the editor. */
                    contentFile = textDirectories[0];
                }
            }

            determineLanguage();

            string body = File.ReadAllText(contentFile);

            /* Used to detect if EPUB file is a CSS Accessible EPUB file. */
            string imp = "<div style=\"padding:none\" id=\"impaired\" class=\"impaired\">\n<!--StartOfImpairedSection-->\n";

            if (body.Contains(imp))
            {
                mode = (int)fileMode.singleFileCss;
            }
            else if (File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "VersionChanger.xhtml")))
            {
                mode = (int)fileMode.singleFileJs;
            }
            else
            {
                mode = (int)fileMode.none;
            }

            /* Sets up the web browsers. Only the JavaScript files need to have the three preview browsers in TabControl1 visible.
             * All other files only need one preview browser. */
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

            /* Sets up the three preview browsers with each one showing a different display style. */
            if (mode == (int)fileMode.singleFileJs && contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml")))
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

          
            //if (mode != (int)fileMode.none)
            //{
            geckoWebBrowser4.Navigate(contentFile);

            htmlToWysiwyg();

            //}

            

            //if (mode == (int)fileMode.singleFileJs)
            //{
            //    string visibleCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Styles"), "visible.css");
            //    string impairedCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Styles"), "impaired.css");
            //    string blindCss = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Styles"), "blind.css");

            //    //geckoWebBrowser1.Document.Head.Style.CssText = File.ReadAllText(visibleCss);
            //    //geckoWebBrowser2.Document.Head.Style.CssText = File.ReadAllText(impairedCss);
            //    //geckoWebBrowser3.Document.Head.Style.CssText = File.ReadAllText(blindCss);
            //}

            showToolStrips();
            //splitContainer1.Panel1Collapsed = false;
            //splitContainer1.Panel1.Show();

            /* Changes from initial view to editor view. */
            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();

            splashScreenPanel.Visible = false;

            //TabPage myTabPage = new TabPage(Path.GetFileName(contentFile));

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

            string bodyText = HTMLEditor.Document.Body.OuterHtml;

            string toFind = "xml:id=\"page";

            int pageNumberIndex = bodyText.LastIndexOf(toFind);
            Console.WriteLine("PageNumberIndex: " + pageNumberIndex);
            if (pageNumberIndex > 0)
            {
                string pageNumberText = "";
                int i = 0;
                while (char.IsDigit(bodyText[pageNumberIndex + toFind.Length + i])) {
                    pageNumberText = pageNumberText + bodyText[pageNumberIndex + toFind.Length + i];
                    i++;
                }
                Int32.TryParse(pageNumberText, out currentPageNumber);
                currentPageNumber++;
            }



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






        /// <summary>
        /// Closes the current file and resets the view to the initial one. 
        /// </summary>
        private void closeFile()
        {
            splitContainer1.Panel1Collapsed = true;
          
            //filesTabControl.TabPages.Clear();
            treeView1.Nodes.Clear();
            //openTabs.Clear();
            //openTextEditors.Clear();
            //tabsToTextEditors.Clear();

            containsFile = false;
            fileEdited = false;

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



        /* These public setter methods are used by the NewFileDialogBox form to change attributes of the EPUB. */
        /// <summary>
        /// Sets the mode of the EPUB file. 
        /// </summary>
        /// <param name="modeNew">The new mode</param>
        public void setMode(int modeNew)
        {
            mode = modeNew;
        }

        /// <summary>
        /// Sets the author of the EPUB file.
        /// </summary>
        /// <param name="authorNew">The new author</param>
        public void setAuthor(string authorNew)
        {
            author = authorNew;
        }

        /// <summary>
        /// Sets the  title of the EPUB file.
        /// </summary>
        /// <param name="titleNew">The new title</param>
        public void setTitle(string titleNew)
        {
            title = titleNew;
        }

        /// <summary>
        /// Sets the language of the EPUB file.
        /// </summary>
        /// <param name="languageNew">The new language</param>
        public void setLanguage(string languageNew)
        {
            language = languageNew;
        }

        /// <summary>
        /// Sets the publisher of the EPUB file.
        /// </summary>
        /// <param name="publisherNew">The new publisher</param>
        public void setPublisher(string publisherNew)
        {
            publisher = publisherNew;
        }

        /// <summary>
        /// Get a variable which is true if a new file was actually created or and false if the process was halted in the middle.
        /// </summary>
        /// <param name="newFileCorrectNew">It is true if a new file was actually created or and false if the process was halted in the middle.</param>
        public void setNewFileCorrect(bool newFileCorrectNew)
        {
            newFileCorrect = newFileCorrectNew;
        }


        /// <summary>
        /// Enables user to create a new file in either display mode. 
        /// </summary>
        private void newSingleFile()
        {

            contentFileName = "Content.xhtml";

            //tempFolder = Path.Combine(tempPath, "AccessibleEPUB");

            string initialDirectory = Settings.Default.LastDirectory;
            if (initialDirectory == "")
            {
                initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "EPUB|*.epub";
            saveFileDialog1.Title = "Create a new EPUB File";
            saveFileDialog1.InitialDirectory = initialDirectory;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
            {
                return;
            }

            Settings.Default.LastDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);

            NewFileDialogBox nfd = new NewFileDialogBox(this);
            nfd.ShowDialog();

            /* If the NewFileDialogBox was cancelled, no file should be created. */
            if (newFileCorrect == false)
            {
                return;
            }

            /* If a file of the same name exists, it will be deleted first. */
            if (saveFileDialog1.CheckFileExists)
            {
                File.Delete(saveFileDialog1.FileName);
            }
            
            closeFile();

            containsFile = true;

            HTMLEditor.Visible = true;
            HTMLEditor.DocumentText = @"<html><body></body></html>";

            /* Changes from initial view to editor view. */
            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();

            splashScreenPanel.Visible = false;
 

            target = saveFileDialog1.FileName;
            targetFolder = Path.GetDirectoryName(target);



            //DirectoryDelete(accEpubFolderName);

            /* Creates the Accessible EPUB temp folder if it doesn't exist yet. */
            //DirectoryInfo accEpubFolder = Directory.CreateDirectory(accEpubFolderName);
       
            //string accEpubFolderName = accEpubFolder.Name;

            System.IO.DirectoryInfo di = new DirectoryInfo(accEpubFolderName);

            /* Empties the files in the temp folder, but not its subfolders, before use.  */
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            int count = 0;

            /* Empties the temp folder before use. */
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
                        /* Three IOExceptions are given out for every error, so count == 3 prevents the user from getting swarmed with MessagesBox windows. */
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

                /* Copies the template zip file to the temp folder. */
                string emptySingleFileZip = Path.Combine("EmptyFiles", "SingleFile", "empty_Single_File.zip");
                string emptySingleFileEpub = Path.Combine("EmptyFiles", "SingleFile", "empty_Single_File.epub");
                File.Copy(Path.Combine(initialPath, emptySingleFileZip), Path.Combine(accEpubFolderName, "empty_Single_File.zip"), true);


                //CloneDirectory(initialPath + "\\EmptyFiles\\empty_Single_File", targetFolder);

                /* Copies the template EPUB file to target file location. */
                File.Copy(Path.Combine(initialPath, emptySingleFileEpub), target, true);

                /* Changes the last write time of the just copied EPUB file, so the date is not the creation time of the original EPUB file.  */
                File.SetLastWriteTime(target, DateTime.Now);

                //System.IO.Compression.ZipFile.CreateFromDirectory(targetFolder + "\\empty_Single_File", targetFolder + "\\empty_Single_File.zip");


                //File.Move(targetFolder + "\\empty_Single_File.zip", target);


                //Directory.Move(targetFolder + "\\empty_Single_File", targetFolder + "\\" + Path.GetFileName(target));

                //File.Copy(initialPath + "\\EmptyFiles\\empty_Single_File.zip", targetFolder);
                //File.Move(targetFolder + "\\empty_Single_File.zip", target)

                //target = accEpubFolderName + "\\" + IInputBox.Show("What should be the name of the EPUB file?", "New File Name" ).ToString();
                //System.IO.Compression.ZipFile.ExtractToDirectory(accEpubFolderName + "\\empty_Single_File.zip", accEpubFolderName + "\\" + Path.GetFileName(target));
                //Directory.Move(accEpubFolderName + "\\empty_Single_File", accEpubFolderName + Path.GetFileName(target));

                /* The name of the EPUB file when located to the temp folder. */
                string epubFileName;       // Formerly tempFile

                /* The name of the EPUB file in the temp folder without the file extension. */
                string fileName = "";      // Formerly tempFile2

                /* The name of the EPUB file, but with .zip as extension instead. */
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

                /* OEBPS is the rootFolderName chosen for the Accessible EPUB standard. */
                rootFolderName = "OEBPS";

                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), contentFileName);

                System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(accEpubFolderName, "empty_Single_File.zip"), fileName);

                zipFileName = fileName + ".zip";

                File.Delete(Path.Combine(accEpubFolderName, "empty_Single_File.zip"));
            }
            else if (mode == (int)fileMode.singleFileJs)
            {
                string setPath = Path.Combine(Path.Combine(Path.Combine("", "EmptyFiles"), "JsVersionChanger"), "emptyJsFile");
         
                //CloneDirectory(initialPath + "\\EmptyFiles\\empty_Single_File", accEpubFolderName);
                File.Copy(Path.Combine(initialPath, setPath + ".zip"), Path.Combine(accEpubFolderName, "empty_Single_File.zip"), true);


                //CloneDirectory(initialPath + "\\EmptyFiles\\empty_Single_File", targetFolder);

                /* Copies the template EPUB file to target file location. */
                File.Copy(Path.Combine(initialPath, setPath + ".epub"), target, true);

                /* Changes the last write time of the just copied EPUB file, so the date is not the creation time of the original EPUB file.  */
                File.SetLastWriteTime(target, DateTime.Now);

                //System.IO.Compression.ZipFile.CreateFromDirectory(targetFolder + "\\empty_Single_File", targetFolder + "\\empty_Single_File.zip");

                //File.Move(targetFolder + "\\empty_Single_File.zip", target);


                //Directory.Move(targetFolder + "\\empty_Single_File", targetFolder + "\\" + Path.GetFileName(target));

                //File.Copy(initialPath + "\\EmptyFiles\\empty_Single_File.zip", targetFolder);
                //File.Move(targetFolder + "\\empty_Single_File.zip", target)

                //target = accEpubFolderName + "\\" + IInputBox.Show("What should be the name of the EPUB file?", "New File Name" ).ToString();
                //System.IO.Compression.ZipFile.ExtractToDirectory(accEpubFolderName + "\\empty_Single_File.zip", accEpubFolderName + "\\" + Path.GetFileName(target));
                //Directory.Move(accEpubFolderName + "\\empty_Single_File", accEpubFolderName + Path.GetFileName(target));

                /* The name of the EPUB file when located to the temp folder. */
                string epubFileName;       // Formerly tempFile

                /* The name of the EPUB file in the temp folder without the file extension. */
                string fileName = "";      // Formerly tempFile2

                /* The name of the EPUB file, but with .zip as extension instead. */
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

                /* OEBPS is the rootFolderName chosen for the Accessible EPUB standard. */
                rootFolderName = "OEBPS";

                contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), contentFileName);
            
                System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(accEpubFolderName, "empty_Single_File.zip"), fileName);           

                zipFileName = fileName + ".zip";

                File.Delete(Path.Combine(accEpubFolderName, "empty_Single_File.zip"));
            }

            /* Shows the CSS specific window view. */
            if (mode == (int)fileMode.singleFileCss)
            {
                splitContainer2.Panel2Collapsed = true;
                splitContainer2.Panel2.Hide();
                splitContainer2.Panel2.Visible = false;
                geckoWebBrowser4.Visible = true;
            }
            /* Shows the JavaScript specific window view. */
            else
            {
                splitContainer2.Panel2Collapsed = false;
                splitContainer2.Panel2.Show();
                splitContainer2.Panel2.Visible = true;
                geckoWebBrowser4.Visible = false;
                TabControl1.Visible = true;
            }
            
            //using (File.Create(epubFileName)) ;
            //using (File.Create(tempFile2)) ;
            //System.IO.File.Move(epubFileName, zipFileName);

            //System.IO.Compression.ZipFile.ExtractToDirectory(zipFileName, fileName);

            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            //if (dialog.ShowDialog() != DialogResult.OK) { return; }
            //dialog.SelectedPath = tempFolder;
            this.treeView1.Nodes.Add(TraverseDirectory(epubFolderName));

            //this.treeView1.CollapseAll();
            //foreach (TreeNode node in this.treeView1.Nodes)
            //{
            //    node.Collapse();
            //}


            //webBrowser1.Navigate(tempFile2 + "\\OEBPS\\Text\\Content.xhtml");
            //richTextBox1.Text = webBrowser1.DocumentText;

            //richTextBox1.LoadFile(tempFile2 + "\\OEBPS\\Styles\\style.css");

            /* Edits the premade metadata file to add the information entered by the user in the NewFileDialogBox. */
            string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "content.opf"));

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

            /* Creation date of the file. */
            string time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            //string identifier = "AccessibleEPUB:" + DateTime.UtcNow.ToString("yyyy-MM-ddTZ");
  
            /* The indices are to find the position of the tags and place the appropriate values in between
             * the start and end of the tags.  */
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

            //TODO Is languageShort needed? language could just be used instead.
            string languageShort;
            
            languageShort = language;
            //switch (language)
            //{
            //    case "en":
            //        languageShort = "en";
            //        break;
            //    case "de":
            //        languageShort = "de";
            //        break;
            //    default:
            //        languageShort = "en";
            //        break;
            //}

            //List<int> order = new List<int>{titleStartIndex, titleEndIndex, creatorStartIndex, creatorEndIndex, languageStartIndex, languageEndIndex };

            /* The tagsList has the following elements in the tuple: 
             * Item1: Index of Item2 string in the metadata string 
             * Item2: A tag for the metadata file
             * Item3: The content which is to be placed after after Item2.
             * Item3 is an empty string if Item2 is an ending tag.  */ 
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

            /* Orders by appearance of tag in the metadata file.  */
            tagsList = tagsList.OrderBy(x => x.Item1).ToList();
            tagsList.Sort();

            //List<string> metaItems = new List<string>();

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

            /* A Universally Unique Identifier (UUID) (or Globally Unique Identifier (GUID) 
             * has to be present in the BookId tag of every EPUB file, so it is created here.  */
            Guid uuid = Guid.NewGuid();
            string uuidString = uuid.ToString().Replace("-", "");

   

            if (publisher == "")
            {
                newMetaData = newMetaData.Replace(publisherStart, "");
                newMetaData = newMetaData.Replace(publisherEnd, "");
            }

            /* "BookIdentificationNumber" is the placeholder for the UUID, so once an UUID is created, it can be replaced. */
            newMetaData = newMetaData.Replace("BookIdentificationNumber", uuidString);

            File.WriteAllText(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "content.opf"), newMetaData);

            /* Creates the file names for the temporary visually impaired and blind content files which will shown in the preview. 
             * Only an "Imp" and "Bli" are added as prefix to the actual file name. */
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

            /* Replaces the CSS link file name reference in the HTML header section with the CSS file name of the
             * other display styles. */
            impFile = impFile.Replace(cssString, impCssString);
            bliFile = bliFile.Replace(cssString, bliCssString);

            if (mode == (int)fileMode.singleFileJs)
            {
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Imp" + Path.GetFileName(contentFile)), impFile);
                File.WriteAllText(Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "Bli" + Path.GetFileName(contentFile)), bliFile);
            }

            /* Sets up the view before use */
            determineLanguage();

            HTMLEditor.Document.Body.InnerText += "\n";

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

        /// <summary>
        /// Reads the metadata file to figure out the language of the EPUB file.
        /// </summary>
        private void determineLanguage()
        {
            string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "content.opf"));

            string languageStart = "<dc:language";
            string languageEnd = "</dc:language>";
            string closeTag = ">";


            int languageStartIndex = metadata.IndexOf(languageStart);
            int languageEndTagIndex = metadata.Substring(languageStartIndex).IndexOf(closeTag);
            int languageEndIndex = metadata.IndexOf(languageEnd);
            
            language = metadata.Substring(languageStartIndex + languageEndTagIndex + closeTag.Length, languageEndIndex - languageStartIndex - languageEndTagIndex - closeTag.Length);
        
        }

        /* The next few methods handle special directory actions */

        /// <summary>
        /// Deletes the contents of an empty or not empty directory, but not the directory itself.
        /// </summary>
        /// <param name="path"></param>
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
                    /* Three IOExceptions are given out for every error, so count == 3 prevents the user from getting swarmed with MessagesBox windows. */
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

        /// <summary>
        /// Copies the contents of the directory, but not the directory itself.
        /// </summary>
        /// <param name="sourceDirName">The directory from where the contents are copied.</param>
        /// <param name="destDirName">The directory to where the contents are copied. </param>
        private static void DirectoryCopy(string sourceDirName, string destDirName)
        {
            // Copied from https://msdn.microsoft.com/en-us/library/bb762914(v=vs.110).aspx
            
            /* Get the subdirectories for the specified directory. */
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            /* If the destination directory doesn't exist, create it. */
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            /* Get the files in the directory and copy them to the new location. */
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temp = Path.Combine(destDirName, file.Name);
                //file.CopyTo(temp, false);
                file.CopyTo(temp, true);

            }

            /* If copying subdirectories, copy them and their contents to new location. */

            foreach (DirectoryInfo subdir in dirs)
            {
                string temp = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temp);
            }

        }

        /* Tab support for the code editor was removed so this function is unnecessary. */
        /* Refreshes the code editor view to have the newest content. */
        //private void filesTabControl_Selected(object sender, TabControlEventArgs e)
        //{
        //if (filesTabControl.TabPages.Count >= 1)
        //{
        //    filesTabControl.SelectedTab = e.TabPage;

        //    string absPath = Path.Combine(accEpubFolderName, e.TabPage.Name);
        //    openTab(absPath);
        //}
        //}

  
        /// <summary>
        /// Generates the table of contents, but only for JavaScript version of Accessible EPUB, as the CSS version does not support it. 
        /// To make generating a table of contents possible, headers and figures get an ID added.
        /// </summary>
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

            //TODO Order of "if statements": should checking for singleFileJs come before the other, as that is more important?
            //TODO Furthermore, should there be an error message, as this is done automatically without the user knowing.
            /* File has to be an Accessible EPUB file. */
            if (!File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml")))
            {
                //MessageBox.Show("Table of Contents can only be generated if file was created in Accessible EPUB.", "Table of contents error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //TODO Should there be an error message as this method is called automatically.
                //MessageBox.Show(Resource_MessageBox.tocAccEpubContent, Resource_MessageBox.tocAccEpubTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //TODO Should this "if statement" appear before the earlier one?
            if (mode != (int)fileMode.singleFileJs)
            {
                //MessageBox.Show("Table of contents only supported in JavaScript Mode.", "Table of contents error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //MessageBox.Show(Resource_MessageBox.tocJsContent, Resource_MessageBox.tocJsTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //string oldContentFile = contentFile;
            //contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml");

            /* Since it is an Accessible EPUB file, it can be guaranteed that "Content.xhtml" exists. */
            string fileToRead = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml");

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

            /* This is used to find out how long the starting <body> tag is. */
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

            string hRegex = "<h[1-6][^>]*?>(?<TagText>.*?)</h[1-6]>";

            //string hRegex = "<h[1-6]";
            
            MatchCollection mc = Regex.Matches(bodyContent, hRegex, RegexOptions.Singleline);

            //MatchCollection mc1 = Regex.Matches(bodyContent, hRegex, RegexOptions.Singleline);

            /* A list with all the headers in the content file.
             * Item1: The whole match so from opening to closing tag of the header
             * Item2: The level of the header, so between 1 to 6
             * Item3: The text in between the opening and closing tag with new line characters replaced.
             *  */
            List<Tuple<string, string, string>> headersList = new List<Tuple<string, string, string>>();

            /* A list with the original match and an slightly edited version of it, with which the original match will be replaced by. 
             * Item1: The old whole match, so Item1 of headersList
             * Item2: The new content which is to replace the match. */
            List<Tuple<string, string>> oldNew = new List<Tuple<string, string>>();

            //int hCount = Regex.Matches(bodyContent, hRegex).Count;

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

            //string idString = " id=\"";
            
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

            /* Adds the headers with their new IDs. */
            foreach (var entry in oldNew)
            {
                bodyContent = bodyContent.Replace(entry.Item1, entry.Item2);

            }

            //Console.WriteLine(bodyContent);
            File.WriteAllText(Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml"), header + bodyContent + closer);


            /* The following code generates the table of contents. */
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

            //TODO ncx table of contents

            string textFolder = "../Text/";

            //string longtextFolder = Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text").Replace("\\", "/") + "/";
            //string tabs = "\t";
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


            /* The table of contents is added to the "nav.xhtml" file. */
            string navfileToRead = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "nav.xhtml");

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

            /* This is used to find out how long the starting <nav> tag is. */
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

            File.WriteAllText(Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "nav.xhtml"), navbodyContent);

            string tocSpineEntry = "<itemref idref=\"navid\"/>";
            string oldSpine = "<itemref idref=\"VersionChanger.xhtml\"/>\n";
            string newSpine = "<itemref idref=\"VersionChanger.xhtml\"/>\n\t<itemref idref=\"navid\"/>\n"; ;

            string metadata = File.ReadAllText(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "content.opf"));

            if (metadata.Contains(tocSpineEntry))
            {
                return;
            }
            


            metadata = metadata.Replace(oldSpine, newSpine);

            File.WriteAllText(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "content.opf"), metadata);

            //foreach (Match a in mc1)
            //{
            //    //Console.WriteLine(a.Value);
            //}
            //Console.WriteLine(h1Count);

            //Console.WriteLine(bodyContent);


            //contentFile = oldContentFile;
            //htmlToWysiwyg();
        }


        /* The XHTML div section splits for each section. */
        /// <summary>
        /// The marker for the beginning of the content section in the XHTML body. The links to change the display style are placed ahead of this marker.
        /// </summary>
        string startOfContent = "<!--StartOfContent-->";

        /// <summary>
        /// The marker for the start of the visually impaired section.
        /// </summary>
        string imp = "<div style=\"padding:none\" id=\"impaired\" class=\"impaired\">\n<!--StartOfImpairedSection-->\n";

        /// <summary>
        /// The marker for the end of the visually impaired section.
        /// </summary>
        string impEnd = "<!--EndOfImpairedSection-->\n</div>\n";

        /// <summary>
        /// The marker for the start of the blind section.
        /// </summary>
        string bli = "<div id=\"blind\" class=\"blind\">\n<!--StartOfBlindSection-->\n";

        /// <summary>
        /// The marker for the end of the blind section.
        /// </summary>
        string bliEnd = "<!--EndOfBlindSection-->\n</div>\n";

        /// <summary>
        /// The marker for the start of the normal section.
        /// </summary>
        string vis = "<div id=\"visible\" class=\"visible\">\n<!--StartOfVisibleSection-->\n";

        /// <summary>
        /// The marker for the end of the normal section.
        /// </summary>
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


     
        /// <summary>
        /// Zips up the EPUB as according to the EPUB standards. The mimetype file should not be compressed, so it is added separately. 
        /// </summary>
        /// <param name="source">The name of the directory where all the files of the EPUB will be located.</param>
        /// <param name="dest">The destination and name of the compressed file.</param>
        private void createEpubZip(string source, string dest)
        {
            // Copied and slightly adjusted from https://stackoverflow.com/questions/5898787/creating-an-epub-file-with-a-zip-library. 

            /* Creating ZIP file and writing mimetype. */
            using (Ionic.Zip.ZipOutputStream zs = new Ionic.Zip.ZipOutputStream(dest))
            {
                var o = zs.PutNextEntry("mimetype");
                o.CompressionLevel = Ionic.Zlib.CompressionLevel.None;

                byte[] mimetype = System.Text.Encoding.ASCII.GetBytes("application/epub+zip");
                zs.Write(mimetype, 0, mimetype.Length);
            }

            /* Adding META-INF and OEPBS folders including files. */
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(dest))
            {
                zip.AddDirectory(Path.Combine(source, "META-INF"), "META-INF");
                zip.AddDirectory(Path.Combine(source, rootFolderName), rootFolderName);
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

        /// <summary>
        /// Saves the EPUB file by calling up saveFile().
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        /// <summary>
        /// Saves the EPUB file to the target location.
        /// </summary>
        private void saveFile()
        {
            if (containsFile == false)
            {
                return;
            }
            //if (filesTabControl.Visible == false)

            /* Depending on if the code editor is being used or not, saving has to be done differently. */
            if (elementHost2.Visible == false)
            {

                if (refresh == true)
                {
                    wysiwygToHtml();
                }
                else
                {
                    convertInlineFormula();
                }

              
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
            
            impairedContentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "ImpContent.xhtml");
            blindContentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "BliContent.xhtml");
        
            /* Deletes the temporary visually impaired and blind content files if they exist, so they don't get added
             * to EPUB file. */
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

            /* Deletes the zip file with the old files in temp folder and replaces it with the updated files. */
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

            /* Recreates the temporary visually impaired and blind content files and reloads them to the preview browsers. */
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

        /// <summary>
        /// Toggles the visibility of the code editor. Converts the content from HTML code to the WYSIWYG editor and vice versa, 
        /// depending on if the code editor was visible before or not.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Converts code editor code to WYSIWYG editor suitable code. 
        /// </summary>
        private void htmlToWysiwyg()
        {
            /* The WYSIWYG editor uses Internet Explorer as a base, so it does not support XHTML, so the 
             * content has to be converted to HTML code. */

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

            if (elementHost2.Visible == true && currentEditorFile != null)
            {
                codeEditor.Save(currentEditorFile);
            }

            string bodyStart = "<body";
            string bodyEnd = "</body>";

            //TODO Is singleFileMode required? It could be replaced with fileMode.singleFileCss
            bool singleFileMode = true;
            //bool contentFileExists = true;
            string body = "";
            if (File.Exists(contentFile))
            {
                body = File.ReadAllText(contentFile);
                
                body = body.Replace(Path.Combine("..", ""), Path.Combine(epubFolderName, rootFolderName));

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
                //contentFileExists = false;
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


            
            /* It has to be InnerHtml and not OuterHtml. Otherwise editing images and math would not work */
            string mathBody = HTMLEditor.Document.Body.InnerHtml.Replace("\n", "");




            //Regex inlineMathRegex = new Regex(@"<span class=""inlineFormula"">/^(.*?)</span>/");
            //Regex inlineMathRegex = new Regex(@"<span class=""inlineFormula"">[.]*(?:(?!\<\/span\>).)*");


            /* Inline math is recognized and converted here */
            Regex inlineMathRegex = new Regex(@"<span class=""inlineFormula"" (?:(?!(<!--EndOfInlineMath-->)).)*<!--EndOfInlineMath-->", RegexOptions.IgnoreCase);
            Regex inlineMathRegex2 = new Regex(@"<div class=""inlineFormula"" (?:(?!(</p>)).)*</p>", RegexOptions.IgnoreCase);



            MatchCollection inlineMathMatches = inlineMathRegex.Matches(mathBody);

            if (inlineMathMatches.Count > 0)
            {
                foreach (Match m in inlineMathMatches)
                {
                    
                  
                    Regex formulaRegex = new Regex(@"\$[^\$]+\$");
                   
                    Match formulaMatch = formulaRegex.Match(m.ToString());
               
                    mathBody = mathBody.Replace(m.ToString(), "$" + formulaMatch.ToString() + "$");
                    
                }

    
                HTMLEditor.Document.Body.InnerHtml = mathBody;
                //HTMLEditor.Document.Body.OuterHtml = HTMLEditor.Document.Body.OuterHtml.Replace("<P></P>", "");
            }

            MatchCollection inlineMathMatches2 = inlineMathRegex2.Matches(mathBody);

            if (inlineMathMatches2.Count > 0)
            {
                foreach (Match m in inlineMathMatches2)
                {


                    Regex formulaRegex = new Regex(@"\$[^\$]+\$");

                    Match formulaMatch = formulaRegex.Match(m.ToString());

                    mathBody = mathBody.Replace(m.ToString(), "$" + formulaMatch.ToString() + "$");

                }


                HTMLEditor.Document.Body.InnerHtml = mathBody;
                //HTMLEditor.Document.Body.OuterHtml = HTMLEditor.Document.Body.OuterHtml.Replace("<P></P>", "");
            }


        }

        /// <summary>
        /// Converts inline formulas to MathML.
        /// </summary>
        private void convertInlineFormula()
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

            /* Removes all span elements inserted by the editor as it affects and disrupts spacing and layout. No span elements 
             * are added by Accessible EPUB itself. */
            Regex spanRegex = new Regex(@"<span[^>]*>(.*?)<\/span>");
            //Console.WriteLine(body);
            MatchCollection spanMatches = spanRegex.Matches(body);
            
            //Console.WriteLine("LALA:" + sp.ToString());
            //Console.WriteLine("BABA:" + sp.Groups[1].ToString());

            //foreach (Match span in spanMatches)
            //{
            //    string replacementString = span.Groups[1].ToString();
            //    body = body.Replace(span.ToString(), replacementString);
               
            //}

            if (body == null)
            {
                return;
            }

            //Console.WriteLine(contentFile);

            string newContent = "";
            string contentBody = "";

            string textFolder = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"));
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

            body = body.Replace(Path.Combine(epubFolderName, rootFolderName), "..");

            /* Replaces the annotation tags which are present in MathML. */
            string annoStart = "<annotation encoding=\"application/x-tex\">";
            string annoEnd = "</annotation>";

            while (body.Contains(annoStart) && body.Contains(annoEnd))
            {
                int start = body.IndexOf(annoStart);
                int end = body.IndexOf(annoEnd) + annoEnd.Length;

                body = body.Replace(body.Substring(start, end - start), "");
            }

            /* Puts together the content file for the CSS version by pasting by the content after each other with a different style in each div element. */
            if ((contentFile == Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml")
                && (mode == (int)fileMode.singleFileCss)))
            {

                //System.IO.File.WriteAllText(Path.Combine(textFolder, "ContentBla.txt"), contentBody);

                //System.IO.File.WriteAllText(Path.Combine(textFolder, "Content.txt"), body);
                //System.IO.File.WriteAllText(Path.Combine(textFolder, "haha.txt"), contentBody.Substring(0, contentBody.IndexOf(imp) + imp.Length));
                newContent = contentBody.Substring(0, contentBody.IndexOf(startOfContent) + startOfContent.Length) + "\n";

                //string imagesFolder = getImageFolder();

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

                /* This is used to find out how long the starting <body> tag is. */
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

            /* Adds the first two lines which have to present in XHTML files. */
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


            /* Converts the written inline math to MathML. */
            Regex inlineFormulaRegex = new Regex(@"\$\$[^\$<>\n]+\$\$");

            MatchCollection inlineFormulasMatches = inlineFormulaRegex.Matches(newContent);


            if (inlineFormulasMatches.Count > 0)
            {
  
                WaitForm wf = new WaitForm();
                wf.SetDesktopLocation(this.Width / 2 - wf.Width / 2, this.Height / 2 - wf.Height / 2);
                wf.Show();
                foreach (Match m in inlineFormulasMatches)
                {
                    string pandoc = Path.Combine(initialPath, "pandoc-2.1");
                    string currentDic = Directory.GetCurrentDirectory();


                    string accFile = Path.Combine(accEpubFolderName, "accEpub.txt");
                    string formulaResult = Path.Combine(accEpubFolderName, "formulaResult.txt");

                    Directory.SetCurrentDirectory(pandoc);
                    string mathInput = m.ToString().Substring(1, m.ToString().Length - 2).Replace("&lt;", "<");
                    mathInput = mathInput.Replace("&gt;", ">");
                    /* The first and last character are not required as they are $ (dollar) signs. */
                    System.IO.File.WriteAllText(accFile, mathInput);

                    /* Pandoc has to be called up indirectly via cmd (Windows command prompt) to avoid encoding errors with certain characters, 
                        * which appear if it is called up directly. */
                    var proc = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            //FileName = "pandoc", //Path.Combine(pandoc, "pandoc"),
                            FileName = @"c:\windows\system32\cmd.exe",
                            Arguments = @"/c pandoc --mathml " + accFile + " > " + formulaResult,
                            //UseShellExecute = false,
                            //RedirectStandardOutput = false,
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden
                        }
                    };


                    proc.Start();
                    proc.WaitForExit();

                    /* Cleans up the MathML code. */
                    string math = System.IO.File.ReadAllText(formulaResult);

                    math = math.Replace("<semantics>", "<mstyle>");
                    math = math.Replace("</semantics>", "</mstyle>");
                    math = math.Replace("<p>", "");
                    math = math.Replace("</p>", "");
                    //math = math.Replace("<mrow>", "");
                    //math = math.Replace("</mrow>", "");


                    //math = ReplaceFirst(math, "<mrow>", "");
                    //math = ReplaceLast(math, "</mrow>", "");


                    /* Replaces the annotation tags which are present in MathML. */
                    while (math.Contains(annoStart) && math.Contains(annoEnd))
                    {
                        int start = math.IndexOf(annoStart);
                        int end = math.IndexOf(annoEnd) + annoEnd.Length;

                        math = math.Replace(math.Substring(start, end - start), "");
                    }

                    /* Pieces together the math for each display style. */
                    string divMath = "<span class=\"math\" display=\"inline\" role=\"math\">";
                    string divMathImpaired = "<span class=\"mathImpaired\" display=\"inline\" role=\"math\">";
                    string divEnd = "</span>";

                    string mathImpaired = math;
                    math = math.Replace("display=\"block\"", "display=\"inline\"");
                    mathImpaired = mathImpaired.Replace("display=\"block\"", "display=\"inline\"");
                    mathImpaired = mathImpaired.Replace("<mstyle>", "<mstyle scriptsizemultiplier=\"1\" lspace=\"20%\" rspace=\"20%\" mathvariant=\"sans-serif\">");

                    math = @"<span style=""display:inline;"" class=""inlineFormula"">" + divMath + math + divEnd + divMathImpaired + mathImpaired + divEnd + "<span class=\"transparent\" display=\"inline\">" + m.ToString().Substring(1, m.ToString().Length - 2) + "</span>" + "</span><!--EndOfInlineMath-->";

                    //body =  body.Replace(m.ToString(), m.ToString().Substring(0, m.ToString().Length - 1));

                    newContent = newContent.Replace(m.ToString(), math);

                    //HTMLEditor.Document.Body.OuterHtml = HTMLEditor.Document.Body.OuterHtml.Replace("</p><p><math", "<math");
                    //Console.WriteLine("Inline: " + math);
                }
                wf.Hide();
                
                wf.Dispose();
            }
            
          

            //HtmlAgilityPack.HtmlDocument hap = new HtmlAgilityPack.HtmlDocument();
            //hap.LoadHtml(newContent);
            //hap.OptionOutputAsXml = true;
            //newContent = hap.ParsedText;


           
            //string fileLocation = Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text");

            System.IO.File.WriteAllText(contentFile, newContent);

            codeEditor.Load(contentFile);
            ///* Loads a file to a code editor. */
            //foreach (KeyValuePair<string, ICSharpCode.AvalonEdit.TextEditor> ca in tabsToTextEditors)
            //{
            //    ca.Value.Load(Path.Combine(accEpubFolderName, ca.Key));
            //}
        }



        /// <summary>
        /// Converts the WYSIWYG browser content, which is HTML, to XHTML. 
        /// </summary>
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

            /* Removes all span elements inserted by the editor as it affects and disrupts spacing and layout. No span elements 
             * are added by Accessible EPUB itself. */
            Regex spanRegex = new Regex(@"<span[^>]*>(.*?)<\/span>");
            //Console.WriteLine(body);
            MatchCollection spanMatches = spanRegex.Matches(body);

            //Console.WriteLine("LALA:" + sp.ToString());
            //Console.WriteLine("BABA:" + sp.Groups[1].ToString());

            //foreach (Match span in spanMatches)
            //{
            //    string replacementString = span.Groups[1].ToString();
            //    body = body.Replace(span.ToString(), replacementString);

            //}
           
            if (body == null)
            {
                return;
            }

            //Console.WriteLine(contentFile);

            string newContent = "";
            string contentBody = "";

            string textFolder = Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"));
            
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

            body = body.Replace(Path.Combine(epubFolderName, rootFolderName), "..");

            /* Replaces the annotation tags which are present in MathML. */
            string annoStart = "<annotation encoding=\"application/x-tex\">";
            string annoEnd = "</annotation>";

            while (body.Contains(annoStart) && body.Contains(annoEnd))
            {
                int start = body.IndexOf(annoStart);
                int end = body.IndexOf(annoEnd) + annoEnd.Length;

                body = body.Replace(body.Substring(start, end - start), "");
            }

            /* Puts together the content file for the CSS version by pasting by the content after each other with a different style in each div element. */
            if ((contentFile == Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml")
                && (mode == (int)fileMode.singleFileCss)))
            {

                //System.IO.File.WriteAllText(Path.Combine(textFolder, "ContentBla.txt"), contentBody);

                //System.IO.File.WriteAllText(Path.Combine(textFolder, "Content.txt"), body);
                //System.IO.File.WriteAllText(Path.Combine(textFolder, "haha.txt"), contentBody.Substring(0, contentBody.IndexOf(imp) + imp.Length));
                newContent = contentBody.Substring(0, contentBody.IndexOf(startOfContent) + startOfContent.Length) + "\n";

                //string imagesFolder = getImageFolder();

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

                /* This is used to find out how long the starting <body> tag is. */
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

            /* Adds the first two lines which have to present in XHTML files. */
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


            /* Converts the written inline math to MathML. */
            Regex inlineFormulaRegex = new Regex(@"\$\$[^\$<>\n]+\$\$");

            MatchCollection inlineFormulasMatches = inlineFormulaRegex.Matches(newContent);

            if (inlineFormulasMatches.Count > 5 && refresh == true)
            {
                MessageBox.Show(Resource_MessageBox.automaticRefreshDisabledContent, Resource_MessageBox.automaticRefreshDisabledTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                setRefresh(false);
                
            }
            else if (inlineFormulasMatches.Count <= 5)
            {
                setRefresh(true);
            }

            
            if (refresh == true)
            {
                if (inlineFormulasMatches.Count > 0)
                {
                    foreach (Match m in inlineFormulasMatches)
                    {
                        string pandoc = Path.Combine(initialPath, "pandoc-2.1");
                        string currentDic = Directory.GetCurrentDirectory();


                        string accFile = Path.Combine(accEpubFolderName, "accEpub.txt");
                        string formulaResult = Path.Combine(accEpubFolderName, "formulaResult.txt");

                        Directory.SetCurrentDirectory(pandoc);

                        /* The first and last character are not required as they are $ (dollar) signs. */
                        string mathInput = m.ToString().Substring(1, m.ToString().Length - 2).Replace("&lt;", "<");
                        mathInput = mathInput.Replace("&gt;", ">");
                        System.IO.File.WriteAllText(accFile, mathInput);

                        /* Pandoc has to be called up indirectly via cmd (Windows command prompt) to avoid encoding errors with certain characters, 
                         * which appear if it is called up directly. */
                        var proc = new Process
                        {
                            StartInfo = new ProcessStartInfo
                            {
                                //FileName = "pandoc", //Path.Combine(pandoc, "pandoc"),
                                FileName = @"c:\windows\system32\cmd.exe",
                                Arguments = @"/c pandoc --mathml " + accFile + " > " + formulaResult,
                                //UseShellExecute = false,
                                //RedirectStandardOutput = false,
                                CreateNoWindow = true,
                                WindowStyle = ProcessWindowStyle.Hidden
                            }
                        };


                        proc.Start();
                        proc.WaitForExit();

                        /* Cleans up the MathML code. */
                        string math = System.IO.File.ReadAllText(formulaResult);

                        math = math.Replace("<semantics>", "<mstyle>");
                        math = math.Replace("</semantics>", "</mstyle>");
                        math = math.Replace("<p>", "");
                        math = math.Replace("</p>", "");
                        //math = math.Replace("<mrow>", "");
                        //math = math.Replace("</mrow>", "");


                        //math = ReplaceFirst(math, "<mrow>", "");
                        //math = ReplaceLast(math, "</mrow>", "");


                        /* Replaces the annotation tags which are present in MathML. */
                        while (math.Contains(annoStart) && math.Contains(annoEnd))
                        {
                            int start = math.IndexOf(annoStart);
                            int end = math.IndexOf(annoEnd) + annoEnd.Length;

                            math = math.Replace(math.Substring(start, end - start), "");
                        }

                        /* Pieces together the math for each display style. */
                        string divMath = "<span class=\"math\" display=\"inline\" role=\"math\">";
                        string divMathImpaired = "<span class=\"mathImpaired\" display=\"inline\" role=\"math\">";
                        string divEnd = "</span>";

                        string mathImpaired = math;
                        math = math.Replace("display=\"block\"", "display=\"inline\"");
                        mathImpaired = mathImpaired.Replace("display=\"block\"", "display=\"inline\"");
                        mathImpaired = mathImpaired.Replace("<mstyle>", "<mstyle scriptsizemultiplier=\"1\" lspace=\"20%\" rspace=\"20%\" mathvariant=\"sans-serif\">");

                        math = @"<span style=""display:inline;"" class=""inlineFormula"">" + divMath + math + divEnd + divMathImpaired + mathImpaired + divEnd + "<span class=\"transparent\" display=\"inline\">" + m.ToString().Substring(1, m.ToString().Length - 2) + "</span>" + "</span><!--EndOfInlineMath-->";

                        //body =  body.Replace(m.ToString(), m.ToString().Substring(0, m.ToString().Length - 1));

                        newContent = newContent.Replace(m.ToString(), math);

                        //HTMLEditor.Document.Body.OuterHtml = HTMLEditor.Document.Body.OuterHtml.Replace("</p><p><math", "<math");
                        //Console.WriteLine("Inline: " + math);
                    }
                }
            }


            //HtmlAgilityPack.HtmlDocument hap = new HtmlAgilityPack.HtmlDocument();
            //hap.LoadHtml(newContent);
            //hap.OptionOutputAsXml = true;
            //newContent = hap.ParsedText;



            //string fileLocation = Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text");
            
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

        //private void HTMLEditorMouseUp(object sender, System.Windows.Forms.HtmlElementEventArgs e)
        //{
        //    int x = e.MousePosition.X;
        //    int y = e.MousePosition.Y;
        //    Point p = new Point(x, y);

        //    Point ScreenCoord = new Point(MousePosition.X, MousePosition.Y);

        //    Point BrowserCoord = HTMLEditor.PointToClient(ScreenCoord);

        //    HtmlElement elem = HTMLEditor.Document.GetElementFromPoint(BrowserCoord);
        //    Console.WriteLine(elem.TagName);


        //    dynamic currentSelection = doc.selection as IHTMLSelectionObject;

        //    if (elem.TagName.ToUpper() == "IMG")
        //    {
        //        try
        //        {
        //            IHTMLElement current = doc.elementFromPoint(x, y) as IHTMLElement;
        //            IHTMLElement pare = current.parentElement;
        //            IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;

        //            foreach (IHTMLElement a in doc.all)
        //            {

        //                if (a.outerHTML.ToLower() == pare.outerHTML.ToLower())
        //                {
        //                    Console.WriteLine(a.outerHTML);
        //                    range.moveToElementText(range.parentElement());
        //                    //range.moveToElementText(pare);
        //                    range.select();
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //        //    //HTMLEditor.Document.Body.               
        //        //    HTMLSelectElement bla = new HTMLSelectElement();



        //    }


        //}


        //private void HTMLEditorMouseDown(object sender, HtmlElementEventArgs e)
        //{
        //    int x = e.MousePosition.X;
        //    int y = e.MousePosition.Y;
        //    Point p = new Point(x, y);

        //    Point ScreenCoord = new Point(MousePosition.X, MousePosition.Y);

        //    Point BrowserCoord = HTMLEditor.PointToClient(ScreenCoord);

        //    HtmlElement elem = HTMLEditor.Document.GetElementFromPoint(BrowserCoord);
        //    Console.WriteLine(elem.TagName);


        //    dynamic currentSelection = doc.selection as IHTMLSelectionObject;

        //    if (elem.TagName.ToUpper() == "IMG")
        //    {
        //        try
        //        {
        //            IHTMLElement current = doc.elementFromPoint(x, y) as IHTMLElement;
        //            IHTMLElement pare = current.parentElement;
        //            IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;

        //            foreach (IHTMLElement a in doc.all)
        //            {

        //                if (a.outerHTML.ToLower() == pare.outerHTML.ToLower())
        //                {
        //                    Console.WriteLine(a.outerHTML);
        //                    range.moveToElementText(range.parentElement());
        //                    //range.moveToElementText(pare);
        //                    range.select();
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //        //    //HTMLEditor.Document.Body.               
        //        //    HTMLSelectElement bla = new HTMLSelectElement();



        //    }

        //}

        

        
        /// <summary>
        /// Gets the current heading style (p, h1, h2 and so on) and updates it in the formatComboBox.
        /// </summary>
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

       
        /// <summary>
        /// Replaces only the first instance of a string in the searchable text.
        /// </summary>
        /// <param name="text">The text which will be searched through.</param>
        /// <param name="search">The word which will be replaced.</param>
        /// <param name="replace">The word which will replace the string which will be searched for, named <c>search</c>.</param>
        /// <returns>Text with first instance of string replaced.</returns>
        private string ReplaceFirst(string text, string search, string replace)
        {
            // Copied from https://stackoverflow.com/questions/141045/how-do-i-replace-the-first-instance-of-a-string-in-net.

            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        /// <summary>
        /// Replaces only the last instance of a string in the searchable text.
        /// </summary>
        /// <param name="text">The text which will be searched through.</param>
        /// <param name="search">The word which will be replaced.</param>
        /// <param name="replace">The word which will replace the string which will be searched for, named <c>search</c>.</param>
        /// <returns>Text with last instrance of string replaced.</returns>
        public static string ReplaceLast(string text, string search, string replace)
        {
            // Copied and slightly adjusted from https://stackoverflow.com/questions/14825949/replace-the-last-occurrence-of-a-word-in-a-string-c-sharp.

            int place = text.LastIndexOf(search);

            if (place == -1)
                return text;

            string result = text.Remove(place, search.Length).Insert(place, replace);
            return result;
        }


        /// <summary>
        /// Updates both the font format and headers list. It also identifies the HTML element at the location 
        /// of the mouse click, without which editing math and images would not be possible.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Used to find the location of the mouse.</param>
        private void HTMLEditorClick(object sender, HtmlElementEventArgs e)
        {
            int x = e.MousePosition.X;
            int y = e.MousePosition.Y;
            Point p = new Point(x, y);

            Point ScreenCoord = new Point(MousePosition.X, MousePosition.Y);

            Point BrowserCoord = HTMLEditor.PointToClient(ScreenCoord);

            HtmlElement elem = HTMLEditor.Document.GetElementFromPoint(BrowserCoord);

            //dynamic currentSelection = doc.selection as IHTMLSelectionObject;

            //if (elem.TagName.ToUpper() == "IMG")
            //{
            //    IHTMLElement current = doc.elementFromPoint(x, y) as IHTMLElement;
            //    IHTMLElement pare = current.parentElement;
            //    dynamic range = currentSelection.createRange() as IHTMLTxtRange;
            //    //    //HTMLEditor.Document.Body.               
            //    //    HTMLSelectElement bla = new HTMLSelectElement();


            //    foreach (IHTMLElement a in doc.all)
            //    {
            //        Console.WriteLine(a.outerHTML);
            //        if (a.outerHTML.ToLower() == pare.outerHTML.ToLower())
            //        {
            //            range.moveToElementText(pare);
            //            range.select();
            //        }
            //    }
            //}

            updateFontFormat();
            updateHeaderList();

        }

        /// <summary>
        /// Finds the HtmlElement which has been double clicked on and passes the result to the method identifyElement, 
        /// so that images and math can be edited.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Used to find the location of the mouse.</param>
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


        /// <summary>
        /// Method is used to for editing images, math and tables. It also allows the bullet point style to change.
        /// </summary>
        /// <param name="elem">The parent element which will be looked at.</param>
        private void identifyElement(HtmlElement elem)
        {
            HtmlElementCollection elems = HTMLEditor.Document.GetElementsByTagName(elem.TagName);
            //Console.WriteLine("HTMLelement " + HTMLEditor.Document.ActiveElement.TagName);
            //Console.WriteLine("Point " + BrowserCoord.X + "," + BrowserCoord.Y + " outerHTML " + elem.OuterHtml);


            bool isImage = false;
            bool isMath = false;
            bool isDiv = false;
            bool imageClicked = false;

            /* Changes list style. */

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

            /* Edits table. */
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

                /* If the editing is cancelled, the table is inserted again. */
                if (tdb.DialogResult.Equals(DialogResult.Cancel))
                {
                   
                    dynamic currentLocation = doc.selection.createRange();
                    currentLocation.pasteHTML(oldElem);
                }

                fileEdited = true;
                fileNotSaved = true;

                refreshBrowsers();

            }

            /* Also allows the image itself to be clicked instead of the figure. Some things will be done differently 
             * if the image is clicked instead. */
            if (elem.TagName.StartsWith("IMG"))
            {

                if (elem.Parent.TagName.StartsWith("FIGURE"))
                {
                    elem = elem.Parent;
                    imageClicked = true;   
                }
               
               
            }


            /* Edits images and math. */
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

                    //string closeTag = ">";

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

                    //bool hasAltImg = true;

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
                        //hasAltImg = false;
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

                    /* If the editing is cancelled, the deletion of the image and figure is undone. */
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

                    /* If the image is clicked delete should be called first, before emptying the outerHtml of the element. 
                     * This was found out with trial and error, so there is no real reason or explanation for this.
                     * Otherwise, some layout issues appear and the order is messed up. */
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

                    /* If the editing is cancelled, the figure with the math is inserted again. */
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

        /// <summary>
        /// This method is called up every time the timer ticks.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        void timer_Tick(object sender, EventArgs e)
        {          

            handleRefresh();
            //if (containsFile == true && fileEdited == true && refresh == true)
            //{
            //    //refreshBrowsers();
            //    //HTMLEditor.Document.Focus();
            //    updateFontFormat();

            //}

        }

        /// <summary>
        /// This method is called up every time the header timer ticks, which only less frequently than 
        /// the other timer, as seeing the header list refresh frequently can be irritating.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        void timerForHeaders_Tick(object sender, EventArgs e)
        {

            updateHeaderList();
            //if (containsFile == true && fileEdited == true && refresh == true)
            //{
            //    //refreshBrowsers();
            //    //HTMLEditor.Document.Focus();
            //    updateFontFormat();

            //}

        }

       


        /// <summary>
        /// Updates the list of headers and figures in the side panel.
        /// </summary>
        private void updateHeaderList()
        {
            //if (refresh == false)
            //{
            //    return;
            //}

            //if (fileEdited == false)
            //{
            //    return;
            //}

            headerTreeView.Nodes.Clear();
            figureTreeView.Nodes.Clear();
            //List<HtmlElement> headerOrder = new List<HtmlElement>();
            //Dictionary<HtmlElement, string> headerMap = new Dictionary<HtmlElement, string>();
            
            foreach (HtmlElement el in HTMLEditor.Document.Body.Children)
            {
                if ((el.TagName == "H1"))
                //if ((el.TagName == "H1") || (el.TagName == "H2") || (el.TagName == "H3") || (el.TagName == "H4") || (el.TagName == "H5") || (el.TagName == "H6"))
                {
                    //headerOrder.Add(el);
                    //headerMap.Add(el, el.InnerText);
                    headerTreeView.Nodes.Add(el.OuterHtml, el.InnerText);
                }

                if ((el.TagName == "H2") || (el.TagName == "H3") || (el.TagName == "H4") || (el.TagName == "H5") || (el.TagName == "H6"))
                {
                    //headerOrder.Add(el);
                    //headerMap.Add(el, el.InnerText);
                    //headerTreeView.no
                    //headerTreeView.Nodes.Add(el.OuterHtml, el.InnerText);
                    headerTreeView.Nodes[headerTreeView.GetNodeCount(false) - 1].Nodes.Add(el.OuterHtml, el.InnerText);
                }
              
                //TODO This was commented out before. Why? Is it suspectible to errors?
                if ((el.TagName == "FIGURE"))
                {
                    //Console.WriteLine(el.OuterHtml);
                    //return;
                    string s = el.OuterHtml;
                    string titleStart = "title=\"";
                    string titleEnd = "\" ";
                    string title = "";
                    int titleStartIndex = s.IndexOf(titleStart);
                    int titleEndIndex = 0;
                    //string shorterString = s;

                    //string tag = "";


                    string altBeg = "alttext=\"";
                    string altText = "";

                    //string openTag = "&lt;";
                    //string endTag = "&gt;";
                    string nodeValue = "";

                    if (s.ToLower().Contains(altBeg))
                    {
                        for (int i = s.IndexOf(altBeg) + altBeg.Length; s[i] != '\"'; i++)
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


        /// <summary>
        /// Updates the preview to reflect the editor's contents.
        /// </summary>
        private void refreshBrowsers()
        {
            //Gecko.GeckoDocument.StyleSheetCollection styleSheets12 = geckoWebBrowser1.Document.StyleSheets;
            //GeckoStyleSheet styleSheet12 = geckoWebBrowser1.Document.StyleSheets.First();
            //Console.WriteLine("CSS Text1: " + GetCssText(styleSheet12) + "CSS End");

            /* CSS style of browser which is slightly different to the Accessible EPUB standard */

            IHTMLStyleSheet ss = doc.createStyleSheet("", 0);
//            ss.cssText = @"html *
//{
//	font-family: ""Arial"", Helvetica, sans-serif !important;

//        }
//        p {
//  font-size:16px;

//word-wrap: break-word;
//}

//figure {
//	padding: 2px;
//	max-width : 95%;
//    border: double 4px;
//}

//figcaption {
//	word-wrap: break-word;
//	max-width : 100%;
//  font-size:16px;
//}

//img {
//	max-width : 100%;
//    margin: 10px
//}


//object {
//  max-width : 100%; 
//}

//math {
//  max-width : 100%;

//}

//table, th, td, tr, tbody {
//      border-style: double;
//    border-collapse: collapse;
//    border-width:4px;
//  text-align: center;
//}

//.transparent {
//  display: none;
//  color: transparent;
//}

//body {
//	width: 100%;
//	margin-left: 2px;
//	margin-right: auto;
//}

//.math {

//    display:none;
//    height:0%;

//}

//.mathImpaired {

//    display:none;
//    height:0%;
//}

//.imageImpaired {
//    display: none;
//}

//.imageOthers {
//    max - width : 100 %;
//    display: initial;
//}


//;"

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

            if (mode == (int)fileMode.singleFileJs && contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml")))
            {

                //Console.WriteLine(geckoWebBrowser1.Document.Head.InnerHtml);

                //File.Copy(contentFile, Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "ViContent.xhtml"));
                //File.Copy(contentFile, Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "ImpContent.xhtml"));
                //File.Copy(contentFile, Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "BliContent.xhtml"));


                /* Deletes the temporary visually impaired and blind content files if they exist.  */
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

            scrollHeight = HTMLEditor.Document.Body.ScrollTop;

            if (mode == (int)fileMode.singleFileJs)
            {

                //g1y = geckoWebBrowser1.Window.ScrollY;
                
  


                geckoWebBrowser1.Navigate(contentFile);
           
                geckoWebBrowser2.Navigate(impairedContentFile);
                geckoWebBrowser3.Navigate(blindContentFile);

                //geckoWebBrowser1.Window.ScrollTo(0, int.MaxValue);
                //geckoWebBrowser2.Window.ScrollTo(0, int.MaxValue);
                //geckoWebBrowser3.Window.ScrollTo(0, int.MaxValue);

            }


            geckoWebBrowser4.Navigate(contentFile);
          
            shouldScroll = true;
            fileEdited = false;

        }

   

        /// <summary>
        /// Handles what happens if a key is let go off while in the WYSIWYG editor. Currently, information like word count, character count,
        /// time since last save.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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


                lastSavedLabel.Text = origLastSavedLabel + span.Minutes + " Min ago";
            }         

        }


        ///// <summary>
        ///// Sets the CSS of the given style sheet of the Gecko Browser to be the given CSS text.
        ///// </summary>
        ///// <param name="cssText">The CSS text to be set.</param>
        ///// <param name="gss">Style sheet of a Gecko Browser.</param>
        //private void SetCssText(string cssText, GeckoStyleSheet gss)
        //{
        //    gss.CssRules.Clear();
        //    gss.CssRules.Add(cssText);
        //    //foreach (string rule in System.Text.RegularExpressions.Regex.Split(cssText, @"(?<=[}])"))
        //    //{
        //    //    // skip any trailing whitespace
        //    //    if (!(rule.Contains("}")))
        //    //        continue;
        //    //    gss.CssRules.Add(rule);
        //    //}
        //}

        ///// <summary>
        ///// Gets the CSS of the given style sheet of the Gecko Browser.
        ///// </summary>
        ///// <param name="gss">Style sheet of a Gecko Browser.</param>
        ///// <returns></returns>
        //public string GetCssText(GeckoStyleSheet gss)
        //{
        //    var text = new StringBuilder();
        //    foreach (GeckoStyleRule rule in gss.CssRules)
        //    {
        //        text.Append(rule.CssText);
        //    }
        //    return text.ToString();
        //}

        /// <summary>
        /// Initializes the header list and maps the name of the header to the HTML tag.
        /// </summary>
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

        /* Not actually needed as the changing fonts in the WYSIWYG editor is incompatible with Accessible EPUB. */
        ///// <summary>
        ///// Initializes the font list.
        ///// </summary>
        //private void InitFontList()
        //{
        //    foreach (var font in FontFamily.Families)
        //    {
        //        fontComboBox.Items.Add(font.Name);
        //    }

        //    int index = fontComboBox.Items.IndexOf("Arial");

        //    fontComboBox.SelectedIndex = index;

        //}

        /// <summary>
        /// Initializes the font size list. The font sizes follow the HTML font sizes.
        /// </summary>
        private void InitFontSizeList()
        {


            for (int x = 1; x <= 10; x++)
            {
                fontSizeComboBox.Items.Add(x);
            }

            int index = fontSizeComboBox.Items.IndexOf(3);

            fontSizeComboBox.SelectedIndex = index;

        }

        /// <summary>
        /// Makes the selected text bold.
        /// </summary>
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

        /// <summary>
        /// Italicizes the selected text.
        /// </summary>
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

        /// <summary>
        /// Underlines the selected text.
        /// </summary>
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

        /// <summary>
        /// Strikes through the selected text.
        /// </summary>
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


        /// <summary>
        /// Inserts an ordered list, which can have numbers, letters or roman numerals.
        /// </summary>
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

        /// <summary>
        /// Inserts an unordered list, which can be a variety of symbols.
        /// </summary>
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

        /// <summary>
        /// Changes the format of the selected text, such as from paragraph to a header of level 1.
        /// </summary>
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

        /// <summary>
        /// Adds an indent at the current cursor position.
        /// </summary>
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

        /// <summary>
        /// Deletes an indent at the current cursor position.
        /// </summary>
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

        /// <summary>
        /// Aligns the selected text to the left.
        /// </summary>
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

        /// <summary>
        /// Aligns the selected text to the center.
        /// </summary>
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

        /// <summary>
        /// Aligns the selected text to the right.
        /// </summary>
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

        /// <summary>
        /// Justifies the selected text.
        /// </summary>
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

        /* Not used in Accessible EPUB. */
        ///// <summary>
        ///// Changes the font of the selected text.
        ///// </summary>
        //private void changeFont()
        //{
        //    if (containsFile == false)
        //    {
        //        return;
        //    }
        //    //HTMLEditor.Document.ExecCommand("FontName", false, fontComboBox.SelectedItem.ToString());
        //    fileEdited = true;
        //    fileNotSaved = true;
        //    //ss.cssText = "html * {	font-family: 'Arial', Helvetica, sans-serif !important; }";
        //    //ss.cssText = "html * {	font-family: '" + fontComboBox.SelectedItem.ToString() + "', Helvetica, sans-serif !important; }";
        //}

        /// <summary>
        /// Changes the color of the selected text.
        /// </summary>
        private void changeFontColor()
        {
            if (containsFile == false)
            {
                return;
            }
            Color col = new Color();
            ColorDialog MyDialog = new ColorDialog();

            /* Allows user to select a custom color. */
            MyDialog.AllowFullOpen = true;
            
            /* Turns off help */
            MyDialog.ShowHelp = false;

            /* Sets the initial color select to the current text color. */
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                col = MyDialog.Color;
            }
            MyDialog.Dispose();
            string colorstr = string.Format("#{0:X2}{1:X2}{2:X2}", col.R, col.G, col.B);
            HTMLEditor.Document.ExecCommand("ForeColor", false, colorstr);
            fileEdited = true;
            fileNotSaved = true;
        }

        /// <summary>
        /// Changes the size of the selected text.
        /// </summary>
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

        /// <summary>
        /// Opens the ImageDialogBox so that a figure with an image can be inserted at the current location.
        /// </summary>
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

            handleRefresh();
            //refreshBrowsers();
        }

        /// <summary>
        /// Opens the TableDialogBox so that a table can be inserted at the current location.
        /// </summary>
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

            handleRefresh();
            //refreshBrowsers();
        }

        /// <summary>
        /// Opens the ImageDialogBox so that a figure with an image of the formula and MathML can be inserted at the current location.
        /// </summary>
        private void insertMath()
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("formatBlock", false, "<p>");

            MathDialogBox mdb = new MathDialogBox(doc, getImageFolder());
            mdb.ShowDialog();

            Directory.SetCurrentDirectory(initialPath);

            fileEdited = true;
            fileNotSaved = true;

            handleRefresh();
            //refreshBrowsers();
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

        //private void fontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    changeFont();
        //}

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

        /// <summary>
        /// If Ctrl + S is pressed, the EPUB file gets saved. This can be done anytime the main window (Form1) is focused on.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Event with information containing which keys were pressed.</param>
        //private void keyPressSave(object sender, KeyPressedEventArgs e)
        //{
        //    if (e.HotKey.Key == Key.S)
        //    {
        //        //saveFile();
        //    }
        //}

       


        /// <summary>
        /// A getter for the Images folder.
        /// </summary>
        /// <returns>The absolute path to the Images folder in the temp directory.</returns>
        private string getImageFolder()
        {
            return Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Images");
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

        

        /// <summary>
        /// Executes the undo command.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Undo", false, null);
        }

        /// <summary>
        /// Executes the redo command.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Redo", false, null);
        }

        /// <summary>
        /// Calls up the search command by simulating Ctrl + F.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            
            SendKeys.Send("^(f)");
        }

        /// <summary>
        /// Executes the cut command.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Cut", false, null);
        }

        /// <summary>
        /// Executes the copy command.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Copy", false, null);
        }

        /// <summary>
        /// Executes the paste command.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Paste", false, null);
        }

        /// <summary>
        /// Executes the delete command.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }
            HTMLEditor.Document.ExecCommand("Delete", false, null);
        }

        /// <summary>
        /// When the main window is closed, a dialog pops up which asks if the current file should be saved or if the closing process should be cancelled. 
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Used to cancel the process of closing the window.</param>
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

        /// <summary>
        /// Opens the link to the help page in a web browser.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Path.Combine(initialPath, "Help.html"));
        }

        /// <summary>
        /// Opens the AboutDialogBox.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialogBox abd = new AboutDialogBox();
            abd.ShowDialog();
        }

        /// <summary>
        /// Opens the SettingsDialogBox which contains all the savable options.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Saves the file under a new name and changes the target for future uses.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (containsFile == false)
            {
                return;
            }

            string initialDirectory = Settings.Default.LastDirectory;
            if (initialDirectory == "")
            {
                initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "EPUB|*.epub";
            saveFileDialog1.Title = "Create a new EPUB File";
            saveFileDialog1.InitialDirectory = initialDirectory;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
            {
                return;
            }

            if (saveFileDialog1.CheckFileExists)
            {
                File.Delete(saveFileDialog1.FileName);
            }

            Settings.Default.LastDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);

            target = saveFileDialog1.FileName;

            saveFile();

            this.Text = Path.GetFileName(target) + " - " + accessibleEpubFormText;
        }

        private void newFileSplashButton_Click(object sender, EventArgs e)
        {
            newSingleFile();
        }


        private void newFileButton_Click(object sender, EventArgs e)
        {
            newSingleFile();
        }

        private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newSingleFile();
        }


        private void openFileSplashButton_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFile();
        }

        private void closeFileToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            closeFile();
        }

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeFile();
        }

        /// <summary>
        /// Sets <c>refresh</c> to the parameter.
        /// </summary>
        /// <param name="toSet">The new value of <c>refresh.</c></param>
        private void setRefresh(bool toSet)
        {
            refresh = toSet;

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

        /// <summary>
        /// Toggles the automatic refresh of the preview browsers. If it is paused, the performance is improved.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void playPauseRefreshButton_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Toggles the automatic refresh of the preview browsers. If it is paused, the performance is improved. 
        /// Also toggles the image of the button.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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
    

        /// <summary>
        /// The current version of the product.
        /// </summary>
        private static Version version = new Version(Application.ProductVersion);

        /// <summary>
        /// A class for the version of the product
        /// </summary>
        public static Version Version
        {
            get
            {
                return version;
            }
        }

        /// <summary>
        /// Shows the tool strip as it should be hidden if no file is loaded into the editor.
        /// </summary>
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
            scrollLockButton.Visible = true;
        }

        /// <summary>
        /// Hides the tool strip as it should only be shown if a file is loaded into the editor.
        /// </summary>
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
            scrollLockButton.Visible = true;
        }

        /// <summary>
        /// Edits images and mathematic formulas. 
        /// </summary>
        private void editImageMath()
        {
            //IHTMLElement ielem = null;
            HtmlElement elem;

            IHTMLSelectionObject currentSelection = doc.selection;
            if (currentSelection != null)
            {
                /* Gets the currently selected text twice. range will be edited while oldRange will not be edited. */
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

                    /* Move to the div parent element of the figure. */
                    range.moveToElementText(range.parentElement());

                    //range.select();
                    //Console.WriteLine("RangeHTML: " + range.parentElement().outerHTML);

                    /* Checks if HTML element given in the range is contained in one of the child elements of the body. */
                    foreach (HtmlElement kid in HTMLEditor.Document.Body.Children)
                    {
                        //Console.WriteLine("Kid: " + kid.OuterHtml);
                        //if (kid.OuterHtml.ToLower().StartsWith(@"<div style=""display:inline""> <figure"))
                        //{
                            //Console.WriteLine("Kid: " + kid.OuterHtml);
                        //}
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

                    //if (range.parentElement().outerHTML.ToLower().Contains("<figure"))
                    //{
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
                    //}

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

        /// <summary>
        /// Stops the timer at the beginning of the method when any key is pressed to prevent overhead and slowdowns while typing and starts it again at the end of the method. Furthermore, indents and outdents are also handled.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">The key which was pressed.</param>
        private void HTMLEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            timer.Stop();

            //IHTMLElement ielem = null;
            //HtmlElement elem;

            if (e.Control && e.KeyCode == Keys.S)
            {
                e.IsInputKey = true;
                saveFile();
            }

            else if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                indent();
            }
            else if (e.KeyCode == Keys.Shift && e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                outdent();
            }

            else if (e.Control && e.KeyCode == Keys.Enter)
            {
                e.IsInputKey = true;
                insertPageNumberSplitButton.PerformButtonClick();                
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


            //handleRefresh();
            //if (containsFile == true && fileEdited == true && refresh == true)
            //{


            //    refreshBrowsers();

            //    //HTMLEditor.Document.Focus();
            //    updateFontFormat();
            //    updateHeaderList();
            //}

            HTMLEditor.Document.Focus();
            timer.Start();
            //updateFontFormat();
        }

        /// <summary>
        /// Captures input anywhere in the whole form.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">The key which was pressed.</param>
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.IsInputKey = true;
                saveFile();
            }

        }

        //[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
        /// <summary>
        /// Handles the refresh of everyting in the main window, such as the preview browsers, current font format, header and figure lists 
        /// and the time since the last save.
        /// </summary>
        private void handleRefresh()
        {
           
            refreshBrowsers();
           

            updateFontFormat();
            //updateHeaderList();
            
            DateTime time = DateTime.UtcNow;

            if (lastSave.Year == time.Year)
            {
                TimeSpan span = time.Subtract(lastSave);

                lastSavedLabel.Text = origLastSavedLabel + span.Minutes + " Min ago";
            }

            //Console.WriteLine("BLA");
            //if (lockRefreshBrowsers == false)
            //{
            //    Console.WriteLine("HAHA");

            //    if (containsFile == true && fileEdited == true && refresh == true)
            //    {

            //        lockRefreshBrowsers = true;
            //        //Task.Factory.StartNew(() => refreshBrowsers());
            //        refreshBrowsers();

            //        updateFontFormat();
            //        updateHeaderList();
            //        lockRefreshBrowsers = false;
            //    }


            //}
  
            
            if (!scrollLock && shouldScroll)
            {
                if (mode == (int)fileMode.singleFileJs)
                {
                    geckoWebBrowser1.Window.ScrollTo(0, scrollHeight);
                    geckoWebBrowser2.Window.ScrollTo(0, scrollHeight);
                    geckoWebBrowser3.Window.ScrollTo(0, scrollHeight);
                }

                else if (mode == (int)fileMode.singleFileCss)
                {
                    geckoWebBrowser4.Window.ScrollTo(0, scrollHeight);
                }

                // If this is set to "shouldScroll = false;" it will not scroll the preview window any more.
                shouldScroll = true;
            }
            
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            importText(sender, e);
        }

        private void importTextButton_Click(object sender, EventArgs e)
        {
            importText(sender, e);
        }

        //TODO Use LConvEncoding instead of the half baked measure used now, which doesn't always work.
        /// <summary>
        /// Allows text files to be imported. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importText(object sender, EventArgs e)
        {
            string initialDirectory = Settings.Default.LastDirectory;
            if (initialDirectory == "")
            {
                initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            //string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.InitialDirectory = initialDirectory;

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

                Settings.Default.LastDirectory = Path.GetDirectoryName(ofd.FileName);
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


                //TODO Add a notification that characters were replaced with question marks.
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

        //TODO Recheck which UTF text cannot be shown in and where this method was gotten from.
        /// <summary>
        /// Checks if there are characters which can not be shown in UTF-8.
        /// </summary>
        /// <param name="s">String which will be checked for non UTF-8 characters.</param>
        /// <returns>True if all characters conform to UTF-8, false otherwise.</returns>
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

        //TODO Recheck which UTF text cannot be shown in and where this method was gotten from.
        /// <summary>
        /// Replaces all characters which don't conform to UTF-8 with a given character.
        /// </summary>
        /// <param name="s">String which will have its non UTF-8 characters replaced.</param>
        /// <param name="replaceWith">The character which will replace non UTF-8 conform characters.</param>
        /// <returns>The string given as parameter, but with all of its non UTF-8 characters replaced with a given character.</returns>
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

        /// <summary>
        /// Inserts a normal ordered list and changes the list style with <c>editImageMath()</c> once to get the desired style.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void alphabeticallyCapitalizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOrderedList();
            editImageMath();
        }

        /// <summary>
        /// Inserts a normal ordered list and changes the list style with <c>editImageMath()</c> twice to get the desired style.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void alphabeticallyLowercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOrderedList();
            editImageMath();
            editImageMath();
        }

        /// <summary>
        /// Inserts a normal ordered list and changes the list style with <c>editImageMath()</c> thrice to get the desired style.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void romanUppercaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertOrderedList();
            editImageMath();
            editImageMath();
            editImageMath();
        }

        /// <summary>
        /// Inserts a normal ordered list and changes the list style with <c>editImageMath()</c> four times to get the desired style.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Inserts a normal unordered list and changes the list style with <c>editImageMath()</c> once to get the desired style.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void emptyCircleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertUnorderedList();
            editImageMath();
        }

        /// <summary>
        /// Inserts a normal unordered list and changes the list style with <c>editImageMath()</c> twice to get the desired style.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertUnorderedList();
            editImageMath();
            editImageMath();
        }


        /// <summary>
        /// Toggles the visibility of the preview browsers and shows/hides the panel they are on.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Toggles the visibility of the WYSIWYG editor and shows/hides the panel it is on.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Toggles the visibility of the file explorer tree and hides the panel it is on, if file explorer is not visible already.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Toggles the visibility of the navigation pane and hides the panel it is on, if navigation pane is not visible already.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Toggles the visibility of the navigation pane and hides the panel it is on, if navigation pane is not visible already.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Converts the current JavaScript Accessible EPUB to CSS Accessible EPUB. The current JavaScript Accessible EPUB file remains in the editor.
        /// </summary>
        private void convertJsToCss()
        {

            if (containsFile == false)
            {
                return;
            }

            /* If it is already a CSS Accesible EPUB file or not an Accessible EPUB file at all, it can not be converted. */
            if (mode == (int)fileMode.singleFileCss)
            {
                MessageBox.Show(Resource_MessageBox.jsToCssContent, Resource_MessageBox.jsToCssTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (mode != (int)fileMode.singleFileJs)
            {
                MessageBox.Show(Resource_MessageBox.notAnAepubFileContent, Resource_MessageBox.notAnAepubFileTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;   
            }

            string initialDirectory = Settings.Default.LastDirectory;
            if (initialDirectory == "")
            {
                initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "EPUB|*.epub";
            saveFileDialog1.Title = "Create a new EPUB File";
            saveFileDialog1.InitialDirectory = initialDirectory;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
            {
                return;
            }

            if (saveFileDialog1.CheckFileExists)
            {
                File.Delete(saveFileDialog1.FileName);
            }

            /* Saves it under a new target so that the current file remains in the editor. */
            string newTarget = saveFileDialog1.FileName;
            Settings.Default.LastDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);

            /* The remaining steps are very similar to the saveFile() method. */
            string tempFolderName = epubFolderName + "temp";
           
            string emptySingleFileZip = Path.Combine("EmptyFiles", "SingleFile", "empty_Single_File.zip");
      
            File.Copy(Path.Combine(initialPath, emptySingleFileZip), Path.Combine(accEpubFolderName, "empty_Single_File.zip"), true);

            System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(accEpubFolderName, "empty_Single_File.zip"), tempFolderName);

            File.Delete(Path.Combine(accEpubFolderName, "empty_Single_File.zip"));

            string tempImages = Path.Combine(Path.Combine(tempFolderName, rootFolderName), "Images");

            DirectoryCopy(getImageFolder(), tempImages);


            createManifest(tempFolderName);        

            string contentBody = File.ReadAllText(contentFile);


            string tempFile = Path.Combine(Path.Combine(Path.Combine(tempFolderName, rootFolderName), "Text"), "Content.xhtml");

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

            Directory.Delete(tempFolderName, true);
        }

        /// <summary>
        /// Converts the current CSS Accessible EPUB to JavaScript Accessible EPUB. The current CSS Accessible EPUB file remains in the editor.
        /// </summary>
        private void convertCssToJs()
        {
            if (containsFile == false)
            {
                return;
            }

            /* If it is already a JavaScript Accesible EPUB file or not an Accessible EPUB file at all, it can not be converted. */
            if (mode == (int)fileMode.singleFileJs)
            {
                MessageBox.Show(Resource_MessageBox.cssToJsContent, Resource_MessageBox.cssToJsTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (mode != (int)fileMode.singleFileCss)
            {
                MessageBox.Show(Resource_MessageBox.notAnAepubFileContent, Resource_MessageBox.notAnAepubFileTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;   
            }

            string initialDirectory = Settings.Default.LastDirectory;
            if (initialDirectory == "")
            {
                initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }


            System.Windows.Forms.SaveFileDialog saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog1.Filter = "EPUB|*.epub";
            saveFileDialog1.Title = "Create a new EPUB File";
            saveFileDialog1.InitialDirectory = initialDirectory;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName == "")
            {
                return;
            }

            if (saveFileDialog1.CheckFileExists)
            {
                File.Delete(saveFileDialog1.FileName);
            }

            /* Saves it under a new target so that the current file remains in the editor. */
            string newTarget = saveFileDialog1.FileName;
            Settings.Default.LastDirectory = Path.GetDirectoryName(saveFileDialog1.FileName);

            /* The remaining steps are very similar to the saveFile() method. */
            string tempFolderName = epubFolderName + "temp";

            string emptySingleFileZip = Path.Combine("EmptyFiles", "JsVersionChanger", "emptyJsFile.zip");
           
            File.Copy(Path.Combine(initialPath, emptySingleFileZip), Path.Combine(accEpubFolderName, "emptyJsFile.zip"), true);

            System.IO.Compression.ZipFile.ExtractToDirectory(Path.Combine(accEpubFolderName, "emptyJsFile.zip"), tempFolderName);

            File.Delete(Path.Combine(accEpubFolderName, "emptyJsFile.zip"));

            string tempImages = Path.Combine(Path.Combine(tempFolderName, rootFolderName), "Images");

            DirectoryCopy(getImageFolder(), tempImages);

            createManifest(tempFolderName);

            string contentBody = File.ReadAllText(contentFile);

            string tempFile = Path.Combine(Path.Combine(Path.Combine(tempFolderName, rootFolderName), "Text"), "Content.xhtml");

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

            Directory.Delete(tempFolderName, true);
        }

        private void javaScriptToCSSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            convertJsToCss();                       
        }

        private void cSSToJavaScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            convertCssToJs();
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


        // The changeBackgroundColorButton is not visible in the editor currently, as the method has not been implemented
        private void changeBackgroundColorButton_Click(object sender, EventArgs e)
        {
            if (mode == (int)fileMode.singleFileJs)
            {
                if (containsFile == false)
                {
                    return;
                }
                Color col = new Color();
                ColorDialog MyDialog = new ColorDialog();
                MyDialog.AllowFullOpen = true;

                // Keeps the user from selecting a custom color.
                MyDialog.AllowFullOpen = true;

                // Allows the user to get help. (The default is false.)
                MyDialog.ShowHelp = false;
                // Sets the initial color select to the current text color.
                if (MyDialog.ShowDialog() == DialogResult.OK)
                {
                    col = MyDialog.Color;
                }
                MyDialog.Dispose();
                string colorstr = string.Format("#{0:X2}{1:X2}{2:X2}", col.R, col.G, col.B);

                fileEdited = true;
                fileNotSaved = true;
            }
        }

        /* The following four methods are necessary to prevent the comboboxes from automatically closing after a while, 
         * as preview browser refreshes periodically. When the comboboxes are opened, the timer stops and they will
         * therefore not close any more. */
        private void formatComboBox_DropDown(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void formatComboBox_DropDownClosed(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void fontSizeComboBox_DropDown(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void fontSizeComboBox_DropDownClosed(object sender, EventArgs e)
        {
            timer.Start();
        }

        /// <summary>
        /// Converts the inline math if there are too many formulas on the page, as this slows 
        /// the program down, and refreshes the preview browsers.
        /// </summary>
        private void convertInlineMathAndRefresh()
        {
            if (containsFile == false)
            {
                return;
            }

            convertInlineFormula();


            IHTMLStyleSheet ss = doc.createStyleSheet("", 0);
            //            ss.cssText = @"html *
            //{
            //	font-family: ""Arial"", Helvetica, sans-serif !important;

            //        }
            //        p {
            //  font-size:16px;

            //word-wrap: break-word;
            //}

            //figure {
            //	padding: 2px;
            //	max-width : 95%;
            //    border: double 4px;
            //}

            //figcaption {
            //	word-wrap: break-word;
            //	max-width : 100%;
            //  font-size:16px;
            //}

            //img {
            //	max-width : 100%;
            //    margin: 10px
            //}


            //object {
            //  max-width : 100%; 
            //}

            //math {
            //  max-width : 100%;

            //}

            //table, th, td, tr, tbody {
            //      border-style: double;
            //    border-collapse: collapse;
            //    border-width:4px;
            //  text-align: center;
            //}

            //.transparent {
            //  display: none;
            //  color: transparent;
            //}

            //body {
            //	width: 100%;
            //	margin-left: 2px;
            //	margin-right: auto;
            //}

            //.math {

            //    display:none;
            //    height:0%;

            //}

            //.mathImpaired {

            //    display:none;
            //    height:0%;
            //}

            //.imageImpaired {
            //    display: none;
            //}

            //.imageOthers {
            //    max - width : 100 %;
            //    display: initial;
            //}


            //;"



            //wysiwygToHtml();

            //if (contentFile != Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml"))
            //{
            //    Console.WriteLine("Called");
            //    return;
            //}

            if (mode == (int)fileMode.singleFileJs && contentFile == (Path.Combine(Path.Combine(Path.Combine(epubFolderName, rootFolderName), "Text"), "Content.xhtml")))
            {

                //Console.WriteLine(geckoWebBrowser1.Document.Head.InnerHtml);

                //File.Copy(contentFile, Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "ViContent.xhtml"));
                //File.Copy(contentFile, Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "ImpContent.xhtml"));
                //File.Copy(contentFile, Path.Combine(Path.GetDirectoryName(contentFile).ToString(), "BliContent.xhtml"));


                /* Deletes the temporary visually impaired and blind content files if they exist.  */
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

            updateHeaderList();
            updateFontFormat();

            DateTime time = DateTime.UtcNow;

            if (lastSave.Year == time.Year)
            {
                TimeSpan span = time.Subtract(lastSave);

                lastSavedLabel.Text = origLastSavedLabel + span.Minutes + " Min ago";
            }
        }

        private void convertInlineMathButton_Click(object sender, EventArgs e)
        {
            convertInlineMathAndRefresh();
        }

        private void convertPageWithInlineMathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            convertInlineMathAndRefresh();
        }

        /// <summary>
        /// 
        /// </summary>
        private void toInlineMath()
        {
              if (containsFile == false)
            {
                return;
            }

            IHTMLSelectionObject currentSelection = doc.selection;

            if (currentSelection != null)
            {
                IHTMLTxtRange range = currentSelection.createRange() as IHTMLTxtRange;

                if (range.text.StartsWith("$$") && range.text.EndsWith("$$"))
                {
                    range.text = range.text.Substring(2, range.text.Length - 4);
                }
                else
                {
                    range.text = "$$" + range.text + "$$";
                }

            }

            fileEdited = true;
            fileNotSaved = true;

            handleRefresh();

        }

        private void toInlineMathButton_Click(object sender, EventArgs e)
        {
            toInlineMath();
        }

        private void toInlineMathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toInlineMath();
        }

        private void insertPageNumberSplitButton_ButtonClick(object sender, EventArgs e)
        {
            insertPageNumber();
        }

        /// <summary>
        /// Inserts a new page with the current page number and increments the page number counter.
        /// </summary>
        private void insertPageNumber()
        {
            dynamic currentLocation = doc.selection.createRange();
            string pageNumberFormatStart = "&lt;" + Resource_MessageBox.page + "&gt;";
            string pageNumberFormatEnd = "&lt;/" + Resource_MessageBox.page + "&gt;";

    //        string versionChangerLinksJavaScript = "<a id=\"a1_p" + currentPageNumber +
    //"\" href=\"#a1\" onclick=\"selectVisible();\">Normal</a> " +
    //"<a id=\"a2_p" + currentPageNumber + "\"href=\"#a2\" onclick=\"selectImpaired();\">Visually impaired</a> " +
    //"<a id=\"a3_p" + currentPageNumber + "\"href=\"#a3\" onclick=\"selectBlind();\">Blind</a>";

            string pageNumberHtml = "";

            string currentPageNumberString = currentPageNumber + "";

            if (isRomanPageNumber)
            {
                currentPageNumberString = toRomanNumeral(currentPageNumber);
            }



            //if (mode == (int)fileMode.singleFileCss)
            //{
            //    pageNumberHtml = "<span xml:id=\"page" + currentPageNumber + "\" epub:type=\"pagebreak\" ><p class=\"pagebreak\">" +
            //        pageNumberFormatStart + currentPageNumber + pageNumberFormatEnd + "</p></span>";
            //}
            //else if (mode == (int)fileMode.singleFileJs)
            //{
            //    pageNumberHtml = "<span xml:id=\"page" + currentPageNumber + "\" epub:type=\"pagebreak\" >" +
            //   versionChangerLinksJavaScript + "<p class=\"pagebreak\">" +
            //   pageNumberFormatStart + currentPageNumber + pageNumberFormatEnd + "</p></span>";
            //}


            pageNumberHtml = "<span xml:id=\"page" + currentPageNumberString + "\" epub:type=\"pagebreak\" ><p class=\"pagebreak\">" +
                   pageNumberFormatStart + currentPageNumberString + pageNumberFormatEnd + "</p></span>";

            currentLocation.pasteHTML(pageNumberHtml + "\n");


            currentPageNumber++;
        }


        //TODO: Fix error messages
        /// <summary>
        /// Accepts a normal integer as a parameter and returns a string of the roman numeral
        /// equivalent.
        /// </summary>
        /// <param name="number">Number to convert to a roman numeral</param>
        /// <returns>The roman numeral string equivalent of the parameter number</returns>
        public string toRomanNumeral(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + toRomanNumeral(number - 1000);
            if (number >= 900) return "CM" + toRomanNumeral(number - 900);
            if (number >= 500) return "D" + toRomanNumeral(number - 500);
            if (number >= 400) return "CD" + toRomanNumeral(number - 400);
            if (number >= 100) return "C" + toRomanNumeral(number - 100);
            if (number >= 90) return "XC" + toRomanNumeral(number - 90);
            if (number >= 50) return "L" + toRomanNumeral(number - 50);
            if (number >= 40) return "XL" + toRomanNumeral(number - 40);
            if (number >= 10) return "X" + toRomanNumeral(number - 10);
            if (number >= 9) return "IX" + toRomanNumeral(number - 9);
            if (number >= 5) return "V" + toRomanNumeral(number - 5);
            if (number >= 4) return "IV" + toRomanNumeral(number - 4);
            if (number >= 1) return "I" + toRomanNumeral(number - 1);
            throw new ArgumentOutOfRangeException("Error with roman numerals");
        }

        private void changeresetPageNumberingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeResetPageNumber();
        }

        private void changeResetPageNumber()
        {
            PageNumberDialogBox pndb = new PageNumberDialogBox(currentPageNumber, this);
            pndb.ShowDialog();
        }

        /// <summary>
        /// Sets the current page number and if it should be a roman numeral.
        /// </summary>
        /// <param name="pageNumber">The new page number</param>
        /// <param name="isRoman">Sets if the number should be shown as a roman numeral</param>
        public void setPageNumber(int pageNumber, bool isRoman)
        {
            currentPageNumber = pageNumber;
            isRomanPageNumber = isRoman;
        }

        private void insertPageNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertPageNumber();
        }

        private void changeresetPageNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeResetPageNumber();
        }


        private void scrollLockButton_Click(object sender, EventArgs e)
        {
            toggleScrollLock();
        }

        /// <summary>
        /// Toggles the scroll lock and resets the default scroll height to 0, the top of the preview browser.
        /// </summary>
        private void toggleScrollLock()
        {
            scrollLock = !scrollLock;
            scrollHeight = 0;
        }
  
    }
}
    