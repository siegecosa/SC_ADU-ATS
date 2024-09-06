namespace ATS
{
    partial class emp_changepass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(emp_changepass));
            this.oldPasswordTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_show3 = new System.Windows.Forms.Button();
            this.btn_show2 = new System.Windows.Forms.Button();
            this.btn_show1 = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // oldPasswordTextBox
            // 
            this.oldPasswordTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldPasswordTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.oldPasswordTextBox.Location = new System.Drawing.Point(48, 241);
            this.oldPasswordTextBox.MaxLength = 50;
            this.oldPasswordTextBox.Name = "oldPasswordTextBox";
            this.oldPasswordTextBox.Size = new System.Drawing.Size(335, 29);
            this.oldPasswordTextBox.TabIndex = 0;
            this.oldPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.newPasswordTextBox.Location = new System.Drawing.Point(48, 311);
            this.newPasswordTextBox.MaxLength = 50;
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(335, 29);
            this.newPasswordTextBox.TabIndex = 2;
            this.toolTip2.SetToolTip(this.newPasswordTextBox, "In order to protect your account, make sure your password:\r\n- is longer than 8 ch" +
        "aracters\r\n- contains at least one uppercase, one lowercase, one numeric, and one" +
        " special character");
            this.newPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordTextBox.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(48, 386);
            this.confirmPasswordTextBox.MaxLength = 50;
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(335, 29);
            this.confirmPasswordTextBox.TabIndex = 4;
            this.toolTip3.SetToolTip(this.confirmPasswordTextBox, "In order to protect your account, make sure your password:\r\n- is longer than 8 ch" +
        "aracters\r\n- contains at least one uppercase, one lowercase, one numeric, and one" +
        " special character");
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(44, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Old Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(44, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "New Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(44, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirm New Password:";
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.Coral;
            this.btn_submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_submit.Location = new System.Drawing.Point(266, 460);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(167, 32);
            this.btn_submit.TabIndex = 6;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.DimGray;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_cancel.Location = new System.Drawing.Point(48, 460);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(167, 32);
            this.btn_cancel.TabIndex = 14;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_show3
            // 
            this.btn_show3.BackColor = System.Drawing.Color.DimGray;
            this.btn_show3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_show3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_show3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_show3.Location = new System.Drawing.Point(379, 386);
            this.btn_show3.Name = "btn_show3";
            this.btn_show3.Size = new System.Drawing.Size(54, 29);
            this.btn_show3.TabIndex = 5;
            this.btn_show3.Text = "Show";
            this.btn_show3.UseVisualStyleBackColor = false;
            this.btn_show3.Click += new System.EventHandler(this.btn_show3_Click);
            // 
            // btn_show2
            // 
            this.btn_show2.BackColor = System.Drawing.Color.DimGray;
            this.btn_show2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_show2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_show2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_show2.Location = new System.Drawing.Point(379, 312);
            this.btn_show2.Name = "btn_show2";
            this.btn_show2.Size = new System.Drawing.Size(54, 29);
            this.btn_show2.TabIndex = 3;
            this.btn_show2.Text = "Show";
            this.btn_show2.UseVisualStyleBackColor = false;
            this.btn_show2.Click += new System.EventHandler(this.btn_show2_Click);
            // 
            // btn_show1
            // 
            this.btn_show1.BackColor = System.Drawing.Color.DimGray;
            this.btn_show1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_show1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_show1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_show1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_show1.Location = new System.Drawing.Point(379, 241);
            this.btn_show1.Name = "btn_show1";
            this.btn_show1.Size = new System.Drawing.Size(54, 29);
            this.btn_show1.TabIndex = 1;
            this.btn_show1.Text = "Show";
            this.btn_show1.UseVisualStyleBackColor = false;
            this.btn_show1.Click += new System.EventHandler(this.btn_show1_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_title.Location = new System.Drawing.Point(99, 158);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(274, 41);
            this.lbl_title.TabIndex = 13;
            this.lbl_title.Text = "Change Password";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // toolTip2
            // 
            this.toolTip2.AutomaticDelay = 100;
            this.toolTip2.AutoPopDelay = 5000;
            this.toolTip2.InitialDelay = 100;
            this.toolTip2.ReshowDelay = 20;
            this.toolTip2.ShowAlways = true;
            this.toolTip2.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip2.ToolTipTitle = "Password Check";
            // 
            // toolTip3
            // 
            this.toolTip3.AutomaticDelay = 100;
            this.toolTip3.AutoPopDelay = 5000;
            this.toolTip3.InitialDelay = 100;
            this.toolTip3.ReshowDelay = 20;
            this.toolTip3.ShowAlways = true;
            this.toolTip3.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip3.ToolTipTitle = "Password Check";
            // 
            // emp_changepass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(483, 538);
            this.Controls.Add(this.btn_show1);
            this.Controls.Add(this.btn_show2);
            this.Controls.Add(this.btn_show3);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.newPasswordTextBox);
            this.Controls.Add(this.oldPasswordTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "emp_changepass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.emp_changepass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox oldPasswordTextBox;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_show3;
        private System.Windows.Forms.Button btn_show2;
        private System.Windows.Forms.Button btn_show1;
        internal System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
    }
}