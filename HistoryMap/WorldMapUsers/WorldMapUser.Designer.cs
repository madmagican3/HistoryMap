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
            ((System.ComponentModel.ISupportInitialize)(this.WorldMap)).BeginInit();
            this.SuspendLayout();
            // 
            // WorldMap
            // 
            this.WorldMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorldMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WorldMap.Image = global::HistoryMap.Properties.Resources.maps_world_map_02;
            this.WorldMap.Location = new System.Drawing.Point(3, 3);
            this.WorldMap.Name = "WorldMap";
            this.WorldMap.Size = new System.Drawing.Size(1294, 689);
            this.WorldMap.TabIndex = 0;
            this.WorldMap.TabStop = false;
            this.WorldMap.SizeChanged += new System.EventHandler(this.WorldMap_SizeChanged);
            this.WorldMap.Paint += new System.Windows.Forms.PaintEventHandler(this.WorldMap_Paint);
            // 
            // WorldMapUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 691);
            this.Controls.Add(this.WorldMap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WorldMapUser";
            this.Text = "World History Map";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.WorldMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox WorldMap;
    }
}

