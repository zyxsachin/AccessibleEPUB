namespace AccessibleEPUB
{
    partial class newFileDialog
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
            this.newFileCssButton = new System.Windows.Forms.Button();
            this.newFileJs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newFileCssButton
            // 
            this.newFileCssButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newFileCssButton.Location = new System.Drawing.Point(26, 351);
            this.newFileCssButton.Name = "newFileCssButton";
            this.newFileCssButton.Size = new System.Drawing.Size(219, 84);
            this.newFileCssButton.TabIndex = 0;
            this.newFileCssButton.Text = "New File(CSS)";
            this.newFileCssButton.UseVisualStyleBackColor = true;
            // 
            // newFileJs
            // 
            this.newFileJs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newFileJs.Location = new System.Drawing.Point(279, 351);
            this.newFileJs.Name = "newFileJs";
            this.newFileJs.Size = new System.Drawing.Size(219, 84);
            this.newFileJs.TabIndex = 1;
            this.newFileJs.Text = "New File(JS)";
            this.newFileJs.UseVisualStyleBackColor = true;
            // 
            // newFileDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 492);
            this.Controls.Add(this.newFileJs);
            this.Controls.Add(this.newFileCssButton);
            this.Name = "newFileDialog";
            this.Text = "newFileDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newFileCssButton;
        private System.Windows.Forms.Button newFileJs;
    }
}