using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.IO.Compression;
using System.Net;

using mshtml;

using Gecko;
using IPrompt;

using ICSharpCode.AvalonEdit;

using Microsoft.Win32;






namespace AccessibleEPUB
{

    public partial class Form1 : Form
    {

        //ScintillaNET.Scintilla TextArea;
        ICSharpCode.AvalonEdit.TextEditor codeArea;

        string initialPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();
        private IHTMLDocument2 doc;
        Dictionary<string, string> headings;
        string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        enum fileMode
        {
            singleFileCss=1,
            singleFileJs=2,
            onlyVis=3,
            onlyBli=4,
            onlyImp=5,
            none=6
        }

        int mode;
        string target;
        string targetFolder;
        bool containsFile = false;

        string title;
        string author;

        string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
       Environment.OSVersion.Platform == PlatformID.MacOSX)
? Environment.GetEnvironmentVariable("HOME")
: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

        string tempPath = Path.GetTempPath();


        string tempFolder;
        string contentFile;
        string contentFileName = "Content.xhtml";

        string epubFolderName;

        

        List<string> openTabs = new List<string>();
        List<ICSharpCode.AvalonEdit.TextEditor> openTextEditors = new List<ICSharpCode.AvalonEdit.TextEditor>();

        Dictionary<string, ICSharpCode.AvalonEdit.TextEditor> tabsToTextEditors = new Dictionary<string, TextEditor>();

        string accEpubFolderName = Path.Combine(Path.GetTempPath(), "AccessibleEPUB");

        public Form1()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            filesTabControl.Padding = new System.Drawing.Point(21, 3);


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

            Console.WriteLine(RegVal);
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
            int index = path.LastIndexOf('\\');
            string rhs = path.Substring(index + 1);

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
                int index2 = file.ToString().LastIndexOf('\\');
                string rhs2 = file.ToString().Substring(index2 + 1);
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

            string absPath = tempFolder + "\\" + e.Node.FullPath;
            string fileName = e.Node.FullPath;
            FileAttributes attr = File.GetAttributes(absPath);
            if (attr.HasFlag(FileAttributes.Directory)) {
                return;
            }

            if (openTabs == null || openTabs.Contains(fileName) == false)
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
                        openTab(absPath);
                    }
                }
            }







            //webBrowser1.Navigate(filePath);
            //richTextBox1.Text = geckoWebBrowser1.Text;
        }

        private void openTab(string absPath)
        {
            if (absPath.EndsWith(".xhtml") || absPath.EndsWith(".html"))
            {
                geckoWebBrowser1.Navigate(absPath);
                splitContainer2.Panel1Collapsed = false;
                splitContainer2.Panel1.Show();

                splitContainer2.Panel2Collapsed = false;
                splitContainer2.Panel2.Show();
                //rtb.Text = File.ReadAllText(absPath);


                codeArea.Load(absPath);
                //codeArea.Text = File.ReadAllText(absPath);
                codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("HTML");

            }

            else if (absPath.EndsWith(".svg") || absPath.EndsWith(".jpg") || absPath.EndsWith(".png"))
            {
                geckoWebBrowser1.Navigate(absPath);
                splitContainer2.Panel1Collapsed = true;
                splitContainer2.Panel1.Hide();

                splitContainer2.Panel2Collapsed = false;
                splitContainer2.Panel2.Show();

 

                //codeArea.Load(absPath);

                //ICSharpCode.AvalonEdit.Utils.FileReader.OpenFile(absPath);
                return;

            }

            else if (absPath.EndsWith(".css"))
            {

                splitContainer2.Panel1Collapsed = false;
                splitContainer2.Panel1.Show();

                splitContainer2.Panel2Collapsed = true;
                splitContainer2.Panel2.Hide();

                codeArea.Load(absPath);
                //codeArea.Text = File.ReadAllText(absPath);
                codeArea.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("CSS");



            }

            else if (absPath.EndsWith(".js"))
            {

                splitContainer2.Panel1Collapsed = false;
                splitContainer2.Panel1.Show();

                splitContainer2.Panel2Collapsed = true;
                splitContainer2.Panel2.Hide();

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

                splitContainer2.Panel1Collapsed = false;
                splitContainer2.Panel1.Show();

                splitContainer2.Panel2Collapsed = true;
                splitContainer2.Panel2.Hide();

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
            containsFile = true;
            HTMLEditor.Visible = true;
            closeFile(sender, e);
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            tempFolder = Path.Combine(tempPath, "AccessibleEPUB");
            DirectoryInfo accEpubFolder = Directory.CreateDirectory(tempPath + "AccessibleEPUB");
            //string accEpubFolderName = accEpubFolder.Name;
          


            System.IO.DirectoryInfo di = new DirectoryInfo(tempFolder);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
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


            System.Windows.Forms.OpenFileDialog openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            openFileDialog1.InitialDirectory = homePath;
            openFileDialog1.Filter = "EPUB|*.epub|All Files|*.*";


            string epubFileName;       // Formerly tempFile
            string fileName = "";      // Formerly tempFile2
            string zipFileName = "";     // Formerly tempFile3 

           

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
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
                    contentFile = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), contentFileName);
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

            if (File.Exists(Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml")))
            {
                contentFileName = Path.Combine(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text"), "Content.xhtml");
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
            //initializeHTMLeditor();
            geckoWebBrowser1.Navigate(contentFile);
            htmlToWysiwyg();
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel1.Show();
            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();

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


        //    TextArea.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
        //    TextArea.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

        //}

        #region Utils

        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }

        public void InvokeIfNeeded(Action action)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(action);
            }
            else
            {
                action.Invoke();
            }
        }


        #endregion

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

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
            HTMLEditor.Document.Body.InnerHtml = "";
            geckoWebBrowser1.Navigate("about:blank");
            splitContainer2.Panel1Collapsed = false;
            splitContainer2.Panel1.Show();

            splitContainer2.Panel2Collapsed = true;
            splitContainer2.Panel2.Hide();

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




        public void newSingleFile()
        {

            contentFileName = "Content.xhtml";

            tempFolder = Path.Combine(tempPath, "AccessibleEPUB");


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
            NewFileDialogBox nfd = new NewFileDialogBox(this);
            nfd.ShowDialog();

          
            containsFile = true;
            HTMLEditor.Visible = true;
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel1.Show();
            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();

            target = saveFileDialog1.FileName;
            targetFolder = Path.GetDirectoryName(target);

            
            DirectoryDelete(accEpubFolderName);
            
            if (mode == (int) fileMode.singleFileCss)
            {

    
                //CloneDirectory(initialPath + "\\EmptyFiles\\empty_Single_File", accEpubFolderName);

                File.Copy(initialPath + "\\EmptyFiles\\SingleFile\\empty_Single_File.zip", accEpubFolderName + "\\empty_Single_File.zip", true);
            

                //CloneDirectory(initialPath + "\\EmptyFiles\\empty_Single_File", targetFolder);

                File.Copy(initialPath + "\\EmptyFiles\\SingleFile\\empty_Single_File.epub", target, true);

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


                System.IO.Compression.ZipFile.ExtractToDirectory(accEpubFolderName + "\\empty_Single_File.zip", fileName);


                zipFileName = fileName + ".zip";

                File.Delete(accEpubFolderName + "\\empty_Single_File.zip");
            }
            else if (mode == (int)fileMode.singleFileJs)
            {
                string setPath = Path.Combine(Path.Combine(Path.Combine("", "EmptyFiles"), "JsVersionChanger"), "emptyJsFile");

                //CloneDirectory(initialPath + "\\EmptyFiles\\empty_Single_File", accEpubFolderName);

                File.Copy(Path.Combine(initialPath, setPath + ".zip"), accEpubFolderName + "\\empty_Single_File.zip", true);


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


                System.IO.Compression.ZipFile.ExtractToDirectory(accEpubFolderName + "\\empty_Single_File.zip", fileName);


                zipFileName = fileName + ".zip";

                File.Delete(accEpubFolderName + "\\empty_Single_File.zip");
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

            int titleStartIndex = metadata.IndexOf(titleStart);
            int titleEndIndex = metadata.IndexOf(titleEnd);
            int creatorStartIndex = metadata.IndexOf(creatorStart);
            int creatorEndIndex = metadata.IndexOf(creatorEnd);

            string first = metadata.Substring(0, titleStartIndex + titleStart.Length);
            string second = metadata.Substring(titleEndIndex, creatorStartIndex + creatorStart.Length - titleEndIndex);
            string third = metadata.Substring(creatorEndIndex);

            string newMetaData = first + title + second + author + third;
            File.WriteAllText(Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "content.opf"), newMetaData);


            geckoWebBrowser1.Navigate(contentFile);
            splitContainer2.Panel2Collapsed = false;
            splitContainer2.Panel2.Show();
            splitContainer1.Panel1Collapsed = false;
            splitContainer1.Panel1.Show();

        }

        private static void DirectoryDelete(string path)
        {
              
               

            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            bool isInUse = false;
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
                    isInUse = true;
                    MessageBox.Show("Folder in use. Please leave and then press OK.", "Folder in use", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                string temppath = Path.Combine(destDirName, file.Name);
                //file.CopyTo(temppath, false);
                file.CopyTo(temppath, true);

            }

            // If copying subdirectories, copy them and their contents to new location.
           
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(destDirName, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath);
            }
            
        }

        private void filesTabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (filesTabControl.TabPages.Count >= 1)
            {
                string absPath = tempFolder + "\\" + e.TabPage.Name;
            }
        }



        string startOfContent = "<!--StartOfContent-->";
        string imp = "<div style=\"padding:none\" id=\"impaired\" class=\"impaired\">\n<!--StartOfImpairedSection-->\n";
        string impEnd = "<!--EndOfImpairedSection-->\n</div>\n";
        string bli = "<div id=\"blind\" class=\"blind\">\n<!--StartOfBlindSection-->\n";
        string bliEnd = "<!--EndOfBlindSection-->\n</div>\n";
        string vis = "<div id=\"visible\" class=\"visible\">\n<!--StartOfVisibleSection-->\n";
        string visEnd = "<!--EndOfVisibleSection-->\n</div>\n";

        private void initializeHTMLeditor()
        {
            string body = doc.body.innerHTML;
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
                    MessageBox.Show("Problem initializing HTML editor", "Error Title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            string bodyTag = "<body>";
            string bodyEnd = "</body>";
            //System.IO.File.WriteAllText(Path.Combine(textFolder, "Content.txt"), body);
            //System.IO.File.WriteAllText(Path.Combine(textFolder, "haha.txt"), contentBody.Substring(0, contentBody.IndexOf(imp) + imp.Length));
            //newContent = contentBody.Substring(0, contentBody.IndexOf(startOfContent) + startOfContent.Length) + "\n";

            //Console.WriteLine(newContent);
            
            newContent = newContent + imp + body + impEnd +
                bli + body + bliEnd +
                vis + body + visEnd + "</body>\n</html>\n";
            //newContent = contentBody.Substring(0, contentBody.IndexOf(bodyTag) + bodyTag.Length);
            //newContent = newContent +
            //    imp + body + impEnd +
            //    bli + body + bliEnd +
            //    vis + body + visEnd + contentBody.Substring(contentBody.IndexOf(bodyEnd) + bodyEnd.Length);

            string fileLocation = Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text");

            System.IO.File.WriteAllText(contentFile, newContent);

            //Console.WriteLine(contentBody);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void saveFile()
        {

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
            string zipFileName = epubFolderName + ".zip";
            File.Delete(zipFileName);
            ZipFile.CreateFromDirectory(epubFolderName, zipFileName);

            File.Copy(zipFileName, target, true);
            File.Delete(zipFileName);
           

            geckoWebBrowser1.Reload();
            this.treeView1.Nodes.Clear();
            this.treeView1.Nodes.Add(TraverseDirectory(epubFolderName));

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
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Show();
                HTMLEditor.Focus();
                htmlToWysiwyg();
            }
            else
            {
                filesTabControl.Focus();
                //splitContainer1.Panel1Collapsed = true;
                //splitContainer1.Panel1.Hide();
                splitContainer1.Panel1Collapsed = false;
                splitContainer1.Panel1.Show();
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
                ca.Value.Save(Path.Combine(accEpubFolderName, ca.Key));
            }

            string bodyStart = "<body>";
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
                //Console.WriteLine(body.Substring(startIndex + start.Length, endIndex - startIndex - start.Length));
                HTMLEditor.Document.Body.InnerHtml = body.Substring(startIndex + start.Length, endIndex - startIndex - start.Length);
            }
            else
            {
                int startIndex = body.IndexOf(bodyStart);
                int endIndex = body.IndexOf(bodyEnd);

                if (body.IndexOf(vis) >= startIndex)
                {
                    return;
                }

                HTMLEditor.Document.Body.InnerHtml = body.Substring(startIndex, endIndex - startIndex + bodyEnd.Length);
            }
           



        }

        private void wysiwygToHtml()
        {
            string body = doc.body.innerHTML;

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

            if (mode == (int)fileMode.singleFileCss) { 

                //System.IO.File.WriteAllText(Path.Combine(textFolder, "ContentBla.txt"), contentBody);

                //System.IO.File.WriteAllText(Path.Combine(textFolder, "Content.txt"), body);
                //System.IO.File.WriteAllText(Path.Combine(textFolder, "haha.txt"), contentBody.Substring(0, contentBody.IndexOf(imp) + imp.Length));
                newContent = contentBody.Substring(0, contentBody.IndexOf(startOfContent) + startOfContent.Length) + "\n";



                string imagesFolder = getImageFolder();
            

                string mstyleImpaired = "<mstyle scriptsizemultiplier=\"1\" lspace=\"20%\" rspace=\"20%\" mathvariant=\"sans-serif\">";
                string bodyImpaired = body.Replace("<mstyle>", mstyleImpaired); ;

                //Console.WriteLine(newContent);
                newContent = newContent + imp + bodyImpaired + impEnd +
                    bli + body + bliEnd +
                    vis + body + visEnd + "</body>\n</html>\n";
                //newContent = contentBody.Substring(0, contentBody.IndexOf(bodyTag) + bodyTag.Length);
                //newContent = newContent +
                //    imp + body + impEnd +
                //    bli + body + bliEnd +
                //    vis + body + visEnd + contentBody.Substring(contentBody.IndexOf(bodyEnd) + bodyEnd.Length);

            }
            else if (mode == (int)fileMode.singleFileJs)
            {
                string bodyStart = "<body epub:type=\"bodymatter\" onload=\"storageCSS();\">";
                string bodyEnd = "</body>";
                int first = contentBody.IndexOf(bodyStart);
                string header = contentBody.Substring(0, first + bodyStart.Length);

                int end = contentBody.IndexOf(bodyEnd);

                string closer = contentBody.Substring(end);
                newContent = header + body + closer;
            }
            else
            {
                string bodyStart = "<body>";
                string bodyEnd = "</body>";
                int first = contentBody.IndexOf(bodyStart);
                string header = contentBody.Substring(0, first + bodyStart.Length);

                int end = contentBody.IndexOf(bodyEnd);

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
            //Console.WriteLine(newContent);

            //HtmlAgilityPack.HtmlDocument hap = new HtmlAgilityPack.HtmlDocument();
            //hap.LoadHtml(newContent);
            //hap.OptionOutputAsXml = true;
            //newContent = hap.ParsedText;

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

            //HtmlAgilityPack.HtmlDocument hap = new HtmlAgilityPack.HtmlDocument();
            //hap.LoadHtml(newContent);
            //hap.OptionOutputAsXml = true;
            //newContent = hap.ParsedText;
            //Console.WriteLine(xdoc.InnerXml);





            string fileLocation = Path.Combine(Path.Combine(epubFolderName, "OEBPS"), "Text");

            System.IO.File.WriteAllText(contentFile, newContent);

            //Console.WriteLine(contentBody);
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
	font-family: ""Arial"", Helvetica, sans-serif !important;

}
        p {
  font-size:16px;
}

    figure {
	padding: 2px;
	max-width : 95%;
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

table {
  font-size:16px;
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
    visibility:hidden;

}



;"
;
            splitContainer1.Panel1Collapsed = true;
            splitContainer1.Panel1.Hide();


            


            //HTMLEditor.Document.ExecCommand("FontName", false, "Arial");

            InitHeadingsList();
            InitFontList();
            InitFontSizeList();
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
            HTMLEditor.Document.ExecCommand("Bold", false, null);
        }

        private void makeItalic()
        {
            HTMLEditor.Document.ExecCommand("Italic", false, null);
        }

        private void makeUnderline()
        {
            HTMLEditor.Document.ExecCommand("Underline", false, null);
        }

        private void makeStrikethrough()
        {
            HTMLEditor.Document.ExecCommand("StrikeThrough", false, null);
        }



        private void insertOrderedList()
        {
            HTMLEditor.Document.ExecCommand("InsertOrderedList", false, null);
        }

        private void insertUnorderedList()
        {
            HTMLEditor.Document.ExecCommand("InsertUnorderedList", false, null);

        }

        private void changeFormat()
        {
            string format;

            if (headings.TryGetValue(formatComboBox.SelectedItem.ToString(), out format))
            {
                HTMLEditor.Document.ExecCommand("formatBlock", false, format);
            }

            HTMLEditor.Document.Focus();
        }

        private void indent()
        {
            HTMLEditor.Document.ExecCommand("Indent", false, null);
        }

        private void outdent()
        {
            HTMLEditor.Document.ExecCommand("Outdent", false, null);
        }

        private void justifyLeft()
        {
            HTMLEditor.Document.ExecCommand("JustifyLeft", false, null);
        }

        private void justifyCenter()
        {
            HTMLEditor.Document.ExecCommand("JustifyCenter", false, null);
        }

        private void justifyRight()
        {
            HTMLEditor.Document.ExecCommand("JustifyRight", false, null);
        }

        private void justify()
        {
            HTMLEditor.Document.ExecCommand("JustifyFull", false, null);
        }


        private void changeFont()
        {
            HTMLEditor.Document.ExecCommand("FontName", false, fontComboBox.SelectedItem.ToString());
            //ss.cssText = "html * {	font-family: 'Arial', Helvetica, sans-serif !important; }";
            //ss.cssText = "html * {	font-family: '" + fontComboBox.SelectedItem.ToString() + "', Helvetica, sans-serif !important; }";
        }


        private void changeFontColor()
        {
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
        }

        private void changeFontSize()
        {
            HTMLEditor.Document.ExecCommand("FontSize", false, fontSizeComboBox.SelectedItem.ToString());
        }


        private void insertImage()
        {
            ImageDialogBox idb = new ImageDialogBox(doc, getImageFolder());
            idb.ShowDialog();
        }

        private void insertTable()
        {
            TableDialogBox tdb = new TableDialogBox(doc);
            tdb.ShowDialog();
        }

        private void insertMath()
        {
            MathDialogBox mdb = new MathDialogBox(doc, getImageFolder());
            mdb.ShowDialog();
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                makeBold();
            }
            else if (e.Control && e.KeyCode == Keys.I)
            {
                makeItalic();
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                makeUnderline();
            }
            else if (e.Control && e.KeyCode == Keys.I)
            {
                makeItalic();
            }
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


    }


}
