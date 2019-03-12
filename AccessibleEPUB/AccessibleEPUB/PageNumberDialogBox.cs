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
    public partial class PageNumberDialogBox : Form
    {

        Form1 form;

        public PageNumberDialogBox()
        {
            InitializeComponent();
        }

        public PageNumberDialogBox(int currentPageNumber, Form1 form1)
        {
            InitializeComponent();
            pageNumberCounterTextBox.Text = currentPageNumber + "";
            form = form1;

            normalRadioButton.Checked = true;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            pageNumberCounterTextBox.Text = "1";
            normalRadioButton.Checked = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            int toSetPageNumber = 1;
            Int32.TryParse(pageNumberCounterTextBox.Text, out toSetPageNumber);

            bool isRoman = false;

            if (romanRadioButton.Checked == true)
            {
                isRoman = true;
            }

            form.setPageNumber(toSetPageNumber, isRoman);
            

            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
            this.Dispose();
        }


    }
}
