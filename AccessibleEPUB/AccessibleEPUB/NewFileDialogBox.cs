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

    }
}
