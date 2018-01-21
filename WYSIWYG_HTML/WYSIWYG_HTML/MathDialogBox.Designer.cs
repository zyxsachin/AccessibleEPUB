namespace WYSIWYG_HTML
{
    partial class MathDialogBox
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
            this.insertFormulaButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.formulaLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.host = new System.Windows.Forms.Integration.ElementHost();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // insertFormulaButton
            // 
            this.insertFormulaButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertFormulaButton.Location = new System.Drawing.Point(41, 211);
            this.insertFormulaButton.Name = "insertFormulaButton";
            this.insertFormulaButton.Size = new System.Drawing.Size(221, 57);
            this.insertFormulaButton.TabIndex = 0;
            this.insertFormulaButton.Text = "Insert Formula";
            this.insertFormulaButton.UseVisualStyleBackColor = true;
            this.insertFormulaButton.Click += new System.EventHandler(this.insertFormulaButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(279, 211);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(181, 57);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save Image";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Font = new System.Drawing.Font("Arial", 15F);
            this.inputTextBox.Location = new System.Drawing.Point(41, 60);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(930, 36);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.host);
            this.panel1.Location = new System.Drawing.Point(41, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 428);
            this.panel1.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(490, 211);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(142, 57);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // formulaLabel
            // 
            this.formulaLabel.AutoSize = true;
            this.formulaLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formulaLabel.Location = new System.Drawing.Point(37, 22);
            this.formulaLabel.Name = "formulaLabel";
            this.formulaLabel.Size = new System.Drawing.Size(217, 23);
            this.formulaLabel.TabIndex = 5;
            this.formulaLabel.Text = "Enter LaTeX math code";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(37, 110);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(46, 23);
            this.titleLabel.TabIndex = 7;
            this.titleLabel.Text = "Title";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Arial", 15F);
            this.titleTextBox.Location = new System.Drawing.Point(41, 148);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(930, 36);
            this.titleTextBox.TabIndex = 6;
            // 
            // host
            // 
            this.host.BackColor = System.Drawing.SystemColors.Window;
            this.host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.host.Location = new System.Drawing.Point(0, 0);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(930, 428);
            this.host.TabIndex = 4;
            this.host.Text = "host";
            this.host.Child = null;
            // 
            // MathDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1044, 753);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.formulaLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.insertFormulaButton);
            this.Name = "MathDialogBox";
            this.Text = "MathDialogBox";
            this.Load += new System.EventHandler(this.MathDialogBox_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button insertFormulaButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label formulaLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Integration.ElementHost host;
    }
}