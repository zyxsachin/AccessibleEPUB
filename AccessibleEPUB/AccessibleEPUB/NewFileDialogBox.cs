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
    public partial class NewFileDialogBox : Form
    {
        string title;
        string author;
        int mode;
        string publisher;


        string defaultEnglishString = "English";
        string defaultGermanString = "German";

        string englishString;
        string germanString;

        SortedDictionary<string, string> languagesDict = new SortedDictionary<string, string>
        {
           {"Abkhazian", "ab"}, {"Afar", "aa"}, {"Afrikaans", "af"}, {"Albanian", "sq"}, {"Amharic", "am"}, {"Arabic", "ar"},
            { "Armenian", "hy"}, {"Assamese", "as"}, {"Aymara", "ay"}, {"Azerbaijani", "az"}, {"Bashkir", "ba"}, {"Basque", "eu"},
            { "Bengali", "bn"}, {"Bhutani", "dz"}, {"Bihari", "bh"}, {"Bislama", "bi"}, {"Breton", "br"}, {"Bulgarian", "bg"},
            { "Burmese", "my"}, {"Byelorussian", "be"}, {"Cambodian", "km"}, {"Catalan", "ca"}, {"Chinese", "zh"}, {"Corsican", "co"},
            { "Croatian", "hr"}, {"Czech", "cs"}, {"Danish", "da"}, {"Dutch", "nl"}, {"English", "en"}, {"Esperanto", "eo"},
            { "Estonian", "et"}, {"Faeroese", "fo"}, {"Fiji", "fj"}, {"Finnish", "fi"}, {"French", "fr"}, {"Frisian", "fy"},
            { "Galician", "gl"}, {"Georgian", "ka"}, {"German", "de"}, {"Greek", "el"}, {"Greenlandic", "kl"}, {"Guarani", "gn"},
            { "Gujarati", "gu"}, {"Hausa", "ha"}, {"Hebrew", "he"}, {"Hindi", "hi"}, {"Hungarian", "hu"}, {"Icelandic", "is"},
            { "Indonesian", "id"}, {"Interlingua", "ia"}, {"Interlingue", "ie"}, {"Inuktitut", "iu"}, {"Inupiak", "ik"},
            { "Irish", "ga"}, {"Italian", "it"}, {"Japanese", "ja"}, {"Javanese", "jw"}, {"Kannada", "kn"}, {"Kashmiri", "ks"},
            { "Kazakh", "kk"}, {"Kinyarwanda", "rw"}, {"Kirghiz", "ky"}, {"Kirundi", "rn"}, {"Korean", "ko"}, {"Kurdish", "ku"},
            { "Laothian", "lo"}, {"Latin", "la"}, {"Latvian, Lettish", "lv"}, {"Lingala", "ln"}, {"Lithuanian", "lt"},
            { "Macedonian", "mk"}, {"Malagasy", "mg"}, {"Malay", "ms"}, {"Malayalam", "ml"}, {"Maltese", "mt"}, {"Maori", "mi"},
            { "Marathi", "mr"}, {"Moldavian", "mo"}, {"Mongolian", "mn"}, {"Nauru", "na"}, {"Nepali", "ne"}, {"Norwegian", "no"},
            { "Occitan", "oc"}, {"Oriya", "or"}, {"Oromo", "om"}, {"Pashto", "ps"}, {"Persian", "fa"}, {"Polish", "pl"},
            { "Portuguese", "pt"}, {"Punjabi", "pa"}, {"Quechua", "qu"}, {"Rhaeto-Romance", "rm"}, {"Romanian", "ro"}, {"Russian", "ru"},
            { "Samoan", "sm"}, {"Sangro", "sg"}, {"Sanskrit", "sa"}, {"Scots Gaelic", "gd"}, {"Serbian", "sr"}, {"Serbo-Croatian", "sh"},
            { "Sesotho", "st"}, {"Setswana", "tn"}, {"Shona", "sn"}, {"Sindhi", "sd"}, {"Singhalese", "si"}, {"Siswati", "ss"},
            { "Slovak", "sk"}, {"Slovenian", "sl"}, {"Somali", "so"}, {"Spanish", "es"}, {"Sudanese", "su"}, {"Swahili", "sw"},
            { "Swedish", "sv"}, {"Tagalog", "tl"}, {"Tajik", "tg"}, {"Tamil", "ta"}, {"Tatar", "tt"}, {"Tegulu", "te"}, {"Thai", "th"},
            { "Tibetan", "bo"}, {"Tigrinya", "ti"}, {"Tonga", "to"}, {"Tsonga", "ts"}, {"Turkish", "tr"}, {"Turkmen", "tk"},
            { "Twi", "tw"}, {"Uigur", "ug"}, {"Ukrainian", "uk"}, {"Urdu", "ur"}, {"Uzbek", "uz"}, {"Vietnamese", "vi"},
            { "Volapuk", "vo"}, {"Welch", "cy"}, {"Wolof", "wo"}, {"Xhosa", "xh"}, {"Yiddish", "yi"}, {"Yoruba", "yo"}, {"Zhuang", "za"}, {"Zulu", "zu"}
        };


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
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.ProgramLanguage.ToString());

            InitializeComponent();
            form = f;
            //initLanguageList();
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

                string languageChosen = "en";
                if (languageComboBox.SelectedIndex == 0)
                {
                    form.setLanguage("en");
                }
                else if (languageComboBox.SelectedIndex == 1)
                {
                    form.setLanguage("de");
                }

                if (languagesDict.TryGetValue(languageComboBox.Text, out languageChosen)) {
                    Console.WriteLine("HAHA: " + languageChosen);
                    form.setLanguage(languageChosen);
                }


              

               
                form.setNewFileCorrect(true);
                form.setPublisher(publisher);

                this.Dispose();
                this.Hide();
            }
            else
            {
                //System.Windows.Forms.MessageBox.Show("Not all required fields are filled out.", "Empty fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Windows.Forms.MessageBox.Show(Resource_MessageBox.notAllFieldsContent, Resource_MessageBox.notAllFieldsTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void initLanguageList()
        {
            //languageComboBox.Items.Add(englishString);
            //languageComboBox.Items.Add(germanString);

            //languageComboBox.SelectedItem = "English";
        }

        private void NewFileDialogBox_Shown(object sender, EventArgs e)
        {
            if (Settings.Default.DefaultLanguage == defaultEnglishString)
            {
                languageComboBox.SelectedIndex = 0;
            }
            else if (Settings.Default.DefaultLanguage == defaultGermanString)
            {
                languageComboBox.SelectedIndex = 1;
            }


            authorTextBox.Text = Settings.Default.DefaultAuthor;
            publisherTextBox.Text = Settings.Default.DefaultPublisher;

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

            titleTextBox.Focus();
        }
    }
}
