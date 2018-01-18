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
            this.host = new System.Windows.Forms.Integration.ElementHost();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // insertFormulaButton
            // 
            this.insertFormulaButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertFormulaButton.Location = new System.Drawing.Point(165, 89);
            this.insertFormulaButton.Name = "insertFormulaButton";
            this.insertFormulaButton.Size = new System.Drawing.Size(377, 91);
            this.insertFormulaButton.TabIndex = 0;
            this.insertFormulaButton.Text = "Insert Formula";
            this.insertFormulaButton.UseVisualStyleBackColor = true;
            this.insertFormulaButton.Click += new System.EventHandler(this.insertFormulaButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(663, 89);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(142, 79);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.Location = new System.Drawing.Point(165, 35);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(377, 30);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.host);
            this.panel1.Location = new System.Drawing.Point(41, 211);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 331);
            this.panel1.TabIndex = 3;
            // 
            // host
            // 
            this.host.BackColor = System.Drawing.SystemColors.Window;
            this.host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.host.Location = new System.Drawing.Point(0, 0);
            this.host.Name = "host";
            this.host.Size = new System.Drawing.Size(930, 331);
            this.host.TabIndex = 4;
            this.host.Text = "host";
            this.host.Child = null;
            // 
            // MathDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 554);
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
        private System.Windows.Forms.Integration.ElementHost host;
    }
}