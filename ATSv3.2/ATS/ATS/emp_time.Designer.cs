namespace ATS
{
    partial class emp_time
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
            this.datagridtime = new System.Windows.Forms.DataGridView();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridtime)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_fileleave
            // 
            this.lbl_fileleave.AutoSize = true;
            this.lbl_fileleave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_fileleave.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fileleave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_fileleave.Location = new System.Drawing.Point(377, 14);
            this.lbl_fileleave.Name = "lbl_fileleave";
            this.lbl_fileleave.Size = new System.Drawing.Size(87, 21);
            this.lbl_fileleave.TabIndex = 20;
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
            this.lbl_signout.TabIndex = 21;
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
            this.lbl_dashboard.TabIndex = 18;
            this.lbl_dashboard.Text = "DASHBOARD";
            this.lbl_dashboard.Click += new System.EventHandler(this.lbl_dashboard_Click);
            // 
            // lbl_timeinout
            // 
            this.lbl_timeinout.AutoSize = true;
            this.lbl_timeinout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_timeinout.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timeinout.ForeColor = System.Drawing.Color.Coral;
            this.lbl_timeinout.Location = new System.Drawing.Point(140, 14);
            this.lbl_timeinout.Name = "lbl_timeinout";
            this.lbl_timeinout.Size = new System.Drawing.Size(223, 21);
            this.lbl_timeinout.TabIndex = 19;
            this.lbl_timeinout.Text = "TIME-IN TIME-OUT RECORDS";
            this.lbl_timeinout.Click += new System.EventHandler(this.lbl_timeinout_Click);
            // 
            // Panel1
            // 
            this.Panel1.BackColor = System.Drawing.Color.Gray;
            this.Panel1.Controls.Add(this.datagridtime);
            this.Panel1.Location = new System.Drawing.Point(15, 55);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(873, 533);
            this.Panel1.TabIndex = 17;
            // 
            // datagridtime
            // 
            this.datagridtime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridtime.Location = new System.Drawing.Point(17, 14);
            this.datagridtime.Name = "datagridtime";
            this.datagridtime.ReadOnly = true;
            this.datagridtime.RowHeadersWidth = 62;
            this.datagridtime.Size = new System.Drawing.Size(838, 503);
            this.datagridtime.TabIndex = 1;
            // 
            // emp_time
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
            this.Name = "emp_time";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "emp_time";
            this.Load += new System.EventHandler(this.emp_time_Load);
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridtime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lbl_fileleave;
        internal System.Windows.Forms.Label lbl_signout;
        internal System.Windows.Forms.Label lbl_dashboard;
        internal System.Windows.Forms.Label lbl_timeinout;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.DataGridView datagridtime;
    }
}