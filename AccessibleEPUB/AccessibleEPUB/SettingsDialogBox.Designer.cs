namespace AccessibleEPUB
{
    partial class SettingsDialogBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsDialogBox));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.programLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.programLanguageLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.singleFileCssPictureBox = new System.Windows.Forms.PictureBox();
            this.singleFIleJsPictureBox = new System.Windows.Forms.PictureBox();
            this.chooseFileFormatPictureBox = new System.Windows.Forms.PictureBox();
            this.singleFileCssRadioButton = new System.Windows.Forms.RadioButton();
            this.singleFileJsRadioButton = new System.Windows.Forms.RadioButton();
            this.publisherTexbox = new System.Windows.Forms.TextBox();
            this.publisherLabel = new System.Windows.Forms.Label();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.settingsDialogToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.singleFileCssPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleFIleJsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseFileFormatPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Name = "panel1";
            this.settingsDialogToolTip.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.settingsDialogToolTip.SetToolTip(this.cancelButton, resources.GetString("cancelButton.ToolTip"));
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.settingsDialogToolTip.SetToolTip(this.saveButton, resources.GetString("saveButton.ToolTip"));
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.settingsDialogToolTip.SetToolTip(this.tabControl1, resources.GetString("tabControl1.ToolTip"));
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.programLanguageComboBox);
            this.tabPage1.Controls.Add(this.programLanguageLabel);
            this.tabPage1.Name = "tabPage1";
            this.settingsDialogToolTip.SetToolTip(this.tabPage1, resources.GetString("tabPage1.ToolTip"));
            // 
            // programLanguageComboBox
            // 
            resources.ApplyResources(this.programLanguageComboBox, "programLanguageComboBox");
            this.programLanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.programLanguageComboBox.FormattingEnabled = true;
            this.programLanguageComboBox.Items.AddRange(new object[] {
            resources.GetString("programLanguageComboBox.Items"),
            resources.GetString("programLanguageComboBox.Items1")});
            this.programLanguageComboBox.Name = "programLanguageComboBox";
            this.settingsDialogToolTip.SetToolTip(this.programLanguageComboBox, resources.GetString("programLanguageComboBox.ToolTip"));
            // 
            // programLanguageLabel
            // 
            resources.ApplyResources(this.programLanguageLabel, "programLanguageLabel");
            this.programLanguageLabel.Name = "programLanguageLabel";
            this.settingsDialogToolTip.SetToolTip(this.programLanguageLabel, resources.GetString("programLanguageLabel.ToolTip"));
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.publisherTexbox);
            this.tabPage2.Controls.Add(this.publisherLabel);
            this.tabPage2.Controls.Add(this.languageComboBox);
            this.tabPage2.Controls.Add(this.languageLabel);
            this.tabPage2.Controls.Add(this.authorTextBox);
            this.tabPage2.Controls.Add(this.authorLabel);
            this.tabPage2.Name = "tabPage2";
            this.settingsDialogToolTip.SetToolTip(this.tabPage2, resources.GetString("tabPage2.ToolTip"));
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.singleFileCssPictureBox);
            this.groupBox1.Controls.Add(this.singleFIleJsPictureBox);
            this.groupBox1.Controls.Add(this.chooseFileFormatPictureBox);
            this.groupBox1.Controls.Add(this.singleFileCssRadioButton);
            this.groupBox1.Controls.Add(this.singleFileJsRadioButton);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.settingsDialogToolTip.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // singleFileCssPictureBox
            // 
            resources.ApplyResources(this.singleFileCssPictureBox, "singleFileCssPictureBox");
            this.singleFileCssPictureBox.Name = "singleFileCssPictureBox";
            this.singleFileCssPictureBox.TabStop = false;
            this.settingsDialogToolTip.SetToolTip(this.singleFileCssPictureBox, resources.GetString("singleFileCssPictureBox.ToolTip"));
            // 
            // singleFIleJsPictureBox
            // 
            resources.ApplyResources(this.singleFIleJsPictureBox, "singleFIleJsPictureBox");
            this.singleFIleJsPictureBox.Name = "singleFIleJsPictureBox";
            this.singleFIleJsPictureBox.TabStop = false;
            this.settingsDialogToolTip.SetToolTip(this.singleFIleJsPictureBox, resources.GetString("singleFIleJsPictureBox.ToolTip"));
            // 
            // chooseFileFormatPictureBox
            // 
            resources.ApplyResources(this.chooseFileFormatPictureBox, "chooseFileFormatPictureBox");
            this.chooseFileFormatPictureBox.Name = "chooseFileFormatPictureBox";
            this.chooseFileFormatPictureBox.TabStop = false;
            this.settingsDialogToolTip.SetToolTip(this.chooseFileFormatPictureBox, resources.GetString("chooseFileFormatPictureBox.ToolTip"));
            // 
            // singleFileCssRadioButton
            // 
            resources.ApplyResources(this.singleFileCssRadioButton, "singleFileCssRadioButton");
            this.singleFileCssRadioButton.Name = "singleFileCssRadioButton";
            this.singleFileCssRadioButton.TabStop = true;
            this.settingsDialogToolTip.SetToolTip(this.singleFileCssRadioButton, resources.GetString("singleFileCssRadioButton.ToolTip"));
            this.singleFileCssRadioButton.UseVisualStyleBackColor = true;
            // 
            // singleFileJsRadioButton
            // 
            resources.ApplyResources(this.singleFileJsRadioButton, "singleFileJsRadioButton");
            this.singleFileJsRadioButton.Name = "singleFileJsRadioButton";
            this.singleFileJsRadioButton.TabStop = true;
            this.settingsDialogToolTip.SetToolTip(this.singleFileJsRadioButton, resources.GetString("singleFileJsRadioButton.ToolTip"));
            this.singleFileJsRadioButton.UseVisualStyleBackColor = true;
            // 
            // publisherTexbox
            // 
            resources.ApplyResources(this.publisherTexbox, "publisherTexbox");
            this.publisherTexbox.Name = "publisherTexbox";
            this.settingsDialogToolTip.SetToolTip(this.publisherTexbox, resources.GetString("publisherTexbox.ToolTip"));
            // 
            // publisherLabel
            // 
            resources.ApplyResources(this.publisherLabel, "publisherLabel");
            this.publisherLabel.Name = "publisherLabel";
            this.settingsDialogToolTip.SetToolTip(this.publisherLabel, resources.GetString("publisherLabel.ToolTip"));
            // 
            // languageComboBox
            // 
            resources.ApplyResources(this.languageComboBox, "languageComboBox");
            this.languageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            resources.GetString("languageComboBox.Items"),
            resources.GetString("languageComboBox.Items1")});
            this.languageComboBox.Name = "languageComboBox";
            this.settingsDialogToolTip.SetToolTip(this.languageComboBox, resources.GetString("languageComboBox.ToolTip"));
            // 
            // languageLabel
            // 
            resources.ApplyResources(this.languageLabel, "languageLabel");
            this.languageLabel.Name = "languageLabel";
            this.settingsDialogToolTip.SetToolTip(this.languageLabel, resources.GetString("languageLabel.ToolTip"));
            // 
            // authorTextBox
            // 
            resources.ApplyResources(this.authorTextBox, "authorTextBox");
            this.authorTextBox.Name = "authorTextBox";
            this.settingsDialogToolTip.SetToolTip(this.authorTextBox, resources.GetString("authorTextBox.ToolTip"));
            // 
            // authorLabel
            // 
            resources.ApplyResources(this.authorLabel, "authorLabel");
            this.authorLabel.Name = "authorLabel";
            this.settingsDialogToolTip.SetToolTip(this.authorLabel, resources.GetString("authorLabel.ToolTip"));
            // 
            // SettingsDialogBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "SettingsDialogBox";
            this.settingsDialogToolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Shown += new System.EventHandler(this.SettingsDialogBox_Shown);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.singleFileCssPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.singleFIleJsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chooseFileFormatPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.TextBox publisherTexbox;
        private System.Windows.Forms.Label publisherLabel;
        private System.Windows.Forms.ComboBox programLanguageComboBox;
        private System.Windows.Forms.Label programLanguageLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton singleFileCssRadioButton;
        private System.Windows.Forms.RadioButton singleFileJsRadioButton;
        private System.Windows.Forms.ToolTip settingsDialogToolTip;
        private System.Windows.Forms.PictureBox singleFIleJsPictureBox;
        private System.Windows.Forms.PictureBox chooseFileFormatPictureBox;
        private System.Windows.Forms.PictureBox singleFileCssPictureBox;
    }
}