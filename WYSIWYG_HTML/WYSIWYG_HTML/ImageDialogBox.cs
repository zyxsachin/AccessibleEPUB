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

namespace WYSIWYG_HTML
{
    public partial class ImageDialogBox : Form
    {
        IHTMLDocument2 doc;

        public ImageDialogBox(IHTMLDocument2 mainWindowDoc)
        {
            InitializeComponent();
            doc = mainWindowDoc;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dispose();
        }

        private void addImageButton_Click(object sender, EventArgs e)
        {
            dynamic r = doc.selection.createRange();
            //r.pasteHTML
                doc.body.innerHTML+=(@"
<figure>
	<img title=""" + titleTextBox.Text + @""" 
        src =""" + imageLocationTextBox.Text + @""" alt =""" + altTextTextBox.Text + @""" />
  <p class=""transparent"" >
   " + altTextTextBox.Text + @"
  </p>
	<figcaption style = ""text -align:center"" > " + captionTextBox.Text +@"</figcaption>
</figure>
");
            this.Hide();
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
    }
}
