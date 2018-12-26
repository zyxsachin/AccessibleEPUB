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
        /// <summary>
        /// The title of the EPUB file, as specified by the Dublin Core Metadata Initiative.
        /// </summary>
        string title;

        /// <summary>
        /// The author of the EPUB file, as specified by the Dublin Core Metadata Initiative.
        /// </summary>
        string author;

        /// <summary>
        /// The publisher of the EPUB file, as specified by the Dublin Core Metadata Initiative.
        /// </summary>
        string publisher;

        /// <summary>
        /// The format of the currently opened EPUB file, described with values in <c>fileMode</c>.
        /// </summary>
        int mode;

        //TODO Replace with proper implementation of languageDict
        /// <summary>
        /// It is used to compare the language in the settings and set the default document language.
        /// </summary>
        string defaultEnglishString = "English";

        /// <summary>
        /// It is used to compare the language in the settings and set the default document language.
        /// </summary>
        string defaultGermanString = "German";

        //string englishString;
        //string germanString;

        /// <summary>
        /// A group of common languages with their ISO 639-1 codes. Not in use currently, as the english name will be 
        /// replaced with regional names so that each language in the program does not need a separate list.
        /// </summary>
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

        /// <summary>
        /// The various file modes which were intended to be available at the beginning. <c>fileMode</c> is used as identifiers  
        /// for the EPUB formats creatable by this editor. It is used frequently to make sure that CSS flavored EPUB file does
        /// not is of the correct format<c>singleFileCss</c> and therefore avoids errors that would take place if it were treated
        /// as anothed format. <c>singleFIleJs</c> are the only formats which can be created with the Accessible EPUB editor. 
        /// <c>onlyVis</c>, <c>onlyBli</c> and <c>onlyImp</c> stand for formats with only single components, which are
        /// regularly sighted, blind and visually impaired respectively.
        /// </summary>
        enum fileMode
        {
            singleFileCss = 1,
            singleFileJs = 2,
            onlyVis = 3,
            onlyBli = 4,
            onlyImp = 5,
            none = 6
        }

        /// <summary>
        /// The current instance of <c>Form1</c> which is needed as information will be passed to it.
        /// </summary>
        Form1 form;

        /// <summary>
        /// A constructor which needs an instance of <c>Form1</c> to pass the author, title and file mode to the instance.
        /// </summary>
        /// <param name="f">The current instance of <c>Form1</c> which is needed as information will be passed to it.</param>
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


        //private void singleFileJsButton_Click(object sender, EventArgs e)
        //{
        //    if (titleTextBox.Text != "" && authorTextBox.Text != "")
        //    {
        //        title = titleTextBox.Text;
        //        author = authorTextBox.Text;
        //        mode = (int)fileMode.singleFileJs;

        //        form.setAuthor(author);
        //        form.setTitle(title);
        //        form.setMode(mode);

        //        this.Dispose();
        //        this.Hide();

        //    }
        //}

        
        //public int getMode()
        //{
        //    return mode;
        //}

        //public string getTitle()
        //{
        //    return title;
        //}

        //public string getAuthor()
        //{
        //    return author;
        //}

        /// <summary>
        /// Tells the instance of <c>Form1</c> that a new file was not created so the process does not have to continue.
        /// </summary>
        /// <param name="sender">Not used.</param>
        /// <param name="e">Not used.</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            form.setNewFileCorrect(false);
            this.Hide();
            this.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                //if (languagesDict.TryGetValue(languageComboBox.Text, out languageChosen)) {
                //    form.setLanguage(languageChosen);
                //}



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
