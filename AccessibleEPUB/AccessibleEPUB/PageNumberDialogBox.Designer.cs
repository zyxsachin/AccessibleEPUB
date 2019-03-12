namespace AccessibleEPUB
{
    partial class PageNumberDialogBox
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
            this.pageNumberCounterLabel = new System.Windows.Forms.Label();
            this.pageNumberCounterTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.numberFormatGroupBox = new System.Windows.Forms.GroupBox();
            this.normalRadioButton = new System.Windows.Forms.RadioButton();
            this.romanRadioButton = new System.Windows.Forms.RadioButton();
            this.numberFormatGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageNumberCounterLabel
            // 
            this.pageNumberCounterLabel.AutoSize = true;
            this.pageNumberCounterLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.pageNumberCounterLabel.Location = new System.Drawing.Point(50, 50);
            this.pageNumberCounterLabel.Name = "pageNumberCounterLabel";
            this.pageNumberCounterLabel.Size = new System.Drawing.Size(351, 27);
            this.pageNumberCounterLabel.TabIndex = 0;
            this.pageNumberCounterLabel.Text = "Page Number Counter (normal)";
            // 
            // pageNumberCounterTextBox
            // 
            this.pageNumberCounterTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageNumberCounterTextBox.Location = new System.Drawing.Point(559, 50);
            this.pageNumberCounterTextBox.Name = "pageNumberCounterTextBox";
            this.pageNumberCounterTextBox.Size = new System.Drawing.Size(92, 35);
            this.pageNumberCounterTextBox.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Arial", 12F);
            this.okButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.okButton.Location = new System.Drawing.Point(364, 252);
            this.okButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(132, 60);
            this.okButton.TabIndex = 22;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Arial", 12F);
            this.resetButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.resetButton.Location = new System.Drawing.Point(209, 252);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(132, 60);
            this.resetButton.TabIndex = 21;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Arial", 12F);
            this.cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelButton.Location = new System.Drawing.Point(519, 252);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(132, 60);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // numberFormatGroupBox
            // 
            this.numberFormatGroupBox.Controls.Add(this.romanRadioButton);
            this.numberFormatGroupBox.Controls.Add(this.normalRadioButton);
            this.numberFormatGroupBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberFormatGroupBox.Location = new System.Drawing.Point(55, 112);
            this.numberFormatGroupBox.Name = "numberFormatGroupBox";
            this.numberFormatGroupBox.Size = new System.Drawing.Size(596, 95);
            this.numberFormatGroupBox.TabIndex = 11;
            this.numberFormatGroupBox.TabStop = false;
            this.numberFormatGroupBox.Text = "Number format";
            // 
            // normalRadioButton
            // 
            this.normalRadioButton.AutoSize = true;
            this.normalRadioButton.Location = new System.Drawing.Point(16, 45);
            this.normalRadioButton.Name = "normalRadioButton";
            this.normalRadioButton.Size = new System.Drawing.Size(150, 31);
            this.normalRadioButton.TabIndex = 0;
            this.normalRadioButton.TabStop = true;
            this.normalRadioButton.Text = "Normal (1)";
            this.normalRadioButton.UseVisualStyleBackColor = true;
            // 
            // romanRadioButton
            // 
            this.romanRadioButton.AutoSize = true;
            this.romanRadioButton.Location = new System.Drawing.Point(351, 45);
            this.romanRadioButton.Name = "romanRadioButton";
            this.romanRadioButton.Size = new System.Drawing.Size(143, 31);
            this.romanRadioButton.TabIndex = 6;
            this.romanRadioButton.TabStop = true;
            this.romanRadioButton.Text = "Roman (I)";
            this.romanRadioButton.UseVisualStyleBackColor = true;
            // 
            // PageNumberDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 374);
            this.Controls.Add(this.numberFormatGroupBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.pageNumberCounterTextBox);
            this.Controls.Add(this.pageNumberCounterLabel);
            this.Name = "PageNumberDialogBox";
            this.Text = "PageNumberDialogBox";
            this.numberFormatGroupBox.ResumeLayout(false);
            this.numberFormatGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pageNumberCounterLabel;
        private System.Windows.Forms.TextBox pageNumberCounterTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox numberFormatGroupBox;
        private System.Windows.Forms.RadioButton normalRadioButton;
        private System.Windows.Forms.RadioButton romanRadioButton;
    }
}