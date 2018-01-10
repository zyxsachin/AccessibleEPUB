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


using Gecko;
using IPrompt;

using ScintillaNET;
using ICSharpCode.AvalonEdit;



namespace AccessibleEPUB
{

    public partial class Form1 : Form
    {

        ScintillaNET.Scintilla TextArea;
        ICSharpCode.AvalonEdit.TextEditor codeArea;

        string initialPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString();



        string target;
        string targetFolder;


        string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
       Environment.OSVersion.Platform == PlatformID.MacOSX)
? Environment.GetEnvironmentVariable("HOME")
: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

        string tempPath = Path.GetTempPath();



        string tempFolder;

        List<string> openTabs = new List<string>();

        string accEpubFolderName = Path.Combine(Path.GetTempPath(), "AccessibleEPUB");

        public Form1()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
            tabControl2.Padding = new System.Drawing.Point(21, 3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
                tabControl2.TabPages.Add(myTabPage);

                //RichTextBox rtb = new RichTextBox();

                System.Windows.Forms.Integration.ElementHost host = new System.Windows.Forms.Integration.ElementHost();
                host.Dock = DockStyle.Fill;
                codeArea = new ICSharpCode.AvalonEdit.TextEditor();
                host.Child = codeArea;
                myTabPage.Controls.Add(host);

                

                //myTabPage.Controls.Add(rtb);

                //rtb.Dock = System.Windows.Forms.DockStyle.Fill;
                openTabs.Add(fileName);

                tabControl2.SelectedTab = myTabPage;

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
                foreach (TabPage tab in tabControl2.TabPages)
                {
                    if (tab.Name == fileName)
                    {
                        tabControl2.SelectedTab = tab;
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

        private void toolStripButton1_Click(object sender, EventArgs e)
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
                dir.Delete(true);
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


            OpenFileDialog openFileDialog1 = new OpenFileDialog();
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


        }

        private void InitColors()
        {

            TextArea.SetSelectionBackColor(true, IntToColor(0x000000));
            TextArea.SetSelectionForeColor(true, IntToColor(0xFFFFFF));

        }

        private void InitSyntaxColoring()
        {

            // Configure the default style
            TextArea.StyleResetDefault();
            TextArea.Styles[Style.Default].Font = "Consolas";
            TextArea.Styles[Style.Default].Size = 10;
            TextArea.Styles[Style.Default].BackColor = IntToColor(0xFFFFFF);
            TextArea.Styles[Style.Default].ForeColor = IntToColor(0x000000);
            TextArea.StyleClearAll();

            TextArea.Styles[Style.Html.Number].ForeColor = IntToColor(0xFFFF00);
            TextArea.Styles[Style.Html.Tag].ForeColor = Color.Purple;
            TextArea.Styles[Style.Html.TagEnd].ForeColor = Color.Blue;
            //TextArea.Styles[Style.Html.TagUnknown].ForeColor = Color.Green;
            TextArea.Styles[Style.Html.Other].ForeColor = Color.Orange;
            TextArea.Styles[Style.Html.Attribute].ForeColor = Color.Red;
            TextArea.Styles[Style.Html.Comment].ForeColor = Color.Green;

            TextArea.Lexer = Lexer.Html;


            TextArea.SetKeywords(0, "class extends implements import interface new case do while else if for in switch throw get set function var try catch finally while with default break continue delete return each const namespace package include use is as instanceof typeof author copy default deprecated eventType example exampleText exception haxe inheritDoc internal link mtasc mxmlc param private return see serial serialData serialField since throws usage version langversion playerversion productversion dynamic private public partial static intrinsic internal native override protected AS3 final super this arguments null Infinity NaN undefined true false abstract as base bool break by byte case catch char checked class const continue decimal default delegate do double descending explicit event extern else enum false finally fixed float for foreach from goto group if implicit in int interface internal into is lock long new null namespace object operator out override orderby params private protected public readonly ref return switch struct sbyte sealed short sizeof stackalloc static string select this throw true try typeof uint ulong unchecked unsafe ushort using var virtual volatile void while where yield");
            TextArea.SetKeywords(1, "void Null ArgumentError arguments Array Boolean Class Date DefinitionError Error EvalError Function int Math Namespace Number Object RangeError ReferenceError RegExp SecurityError String SyntaxError TypeError uint XML XMLList Boolean Byte Char DateTime Decimal Double Int16 Int32 Int64 IntPtr SByte Single UInt16 UInt32 UInt64 UIntPtr Void Path File System Windows Forms ScintillaNET");

        }

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
            tabControl2.TabPages.Clear();
            treeView1.Nodes.Clear();
            openTabs.Clear();

            geckoWebBrowser1.Navigate("about:blank");
            splitContainer2.Panel1Collapsed = false;
            splitContainer2.Panel1.Show();

            splitContainer2.Panel2Collapsed = true;
            splitContainer2.Panel2.Hide();

        }

 
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            closeFile(sender, e);
            newSingleFile();
        }



        private void newSingleFile()
        {
            tempFolder = Path.Combine(tempPath, "AccessibleEPUB");


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
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
            targetFolder = Path.GetDirectoryName(target);

            
            DirectoryDelete(accEpubFolderName);
            
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
            System.IO.Compression.ZipFile.ExtractToDirectory(accEpubFolderName + "\\empty_Single_File.zip", accEpubFolderName + "\\" + Path.GetFileName(target));
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
            }

            System.IO.Compression.ZipFile.ExtractToDirectory(accEpubFolderName + "\\empty_Single_File.zip", fileName);


            zipFileName = fileName + ".zip";

            File.Delete(accEpubFolderName + "\\empty_Single_File.zip");

            //using (File.Create(epubFileName)) ;
            //using (File.Create(tempFile2)) ;
            //System.IO.File.Move(epubFileName, zipFileName);

            //System.IO.Compression.ZipFile.ExtractToDirectory(zipFileName, fileName);

            /*FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK) { return; }
            dialog.SelectedPath = tempFolder; */
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

        private static void DirectoryDelete(string path)
        {

            System.IO.DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
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

        private void tabControl2_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl2.TabPages.Count >= 1)
            { 
                string absPath = tempFolder + "\\" + e.TabPage.Name;
                openTab(absPath);
            }
        }
    }


}
