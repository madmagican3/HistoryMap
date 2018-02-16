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
            this.DeleteIndexBtn = new System.Windows.Forms.Button();
            this.IndexList = new System.Windows.Forms.ListBox();
            this.InterestingInfoBtn = new System.Windows.Forms.CheckBox();
            this.BorderDrawingBtn = new System.Windows.Forms.CheckBox();
            this.ColourDialog = new System.Windows.Forms.ColorDialog();
            this.ViewCompleteBtn = new System.Windows.Forms.Button();
            this.CompleteBtn = new System.Windows.Forms.Button();
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
            this.ControlsPanel.Controls.Add(this.CompleteBtn);
            this.ControlsPanel.Controls.Add(this.ViewCompleteBtn);
            this.ControlsPanel.Controls.Add(this.DeleteIndexBtn);
            this.ControlsPanel.Controls.Add(this.IndexList);
            this.ControlsPanel.Controls.Add(this.InterestingInfoBtn);
            this.ControlsPanel.Controls.Add(this.BorderDrawingBtn);
            this.ControlsPanel.Location = new System.Drawing.Point(946, 12);
            this.ControlsPanel.MaximumSize = new System.Drawing.Size(180, 0);
            this.ControlsPanel.Name = "ControlsPanel";
            this.ControlsPanel.Size = new System.Drawing.Size(180, 635);
            this.ControlsPanel.TabIndex = 1;
            // 
            // DeleteIndexBtn
            // 
            this.DeleteIndexBtn.Enabled = false;
            this.DeleteIndexBtn.Location = new System.Drawing.Point(50, 527);
            this.DeleteIndexBtn.Name = "DeleteIndexBtn";
            this.DeleteIndexBtn.Size = new System.Drawing.Size(75, 24);
            this.DeleteIndexBtn.TabIndex = 4;
            this.DeleteIndexBtn.Text = "Delete";
            this.DeleteIndexBtn.UseVisualStyleBackColor = true;
            this.DeleteIndexBtn.Visible = false;
            this.DeleteIndexBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // IndexList
            // 
            this.IndexList.FormattingEnabled = true;
            this.IndexList.Location = new System.Drawing.Point(17, 335);
            this.IndexList.Name = "IndexList";
            this.IndexList.Size = new System.Drawing.Size(140, 186);
            this.IndexList.TabIndex = 3;
            this.IndexList.Visible = false;
            this.IndexList.SelectedIndexChanged += new System.EventHandler(this.IndexList_SelectedIndexChanged);
            // 
            // InterestingInfoBtn
            // 
            this.InterestingInfoBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.InterestingInfoBtn.AutoSize = true;
            this.InterestingInfoBtn.Location = new System.Drawing.Point(38, 275);
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
            // ColourDialog
            // 
            this.ColourDialog.FullOpen = true;
            // 
            // ViewCompleteBtn
            // 
            this.ViewCompleteBtn.Location = new System.Drawing.Point(38, 557);
            this.ViewCompleteBtn.Name = "ViewCompleteBtn";
            this.ViewCompleteBtn.Size = new System.Drawing.Size(93, 23);
            this.ViewCompleteBtn.TabIndex = 5;
            this.ViewCompleteBtn.Text = "See completed";
            this.ViewCompleteBtn.UseVisualStyleBackColor = true;
            this.ViewCompleteBtn.Visible = false;
            this.ViewCompleteBtn.Click += new System.EventHandler(this.ViewCompleteBtn_Click);
            // 
            // CompleteBtn
            // 
            this.CompleteBtn.Enabled = false;
            this.CompleteBtn.Location = new System.Drawing.Point(52, 587);
            this.CompleteBtn.Name = "CompleteBtn";
            this.CompleteBtn.Size = new System.Drawing.Size(75, 23);
            this.CompleteBtn.TabIndex = 6;
            this.CompleteBtn.Text = "Save Border";
            this.CompleteBtn.UseVisualStyleBackColor = true;
            this.CompleteBtn.Visible = false;
            this.CompleteBtn.Click += new System.EventHandler(this.CompleteBtn_Click);
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 659);
            this.Controls.Add(this.ControlsPanel);
            this.Controls.Add(this.WorldMapPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateForm";
            this.Text = "Create Data";
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
        private System.Windows.Forms.ColorDialog ColourDialog;
        private System.Windows.Forms.Button DeleteIndexBtn;
        private System.Windows.Forms.ListBox IndexList;
        private System.Windows.Forms.Button CompleteBtn;
        private System.Windows.Forms.Button ViewCompleteBtn;
    }
}