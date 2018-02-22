namespace HistoryMap.AdminPanel
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.WorldMapPanel = new System.Windows.Forms.Panel();
            this.ItemsList = new System.Windows.Forms.ListBox();
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.RejectBtn = new System.Windows.Forms.Button();
            this.ChangePassBtn = new System.Windows.Forms.Button();
            this.ManageUsersBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WorldMapPanel
            // 
            this.WorldMapPanel.Location = new System.Drawing.Point(366, 0);
            this.WorldMapPanel.Name = "WorldMapPanel";
            this.WorldMapPanel.Size = new System.Drawing.Size(1005, 767);
            this.WorldMapPanel.TabIndex = 0;
            // 
            // ItemsList
            // 
            this.ItemsList.FormattingEnabled = true;
            this.ItemsList.Location = new System.Drawing.Point(0, 0);
            this.ItemsList.Name = "ItemsList";
            this.ItemsList.Size = new System.Drawing.Size(360, 563);
            this.ItemsList.TabIndex = 1;
            this.ItemsList.SelectedIndexChanged += new System.EventHandler(this.ItemsList_SelectedIndexChanged);
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(209, 654);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(75, 23);
            this.AcceptBtn.TabIndex = 2;
            this.AcceptBtn.Text = "Accept";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // RejectBtn
            // 
            this.RejectBtn.Location = new System.Drawing.Point(46, 654);
            this.RejectBtn.Name = "RejectBtn";
            this.RejectBtn.Size = new System.Drawing.Size(75, 23);
            this.RejectBtn.TabIndex = 3;
            this.RejectBtn.Text = "Reject";
            this.RejectBtn.UseVisualStyleBackColor = true;
            this.RejectBtn.Click += new System.EventHandler(this.RejectBtn_Click);
            // 
            // ChangePassBtn
            // 
            this.ChangePassBtn.Location = new System.Drawing.Point(104, 705);
            this.ChangePassBtn.Name = "ChangePassBtn";
            this.ChangePassBtn.Size = new System.Drawing.Size(109, 23);
            this.ChangePassBtn.TabIndex = 4;
            this.ChangePassBtn.Text = "Change password";
            this.ChangePassBtn.UseVisualStyleBackColor = true;
            this.ChangePassBtn.Click += new System.EventHandler(this.ChangePassBtn_Click);
            // 
            // ManageUsersBtn
            // 
            this.ManageUsersBtn.Location = new System.Drawing.Point(104, 734);
            this.ManageUsersBtn.Name = "ManageUsersBtn";
            this.ManageUsersBtn.Size = new System.Drawing.Size(109, 23);
            this.ManageUsersBtn.TabIndex = 5;
            this.ManageUsersBtn.Text = "Manage Users";
            this.ManageUsersBtn.UseVisualStyleBackColor = true;
            this.ManageUsersBtn.Visible = false;
            this.ManageUsersBtn.Click += new System.EventHandler(this.ManageUsersBtn_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 769);
            this.Controls.Add(this.ManageUsersBtn);
            this.Controls.Add(this.ChangePassBtn);
            this.Controls.Add(this.RejectBtn);
            this.Controls.Add(this.AcceptBtn);
            this.Controls.Add(this.ItemsList);
            this.Controls.Add(this.WorldMapPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminPanel";
            this.Text = "Admin Panel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.ResizeEnd += new System.EventHandler(this.AdminPanel_ResizeEnd);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel WorldMapPanel;
        private System.Windows.Forms.ListBox ItemsList;
        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.Button RejectBtn;
        private System.Windows.Forms.Button ChangePassBtn;
        private System.Windows.Forms.Button ManageUsersBtn;
    }
}