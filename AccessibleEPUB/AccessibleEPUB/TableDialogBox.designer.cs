namespace AccessibleEPUB
{
    partial class TableDialogBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableDialogBox));
            this.rowsLabel = new System.Windows.Forms.Label();
            this.columnLabel = new System.Windows.Forms.Label();
            this.rowTextBox = new System.Windows.Forms.TextBox();
            this.columnTextBox = new System.Windows.Forms.TextBox();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.insertTableButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.adjustTableButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rowsLabel
            // 
            resources.ApplyResources(this.rowsLabel, "rowsLabel");
            this.rowsLabel.Name = "rowsLabel";
            // 
            // columnLabel
            // 
            resources.ApplyResources(this.columnLabel, "columnLabel");
            this.columnLabel.Name = "columnLabel";
            // 
            // rowTextBox
            // 
            resources.ApplyResources(this.rowTextBox, "rowTextBox");
            this.rowTextBox.Name = "rowTextBox";
            this.rowTextBox.TextChanged += new System.EventHandler(this.rowTextBox_TextChanged);
            // 
            // columnTextBox
            // 
            resources.ApplyResources(this.columnTextBox, "columnTextBox");
            this.columnTextBox.Name = "columnTextBox";
            this.columnTextBox.TextChanged += new System.EventHandler(this.columnTextBox_TextChanged);
            // 
            // tablePanel
            // 
            resources.ApplyResources(this.tablePanel, "tablePanel");
            this.tablePanel.Name = "tablePanel";
            // 
            // insertTableButton
            // 
            resources.ApplyResources(this.insertTableButton, "insertTableButton");
            this.insertTableButton.Name = "insertTableButton";
            this.insertTableButton.UseVisualStyleBackColor = true;
            this.insertTableButton.Click += new System.EventHandler(this.insertTableButton_Click);
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
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // adjustTableButton
            // 
            resources.ApplyResources(this.adjustTableButton, "adjustTableButton");
            this.adjustTableButton.Name = "adjustTableButton";
            this.adjustTableButton.UseVisualStyleBackColor = true;
            this.adjustTableButton.Click += new System.EventHandler(this.adjustTableButton_Click);
            // 
            // TableDialogBox
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.adjustTableButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.insertTableButton);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.columnTextBox);
            this.Controls.Add(this.rowTextBox);
            this.Controls.Add(this.columnLabel);
            this.Controls.Add(this.rowsLabel);
            this.Name = "TableDialogBox";
            this.Shown += new System.EventHandler(this.TableDialogBox_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label columnLabel;
        private System.Windows.Forms.TextBox rowTextBox;
        private System.Windows.Forms.TextBox columnTextBox;
        private System.Windows.Forms.Panel tablePanel;
        private System.Windows.Forms.Button insertTableButton;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button adjustTableButton;
    }
}