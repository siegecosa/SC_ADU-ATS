namespace ATS_WEBCAM_v._1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Time_in = new System.Windows.Forms.PictureBox();
            this.Time_out = new System.Windows.Forms.PictureBox();
            this.Details = new System.Windows.Forms.Panel();
            this.time = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.employee_name = new System.Windows.Forms.Label();
            this.employee_ID = new System.Windows.Forms.Label();
            this.employee_picture = new System.Windows.Forms.PictureBox();
            this.timein = new System.Windows.Forms.Button();
            this.timeout = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Time_in)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Time_out)).BeginInit();
            this.Details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employee_picture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(269, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // Time_in
            // 
            this.Time_in.Location = new System.Drawing.Point(18, 38);
            this.Time_in.Name = "Time_in";
            this.Time_in.Size = new System.Drawing.Size(283, 337);
            this.Time_in.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Time_in.TabIndex = 2;
            this.Time_in.TabStop = false;
            // 
            // Time_out
            // 
            this.Time_out.Location = new System.Drawing.Point(307, 38);
            this.Time_out.Name = "Time_out";
            this.Time_out.Size = new System.Drawing.Size(283, 337);
            this.Time_out.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Time_out.TabIndex = 3;
            this.Time_out.TabStop = false;
            // 
            // Details
            // 
            this.Details.Controls.Add(this.time);
            this.Details.Controls.Add(this.lbl_time);
            this.Details.Controls.Add(this.employee_name);
            this.Details.Controls.Add(this.employee_ID);
            this.Details.Controls.Add(this.employee_picture);
            this.Details.Location = new System.Drawing.Point(619, 38);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(253, 337);
            this.Details.TabIndex = 4;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Location = new System.Drawing.Point(98, 302);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(26, 13);
            this.time.TabIndex = 4;
            this.time.Text = "time";
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.Location = new System.Drawing.Point(98, 278);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(49, 15);
            this.lbl_time.TabIndex = 3;
            this.lbl_time.Text = "lbl_time";
            // 
            // employee_name
            // 
            this.employee_name.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_name.Location = new System.Drawing.Point(21, 198);
            this.employee_name.Name = "employee_name";
            this.employee_name.Size = new System.Drawing.Size(214, 51);
            this.employee_name.TabIndex = 2;
            this.employee_name.Text = "Name";
            this.employee_name.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // employee_ID
            // 
            this.employee_ID.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employee_ID.Location = new System.Drawing.Point(21, 168);
            this.employee_ID.Name = "employee_ID";
            this.employee_ID.Size = new System.Drawing.Size(214, 30);
            this.employee_ID.TabIndex = 1;
            this.employee_ID.Text = "ID";
            this.employee_ID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // employee_picture
            // 
            this.employee_picture.Location = new System.Drawing.Point(21, 14);
            this.employee_picture.Name = "employee_picture";
            this.employee_picture.Size = new System.Drawing.Size(214, 141);
            this.employee_picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.employee_picture.TabIndex = 0;
            this.employee_picture.TabStop = false;
            // 
            // timein
            // 
            this.timein.Location = new System.Drawing.Point(118, 381);
            this.timein.Name = "timein";
            this.timein.Size = new System.Drawing.Size(75, 23);
            this.timein.TabIndex = 5;
            this.timein.Text = "Time In";
            this.timein.UseVisualStyleBackColor = true;
            this.timein.Click += new System.EventHandler(this.timein_Click);
            // 
            // timeout
            // 
            this.timeout.Location = new System.Drawing.Point(406, 381);
            this.timeout.Name = "timeout";
            this.timeout.Size = new System.Drawing.Size(75, 23);
            this.timeout.TabIndex = 6;
            this.timeout.Text = "Time Out";
            this.timeout.UseVisualStyleBackColor = true;
            this.timeout.Click += new System.EventHandler(this.timeout_Click);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Red;
            this.exit.Location = new System.Drawing.Point(842, 5);
            this.exit.Name = "exit";
            this.exit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.exit.Size = new System.Drawing.Size(30, 23);
            this.exit.TabIndex = 7;
            this.exit.Text = "X";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(884, 490);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.timeout);
            this.Controls.Add(this.timein);
            this.Controls.Add(this.Details);
            this.Controls.Add(this.Time_out);
            this.Controls.Add(this.Time_in);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Time_in)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Time_out)).EndInit();
            this.Details.ResumeLayout(false);
            this.Details.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employee_picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.PictureBox Time_in;
        private System.Windows.Forms.PictureBox Time_out;
        private System.Windows.Forms.Panel Details;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label employee_name;
        private System.Windows.Forms.Label employee_ID;
        private System.Windows.Forms.PictureBox employee_picture;
        private System.Windows.Forms.Button timein;
        private System.Windows.Forms.Button timeout;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

