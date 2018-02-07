namespace AccessibleEPUB
{
    partial class NewFileDialogBox
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
            this.singleFileCssButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.singleFileJsButton = new System.Windows.Forms.Button();
            this.onlyVisuallyImpairedButton = new System.Windows.Forms.Button();
            this.onlyNormalButton = new System.Windows.Forms.Button();
            this.onlyBlindButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // singleFileCssButton
            // 
            this.singleFileCssButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleFileCssButton.Location = new System.Drawing.Point(39, 230);
            this.singleFileCssButton.Name = "singleFileCssButton";
            this.singleFileCssButton.Size = new System.Drawing.Size(220, 65);
            this.singleFileCssButton.TabIndex = 0;
            this.singleFileCssButton.Text = "Single File(CSS)";
            this.singleFileCssButton.UseVisualStyleBackColor = true;
            this.singleFileCssButton.Click += new System.EventHandler(this.singleFileCssButton_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(39, 78);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(727, 30);
            this.titleTextBox.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(35, 41);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(46, 23);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Title";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorLabel.Location = new System.Drawing.Point(35, 129);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(67, 23);
            this.authorLabel.TabIndex = 4;
            this.authorLabel.Text = "Author";
            // 
            // authorTextBox
            // 
            this.authorTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorTextBox.Location = new System.Drawing.Point(39, 166);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(727, 30);
            this.authorTextBox.TabIndex = 3;
            // 
            // singleFileJsButton
            // 
            this.singleFileJsButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singleFileJsButton.Location = new System.Drawing.Point(284, 230);
            this.singleFileJsButton.Name = "singleFileJsButton";
            this.singleFileJsButton.Size = new System.Drawing.Size(220, 65);
            this.singleFileJsButton.TabIndex = 5;
            this.singleFileJsButton.Text = "Single File(JavaScript)";
            this.singleFileJsButton.UseVisualStyleBackColor = true;
            this.singleFileJsButton.Click += new System.EventHandler(this.singleFileJsButton_Click);
            // 
            // onlyVisuallyImpairedButton
            // 
            this.onlyVisuallyImpairedButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlyVisuallyImpairedButton.Location = new System.Drawing.Point(284, 328);
            this.onlyVisuallyImpairedButton.Name = "onlyVisuallyImpairedButton";
            this.onlyVisuallyImpairedButton.Size = new System.Drawing.Size(220, 65);
            this.onlyVisuallyImpairedButton.TabIndex = 7;
            this.onlyVisuallyImpairedButton.Text = "Only Visually Impaired";
            this.onlyVisuallyImpairedButton.UseVisualStyleBackColor = true;
            // 
            // onlyNormalButton
            // 
            this.onlyNormalButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlyNormalButton.Location = new System.Drawing.Point(39, 328);
            this.onlyNormalButton.Name = "onlyNormalButton";
            this.onlyNormalButton.Size = new System.Drawing.Size(220, 65);
            this.onlyNormalButton.TabIndex = 6;
            this.onlyNormalButton.Text = "Only Normal";
            this.onlyNormalButton.UseVisualStyleBackColor = true;
            // 
            // onlyBlindButton
            // 
            this.onlyBlindButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlyBlindButton.Location = new System.Drawing.Point(529, 328);
            this.onlyBlindButton.Name = "onlyBlindButton";
            this.onlyBlindButton.Size = new System.Drawing.Size(220, 65);
            this.onlyBlindButton.TabIndex = 8;
            this.onlyBlindButton.Text = "Only Blind";
            this.onlyBlindButton.UseVisualStyleBackColor = true;
            // 
            // NewFileDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 459);
            this.Controls.Add(this.onlyBlindButton);
            this.Controls.Add(this.onlyVisuallyImpairedButton);
            this.Controls.Add(this.onlyNormalButton);
            this.Controls.Add(this.singleFileJsButton);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.authorTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.singleFileCssButton);
            this.Name = "NewFileDialogBox";
            this.Text = "NewFileDialogBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button singleFileCssButton;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Button singleFileJsButton;
        private System.Windows.Forms.Button onlyVisuallyImpairedButton;
        private System.Windows.Forms.Button onlyNormalButton;
        private System.Windows.Forms.Button onlyBlindButton;
    }
}