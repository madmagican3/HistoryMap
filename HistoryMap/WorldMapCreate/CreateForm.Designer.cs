namespace HistoryMap.WorldMapCreate
{
    partial class CreateForm
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
            this.WorldMapPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // WorldMapPanel
            // 
            this.WorldMapPanel.Location = new System.Drawing.Point(1, 1);
            this.WorldMapPanel.Name = "WorldMapPanel";
            this.WorldMapPanel.Size = new System.Drawing.Size(833, 573);
            this.WorldMapPanel.TabIndex = 0;
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 603);
            this.Controls.Add(this.WorldMapPanel);
            this.Name = "CreateForm";
            this.Text = "CreateForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateForm_FormClosing);
            this.Load += new System.EventHandler(this.CreateForm_Load);
            this.ResizeEnd += new System.EventHandler(this.CreateForm_ResizeEnd);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorldMapPanel;
    }
}