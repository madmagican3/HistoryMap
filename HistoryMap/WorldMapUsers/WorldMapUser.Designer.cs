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
            this.SearchIcoLabel = new System.Windows.Forms.Label();
            this.SearchTxtBox = new System.Windows.Forms.TextBox();
            this.InterestingItemsList = new System.Windows.Forms.ListBox();
            this.SettingsIcon = new System.Windows.Forms.Label();
            this.ZoomOutLabel = new System.Windows.Forms.Label();
            this.ZoomInLabel = new System.Windows.Forms.Label();
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
            this.MinButton.Location = new System.Drawing.Point(162, 349);
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
            this.MaximiseButton.Location = new System.Drawing.Point(0, 0);
            this.MaximiseButton.MaximumSize = new System.Drawing.Size(32, 32);
            this.MaximiseButton.MinimumSize = new System.Drawing.Size(32, 32);
            this.MaximiseButton.Name = "MaximiseButton";
            this.MaximiseButton.Size = new System.Drawing.Size(32, 32);
            this.MaximiseButton.TabIndex = 3;
            // 
            // ListPanel
            // 
            this.ListPanel.Controls.Add(this.SearchIcoLabel);
            this.ListPanel.Controls.Add(this.SearchTxtBox);
            this.ListPanel.Controls.Add(this.InterestingItemsList);
            this.ListPanel.Controls.Add(this.MinButton);
            this.ListPanel.Enabled = false;
            this.ListPanel.Location = new System.Drawing.Point(0, 0);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(194, 691);
            this.ListPanel.TabIndex = 4;
            // 
            // SearchIcoLabel
            // 
            this.SearchIcoLabel.AutoSize = true;
            this.SearchIcoLabel.Image = global::HistoryMap.Properties.Resources.if_icon_ios7_search_211818;
            this.SearchIcoLabel.Location = new System.Drawing.Point(124, 1);
            this.SearchIcoLabel.MaximumSize = new System.Drawing.Size(32, 32);
            this.SearchIcoLabel.MinimumSize = new System.Drawing.Size(32, 32);
            this.SearchIcoLabel.Name = "SearchIcoLabel";
            this.SearchIcoLabel.Size = new System.Drawing.Size(32, 32);
            this.SearchIcoLabel.TabIndex = 5;
            // 
            // SearchTxtBox
            // 
            this.SearchTxtBox.Location = new System.Drawing.Point(3, 13);
            this.SearchTxtBox.Name = "SearchTxtBox";
            this.SearchTxtBox.Size = new System.Drawing.Size(114, 20);
            this.SearchTxtBox.TabIndex = 4;
            // 
            // InterestingItemsList
            // 
            this.InterestingItemsList.FormattingEnabled = true;
            this.InterestingItemsList.Location = new System.Drawing.Point(0, 36);
            this.InterestingItemsList.Name = "InterestingItemsList";
            this.InterestingItemsList.Size = new System.Drawing.Size(156, 654);
            this.InterestingItemsList.TabIndex = 3;
            // 
            // SettingsIcon
            // 
            this.SettingsIcon.AutoSize = true;
            this.SettingsIcon.Image = global::HistoryMap.Properties.Resources.if_settings_alt_2628490;
            this.SettingsIcon.Location = new System.Drawing.Point(1258, 1);
            this.SettingsIcon.MaximumSize = new System.Drawing.Size(32, 32);
            this.SettingsIcon.MinimumSize = new System.Drawing.Size(32, 32);
            this.SettingsIcon.Name = "SettingsIcon";
            this.SettingsIcon.Size = new System.Drawing.Size(32, 32);
            this.SettingsIcon.TabIndex = 5;
            // 
            // ZoomOutLabel
            // 
            this.ZoomOutLabel.AutoSize = true;
            this.ZoomOutLabel.Image = global::HistoryMap.Properties.Resources.if_13_Zoom_out_106233;
            this.ZoomOutLabel.Location = new System.Drawing.Point(1217, 0);
            this.ZoomOutLabel.MaximumSize = new System.Drawing.Size(32, 32);
            this.ZoomOutLabel.MinimumSize = new System.Drawing.Size(32, 32);
            this.ZoomOutLabel.Name = "ZoomOutLabel";
            this.ZoomOutLabel.Size = new System.Drawing.Size(32, 32);
            this.ZoomOutLabel.TabIndex = 6;
            // 
            // ZoomInLabel
            // 
            this.ZoomInLabel.AutoSize = true;
            this.ZoomInLabel.Image = global::HistoryMap.Properties.Resources.if_12_Zoom_in_106237;
            this.ZoomInLabel.Location = new System.Drawing.Point(1176, 1);
            this.ZoomInLabel.MaximumSize = new System.Drawing.Size(32, 32);
            this.ZoomInLabel.MinimumSize = new System.Drawing.Size(32, 32);
            this.ZoomInLabel.Name = "ZoomInLabel";
            this.ZoomInLabel.Size = new System.Drawing.Size(32, 32);
            this.ZoomInLabel.TabIndex = 7;
            // 
            // WorldMapUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 691);
            this.Controls.Add(this.ZoomInLabel);
            this.Controls.Add(this.ZoomOutLabel);
            this.Controls.Add(this.SettingsIcon);
            this.Controls.Add(this.MaximiseButton);
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
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox WorldMap;
        internal System.Windows.Forms.Label MinButton;
        internal System.Windows.Forms.Label MaximiseButton;
        internal System.Windows.Forms.Panel ListPanel;
        internal System.Windows.Forms.Label SearchIcoLabel;
        internal System.Windows.Forms.TextBox SearchTxtBox;
        internal System.Windows.Forms.ListBox InterestingItemsList;
        private System.Windows.Forms.Label SettingsIcon;
        private System.Windows.Forms.Label ZoomOutLabel;
        private System.Windows.Forms.Label ZoomInLabel;
    }
}

