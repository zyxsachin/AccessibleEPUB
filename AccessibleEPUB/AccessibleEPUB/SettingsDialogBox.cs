using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using System.Threading;

namespace AccessibleEPUB
{
    public partial class SettingsDialogBox : Form
    {

        string defaultEnglishString = "English";
        string defaultGermanString = "German";

        string englishString;
        string germanString;



        public SettingsDialogBox()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());

            InitializeComponent();

            initLanguageList();
        }


        private void initLanguageList()
        {
            //languageComboBox.Items.Add(englishString);
            //languageComboBox.Items.Add(germanString);


            //programLanguageComboBox.Items.Add(englishString);
            //programLanguageComboBox.Items.Add(germanString);



        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Settings.Default.DefaultLanguage = languageComboBox.SelectedItem.ToString();
            Settings.Default.DefaultAuthor = authorTextBox.Text;
            Settings.Default.DefaultPublisher = publisherTexbox.Text;

            string newLanguage = ""; ;

            if (languageComboBox.SelectedIndex == 0)
            {
                Settings.Default.DefaultLanguage = defaultEnglishString;
            }
            else if (languageComboBox.SelectedIndex == 1)
            {
                Settings.Default.DefaultLanguage = defaultGermanString;
            }

            if (programLanguageComboBox.SelectedIndex == 0)
            {
                newLanguage = "";
                Settings.Default.ProgramLanguage = newLanguage;
            }
            else if (programLanguageComboBox.SelectedIndex == 1)
            {
                newLanguage = "de-DE";
                Settings.Default.ProgramLanguage = newLanguage;
            }


            if (singleFileJsRadioButton.Checked == true)
            {
                Settings.Default.DefaultEpubFormat = "singleFileJs";
            }
            else if (singleFileCssRadioButton.Checked == true)
            {
                Settings.Default.DefaultEpubFormat = "singleFileCss";
            }



            Settings.Default.Save();

            MessageBox.Show(Resource_MessageBox.changesContent, Resource_MessageBox.conversionTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


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
            //languageComboBox.SelectedItem = Settings.Default.DefaultLanguage;
            authorTextBox.Text = Settings.Default.DefaultAuthor;
            publisherTexbox.Text = Settings.Default.DefaultPublisher;





            if (Settings.Default.DefaultLanguage == defaultEnglishString)
            {
                languageComboBox.SelectedIndex = 0;
            }
            else if (Settings.Default.DefaultLanguage == defaultGermanString)
            {
                languageComboBox.SelectedIndex = 1;
            }

            if (Settings.Default.ProgramLanguage == "")
            {
               programLanguageComboBox.SelectedIndex = 0;
            }
            else if (Settings.Default.ProgramLanguage == "de-DE")
            {
                programLanguageComboBox.SelectedIndex = 1;
            }

           

            if (Settings.Default.DefaultEpubFormat == "singleFileJs")
            {
                singleFileJsRadioButton.Checked = true;
            }
            else if (Settings.Default.DefaultEpubFormat == "singleFileCss")
            {
                singleFileCssRadioButton.Checked = true;
            }
            else
            {
                singleFileJsRadioButton.Checked = true;
            }


        }


    }
}
