using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessibleEPUB
{
    public partial class NewFileDialogBox : Form
    {
        string title;
        string author;
        int mode;
        string publisher;

        enum fileMode
        {
            singleFileCss = 1,
            singleFileJs = 2,
            onlyVis = 3,
            onlyBli = 4,
            onlyImp = 5,
            none = 6
        }

        Form1 form;

        public NewFileDialogBox(Form1 f)
        {
            InitializeComponent();
            form = f;
            initLanguageList();
            singleFileJsRadioButton.Select();

        }

        private void singleFileCssButton_Click(object sender, EventArgs e)
        {

            if (titleTextBox.Text != "" && authorTextBox.Text != "")
            {
                title = titleTextBox.Text;
                author = authorTextBox.Text;
                mode = (int)fileMode.singleFileCss;

                form.setAuthor(author);
                form.setTitle(title);
                form.setMode(mode);

                this.Dispose();
                this.Hide();

            }

        }


        private void singleFileJsButton_Click(object sender, EventArgs e)
        {
            if (titleTextBox.Text != "" && authorTextBox.Text != "")
            {
                title = titleTextBox.Text;
                author = authorTextBox.Text;
                mode = (int)fileMode.singleFileJs;

                form.setAuthor(author);
                form.setTitle(title);
                form.setMode(mode);

                this.Dispose();
                this.Hide();

            }
        }


        public int getMode()
        {
            return mode;
        }

        public string getTitle()
        {
            return title;
        }

        public string getAuthor()
        {
            return author;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            form.setNewFileCorrect(false);
            this.Hide();
            this.Dispose();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (titleTextBox.Text != "" && authorTextBox.Text != "")
            {
                if (singleFileJsRadioButton.Checked == true)
                {
                    mode = (int)fileMode.singleFileJs;
                }
                else if (singleFileCssRadioButton.Checked == true)
                {
                    mode = (int)fileMode.singleFileCss;
                }
             
                title = titleTextBox.Text;
                author = authorTextBox.Text;
                publisher = publisherTextBox.Text;

                form.setAuthor(author);
                form.setTitle(title);
                form.setMode(mode);
                form.setLanguage(languageComboBox.SelectedItem.ToString());
                form.setNewFileCorrect(true);
                form.setPublisher(publisher);

                this.Dispose();
                this.Hide();

            }
        }

        private void initLanguageList()
        {
            languageComboBox.Items.Add("English");
            languageComboBox.Items.Add("German");

            //languageComboBox.SelectedItem = "English";
        }

        private void NewFileDialogBox_Shown(object sender, EventArgs e)
        {
            languageComboBox.SelectedItem = Settings.Default.DefaultLanguage;
            authorTextBox.Text = Settings.Default.DefaultAuthor;
            titleTextBox.Focus();
        }
    }
}
