using System.Windows.Forms;

namespace HistoryMap.WorldMapUsers
{
    partial class DateSelectionModal
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
            this.Year = new System.Windows.Forms.TextBox();
            this.TimeFrame = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // Year
            // 
            this.Year.Location = new System.Drawing.Point(206, 13);
            this.Year.Name = "Year";
            this.Year.Size = new System.Drawing.Size(40, 20);
            this.Year.TabIndex = 2;
            this.Year.Text = "1996";
            this.Year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Year_KeyPress);
            // 
            // TimeFrame
            // 
            this.TimeFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeFrame.FormattingEnabled = true;
            this.TimeFrame.Items.AddRange(new object[] {
            "CE",
            "BCE"});
            this.TimeFrame.Location = new System.Drawing.Point(252, 12);
            this.TimeFrame.Name = "TimeFrame";
            this.TimeFrame.Size = new System.Drawing.Size(73, 21);
            this.TimeFrame.TabIndex = 3;
            this.TimeFrame.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TimeFrame_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "MMMM dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 13);
            this.dateTimePicker1.MaxDate = new System.DateTime(1753, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(186, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // DateSelectionModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 74);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TimeFrame);
            this.Controls.Add(this.Year);
            this.Name = "DateSelectionModal";
            this.Text = "Date Selection";
            this.Load += new System.EventHandler(this.DateSelectionModal_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DateSelectionModal_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Year;
        private System.Windows.Forms.ComboBox TimeFrame;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;

    }
}