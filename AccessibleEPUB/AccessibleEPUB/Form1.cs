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


namespace AccessibleEPUB
{

    public partial class Form1 : Form
    {
        string homePath = (Environment.OSVersion.Platform == PlatformID.Unix ||
       Environment.OSVersion.Platform == PlatformID.MacOSX)
? Environment.GetEnvironmentVariable("HOME")
: Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%");

        string tempPath = Path.GetTempPath();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string tempFolder = Path.Combine(tempPath, "AccessibleEPUB");
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
                this.treeView1.Nodes.Add(TraverseDirectory(accEpubFolderName));


                System.IO.StreamReader sr = new
                   System.IO.StreamReader(openFileDialog1.FileName);
                MessageBox.Show(sr.ReadToEnd());
                sr.Close();

            }
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        private TreeNode TraverseDirectory(string path)
        {
            int index = path.LastIndexOf('\\');
            string rhs = path.Substring(index + 1);

            TreeNode result = new TreeNode(path);

            foreach (var subdirectory in Directory.GetDirectories(path))
            {
                //Uri uri = new Uri(subdirectory);
                //string lastSegment = uri.Segments.Last();

                result.Nodes.Add(TraverseDirectory(subdirectory));

            }
            result.Text = rhs;
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
    }
}
