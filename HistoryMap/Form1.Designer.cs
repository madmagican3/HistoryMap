namespace HistoryMap
{
    partial class Form1
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
            this.WorldMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WorldMap)).BeginInit();
            this.SuspendLayout();
            // 
            // WorldMap
            // 
            this.WorldMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WorldMap.Image = global::HistoryMap.Properties.Resources.maps_world_map_02;
            this.WorldMap.Location = new System.Drawing.Point(-1, 0);
            this.WorldMap.Name = "WorldMap";
            this.WorldMap.Size = new System.Drawing.Size(1294, 689);
            this.WorldMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WorldMap.TabIndex = 0;
            this.WorldMap.TabStop = false;
            this.WorldMap.Paint += new System.Windows.Forms.PaintEventHandler(this.WorldMap_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 691);
            this.Controls.Add(this.WorldMap);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.WorldMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox WorldMap;
    }
}

