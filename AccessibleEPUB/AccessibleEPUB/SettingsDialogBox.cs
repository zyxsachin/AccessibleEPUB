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
    public partial class SettingsDialogBox : Form
    {
        public SettingsDialogBox()
        {
            InitializeComponent();

            initLanguageList();
        }


        private void initLanguageList()
        {
            languageComboBox.Items.Add("English");
            languageComboBox.Items.Add("German");

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Settings.Default.DefaultLanguage = languageComboBox.SelectedItem.ToString();
            Settings.Default.DefaultAuthor = authorTextBox.Text;
            Settings.Default.Save();
            this.Hide();
            this.Dispose();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }


        private void SettingsDialogBox_Shown(object sender, EventArgs e)
        {
            languageComboBox.SelectedItem = Settings.Default.DefaultLanguage;
            authorTextBox.Text = Settings.Default.DefaultAuthor;
        }  
    }
}
