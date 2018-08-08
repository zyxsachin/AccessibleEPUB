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

            imageLocationTextBox.TabIndex = 1;
            noneRadioButton.Checked = true;

            initTypeList();
        }

        public ImageDialogBox(IHTMLDocument2 mainWindowDoc, string ip, string dl, string location, string title, string altText, string caption, string tag, string altImgLocation, string width, string height, string floatValue)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());
            currentCI = Thread.CurrentThread.CurrentUICulture;
            InitializeComponent();
            doc = mainWindowDoc;
            imageFolderPath = ip;
            docLanguage = dl;

            initTypeList();

            imageLocationTextBox.TabIndex = 20;
            imageLocationTextBox.Text = location;
            titleTextBox.Text = title;
            altTextTextBox.Text = altText;
            captionTextBox.Text = caption;
            typeComboBox.Text = tag;
            alternativeImageTextBox.Text = altImgLocation;
            widthTextBox.Text = width;
            heightTextBox.Text = height;

            if (floatValue == "none")
            {
                noneRadioButton.Checked = true;
            }
            else if (floatValue == "left")
            {
                leftRadioButton.Checked = true;
            }
            else if (floatValue == "right")
            {
                rightRadioButton.Checked = true;
            }
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;

            this.Hide();
            this.Dispose();
            //this.Close();
        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            bool altImageExists = false;
            bool toEnd = false;
     
            if (imageLocationTextBox.Text == "")
            {
                //System.Windows.Forms.MessageBox.Show("The image path is empty.", "Empty image path", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.imagePathContent, Resource_MessageBox.imagePathTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //toEnd = true;
                return;
            } 
            else if (File.Exists(imageLocationTextBox.Text) == false)
            {
                //System.Windows.Forms.MessageBox.Show("Image doesn't exist.", "Image doesn't exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.imagePathContent, Resource_MessageBox.imagePathTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //toEnd = true;
                return;
            }

            if (alternativeImageTextBox.Text.Trim() != "")
            {
                altImageExists = true;               
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

            //if (toEnd == true)
            //{
            //    //return;
            //}

            //else { 
            if (!Directory.Exists(imageFolderPath))
            {
                Directory.CreateDirectory(imageFolderPath);
            }

            string imagePath = Path.Combine(imageFolderPath, Path.GetFileName(imageLocationTextBox.Text));          
            string altImagePath = "";
            
            try
            {
                if (imageLocationTextBox.Text != imagePath)
                {
                    System.IO.File.Copy(imageLocationTextBox.Text, imagePath);
                }
                
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

            if (altImageExists)
            {
                try
                {
                    altImagePath = Path.Combine(imageFolderPath, Path.GetFileName(alternativeImageTextBox.Text));
                    if (alternativeImageTextBox.Text != altImagePath)
                    {
                        System.IO.File.Copy(alternativeImageTextBox.Text, altImagePath);
                    }
                }
                catch (IOException ie)
                {
                    //DialogResult dialogResult = MessageBox.Show("Image with same name already exists in the document. Should the file be overwritten?", "Overwrite file", MessageBoxButtons.YesNo);
                    DialogResult dialogResult = MessageBox.Show(Resource_MessageBox.imageOverwriteContent, Resource_MessageBox.imageOverwriteTitle, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        System.IO.File.Copy(alternativeImageTextBox.Text, altImagePath, true);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            else
            {               
                altImagePath = imagePath;
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


            string styleTag = "";
            
            if (noneRadioButton.Checked == true)
            {

            }
            else if (leftRadioButton.Checked == true)
            {
                styleTag = " style=\"float:left;\" ";
            }
            else if (rightRadioButton.Checked == true)
            {
                styleTag = " style=\"float:right;\" ";
            }


            // currentLocation.pasteHTML("\n" + @"<div class=""imageOthers""> <figure" + heightTag + widthTag + @"><img title=""" + titleTextBox.Text + @"""src =""" + imagePath + @""" alt =""" + altTextTextBox.Text + heightTag + widthTag +  @"""><p class=""transparent"">" +
            //    tag + altTextTextBox.Text + tagEnd +  @"</p><figcaption style = ""text -align:center"" >" + captionTextBox.Text +@"</figcaption></figure></div>" + "\n");

            //currentLocation.pasteHTML("\n" + @"<div class=""imageImpaired""> <figure" + heightTag + widthTag + @"><img title=""" + titleTextBox.Text + @"""src =""" + altImagePath + @""" alt =""" + altTextTextBox.Text + heightTag + widthTag + @"""><p class=""transparent"">" +
            //   tag + altTextTextBox.Text + tagEnd + @"</p><figcaption style = ""text -align:center"" >" + captionTextBox.Text + @"</figcaption></figure></div>" + "\n");


            //Console.WriteLine("\n" + @"<div> <figure" + heightTag + widthTag + @"><img class=""imageOthers""  title=""" + titleTextBox.Text + @"""src =""" + imagePath + @""" alt =""" + altTextTextBox.Text + heightTag + widthTag + @"""><img class=""imageImpaired"" title=""" + titleTextBox.Text + @"""src =""" + altImagePath + @""" alt =""" + altTextTextBox.Text + heightTag + widthTag + @"""><p class=""transparent imageImpaired"">" +
            //   tag + altTextTextBox.Text + tagEnd + @"</p><figcaption style = ""text -align:center"" >" + captionTextBox.Text + @"</figcaption></figure></div>" + "\n");

           
            currentLocation.pasteHTML("\n" + @"<figure" + styleTag + heightTag + widthTag + @"><img class=""imageOthers""" + styleTag + @" title=""" + titleTextBox.Text + @""" src=""" + imagePath + @""" alt=""" + altTextTextBox.Text + "\"" + heightTag + widthTag + @"/><img class=""imageImpaired""" + styleTag + @"title=""" + titleTextBox.Text + @"""src=""" + altImagePath + @""" alt=""" + altTextTextBox.Text + "\"" + heightTag + widthTag + @"/><p class=""transparent"">" +
               tag + altTextTextBox.Text + tagEnd + @"</p><figcaption style = ""text -align:center"" >" + captionTextBox.Text + @"</figcaption></figure>" + "\n");
            // Old version with outside div
            //currentLocation.pasteHTML("\n" + @"<div style=""display:inline""> <figure" + styleTag + heightTag + widthTag + @"><img class=""imageOthers""" + styleTag +  @"title =""" + titleTextBox.Text + @"""src =""" + imagePath + @""" alt =""" + altTextTextBox.Text + heightTag + widthTag + @"""><img class=""imageImpaired""" + styleTag + @"title =""" + titleTextBox.Text + @"""src =""" + altImagePath + @""" alt =""" + altTextTextBox.Text + heightTag + widthTag + @"""><p class=""transparent imageImpaired"">" +
            //   tag + altTextTextBox.Text + tagEnd + @"</p><figcaption style = ""text -align:center"" >" + captionTextBox.Text + @"</figcaption></figure></div>" + "\n");


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
            this.DialogResult = DialogResult.OK;
            this.Hide();
            this.Dispose();
            //}
        }

        private void chooseImageButton_Click(object sender, EventArgs e)
        {
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = documents;
            ofd.Filter = "Image files (jpg, png, svg)|*.jpg;*.png;*.svg|All files (*.*)|*.*";
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

        private void chooseAlternativeImageButton_Click(object sender, EventArgs e)
        {
            string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = documents;
            ofd.Filter = "Image files (jpg, png, svg)|*.jpg;*.png;*.svg|All files (*.*)|*.*";
            ofd.RestoreDirectory = true;


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                alternativeImageTextBox.Text = ofd.FileName;
            }
        }
    }
}
