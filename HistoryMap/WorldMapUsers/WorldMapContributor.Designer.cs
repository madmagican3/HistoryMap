namespace HistoryMap.WorldMapUsers
{
    partial class WorldMapContributor
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
            this.ContributionControlsPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // WorldMapPanel
            // 
            this.WorldMapPanel.Location = new System.Drawing.Point(195, 2);
            this.WorldMapPanel.Name = "WorldMapPanel";
            this.WorldMapPanel.Size = new System.Drawing.Size(672, 493);
            this.WorldMapPanel.TabIndex = 0;
            // 
            // ContributionControlsPanel
            // 
            this.ContributionControlsPanel.Location = new System.Drawing.Point(-1, 2);
            this.ContributionControlsPanel.Name = "ContributionControlsPanel";
            this.ContributionControlsPanel.Size = new System.Drawing.Size(197, 493);
            this.ContributionControlsPanel.TabIndex = 1;
            // 
            // WorldMapContributor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 496);
            this.Controls.Add(this.ContributionControlsPanel);
            this.Controls.Add(this.WorldMapPanel);
            this.Name = "WorldMapContributor";
            this.Text = "WorldMapContributor";
            this.Load += new System.EventHandler(this.WorldMapContributor_Load);
            this.ResizeEnd += new System.EventHandler(this.WorldMapContributor_ResizeEnd);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorldMapPanel;
        private System.Windows.Forms.Panel ContributionControlsPanel;
    }
}