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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateForm));
            this.WorldMapPanel = new System.Windows.Forms.Panel();
            this.ControlsPanel = new System.Windows.Forms.Panel();
            this.InterestingInfoBtn = new System.Windows.Forms.CheckBox();
            this.BorderDrawingBtn = new System.Windows.Forms.CheckBox();
            this.ControlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // WorldMapPanel
            // 
            this.WorldMapPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.WorldMapPanel.Location = new System.Drawing.Point(1, 1);
            this.WorldMapPanel.Name = "WorldMapPanel";
            this.WorldMapPanel.Size = new System.Drawing.Size(833, 573);
            this.WorldMapPanel.TabIndex = 0;
            // 
            // ControlsPanel
            // 
            this.ControlsPanel.Controls.Add(this.InterestingInfoBtn);
            this.ControlsPanel.Controls.Add(this.BorderDrawingBtn);
            this.ControlsPanel.Location = new System.Drawing.Point(946, 12);
            this.ControlsPanel.MaximumSize = new System.Drawing.Size(180, 0);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(180, 0);
            this.ControlsPanel.TabIndex = 1;
            // 
            // InterestingInfoBtn
            // 
            this.InterestingInfoBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.InterestingInfoBtn.AutoSize = true;
            this.InterestingInfoBtn.Location = new System.Drawing.Point(35, 206);
            this.InterestingInfoBtn.Name = "InterestingInfoBtn";
            this.InterestingInfoBtn.Size = new System.Drawing.Size(87, 23);
            this.InterestingInfoBtn.TabIndex = 2;
            this.InterestingInfoBtn.Text = "Interesting Info";
            this.InterestingInfoBtn.UseVisualStyleBackColor = true;
            this.InterestingInfoBtn.CheckedChanged += new System.EventHandler(this.InterestingInfoBtn_CheckedChanged);
            // 
            // BorderDrawingBtn
            // 
            this.BorderDrawingBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.BorderDrawingBtn.AutoSize = true;
            this.BorderDrawingBtn.Location = new System.Drawing.Point(52, 95);
            this.BorderDrawingBtn.Name = "BorderDrawingBtn";
            this.BorderDrawingBtn.Size = new System.Drawing.Size(53, 23);
            this.BorderDrawingBtn.TabIndex = 1;
            this.BorderDrawingBtn.Text = "Borders";
            this.BorderDrawingBtn.UseVisualStyleBackColor = true;
            this.BorderDrawingBtn.CheckedChanged += new System.EventHandler(this.BorderDrawingBtn_CheckedChanged);
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 603);
            this.Controls.Add(this.ControlsPanel);
            this.Controls.Add(this.WorldMapPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateForm";
            this.Text = "CreateForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateForm_FormClosing);
            this.Load += new System.EventHandler(this.CreateForm_Load);
            this.ResizeEnd += new System.EventHandler(this.CreateForm_ResizeEnd);
            this.ControlsPanel.ResumeLayout(false);
            this.ControlsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorldMapPanel;
        private System.Windows.Forms.Panel ControlsPanel;
        private System.Windows.Forms.CheckBox BorderDrawingBtn;
        private System.Windows.Forms.CheckBox InterestingInfoBtn;
    }
}