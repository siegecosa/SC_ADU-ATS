namespace ATS
{
    partial class emp_leave
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
            this.lbl_fileleave = new System.Windows.Forms.Label();
            this.lbl_signout = new System.Windows.Forms.Label();
            this.lbl_dashboard = new System.Windows.Forms.Label();
            this.lbl_timeinout = new System.Windows.Forms.Label();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lbl_leaveavailcount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_leaveform = new System.Windows.Forms.Button();
            this.date_end = new System.Windows.Forms.DateTimePicker();
            this.date_start = new System.Windows.Forms.DateTimePicker();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.Button1 = new System.Windows.Forms.Button();
            this.rtb_leavedesc = new System.Windows.Forms.RichTextBox();
            this.cb_leavetype = new System.Windows.Forms.ComboBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.OPF = new System.Windows.Forms.OpenFileDialog();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_fileleave
            // 
            this.lbl_fileleave.AutoSize = true;
            this.lbl_fileleave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_fileleave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fileleave.ForeColor = System.Drawing.Color.Coral;
            this.lbl_fileleave.Location = new System.Drawing.Point(377, 14);
            this.lbl_fileleave.Name = "lbl_fileleave";
            this.lbl_fileleave.Size = new System.Drawing.Size(87, 21);
            this.lbl_fileleave.TabIndex = 25;
            this.lbl_fileleave.Text = "FILE LEAVE";
            this.lbl_fileleave.Click += new System.EventHandler(this.lbl_fileleave_Click);
            // 
            // lbl_signout
            // 
            this.lbl_signout.AutoSize = true;
            this.lbl_signout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_signout.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_signout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_signout.Location = new System.Drawing.Point(496, 14);
            this.lbl_signout.Name = "lbl_signout";
            this.lbl_signout.Size = new System.Drawing.Size(85, 21);
            this.lbl_signout.TabIndex = 26;
            this.lbl_signout.Text = "SIGN-OUT";
            this.lbl_signout.Click += new System.EventHandler(this.lbl_signout_Click);
            // 
            // lbl_dashboard
            // 
            this.lbl_dashboard.AutoSize = true;
            this.lbl_dashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_dashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dashboard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_dashboard.Location = new System.Drawing.Point(15, 14);
            this.lbl_dashboard.Name = "lbl_dashboard";
            this.lbl_dashboard.Size = new System.Drawing.Size(107, 21);
            this.lbl_dashboard.TabIndex = 23;
            this.lbl_dashboard.Text = "DASHBOARD";
            this.lbl_dashboard.Click += new System.EventHandler(this.lbl_dashboard_Click);
            // 
            // lbl_timeinout
            // 
            this.lbl_timeinout.AutoSize = true;
            this.lbl_timeinout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_timeinout.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeinout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_timeinout.Location = new System.Drawing.Point(140, 14);
            this.lbl_timeinout.Name = "lbl_timeinout";
            this.lbl_timeinout.Size = new System.Drawing.Size(223, 21);
            this.lbl_timeinout.TabIndex = 24;
            this.lbl_timeinout.Text = "TIME-IN TIME-OUT RECORDS";
            this.lbl_timeinout.Click += new System.EventHandler(this.lbl_timeinout_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Gray;
            this.Panel1.Controls.Add(this.lbl_leaveavailcount);
            this.Panel1.Controls.Add(this.label3);
            this.Panel1.Controls.Add(this.btn_leaveform);
            this.Panel1.Controls.Add(this.date_end);
            this.Panel1.Controls.Add(this.date_start);
            this.Panel1.Controls.Add(this.Label5);
            this.Panel1.Controls.Add(this.Label4);
            this.Panel1.Controls.Add(this.Label6);
            this.Panel1.Controls.Add(this.FileName);
            this.Panel1.Controls.Add(this.Button1);
            this.Panel1.Controls.Add(this.rtb_leavedesc);
            this.Panel1.Controls.Add(this.cb_leavetype);
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(12, 45);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(874, 543);
            this.Panel1.TabIndex = 22;
            // 
            // lbl_leaveavailcount
            // 
            this.lbl_leaveavailcount.AutoSize = true;
            this.lbl_leaveavailcount.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_leaveavailcount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_leaveavailcount.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_leaveavailcount.Location = new System.Drawing.Point(28, 49);
            this.lbl_leaveavailcount.Name = "lbl_leaveavailcount";
            this.lbl_leaveavailcount.Size = new System.Drawing.Size(185, 17);
            this.lbl_leaveavailcount.TabIndex = 44;
            this.lbl_leaveavailcount.Text = "Number of Leaves Available:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(28, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Leave Description:";
            // 
            // btn_leaveform
            // 
            this.btn_leaveform.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_leaveform.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_leaveform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_leaveform.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_leaveform.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_leaveform.Location = new System.Drawing.Point(694, 474);
            this.btn_leaveform.Name = "btn_leaveform";
            this.btn_leaveform.Size = new System.Drawing.Size(142, 37);
            this.btn_leaveform.TabIndex = 40;
            this.btn_leaveform.Text = "Submit";
            this.btn_leaveform.UseVisualStyleBackColor = false;
            this.btn_leaveform.Click += new System.EventHandler(this.btn_leaveform_Click);
            // 
            // date_end
            // 
            this.date_end.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_end.Cursor = System.Windows.Forms.Cursors.Hand;
            this.date_end.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_end.Location = new System.Drawing.Point(254, 488);
            this.date_end.Name = "date_end";
            this.date_end.Size = new System.Drawing.Size(200, 23);
            this.date_end.TabIndex = 39;
            // 
            // date_start
            // 
            this.date_start.CalendarFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.date_start.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_start.Location = new System.Drawing.Point(39, 488);
            this.date_start.Name = "date_start";
            this.date_start.Size = new System.Drawing.Size(200, 23);
            this.date_start.TabIndex = 38;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Label5.Location = new System.Drawing.Point(251, 468);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(66, 17);
            this.Label5.TabIndex = 42;
            this.Label5.Text = "End Date:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Label4.Location = new System.Drawing.Point(36, 468);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(72, 17);
            this.Label4.TabIndex = 41;
            this.Label4.Text = "Start Date:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Label6.Location = new System.Drawing.Point(499, 45);
            this.Label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(84, 17);
            this.Label6.TabIndex = 37;
            this.Label6.Text = "Attachment:";
            // 
            // FileName
            // 
            this.FileName.Enabled = false;
            this.FileName.Location = new System.Drawing.Point(588, 45);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(201, 20);
            this.FileName.TabIndex = 36;
            // 
            // Button1
            // 
            this.Button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Button1.Location = new System.Drawing.Point(795, 43);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(41, 23);
            this.Button1.TabIndex = 35;
            this.Button1.Text = "...";
            this.Button1.UseVisualStyleBackColor = false;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // rtb_leavedesc
            // 
            this.rtb_leavedesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rtb_leavedesc.Location = new System.Drawing.Point(31, 138);
            this.rtb_leavedesc.MaxLength = 500000;
            this.rtb_leavedesc.Name = "rtb_leavedesc";
            this.rtb_leavedesc.Size = new System.Drawing.Size(805, 304);
            this.rtb_leavedesc.TabIndex = 32;
            this.rtb_leavedesc.Text = "";
            // 
            // cb_leavetype
            // 
            this.cb_leavetype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_leavetype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_leavetype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cb_leavetype.FormattingEnabled = true;
            this.cb_leavetype.Items.AddRange(new object[] {
            "Vacation Leave",
            "Sick Leave",
            "Parental Leave",
            "Maternity Leave/Paternity Leave",
            "Bereavement Leave",
            "Personal Leave",
            "Public Holiday Leave",
            "Birthday Leave",
            "Emergency Leave"});
            this.cb_leavetype.Location = new System.Drawing.Point(127, 81);
            this.cb_leavetype.Name = "cb_leavetype";
            this.cb_leavetype.Size = new System.Drawing.Size(190, 21);
            this.cb_leavetype.TabIndex = 31;
            this.cb_leavetype.SelectedIndexChanged += new System.EventHandler(this.cb_leavetype_SelectedIndexChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Label2.Location = new System.Drawing.Point(28, 81);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(97, 17);
            this.Label2.TabIndex = 33;
            this.Label2.Text = "Type of Leave:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Label1.Location = new System.Drawing.Point(13, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(186, 21);
            this.Label1.TabIndex = 30;
            this.Label1.Text = "Request For Leave Form";
            // 
            // OPF
            // 
            this.OPF.FileName = "openFileDialog1";
            // 
            // emp_leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.lbl_fileleave);
            this.Controls.Add(this.lbl_signout);
            this.Controls.Add(this.lbl_dashboard);
            this.Controls.Add(this.lbl_timeinout);
            this.Controls.Add(this.Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(900, 600);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "emp_leave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "emp_leave";
            this.Load += new System.EventHandler(this.emp_leave_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lbl_fileleave;
        internal System.Windows.Forms.Label lbl_signout;
        internal System.Windows.Forms.Label lbl_dashboard;
        internal System.Windows.Forms.Label lbl_timeinout;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox FileName;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.RichTextBox rtb_leavedesc;
        internal System.Windows.Forms.ComboBox cb_leavetype;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btn_leaveform;
        internal System.Windows.Forms.DateTimePicker date_end;
        internal System.Windows.Forms.DateTimePicker date_start;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lbl_leaveavailcount;
        private System.Windows.Forms.OpenFileDialog OPF;
    }
}