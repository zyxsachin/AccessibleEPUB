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

using System.Globalization;
using System.Threading;

namespace AccessibleEPUB
{
    public partial class ImageDialogBox : Form
    {
        IHTMLDocument2 doc;
        string imageFolderPath;

        string tag = "";

        string docLanguage = "";
        CultureInfo currentCI;

        public ImageDialogBox(IHTMLDocument2 mainWindowDoc, string ip, string dl)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());
            currentCI = Thread.CurrentThread.CurrentUICulture;
            InitializeComponent();
            doc = mainWindowDoc;
            imageFolderPath = ip;
            docLanguage = dl;

            initTypeList();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            if (imageLocationTextBox.Text == "")
            {
                //System.Windows.Forms.MessageBox.Show("The image path is empty.", "Empty image path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.imagePathContent, Resource_MessageBox.imagePathTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            } 
            else if (File.Exists(imageLocationTextBox.Text) == false)
            {
                //System.Windows.Forms.MessageBox.Show("Image doesn't exist.", "Image doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.imagePathContent, Resource_MessageBox.imagePathTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if (titleTextBox.Text == "")
            {
                //System.Windows.Forms.MessageBox.Show("The title is empty.", "Empty title", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.emptyTitleContent, Resource_MessageBox.emptyTitleTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (altTextTextBox.Text == "")
            {
                //System.Windows.Forms.MessageBox.Show("The alternative text is empty.", "Empty alternative text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.emptyAltTextContent, Resource_MessageBox.emptyAltTextTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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
                //DialogResult dialogResult = MessageBox.Show("Image with same name already exists in the document. Should the file be overwritten?", "Overwrite file", MessageBoxButtons.YesNo);
                DialogResult dialogResult = MessageBox.Show(Resource_MessageBox.imageOverwriteContent, Resource_MessageBox.imageOverwriteTitle, MessageBoxButtons.YesNo);
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

            string tagEnd = "";
            tag = typeComboBox.Text;
            if (typeComboBox.Text == "None")
            {
                tag = "";
            }
            else
            {
                tagEnd = "&lt;/" + tag + "&gt;";
                tag = "&lt;" + tag + "&gt;";
            }

            string heightTag = "";
            string widthTag = "";

            int height = 0;
            int width = 0;


            if (heightTextBox.Text == "")
            {

            }
            else if (Int32.TryParse(heightTextBox.Text, out height))
            {
                heightTag = " height=\"" + height + "px\" ";
            } 
            else
            {
                //System.Windows.Forms.MessageBox.Show("Invalid height entry.", "Invalid height", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.invalidHeightContent, Resource_MessageBox.invalidHeightTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (widthTextBox.Text == "")
            {

            }
            else if (Int32.TryParse(widthTextBox.Text, out width))
            {
                widthTag = " width=\"" + width + "px\" ";
            }
            else
            {
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.invalidWidthContent, Resource_MessageBox.invalidWidthTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }





            currentLocation.pasteHTML("\n" + @"<figure" + heightTag + widthTag + @"><img title=""" + titleTextBox.Text + @"""src =""" + imagePath + @""" alt =""" + altTextTextBox.Text + heightTag + widthTag +  @"""><p class=""transparent"">" +
                tag + altTextTextBox.Text + tagEnd +  @"</p><figcaption style = ""text -align:center"" > " + captionTextBox.Text +@"</figcaption></figure>" + "\n");


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
            //typeComboBox.Items.Add("None");
            //typeComboBox.Items.Add("Image");
            //typeComboBox.Items.Add("Graph");
            //typeComboBox.Items.Add("Math");

            string[] tagTypesEng = { "None", "Image", "Graph", "Math" };
            string[] tagTypesGer = { "Kein", "Bild", "Graph", "Mathematik" };

            Console.WriteLine("LANGUAGE:" + docLanguage);

            if (docLanguage == "en")
            {
                typeComboBox.Items.AddRange(tagTypesEng);
            }
            else if (docLanguage == "de")
            {
                typeComboBox.Items.AddRange(tagTypesGer);
            }
            else
            {
                typeComboBox.Items.AddRange(tagTypesEng);
            }

            typeComboBox.SelectedIndex = 1;
        }
    }
}
