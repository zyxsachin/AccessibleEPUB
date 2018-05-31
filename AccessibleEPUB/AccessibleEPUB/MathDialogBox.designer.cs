namespace AccessibleEPUB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MathDialogBox));
            this.insertFormulaButton = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.host = new System.Windows.Forms.Integration.ElementHost();
            this.cancelButton = new System.Windows.Forms.Button();
            this.formulaLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.captionLabel = new System.Windows.Forms.Label();
            this.captionTextBox = new System.Windows.Forms.TextBox();
            this.floatGroupBox = new System.Windows.Forms.GroupBox();
            this.rightRadioButton = new System.Windows.Forms.RadioButton();
            this.leftRadioButton = new System.Windows.Forms.RadioButton();
            this.noneRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.floatGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // insertFormulaButton
            // 
            resources.ApplyResources(this.insertFormulaButton, "insertFormulaButton");
            this.insertFormulaButton.Name = "insertFormulaButton";
            this.insertFormulaButton.UseVisualStyleBackColor = true;
            this.insertFormulaButton.Click += new System.EventHandler(this.insertFormulaButton_Click);
            // 
            // inputTextBox
            // 
            resources.ApplyResources(this.inputTextBox, "inputTextBox");
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.TextChanged += new System.EventHandler(this.inputTextBox_TextChanged);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.host);
            this.panel1.Name = "panel1";
            // 
            // host
            // 
            this.host.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.host, "host");
            this.host.Name = "host";
            this.host.TabStop = false;
            this.host.Child = null;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // formulaLabel
            // 
            resources.ApplyResources(this.formulaLabel, "formulaLabel");
            this.formulaLabel.Name = "formulaLabel";
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // titleTextBox
            // 
            resources.ApplyResources(this.titleTextBox, "titleTextBox");
            this.titleTextBox.Name = "titleTextBox";
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
            // floatGroupBox
            // 
            resources.ApplyResources(this.floatGroupBox, "floatGroupBox");
            this.floatGroupBox.Controls.Add(this.rightRadioButton);
            this.floatGroupBox.Controls.Add(this.leftRadioButton);
            this.floatGroupBox.Controls.Add(this.noneRadioButton);
            this.floatGroupBox.Name = "floatGroupBox";
            this.floatGroupBox.TabStop = false;
            // 
            // rightRadioButton
            // 
            resources.ApplyResources(this.rightRadioButton, "rightRadioButton");
            this.rightRadioButton.Name = "rightRadioButton";
            this.rightRadioButton.TabStop = true;
            this.rightRadioButton.UseVisualStyleBackColor = true;
            // 
            // leftRadioButton
            // 
            resources.ApplyResources(this.leftRadioButton, "leftRadioButton");
            this.leftRadioButton.Name = "leftRadioButton";
            this.leftRadioButton.TabStop = true;
            this.leftRadioButton.UseVisualStyleBackColor = true;
            // 
            // noneRadioButton
            // 
            resources.ApplyResources(this.noneRadioButton, "noneRadioButton");
            this.noneRadioButton.Name = "noneRadioButton";
            this.noneRadioButton.TabStop = true;
            this.noneRadioButton.UseVisualStyleBackColor = true;
            // 
            // MathDialogBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.floatGroupBox);
            this.Controls.Add(this.captionTextBox);
            this.Controls.Add(this.captionLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.formulaLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.insertFormulaButton);
            this.Name = "MathDialogBox";
            this.Load += new System.EventHandler(this.MathDialogBox_Load);
            this.panel1.ResumeLayout(false);
            this.floatGroupBox.ResumeLayout(false);
            this.floatGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button insertFormulaButton;
        private System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label formulaLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Integration.ElementHost host;
        private System.Windows.Forms.Label captionLabel;
        private System.Windows.Forms.TextBox captionTextBox;
        private System.Windows.Forms.GroupBox floatGroupBox;
        private System.Windows.Forms.RadioButton rightRadioButton;
        private System.Windows.Forms.RadioButton leftRadioButton;
        private System.Windows.Forms.RadioButton noneRadioButton;
    }
}