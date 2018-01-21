namespace WYSIWYG_HTML
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
            this.rowsLabel = new System.Windows.Forms.Label();
            this.columnLabel = new System.Windows.Forms.Label();
            this.rowTextBox = new System.Windows.Forms.TextBox();
            this.columnTextBox = new System.Windows.Forms.TextBox();
            this.tablePanel = new System.Windows.Forms.Panel();
            this.adjustTableButton = new System.Windows.Forms.Button();
            this.insertTableButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rowsLabel
            // 
            this.rowsLabel.AutoSize = true;
            this.rowsLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowsLabel.Location = new System.Drawing.Point(45, 23);
            this.rowsLabel.Name = "rowsLabel";
            this.rowsLabel.Size = new System.Drawing.Size(60, 23);
            this.rowsLabel.TabIndex = 0;
            this.rowsLabel.Text = "Rows";
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnLabel.Location = new System.Drawing.Point(225, 23);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(75, 23);
            this.columnLabel.TabIndex = 1;
            this.columnLabel.Text = "Column";
            // 
            // rowTextBox
            // 
            this.rowTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowTextBox.Location = new System.Drawing.Point(49, 72);
            this.rowTextBox.Name = "rowTextBox";
            this.rowTextBox.Size = new System.Drawing.Size(60, 30);
            this.rowTextBox.TabIndex = 2;
            this.rowTextBox.Text = "2";
            // 
            // columnTextBox
            // 
            this.columnTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.columnTextBox.Location = new System.Drawing.Point(229, 72);
            this.columnTextBox.Name = "columnTextBox";
            this.columnTextBox.Size = new System.Drawing.Size(60, 30);
            this.columnTextBox.TabIndex = 3;
            this.columnTextBox.Text = "2";
            // 
            // tablePanel
            // 
            this.tablePanel.AutoSize = true;
            this.tablePanel.Location = new System.Drawing.Point(44, 196);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.Size = new System.Drawing.Size(512, 105);
            this.tablePanel.TabIndex = 4;
            // 
            // adjustTableButton
            // 
            this.adjustTableButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adjustTableButton.Location = new System.Drawing.Point(49, 119);
            this.adjustTableButton.Name = "adjustTableButton";
            this.adjustTableButton.Size = new System.Drawing.Size(136, 53);
            this.adjustTableButton.TabIndex = 5;
            this.adjustTableButton.Text = "Adjust Table";
            this.adjustTableButton.UseVisualStyleBackColor = true;
            this.adjustTableButton.Click += new System.EventHandler(this.adjustTableButton_Click);
            // 
            // insertTableButton
            // 
            this.insertTableButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insertTableButton.Location = new System.Drawing.Point(229, 119);
            this.insertTableButton.Name = "insertTableButton";
            this.insertTableButton.Size = new System.Drawing.Size(136, 53);
            this.insertTableButton.TabIndex = 6;
            this.insertTableButton.Text = "Insert Table";
            this.insertTableButton.UseVisualStyleBackColor = true;
            this.insertTableButton.Click += new System.EventHandler(this.insertTableButton_Click);
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(409, 72);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(299, 30);
            this.titleTextBox.TabIndex = 10;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(405, 23);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(46, 23);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "Title";
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.Location = new System.Drawing.Point(409, 119);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(136, 53);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // TableDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(890, 488);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.insertTableButton);
            this.Controls.Add(this.adjustTableButton);
            this.Controls.Add(this.tablePanel);
            this.Controls.Add(this.columnTextBox);
            this.Controls.Add(this.rowTextBox);
            this.Controls.Add(this.columnLabel);
            this.Controls.Add(this.rowsLabel);
            this.Name = "TableDialogBox";
            this.Text = "TableDialogBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rowsLabel;
        private System.Windows.Forms.Label columnLabel;
        private System.Windows.Forms.TextBox rowTextBox;
        private System.Windows.Forms.TextBox columnTextBox;
        private System.Windows.Forms.Panel tablePanel;
        private System.Windows.Forms.Button adjustTableButton;
        private System.Windows.Forms.Button insertTableButton;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button cancelButton;
    }
}