namespace AccessibleEPUB
{
    partial class ImageDialogBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageDialogBox));
            this.imageLocationLabel = new System.Windows.Forms.Label();
            this.imageLocationTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.altTextTextBox = new System.Windows.Forms.TextBox();
            this.altTextLabel = new System.Windows.Forms.Label();
            this.captionLabel = new System.Windows.Forms.Label();
            this.captionTextBox = new System.Windows.Forms.TextBox();
            this.addImageButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.chooseImageButton = new System.Windows.Forms.Button();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // imageLocationLabel
            // 
            resources.ApplyResources(this.imageLocationLabel, "imageLocationLabel");
            this.imageLocationLabel.Name = "imageLocationLabel";
            // 
            // imageLocationTextBox
            // 
            resources.ApplyResources(this.imageLocationTextBox, "imageLocationTextBox");
            this.imageLocationTextBox.Name = "imageLocationTextBox";
            // 
            // titleTextBox
            // 
            resources.ApplyResources(this.titleTextBox, "titleTextBox");
            this.titleTextBox.Name = "titleTextBox";
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // altTextTextBox
            // 
            resources.ApplyResources(this.altTextTextBox, "altTextTextBox");
            this.altTextTextBox.Name = "altTextTextBox";
            // 
            // altTextLabel
            // 
            resources.ApplyResources(this.altTextLabel, "altTextLabel");
            this.altTextLabel.Name = "altTextLabel";
            // 
            // captionLabel
            // 
            resources.ApplyResources(this.captionLabel, "captionLabel");
            this.captionLabel.Name = "captionLabel";
            // 
            // captionTextBox
            // 
            resources.ApplyResources(this.captionTextBox, "captionTextBox");
            this.captionTextBox.Name = "captionTextBox";
            // 
            // addImageButton
            // 
            resources.ApplyResources(this.addImageButton, "addImageButton");
            this.addImageButton.Name = "addImageButton";
            this.addImageButton.UseVisualStyleBackColor = true;
            this.addImageButton.Click += new System.EventHandler(this.addImageButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // chooseImageButton
            // 
            resources.ApplyResources(this.chooseImageButton, "chooseImageButton");
            this.chooseImageButton.Name = "chooseImageButton";
            this.chooseImageButton.UseVisualStyleBackColor = true;
            this.chooseImageButton.Click += new System.EventHandler(this.chooseImageButton_Click);
            // 
            // typeComboBox
            // 
            resources.ApplyResources(this.typeComboBox, "typeComboBox");
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Name = "typeComboBox";
            // 
            // typeLabel
            // 
            resources.ApplyResources(this.typeLabel, "typeLabel");
            this.typeLabel.Name = "typeLabel";
            // 
            // widthLabel
            // 
            resources.ApplyResources(this.widthLabel, "widthLabel");
            this.widthLabel.Name = "widthLabel";
            // 
            // heightLabel
            // 
            resources.ApplyResources(this.heightLabel, "heightLabel");
            this.heightLabel.Name = "heightLabel";
            // 
            // widthTextBox
            // 
            resources.ApplyResources(this.widthTextBox, "widthTextBox");
            this.widthTextBox.Name = "widthTextBox";
            // 
            // heightTextBox
            // 
            resources.ApplyResources(this.heightTextBox, "heightTextBox");
            this.heightTextBox.Name = "heightTextBox";
            // 
            // ImageDialogBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.chooseImageButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.addImageButton);
            this.Controls.Add(this.captionTextBox);
            this.Controls.Add(this.captionLabel);
            this.Controls.Add(this.altTextTextBox);
            this.Controls.Add(this.altTextLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.imageLocationTextBox);
            this.Controls.Add(this.imageLocationLabel);
            this.Name = "ImageDialogBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label imageLocationLabel;
        private System.Windows.Forms.TextBox imageLocationTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox altTextTextBox;
        private System.Windows.Forms.Label altTextLabel;
        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.TextBox captionTextBox;
        private System.Windows.Forms.Button addImageButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button chooseImageButton;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.TextBox heightTextBox;
    }
}