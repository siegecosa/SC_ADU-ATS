namespace ATS
{
    partial class admin_leave
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
            this.btn_signout = new System.Windows.Forms.Label();
            this.btn_leavemanagement = new System.Windows.Forms.Label();
            this.btn_employeemanagement = new System.Windows.Forms.Label();
            this.btn_admindashboard = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_reject = new System.Windows.Forms.Button();
            this.btn_approve = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.datagridleaves = new System.Windows.Forms.DataGridView();
            this.checkbox1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cb_leavestatus = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridleaves)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_signout
            // 
            this.btn_signout.AutoSize = true;
            this.btn_signout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_signout.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_signout.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_signout.Location = new System.Drawing.Point(582, 17);
            this.btn_signout.Name = "btn_signout";
            this.btn_signout.Size = new System.Drawing.Size(83, 21);
            this.btn_signout.TabIndex = 9;
            this.btn_signout.Text = "SIGN OUT";
            this.btn_signout.Click += new System.EventHandler(this.btn_signout_Click);
            // 
            // btn_leavemanagement
            // 
            this.btn_leavemanagement.AutoSize = true;
            this.btn_leavemanagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_leavemanagement.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_leavemanagement.ForeColor = System.Drawing.Color.Coral;
            this.btn_leavemanagement.Location = new System.Drawing.Point(380, 17);
            this.btn_leavemanagement.Name = "btn_leavemanagement";
            this.btn_leavemanagement.Size = new System.Drawing.Size(170, 21);
            this.btn_leavemanagement.TabIndex = 8;
            this.btn_leavemanagement.Text = "LEAVE MANAGEMENT";
            this.btn_leavemanagement.Click += new System.EventHandler(this.btn_leavemanagement_Click);
            // 
            // btn_employeemanagement
            // 
            this.btn_employeemanagement.AutoSize = true;
            this.btn_employeemanagement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_employeemanagement.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employeemanagement.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_employeemanagement.Location = new System.Drawing.Point(147, 17);
            this.btn_employeemanagement.Name = "btn_employeemanagement";
            this.btn_employeemanagement.Size = new System.Drawing.Size(203, 21);
            this.btn_employeemanagement.TabIndex = 7;
            this.btn_employeemanagement.Text = "EMPLOYEE MANAGEMENT";
            this.btn_employeemanagement.Click += new System.EventHandler(this.btn_employeemanagement_Click);
            // 
            // btn_admindashboard
            // 
            this.btn_admindashboard.AutoSize = true;
            this.btn_admindashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_admindashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_admindashboard.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_admindashboard.Location = new System.Drawing.Point(15, 17);
            this.btn_admindashboard.Name = "btn_admindashboard";
            this.btn_admindashboard.Size = new System.Drawing.Size(107, 21);
            this.btn_admindashboard.TabIndex = 6;
            this.btn_admindashboard.Text = "DASHBOARD";
            this.btn_admindashboard.Click += new System.EventHandler(this.btn_admindashboard_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btn_reject);
            this.panel1.Controls.Add(this.btn_approve);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.datagridleaves);
            this.panel1.Controls.Add(this.cb_leavestatus);
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 528);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Filter:";
            // 
            // btn_reject
            // 
            this.btn_reject.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_reject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_reject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reject.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_reject.Location = new System.Drawing.Point(827, 484);
            this.btn_reject.Name = "btn_reject";
            this.btn_reject.Size = new System.Drawing.Size(130, 30);
            this.btn_reject.TabIndex = 8;
            this.btn_reject.Text = "Reject";
            this.btn_reject.UseVisualStyleBackColor = false;
            this.btn_reject.Click += new System.EventHandler(this.btn_reject_Click);
            // 
            // btn_approve
            // 
            this.btn_approve.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_approve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_approve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_approve.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_approve.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_approve.Location = new System.Drawing.Point(678, 484);
            this.btn_approve.Name = "btn_approve";
            this.btn_approve.Size = new System.Drawing.Size(130, 30);
            this.btn_approve.TabIndex = 7;
            this.btn_approve.Text = "Approve";
            this.btn_approve.UseVisualStyleBackColor = false;
            this.btn_approve.Click += new System.EventHandler(this.btn_approve_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Label1.Location = new System.Drawing.Point(15, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(146, 21);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Requested Leaves:";
            // 
            // datagridleaves
            // 
            this.datagridleaves.AllowUserToAddRows = false;
            this.datagridleaves.AllowUserToDeleteRows = false;
            this.datagridleaves.AllowUserToResizeColumns = false;
            this.datagridleaves.AllowUserToResizeRows = false;
            this.datagridleaves.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagridleaves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridleaves.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkbox1});
            this.datagridleaves.Cursor = System.Windows.Forms.Cursors.Hand;
            this.datagridleaves.Location = new System.Drawing.Point(19, 85);
            this.datagridleaves.Name = "datagridleaves";
            this.datagridleaves.RowHeadersWidth = 51;
            this.datagridleaves.Size = new System.Drawing.Size(938, 383);
            this.datagridleaves.TabIndex = 5;
            this.datagridleaves.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridleaves_CellContentClick);
            // 
            // checkbox1
            // 
            this.checkbox1.HeaderText = "";
            this.checkbox1.MinimumWidth = 6;
            this.checkbox1.Name = "checkbox1";
            this.checkbox1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.checkbox1.Width = 6;
            // 
            // cb_leavestatus
            // 
            this.cb_leavestatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_leavestatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_leavestatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_leavestatus.FormattingEnabled = true;
            this.cb_leavestatus.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Approved",
            "Rejected"});
            this.cb_leavestatus.Location = new System.Drawing.Point(69, 51);
            this.cb_leavestatus.Name = "cb_leavestatus";
            this.cb_leavestatus.Size = new System.Drawing.Size(126, 24);
            this.cb_leavestatus.TabIndex = 4;
            this.cb_leavestatus.SelectedIndexChanged += new System.EventHandler(this.cb_leavestatus_SelectedIndexChanged);
            // 
            // admin_leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.btn_signout);
            this.Controls.Add(this.btn_leavemanagement);
            this.Controls.Add(this.btn_employeemanagement);
            this.Controls.Add(this.btn_admindashboard);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(1000, 600);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "admin_leave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "admin_empmanagement";
            this.Load += new System.EventHandler(this.admin_empmanagement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridleaves)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btn_signout;
        private System.Windows.Forms.Label btn_leavemanagement;
        private System.Windows.Forms.Label btn_employeemanagement;
        private System.Windows.Forms.Label btn_admindashboard;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Button btn_reject;
        internal System.Windows.Forms.Button btn_approve;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DataGridView datagridleaves;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn checkbox1;
        internal System.Windows.Forms.ComboBox cb_leavestatus;
        internal System.Windows.Forms.Label label2;
    }
}