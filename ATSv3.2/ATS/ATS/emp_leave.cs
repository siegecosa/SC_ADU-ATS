using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATS
{
    public partial class emp_leave : Form
    {
        public emp_leave()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password=");

        private void lbl_dashboard_Click(object sender, EventArgs e)
        {
            emp_dashboard nextForm = new emp_dashboard();
            nextForm.Show();
            this.Hide();
        }

        private void lbl_timeinout_Click(object sender, EventArgs e)
        {
            emp_time nextForm = new emp_time();
            nextForm.Show();
            this.Hide();
        }

        private void lbl_fileleave_Click(object sender, EventArgs e)
        {
            //nothing
        }

        private void lbl_signout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide(); form_login nextForm = new form_login();
                nextForm.ShowDialog(); this.Close();
            }
        }

        private void emp_leave_Load(object sender, EventArgs e)
        {
            Button1.Enabled = false;
            FileName.Enabled = false;
        
    }
        private void cb_leavetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_leavetype.SelectedIndex == 1)
            {
                Button1.Enabled = true;
            }
            else
            {
                Button1.Enabled = false;
            }
        }
        private bool IsDateValid(string leaveType, DateTime leaveStart, DateTime leaveEnd)
        {
            if (leaveStart > leaveEnd)
            {
                MessageBox.Show("Start Date cannot be after the End Date");
                return false;
            }

            switch (leaveType)
            {
                case "Vacation Leave":
                    if (leaveStart.Year != leaveEnd.Year)
                    {
                        MessageBox.Show("The year must be the same.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;

                case "Parental Leave":
                    if (leaveStart <= DateTime.Today)
                    {
                        MessageBox.Show("Start date must start today and for the following days.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;

                case "Maternity Leave/Paternity Leave":
                    int minDuration = 1;
                    int maxDuration = 91;

                    int duration = leaveEnd.Subtract(leaveStart).Days + 1;

                    if (duration < minDuration || duration > maxDuration)
                    {
                        MessageBox.Show("The leave should only be 90 days at the maximum.", "Invalid Duration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;

                case "Bereavement Leave":
                    DateTime minStartDate = DateTime.Today.AddDays(-7);
                    DateTime maxStartDate = DateTime.Today.AddDays(7);
                    if (leaveStart < minStartDate || leaveEnd > maxStartDate)
                    {
                        MessageBox.Show("The leave should be maximum of 1 week", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;

                case "Personal Leave":
                    if (leaveStart.Date < DateTime.Today.AddDays(-1))
                    {
                        MessageBox.Show("The leave should be filed a day before the day of leave", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;

                case "Birthday Leave":
                    string employeeBirthdayF = emp_dashboard.Birthday;
                    string format = "yyyy-MM-dd";
                    DateTime employeeBirthday = DateTime.ParseExact(employeeBirthdayF, format, CultureInfo.InvariantCulture);
                    if (leaveStart != employeeBirthday && leaveEnd != employeeBirthday)
                    {
                        MessageBox.Show("The leave should be on the day of birthday", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;

                case "Emergency Leave":
                    if (leaveStart.Date != leaveEnd.Date)
                    {
                        MessageBox.Show("The leave should be filed today", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;

                case "Sick Leave":
                    if (leaveStart.Date != leaveEnd.Date)
                    {
                        MessageBox.Show("Sick leaves can only be filed on the same day", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (FileName.Text == "")
                    {
                        MessageBox.Show("Please Provide Medical Certificate", "Missing attachment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    break;

                default:
                    return false;
            }

            return true;
        }

        private void btn_leaveform_Click(object sender, EventArgs e)
        {
            if (cb_leavetype.Text == "")
            {
                MessageBox.Show("Leave type is empty. Please fill in all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (rtb_leavedesc.Text == "")
            {
                MessageBox.Show("Leave description field is empty. Please fill in all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                byte[] docByte = new byte[] { };
                string fileNames;
                int empid = form_login.empid;
                FileStream fs;

                string leaveType = cb_leavetype.SelectedItem.ToString();
                string leaveDesc = rtb_leavedesc.Text.ToString();
                DateTime leaveStart = date_start.Value.Date;
                DateTime leaveStartFormatted = new DateTime(leaveStart.Year, leaveStart.Month, leaveStart.Day);
                DateTime leaveEnd = date_end.Value.Date;
                DateTime leaveEndFormatted = new DateTime(leaveEnd.Year, leaveEnd.Month, leaveEnd.Day);

                if (!IsDateValid(leaveType, leaveStartFormatted, leaveEndFormatted))
                {
                    return;
                }

                if (cb_leavetype.SelectedItem == "Sick Leave")
                {
                    if (FileName.Text == "")
                    {
                        MessageBox.Show("Please provide medical Certificate for sick leaves.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    fs = new FileStream(OPF.FileName, FileMode.Open, FileAccess.Read);
                    fileNames = System.IO.Path.GetFileName(FileName.Text.ToString());
                    docByte = new byte[fs.Length];
                    fs.Read(docByte, 0, Convert.ToInt32(fs.Length));
                    fs.Close();

                    connection.Open();
                    string query = "INSERT INTO leaves (EMPLOYEE_ID, START_DATE, END_DATE, LEAVE_TYPE, LEAVE_DESC, LEAVE_STATUS, LEAVE_ATTACHMENT) VALUES (@val2, @val3, @val4, @val5, @val6, @val7, @val8)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@val2", empid);
                    cmd.Parameters.AddWithValue("@val3", leaveStartFormatted);
                    cmd.Parameters.AddWithValue("@val4", leaveEndFormatted);
                    cmd.Parameters.AddWithValue("@val5", leaveType);
                    cmd.Parameters.AddWithValue("@val6", leaveDesc);
                    cmd.Parameters.AddWithValue("@val7", "Pending");
                    cmd.Parameters.AddWithValue("@val8", fileNames);

                    if (FileName.Text != "")
                    {
                        System.IO.File.Copy(FileName.Text, Application.StartupPath + "\\PDF\\" + System.IO.Path.GetFileName(FileName.Text));
                    }

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Leave sent to administration. Awaiting review.", "Leave Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cb_leavetype.SelectedIndex = -1;
                    rtb_leavedesc.Text = "";
                    FileName.Text = "";
                    docByte = new byte[] { };
                }
                else
                {
                    connection.Open();
                    string query = "INSERT INTO leaves (EMPLOYEE_ID, START_DATE, END_DATE, LEAVE_TYPE, LEAVE_DESC, LEAVE_STATUS) VALUES (@val2, @val3, @val4, @val5, @val6, @val7)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@val2", empid);
                    cmd.Parameters.AddWithValue("@val3", leaveStartFormatted);
                    cmd.Parameters.AddWithValue("@val4", leaveEndFormatted);
                    cmd.Parameters.AddWithValue("@val5", leaveType);
                    cmd.Parameters.AddWithValue("@val6", leaveDesc);
                    cmd.Parameters.AddWithValue("@val7", "Pending");

                    cmd.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Leave sent to administration. Awaiting review.", "Leave Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cb_leavetype.SelectedIndex = -1;
                    rtb_leavedesc.Text = "";
                    docByte = new byte[] { };
                    Button1.Enabled = false;
                    FileName.Enabled = false;
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OPF.FileName = "";
            OPF.Title = "Browse File";
            OPF.Filter = "Files (*.pdf) | *.pdf";

            if (OPF.ShowDialog() == DialogResult.OK)
            {
                FileName.Text = OPF.FileName;
            }
        }

        
    }
}
