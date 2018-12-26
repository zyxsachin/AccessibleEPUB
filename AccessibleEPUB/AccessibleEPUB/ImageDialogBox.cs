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
    /// <summary>
    /// The <c>ImageDialogBox</c> is used to add images to the EPUB file, which will be inside a figure, and it will 
    /// contain alternative text as simple text.
    /// </summary>
    public partial class ImageDialogBox : Form
    {
        /// <summary>
        /// The HTML document to which the figure with the image is added to.
        /// </summary>
        IHTMLDocument2 doc;

        /// <summary>
        /// The directory where images will be stored.
        /// </summary>
        string imageFolderPath;

        /// <summary>
        /// The tag of image which is used for the alternative text.
        /// </summary>
        string tag = "";

        /// <summary>
        /// The document language of the EPUB which is used to the text of the tags.
        /// </summary>
        string docLanguage = "";

        /// <summary>
        /// Used to set the language of <c>ImageDialogBox</c>.
        /// </summary>
        CultureInfo currentCI;

        /// <summary>
        /// The constructor which is used to transfer information about the current EPUB file and editor
        /// to the <c>ImageDialogBox</c>.
        /// </summary>
        /// <param name="mainWindowDoc">The HTML document of the current file in the editor.</param>
        /// <param name="ip">The temp path to the images folder.</param>
        /// <param name="dl">The language of the EPUB document.</param>
        public ImageDialogBox(IHTMLDocument2 mainWindowDoc, string ip, string dl)
        {       
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());
            currentCI = Thread.CurrentThread.CurrentUICulture;
            InitializeComponent();
            doc = mainWindowDoc;
            imageFolderPath = ip;
            docLanguage = dl;

            /* Setting the TabIndex in the Visual Studio design editor did not work so it had to be done during run time. */
            imageLocationTextBox.TabIndex = 1;
            noneRadioButton.Checked = true;

            initTypeList();
        }

        /// <summary>
        /// The constructor used when an image is edited. All the important information is transferred as parameters.
        /// </summary>
        /// <param name="mainWindowDoc">The HTML document of the current file in the editor.</param>
        /// <param name="ip">The temp path of the image to the images folder.</param>
        /// <param name="dl">The language of the EPUB document.</param>
        /// <param name="location">The location of the image in the temp folder.</param>
        /// <param name="title">The title of the image.</param>
        /// <param name="altText">The alternative text of the image.</param>
        /// <param name="caption">The caption of the figure.</param>
        /// <param name="tag">The tag of the image.</param>
        /// <param name="altImgLocation">The temp path of the alternative image to the images folder.</param>
        /// <param name="width">The width of the figure.</param>
        /// <param name="height">The height of the figure.</param>
        /// <param name="floatValue">The alignment of the figure.</param>
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

        /// <summary>
        /// Closes the window properly and sets <c>DialogResult.Cancel</c>, which tells the main form that the image should not be edited 
        /// and there should not be any changes to it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.Cancel;

            this.Hide();
            this.Dispose();
            //this.Close();
        }

        /// <summary>
        /// Inserts a figure with an image and alternative text into the current HTML file of the EPUB file.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void addImageButton_Click(object sender, EventArgs e)
        {
            //this.DialogResult = DialogResult.OK;

            /* Certain steps can be skipped if there is no alternative image. */
            bool altImageExists = false;
            //bool toEnd = false;
     
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
            
            /* Copies the image into the images folder and if it the file already exists, it asks if the image can be overwritten. */
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

            /* Copies the altImage into the images folder and if it the file already exists, it asks if the image can be overwritten. */
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
            /* If there is no altImage, it just uses the regular image twice. */
            else
            {               
                altImagePath = imagePath;
            }
        

            /* Gets the current selection of the HTML document. */
            dynamic currentLocation = doc.selection.createRange();
            //r.pasteHTML

            /* If a tag exists, the greater than (>) and less than (<) have to be converted to a HTML entity. */
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

            /* The height and width tags are the strings which will be inserted as properties of the figure element. */
            string heightTag = "";
            string widthTag = "";

            int height = 0;
            int width = 0;
          
            /* The empty if prevents the else if being reached. */
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

            /* The empty if prevents the else if being reached. */
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
            
            
            //if (noneRadioButton.Checked == true)
            //{

            //}
            if (leftRadioButton.Checked == true)
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


            /* The HTML code of the figure with the image which will be inserted into the HTML document. */
            currentLocation.pasteHTML(@"<figure" + styleTag + heightTag + widthTag + @"><img class=""imageOthers""" + styleTag + @" title=""" + titleTextBox.Text + @""" src=""" + imagePath + @""" alt=""" + altTextTextBox.Text + "\"" + heightTag + widthTag + @"/><img class=""imageImpaired""" + styleTag + @"title=""" + titleTextBox.Text + @"""src=""" + altImagePath + @""" alt=""" + altTextTextBox.Text + "\"" + heightTag + widthTag + @"/><p class=""transparent"">" +
               tag + altTextTextBox.Text + tagEnd + @"</p><figcaption style = ""text -align:center"" >" + captionTextBox.Text + @"</figcaption></figure>");
            
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

        //TODO If an invalid file is chosen, it somehow has to be tested that it is not an valid image file for EPUB files 
        // and then tell the user it isn't accepted.
        /// <summary>
        /// Allows an image to be chosen which will then be inserted.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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

        /// <summary>
        /// Sets up the type tag list. Only German and English are supported for now, but if more languages are
        /// eventually supported, the resources file must be lengthened.
        /// </summary>
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

        //TODO If an invalid file is chosen, it somehow has to be tested that it is not an valid image file for EPUB files 
        // and then tell the user it isn't accepted.
        /// <summary>
        /// Allows an alternative image to be chosen which will then be inserted.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
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
