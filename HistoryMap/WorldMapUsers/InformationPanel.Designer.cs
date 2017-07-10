namespace HistoryMap.WorldMapUsers
{
    partial class InformationPanel
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
            this.RichText = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RichText
            // 
            this.RichText.Location = new System.Drawing.Point(-1, 0);
            this.RichText.Name = "RichText";
            this.RichText.ReadOnly = true;
            this.RichText.Size = new System.Drawing.Size(783, 644);
            this.RichText.TabIndex = 0;
            this.RichText.Text = "";
            // 
            // InformationPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 645);
            this.Controls.Add(this.RichText);
            this.Name = "InformationPanel";
            this.Text = "InformationPanel";
            this.Load += new System.EventHandler(this.InformationPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RichText;
    }
}