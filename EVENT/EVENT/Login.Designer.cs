namespace EVENT
{
    partial class Login
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
            this.unameTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pwTbx = new System.Windows.Forms.TextBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.PictureBox();
            this.viewPw = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.exitPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.exitPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // unameTbx
            // 
            this.unameTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(193)))), ((int)(((byte)(151)))));
            this.unameTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unameTbx.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unameTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.unameTbx.Location = new System.Drawing.Point(423, 364);
            this.unameTbx.Name = "unameTbx";
            this.unameTbx.Size = new System.Drawing.Size(358, 21);
            this.unameTbx.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.label1.Location = new System.Drawing.Point(404, 332);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "USERNAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.label2.Location = new System.Drawing.Point(404, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "PASSWORD";
            // 
            // pwTbx
            // 
            this.pwTbx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(193)))), ((int)(((byte)(151)))));
            this.pwTbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pwTbx.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwTbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.pwTbx.Location = new System.Drawing.Point(423, 449);
            this.pwTbx.Name = "pwTbx";
            this.pwTbx.PasswordChar = '*';
            this.pwTbx.Size = new System.Drawing.Size(335, 21);
            this.pwTbx.TabIndex = 10;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.ForeColor = System.Drawing.Color.White;
            this.loginBtn.Location = new System.Drawing.Point(514, 518);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(195, 42);
            this.loginBtn.TabIndex = 12;
            this.loginBtn.Text = "LOGIN";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.exitBtn.Image = global::EVENT.Properties.Resources.CLOSE_ICONW;
            this.exitBtn.Location = new System.Drawing.Point(8, 9);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(15, 15);
            this.exitBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exitBtn.TabIndex = 14;
            this.exitBtn.TabStop = false;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // viewPw
            // 
            this.viewPw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(193)))), ((int)(((byte)(151)))));
            this.viewPw.Image = global::EVENT.Properties.Resources.VIEW_PW;
            this.viewPw.Location = new System.Drawing.Point(765, 451);
            this.viewPw.Name = "viewPw";
            this.viewPw.Size = new System.Drawing.Size(25, 17);
            this.viewPw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.viewPw.TabIndex = 13;
            this.viewPw.TabStop = false;
            this.viewPw.Click += new System.EventHandler(this.viewPw_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::EVENT.Properties.Resources.TBOX_BG;
            this.pictureBox3.Location = new System.Drawing.Point(407, 438);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(391, 43);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EVENT.Properties.Resources.LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(514, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(185, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::EVENT.Properties.Resources.TBOX_BG;
            this.pictureBox2.Location = new System.Drawing.Point(407, 353);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(391, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // exitPanel
            // 
            this.exitPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(84)))), ((int)(((byte)(100)))));
            this.exitPanel.Controls.Add(this.exitBtn);
            this.exitPanel.Location = new System.Drawing.Point(1162, 10);
            this.exitPanel.Name = "exitPanel";
            this.exitPanel.Size = new System.Drawing.Size(32, 33);
            this.exitPanel.TabIndex = 15;
            this.exitPanel.Click += new System.EventHandler(this.exitPanel_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1206, 726);
            this.ControlBox = false;
            this.Controls.Add(this.exitPanel);
            this.Controls.Add(this.viewPw);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.pwTbx);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unameTbx);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewPw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.exitPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox unameTbx;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pwTbx;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.PictureBox viewPw;
        private System.Windows.Forms.PictureBox exitBtn;
        private System.Windows.Forms.Panel exitPanel;
    }
}