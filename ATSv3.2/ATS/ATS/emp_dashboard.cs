using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media;

namespace ATS
{
    public partial class emp_dashboard : Form
    {
        public emp_dashboard()
        {
            InitializeComponent();
        }
        public static string Birthday;
        private void lbl_dashboard_Click(object sender, EventArgs e)
        {
            //do nothing
        }

        private void lbl_timeinout_Click(object sender, EventArgs e)
        {
            emp_time nextForm = new emp_time();
            nextForm.Show();
            this.Hide();
        }

        private void lbl_fileleave_Click(object sender, EventArgs e)
        {
            emp_leave nextForm = new emp_leave();
            nextForm.Show();
            this.Hide();
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

        private void emp_dashboard_Load(object sender, EventArgs e)
        {
            LoadEmployeeInformation();
            comboBox1.SelectedIndex = 0;


        }


        private void LoadEmployeeInformation()
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password="))
            {
                string query = "SELECT EMPLOYEE_ID, EMPLOYEE_FN, EMPLOYEE_MN, EMPLOYEE_LN, DEPARTMENT, SEX, BIRTHDATE, AGE, ADDRESS, PHONE, STATUS, EMPLOYMENT_TYPE, EMPLOYEE_EMAIL, HIRE_DATE, JOB_TITLE, EMPLOYEE_IMAGE FROM Employees WHERE EMPLOYEE_ID = @empid";


                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@empid", form_login.empid);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbl_employeeid.Text = reader["EMPLOYEE_ID"].ToString();
                            lbl_name.Text = $"{reader["EMPLOYEE_FN"]} {reader["EMPLOYEE_MN"]} {reader["EMPLOYEE_LN"]}";
                            lbl_department.Text = reader["DEPARTMENT"].ToString();
                            lbl_sex.Text = reader["SEX"].ToString();
                            lbl_bday.Text = Convert.ToDateTime(reader["BIRTHDATE"]).ToShortDateString();
                            lbl_age.Text = reader["AGE"].ToString();
                            lbl_position.Text = reader["JOB_TITLE"].ToString();
                            lbl_address.Text = reader["ADDRESS"].ToString();
                            lbl_phone.Text = reader["PHONE"].ToString();
                            lbl_status.Text = reader["STATUS"].ToString();
                            lbl_emptype.Text = reader["EMPLOYMENT_TYPE"].ToString();
                            lbl_email.Text = reader["EMPLOYEE_EMAIL"].ToString();
                            lbl_hiredate.Text = Convert.ToDateTime(reader["HIRE_DATE"]).ToShortDateString();

                            // Load employee picture if available
                            if (!reader.IsDBNull(reader.GetOrdinal("EMPLOYEE_IMAGE")))
                            {
                                string base64Image = reader.GetString("EMPLOYEE_IMAGE");
                                byte[] imageBytes = Convert.FromBase64String(base64Image);
                                using (var stream = new MemoryStream(imageBytes))
                                {
                                    pb_emppicture.Image = Image.FromStream(stream);
                                }
                            }
                            else
                            {
                                // Set a default image if no employee picture is available
                                pb_emppicture.Image = Properties.Resources.DefaultImage;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        string monthName;
        int monthValue;
        private void loadChart()
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password="))
            {
                try
                {
                    monthValue = comboBox1.SelectedIndex + 1; // Adjust monthValue to start from 1 (January)
                    monthName = comboBox1.Text;
                    int selectedYear = DateTime.Now.Year; // Get the current year

                    emp_dashchart.Series.Clear();
                    emp_dashchart.ChartAreas.Clear();

                    string query = @"
                SELECT
                    COUNT(CASE WHEN ATTENDANCE_STATUS = 'Present' THEN 1 END) AS Present_Count,
                    COUNT(CASE WHEN ATTENDANCE_STATUS = 'Late' THEN 1 END) AS Late_Count,
                    COUNT(CASE WHEN WORK_HOURS_STATUS = 'Overtime' THEN 1 END) AS Overtime_Count,
                    COUNT(CASE WHEN WORK_HOURS_STATUS = 'Undertime' THEN 1 END) AS Undertime_Count
                FROM
                    Attendance
                WHERE
                    MONTH(ATTENDANCE_DATE) = @monthValue AND YEAR(ATTENDANCE_DATE) = @selectedYear AND EMPLOYEE_ID = @empid";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@monthValue", monthValue);
                    command.Parameters.AddWithValue("@selectedYear", selectedYear);
                    command.Parameters.AddWithValue("@empid", form_login.empid);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        DateTime now = DateTime.Now;
                        int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);

                        int presentCount = Convert.ToInt32(reader["Present_Count"]);
                        int absentCount = daysInMonth - presentCount;
                        int lateCount = Convert.ToInt32(reader["Late_Count"]);
                        int overtimeCount = Convert.ToInt32(reader["Overtime_Count"]);
                        int undertimeCount = Convert.ToInt32(reader["Undertime_Count"]);

                        emp_dashchart.ChartAreas.Add(new ChartArea("DefaultArea"));

                        Series presentsSeries = new Series("Presents");
                        presentsSeries.Points.AddXY(monthName, presentCount);
                        emp_dashchart.Series.Add(presentsSeries);

                        Series absentsSeries = new Series("Absents");
                        absentsSeries.Points.AddXY(monthName, absentCount);
                        emp_dashchart.Series.Add(absentsSeries);

                        Series latesSeries = new Series("Lates");
                        latesSeries.Points.AddXY(monthName, lateCount);
                        emp_dashchart.Series.Add(latesSeries);

                        Series overtimesSeries = new Series("Overtimes");
                        overtimesSeries.Points.AddXY(monthName, overtimeCount);
                        emp_dashchart.Series.Add(overtimesSeries);

                        Series undertimesSeries = new Series("Undertimes");
                        undertimesSeries.Points.AddXY(monthName, undertimeCount);
                        emp_dashchart.Series.Add(undertimesSeries);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }









        private void btn_resetpass_Click(object sender, EventArgs e)
        {
            emp_changepass newForm = new emp_changepass(this);
            //this.Hide();
            newForm.ShowDialog();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            loadChart();
        }
    }
}
