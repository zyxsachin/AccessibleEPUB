using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
using System.IO;
using System.Net;

namespace AccessibleEPUB
{
    public partial class ImageDialogBox : Form
    {
        IHTMLDocument2 doc;
        string imageFolderPath;


        public ImageDialogBox(IHTMLDocument2 mainWindowDoc, string ip)
        {
            InitializeComponent();
            doc = mainWindowDoc;
            imageFolderPath = ip;
            initTypeList();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dispose();
        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            string imagePath = Path.Combine(imageFolderPath, Path.GetFileName(imageLocationTextBox.Text));

            try
            {
                System.IO.File.Copy(imageLocationTextBox.Text, imagePath);
            } 
            catch (IOException ie)
            {
                DialogResult dialogResult = MessageBox.Show("Image with same name already exists in the document. Should the file be overwritten?", "Overwrite file", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    System.IO.File.Copy(imageLocationTextBox.Text, imagePath, true);
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
           
            dynamic currentLocation = doc.selection.createRange();
            //r.pasteHTML

                currentLocation.pasteHTML(WebUtility.HtmlDecode("\n" + @"<figure><img title=""" + titleTextBox.Text + @"""src =""" + imagePath + @""" alt =""" + altTextTextBox.Text + @"""><p class=""transparent"">" + altTextTextBox.Text + @"</p><figcaption style = ""text -align:center"" > " + captionTextBox.Text +@"</figcaption></figure>" + "\n"));


            //doc.body.innerHTML = doc.body.innerHTML.Replace("<br>", "");
            //doc.body.innerHTML = doc.body.innerHTML.Replace("<BR>", "");
            //doc.body.innerHTML = doc.body.innerHTML.Replace("<p></p>", "");
            //doc.body.innerHTML = doc.body.innerHTML.Replace("<P></P>", "");
            //doc.body.innerHTML = doc.body.innerHTML.Replace("&nbsp;", "");

            //doc.body.innerHTML = "<br>" + doc.body.innerHTML;
            //doc.body.innerHTML = doc.body.innerHTML + "<br>";
            //doc.body.innerHTML = doc.body.innerHTML.Replace("<figure>", "<br><figure>");
            //doc.body.innerHTML = doc.body.innerHTML.Replace("</figure>", "</figure><br>");


            //src =""" + imageLocationTextBox.Text + @""" alt =""" + altTextTextBox.Text + @""">
            this.Hide();
            this.Dispose();
        }

        private void chooseImageButton_Click(object sender, EventArgs e)
        {
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = documents;
            ofd.Filter = "jpg files (*.jpg)|*.jpg|All files (*.png.*)|*.png|All files (*.gif)|*.gif|All files (*.*)|*.*";
            ofd.RestoreDirectory = true;


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imageLocationTextBox.Text = ofd.FileName;
            }
        }

        private void initTypeList()
        {
            typeComboBox.Items.Add("Image");
            typeComboBox.Items.Add("Graph");
            typeComboBox.Items.Add("Math");

            typeComboBox.SelectedIndex = 0;
        }
    }
}
