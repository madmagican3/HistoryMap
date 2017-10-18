namespace HistoryMap
{
    partial class WorldMapUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorldMapUser));
            this.WorldMap = new System.Windows.Forms.PictureBox();
            this.MinButton = new System.Windows.Forms.Label();
            this.MaximiseButton = new System.Windows.Forms.Label();
            this.ListPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.WorldMap)).BeginInit();
            this.ListPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorldMap
            // 
            this.WorldMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WorldMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WorldMap.Image = global::HistoryMap.Properties.Resources.maps_world_map_02;
            this.WorldMap.Location = new System.Drawing.Point(0, 0);
            this.WorldMap.Margin = new System.Windows.Forms.Padding(0);
            this.WorldMap.Name = "WorldMap";
            this.WorldMap.Size = new System.Drawing.Size(1293, 691);
            this.WorldMap.TabIndex = 0;
            this.WorldMap.TabStop = false;
            // 
            // MinButton
            // 
            this.MinButton.AutoSize = true;
            this.MinButton.Image = global::HistoryMap.Properties.Resources.if_057_CircledArrowLeft_183186;
            this.MinButton.Location = new System.Drawing.Point(162, 331);
            this.MinButton.MaximumSize = new System.Drawing.Size(32, 32);
            this.MinButton.MinimumSize = new System.Drawing.Size(32, 32);
            this.MinButton.Name = "MinButton";
            this.MinButton.Size = new System.Drawing.Size(32, 32);
            this.MinButton.TabIndex = 2;
            // 
            // MaximiseButton
            // 
            this.MaximiseButton.AutoSize = true;
            this.MaximiseButton.Image = global::HistoryMap.Properties.Resources.if_058_CircledArrowRight_183187;
            this.MaximiseButton.Location = new System.Drawing.Point(-3, 201);
            this.MaximiseButton.MaximumSize = new System.Drawing.Size(32, 32);
            this.MaximiseButton.MinimumSize = new System.Drawing.Size(32, 32);
            this.MaximiseButton.Name = "MaximiseButton";
            this.MaximiseButton.Size = new System.Drawing.Size(32, 32);
            this.MaximiseButton.TabIndex = 3;
            // 
            // ListPanel
            // 
            this.ListPanel.Controls.Add(this.MaximiseButton);
            this.ListPanel.Controls.Add(this.MinButton);
            this.ListPanel.Enabled = false;
            this.ListPanel.Location = new System.Drawing.Point(0, 0);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(194, 691);
            this.ListPanel.TabIndex = 4;
            // 
            // WorldMapUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 691);
            this.Controls.Add(this.WorldMap);
            this.Controls.Add(this.ListPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorldMapUser";
            this.Text = "World History Map";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.WorldMap)).EndInit();
            this.ListPanel.ResumeLayout(false);
            this.ListPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox WorldMap;
        private System.Windows.Forms.Label MinButton;
        private System.Windows.Forms.Label MaximiseButton;
        internal System.Windows.Forms.Panel ListPanel;
    }
}

