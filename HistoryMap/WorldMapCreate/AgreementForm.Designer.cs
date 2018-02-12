namespace HistoryMap.WorldMapCreate
{
    partial class AgreementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgreementForm));
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.RefuseBtn = new System.Windows.Forms.Button();
            this.warningTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(499, 486);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(75, 23);
            this.AcceptBtn.TabIndex = 0;
            this.AcceptBtn.Text = "Accept";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptBtn_Click);
            // 
            // RefuseBtn
            // 
            this.RefuseBtn.Location = new System.Drawing.Point(315, 486);
            this.RefuseBtn.Name = "RefuseBtn";
            this.RefuseBtn.Size = new System.Drawing.Size(75, 23);
            this.RefuseBtn.TabIndex = 1;
            this.RefuseBtn.Text = "Refuse";
            this.RefuseBtn.UseVisualStyleBackColor = true;
            this.RefuseBtn.Click += new System.EventHandler(this.RefuseBtn_Click);
            // 
            // warningTxtBox
            // 
            this.warningTxtBox.Location = new System.Drawing.Point(0, 4);
            this.warningTxtBox.Multiline = true;
            this.warningTxtBox.Name = "warningTxtBox";
            this.warningTxtBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.warningTxtBox.Size = new System.Drawing.Size(935, 465);
            this.warningTxtBox.TabIndex = 2;
            this.warningTxtBox.Text = resources.GetString("warningTxtBox.Text");
            // 
            // AgreementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 531);
            this.Controls.Add(this.warningTxtBox);
            this.Controls.Add(this.RefuseBtn);
            this.Controls.Add(this.AcceptBtn);
            this.Name = "AgreementForm";
            this.Text = "AgreementForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.Button RefuseBtn;
        private System.Windows.Forms.TextBox warningTxtBox;
    }
}