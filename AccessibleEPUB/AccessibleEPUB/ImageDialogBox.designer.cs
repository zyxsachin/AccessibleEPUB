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
            this.SuspendLayout();
            // 
            // imageLocationLabel
            // 
            this.imageLocationLabel.AutoSize = true;
            this.imageLocationLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageLocationLabel.Location = new System.Drawing.Point(12, 35);
            this.imageLocationLabel.Name = "imageLocationLabel";
            this.imageLocationLabel.Size = new System.Drawing.Size(166, 23);
            this.imageLocationLabel.TabIndex = 0;
            this.imageLocationLabel.Text = "Location of image";
            // 
            // imageLocationTextBox
            // 
            this.imageLocationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageLocationTextBox.Location = new System.Drawing.Point(16, 76);
            this.imageLocationTextBox.Name = "imageLocationTextBox";
            this.imageLocationTextBox.Size = new System.Drawing.Size(714, 30);
            this.imageLocationTextBox.TabIndex = 1;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(16, 176);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(744, 30);
            this.titleTextBox.TabIndex = 3;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(12, 135);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(46, 23);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Title";
            // 
            // altTextTextBox
            // 
            this.altTextTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altTextTextBox.Location = new System.Drawing.Point(16, 276);
            this.altTextTextBox.Name = "altTextTextBox";
            this.altTextTextBox.Size = new System.Drawing.Size(744, 30);
            this.altTextTextBox.TabIndex = 4;
            // 
            // altTextLabel
            // 
            this.altTextLabel.AutoSize = true;
            this.altTextLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altTextLabel.Location = new System.Drawing.Point(12, 235);
            this.altTextLabel.Name = "altTextLabel";
            this.altTextLabel.Size = new System.Drawing.Size(144, 23);
            this.altTextLabel.TabIndex = 7;
            this.altTextLabel.Text = "Alternative Text";
            // 
            // captionLabel
            // 
            this.captionLabel.AutoSize = true;
            this.captionLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captionLabel.Location = new System.Drawing.Point(12, 335);
            this.captionLabel.Name = "captionLabel";
            this.captionLabel.Size = new System.Drawing.Size(77, 23);
            this.captionLabel.TabIndex = 9;
            this.captionLabel.Text = "Caption";
            // 
            // captionTextBox
            // 
            this.captionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captionTextBox.Location = new System.Drawing.Point(16, 376);
            this.captionTextBox.Name = "captionTextBox";
            this.captionTextBox.Size = new System.Drawing.Size(744, 30);
            this.captionTextBox.TabIndex = 5;
            // 
            // addImageButton
            // 
            this.addImageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addImageButton.Location = new System.Drawing.Point(404, 542);
            this.addImageButton.Name = "addImageButton";
            this.addImageButton.Size = new System.Drawing.Size(166, 48);
            this.addImageButton.TabIndex = 7;
            this.addImageButton.Text = "Insert Image";
            this.addImageButton.UseVisualStyleBackColor = true;
            this.addImageButton.Click += new System.EventHandler(this.addImageButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(594, 542);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(166, 48);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // chooseImageButton
            // 
            this.chooseImageButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chooseImageButton.BackgroundImage")));
            this.chooseImageButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chooseImageButton.Location = new System.Drawing.Point(730, 76);
            this.chooseImageButton.Name = "chooseImageButton";
            this.chooseImageButton.Size = new System.Drawing.Size(30, 30);
            this.chooseImageButton.TabIndex = 2;
            this.chooseImageButton.UseVisualStyleBackColor = true;
            this.chooseImageButton.Click += new System.EventHandler(this.chooseImageButton_Click);
            // 
            // typeComboBox
            // 
            this.typeComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(16, 478);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(199, 31);
            this.typeComboBox.TabIndex = 6;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.Location = new System.Drawing.Point(12, 436);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(53, 23);
            this.typeLabel.TabIndex = 15;
            this.typeLabel.Text = "Type";
            // 
            // ImageDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 615);
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
            this.Text = "Choose Image";
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
    }
}