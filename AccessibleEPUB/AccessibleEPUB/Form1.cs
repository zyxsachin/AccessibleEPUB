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


namespace AccessibleEPUB
{

    public partial class Form1 : Form
    {
        string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
       Environment.OSVersion.Platform == PlatformID.MacOSX)
? Environment.GetEnvironmentVariable("HOME")
: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

        string tempPath = Path.GetTempPath();

        string tempFolder;



        public Form1()
        {
            InitializeComponent();
            Xpcom.Initialize("Firefox");
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

            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            tempFolder = Path.Combine(tempPath, "AccessibleEPUB");
            DirectoryInfo accEpubFolder = Directory.CreateDirectory(tempPath + "AccessibleEPUB");
            //string accEpubFolderName = accEpubFolder.Name;
            string accEpubFolderName = Path.Combine(tempPath, "AccessibleEPUB\\");


            System.IO.DirectoryInfo di = new DirectoryInfo(tempFolder);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }


            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = homePath;
            openFileDialog1.Filter = "EPUB|*.epub|All Files|*.*";


            string tempFile;
            string tempFile2 = "";
            string tempFile3 = "";


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //treeView1.Nodes.Clear();
                //richTextBox1.Clear();
                //geckoWebBrowser1.Navigate("");
                tempFile = Path.Combine(accEpubFolderName, Path.GetFileName(openFileDialog1.FileName));
                File.Copy(openFileDialog1.FileName, tempFile, true);


                if (tempFile.Contains('.'))
                {
                    tempFile2 = tempFile.Substring(0, tempFile.LastIndexOf('.'));
                }

                tempFile3 = tempFile2 + ".zip";

                //using (File.Create(tempFile)) ;
                //using (File.Create(tempFile2)) ;
                System.IO.File.Move(tempFile, tempFile3);

                System.IO.Compression.ZipFile.ExtractToDirectory(tempFile3, tempFile2);

                /*FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() != DialogResult.OK) { return; }
                dialog.SelectedPath = tempFolder;*/
                this.treeView1.Nodes.Add(TraverseDirectory(tempFile2));



                //webBrowser1.Navigate(tempFile2 + "\\OEBPS\\Text\\Content.xhtml");
                //richTextBox1.Text = webBrowser1.DocumentText;

                //richTextBox1.LoadFile(tempFile2 + "\\OEBPS\\Styles\\style.css");

               
            }
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
               
            }
            


            return result;
        }



        private string GetRelativePath(string filespec, string folder)
        {
            Uri pathUri = new Uri(filespec);
            // Folders must end in a slash
            if (!folder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                folder += Path.DirectorySeparatorChar;
            }
            Uri folderUri = new Uri(folder);
            return Uri.UnescapeDataString(folderUri.MakeRelativeUri(pathUri).ToString().Replace('/', Path.DirectorySeparatorChar));
        }

        
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

            if (e.Node.Text.EndsWith(".xhtml") || e.Node.Text.EndsWith(".html") )
            {
                geckoWebBrowser1.Navigate(tempFolder + "\\" + e.Node.FullPath);
                splitContainer2.Panel1Collapsed = false;
                splitContainer2.Panel1.Show();
                splitContainer2.Panel2Collapsed = false;
                splitContainer2.Panel2.Show();
                richTextBox1.Text = File.ReadAllText(tempFolder + "\\" + e.Node.FullPath);
            }

            else if (e.Node.Text.EndsWith(".svg") || e.Node.Text.EndsWith(".jpg") || e.Node.Text.EndsWith(".png"))
            {
                geckoWebBrowser1.Navigate(tempFolder + "\\" + e.Node.FullPath);
                splitContainer2.Panel1Collapsed = true;
                splitContainer2.Panel1.Hide();
            }

            else
            {
                splitContainer2.Panel1Collapsed = false;
                splitContainer2.Panel1.Show();

                splitContainer2.Panel2Collapsed = true;
                splitContainer2.Panel2.Hide();
                richTextBox1.Text = File.ReadAllText(tempFolder + "\\" + e.Node.FullPath);

            }
            

           

            //webBrowser1.Navigate(tempFolder + "\\" + e.Node.FullPath);
            //richTextBox1.Text = geckoWebBrowser1.Text;
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

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


    }
}
