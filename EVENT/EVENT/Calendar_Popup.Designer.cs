namespace EVENT
{
    partial class Calendar_Popup
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
            this.eventDate = new System.Windows.Forms.Label();
            this.eventTime = new System.Windows.Forms.Label();
            this.paxLbl = new System.Windows.Forms.Label();
            this.pplLbl = new System.Windows.Forms.Label();
            this.eventNameTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // eventDate
            // 
            this.eventDate.AutoSize = true;
            this.eventDate.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.eventDate.Location = new System.Drawing.Point(2, 6);
            this.eventDate.Name = "eventDate";
            this.eventDate.Size = new System.Drawing.Size(91, 19);
            this.eventDate.TabIndex = 18;
            this.eventDate.Text = "00/00/000";
            // 
            // eventTime
            // 
            this.eventTime.AutoSize = true;
            this.eventTime.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.eventTime.Location = new System.Drawing.Point(2, 35);
            this.eventTime.Name = "eventTime";
            this.eventTime.Size = new System.Drawing.Size(112, 19);
            this.eventTime.TabIndex = 19;
            this.eventTime.Text = "00:00 - 00:00";
            // 
            // paxLbl
            // 
            this.paxLbl.AutoSize = true;
            this.paxLbl.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paxLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.paxLbl.Location = new System.Drawing.Point(2, 64);
            this.paxLbl.Name = "paxLbl";
            this.paxLbl.Size = new System.Drawing.Size(49, 19);
            this.paxLbl.TabIndex = 20;
            this.paxLbl.Text = "0000";
            // 
            // pplLbl
            // 
            this.pplLbl.AutoSize = true;
            this.pplLbl.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pplLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.pplLbl.Location = new System.Drawing.Point(54, 64);
            this.pplLbl.Name = "pplLbl";
            this.pplLbl.Size = new System.Drawing.Size(61, 19);
            this.pplLbl.TabIndex = 21;
            this.pplLbl.Text = "people";
            // 
            // eventNameTxt
            // 
            this.eventNameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.eventNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eventNameTxt.Font = new System.Drawing.Font("AvenirNext LT Pro Bold", 15.75F, System.Drawing.FontStyle.Bold);
            this.eventNameTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.eventNameTxt.Location = new System.Drawing.Point(13, 10);
            this.eventNameTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.eventNameTxt.Multiline = true;
            this.eventNameTxt.Name = "eventNameTxt";
            this.eventNameTxt.ReadOnly = true;
            this.eventNameTxt.Size = new System.Drawing.Size(308, 61);
            this.eventNameTxt.TabIndex = 22;
            this.eventNameTxt.Text = "Gaby and Dodong Birthday Celebration";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.eventTime);
            this.panel1.Controls.Add(this.eventDate);
            this.panel1.Controls.Add(this.pplLbl);
            this.panel1.Controls.Add(this.paxLbl);
            this.panel1.Location = new System.Drawing.Point(6, 67);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 92);
            this.panel1.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 102);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 24;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // Calendar_Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(345, 171);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.eventNameTxt);
            this.Name = "Calendar_Popup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calendar_Popup";
            this.Load += new System.EventHandler(this.Calendar_Popup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label eventDate;
        private System.Windows.Forms.Label eventTime;
        private System.Windows.Forms.Label paxLbl;
        private System.Windows.Forms.Label pplLbl;
        private System.Windows.Forms.TextBox eventNameTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
    }
}