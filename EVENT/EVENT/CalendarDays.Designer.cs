namespace EVENT
{
    partial class CalendarDays
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dispDay = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.eventLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dispDay
            // 
            this.dispDay.AutoSize = true;
            this.dispDay.Font = new System.Drawing.Font("AvenirNext LT Pro Regular", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dispDay.Location = new System.Drawing.Point(3, 6);
            this.dispDay.Name = "dispDay";
            this.dispDay.Size = new System.Drawing.Size(21, 13);
            this.dispDay.TabIndex = 0;
            this.dispDay.Text = "00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // eventLbl
            // 
            this.eventLbl.AutoSize = true;
            this.eventLbl.Location = new System.Drawing.Point(11, 33);
            this.eventLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.eventLbl.Name = "eventLbl";
            this.eventLbl.Size = new System.Drawing.Size(0, 13);
            this.eventLbl.TabIndex = 1;
            this.eventLbl.Click += new System.EventHandler(this.eventLbl_Click);
            // 
            // CalendarDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(184)))), ((int)(((byte)(142)))));
            this.Controls.Add(this.eventLbl);
            this.Controls.Add(this.dispDay);
            this.Name = "CalendarDays";
            this.Size = new System.Drawing.Size(116, 83);
            this.Load += new System.EventHandler(this.CalendarDays_Load);
            this.Click += new System.EventHandler(this.CalendarDays_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dispDay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label eventLbl;
    }
}
