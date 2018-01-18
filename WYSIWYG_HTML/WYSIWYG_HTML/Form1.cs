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
    public partial class Form1 : Form
    {

        private IHTMLDocument2 doc;
        Dictionary<string, string> headings;
        string documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public Form1()
        {
            InitializeComponent();
       
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            HTMLEditor.DocumentText = @"<html><body></body></html>"; //This will get our HTML editor ready, inserting common HTML blocks into the document
                                                                    //Make the web 'browser' an editable HTML field
       
            doc = HTMLEditor.Document.DomDocument as IHTMLDocument2;
     
            doc.designMode = "On";


            //What we just did was make our web browser editable!


        }
       
        private void Form1_Shown(object sender, EventArgs e)
        {
            //IHTMLStyleSheet ss = doc.createStyleSheet("", 0);
            //ss.cssText = "html * {	font-family: 'Arial', Helvetica, sans-serif !important; }";
            //string css = "<link rel=\"stylesheet\" href=" + documents + "impaired.css" + "/>";
            //HTMLEditor.Document.Encoding = "UTF-8";


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

;"
;
            
  
            

            //HTMLEditor.Document.ExecCommand("FontName", false, "Arial");

            InitHeadingsList();
            InitFontList();
            InitFontSizeList();
        }

        public IHTMLDocument2 getHTMLDocument()
        {
            return doc;
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




        private void boldButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("Bold", false, null);
            richTextBox1.Text = HTMLEditor.DocumentText;
        }

        private void italicButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("Italic", false, null);
        }

        private void underlineButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("Underline", false, null);
        }

        private void strikethroughButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("StrikeThrough", false, null);
            
        }



        


        private void orderedListButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("InsertOrderedList", false, null);
        }

        private void unorderedListButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("InsertUnorderedList", false, null);

        }
   
        private void formatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string format;

            if (headings.TryGetValue(formatComboBox.SelectedItem.ToString(), out format))
            {
                HTMLEditor.Document.ExecCommand("formatBlock", false, format);
            }

            HTMLEditor.Document.Focus();



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
            HTMLEditor.Document.ExecCommand("JustifyLeft", false, null);
        }

        private void justifyCenterButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("JustifyCenter", false, null);
        }

        private void justifyRightButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("JustifyRight", false, null);
        }

        private void justifyButton_Click(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("JustifyFull", false, null);
        }

        private void fontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("FontName", false, fontComboBox.SelectedItem.ToString());
            //ss.cssText = "html * {	font-family: 'Arial', Helvetica, sans-serif !important; }";
            //ss.cssText = "html * {	font-family: '" + fontComboBox.SelectedItem.ToString() + "', Helvetica, sans-serif !important; }";
        }

        private void colorPickerButton_Click(object sender, EventArgs e)
        {
            Color col = new Color() ;
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

        private void fontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HTMLEditor.Document.ExecCommand("FontSize", false, fontSizeComboBox.SelectedItem.ToString());
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            ImageDialogBox idb = new ImageDialogBox(doc);
            idb.ShowDialog();
        }

        private void tableButton_Click(object sender, EventArgs e)
        {
            TableDialogBox tdb = new TableDialogBox(doc);
            tdb.ShowDialog();
        }

        private void mathButton_Click(object sender, EventArgs e)
        {
            MathDialogBox mdb = new MathDialogBox(doc);
            mdb.ShowDialog();
        }
    }
}
