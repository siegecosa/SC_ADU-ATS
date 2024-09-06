using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ATS
{
    public partial class admin_dashboard : Form
    {
        public admin_dashboard()
        {
            InitializeComponent();
        }

        private void admin_dashboard_Load(object sender, EventArgs e)
        {
            loadChart();

            string currentMonth = DateTime.Now.ToString("MMMM").ToUpper();
            lbl_month.Text = "ATTENDANCE REPORT FOR THE MONTH OF: " + currentMonth;

            GetLatestAttendance();
        }

        private void btn_admindashboard_Click(object sender, EventArgs e)
        {
            // Stay on Form
        }

        private void btn_employeemanagement_Click(object sender, EventArgs e)
        {
            admin_empmngmnt nextForm = new admin_empmngmnt();
            nextForm.Show();
            this.Hide();
        }

        private void btn_leavemanagement_Click(object sender, EventArgs e)
        {
            admin_leave nextForm = new admin_leave();
            nextForm.Show();
            this.Hide();
        }

        private void btn_signout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                form_login nextForm = new form_login();
                nextForm.ShowDialog();
                this.Close();
            }
        }

        private void GetLatestAttendance()
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password="))
            {
                // Query to retrieve the latest attendance record based on ATTENDANCE_DATE
                string attendanceQuery = @"SELECT e.EMPLOYEE_FN, e.EMPLOYEE_LN, a.TIME_IN, a.TIME_OUT, a.ATTENDANCE_DATE
                               FROM attendance AS a
                               INNER JOIN employees AS e ON e.EMPLOYEE_ID = a.EMPLOYEE_ID
                               WHERE a.ATTENDANCE_DATE = (SELECT MAX(ATTENDANCE_DATE) FROM attendance)
                               ORDER BY a.ATTENDANCE_DATE DESC
                               LIMIT 1";

                // Query to count the number of leaves
                string leavesQuery = @"SELECT COUNT(*) FROM leaves WHERE LEAVE_STATUS = 'Pending'";

                // Query to count the number of employees
                string employeesQuery = @"SELECT COUNT(*) FROM employees";

                try
                {
                    connection.Open();

                    // Retrieve the latest attendance record
                    MySqlCommand attendanceCommand = new MySqlCommand(attendanceQuery, connection);
                    MySqlDataReader attendanceReader = attendanceCommand.ExecuteReader();

                    if (attendanceReader.Read())
                    {
                        string firstName = attendanceReader.GetString("EMPLOYEE_FN");
                        string lastName = attendanceReader.GetString("EMPLOYEE_LN");
                        string timeIn = attendanceReader.GetString("TIME_IN");
                        string timeOut = attendanceReader.IsDBNull(attendanceReader.GetOrdinal("TIME_OUT")) ? null : attendanceReader.GetString("TIME_OUT");
                        DateTime attendanceDate = attendanceReader.GetDateTime("ATTENDANCE_DATE");

                        // Concatenate the first name and last name to get the employee name
                        string employeeName = $"{firstName} {lastName}";

                        // Determine the latest time between TIME_IN and TIME_OUT
                        DateTime latestTime = !string.IsNullOrEmpty(timeOut) ? DateTime.Parse(timeOut) : DateTime.Parse(timeIn);

                        // Combine the attendance date and latest time
                        DateTime fullDateTime = attendanceDate.Date + latestTime.TimeOfDay;

                        // Format the date and time separately
                        string formattedDate = fullDateTime.ToString("MM/dd/yyyy");
                        string formattedTime = fullDateTime.ToString("hh:mm:ss tt");

                        // Create the label text with line breaks
                        string labelText = $"{formattedDate}\n{formattedTime}";

                        // Update the labels with the employee name and formatted date/time
                        lbl_name.Text = employeeName;
                        lbl_time.Text = labelText;
                    }

                    attendanceReader.Close();

                    // Count the number of pending leaves
                    MySqlCommand leavesCommand = new MySqlCommand(leavesQuery, connection);
                    int leaveCount = Convert.ToInt32(leavesCommand.ExecuteScalar());

                    // Update the lbl_pendingleaves label with the leave count
                    lbl_pendingleaves.Text = leaveCount.ToString();

                    // Count the number of employees
                    MySqlCommand employeesCommand = new MySqlCommand(employeesQuery, connection);
                    int employeeCount = Convert.ToInt32(employeesCommand.ExecuteScalar());

                    // Update the lbl_totalemp label with the employee count
                    lbl_totalemp.Text = employeeCount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void loadChart()
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password="))
            {
                try
                {
                    int monthValue = DateTime.Now.Month; // Adjust monthValue to start from 1 (January)
                    int selectedYear = DateTime.Now.Year; // Get the current year

                    int daysInMonth = DateTime.DaysInMonth(selectedYear, monthValue); // Get the number of days in the current month

                    dashboardchart.Series.Clear();
                    dashboardchart.ChartAreas.Clear();

                    string query = @"
                SELECT
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Administrative' AND a.ATTENDANCE_STATUS = 'Present') AS Administrative_Present_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Finance and Accounting' AND a.ATTENDANCE_STATUS = 'Present') AS Finance_Accounting_Present_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Human Resources' AND a.ATTENDANCE_STATUS = 'Present') AS Human_Resources_Present_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Operations' AND a.ATTENDANCE_STATUS = 'Present') AS Operations_Present_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Information Technology' AND a.ATTENDANCE_STATUS = 'Present') AS Information_Technology_Present_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Administrative' AND (a.ATTENDANCE_STATUS = 'Absent' OR a.ATTENDANCE_STATUS IS NULL)) AS Administrative_Absent_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Finance and Accounting' AND (a.ATTENDANCE_STATUS = 'Absent' OR a.ATTENDANCE_STATUS IS NULL)) AS Finance_Accounting_Absent_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Human Resources' AND (a.ATTENDANCE_STATUS = 'Absent' OR a.ATTENDANCE_STATUS IS NULL)) AS Human_Resources_Absent_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Operations' AND (a.ATTENDANCE_STATUS = 'Absent' OR a.ATTENDANCE_STATUS IS NULL)) AS Operations_Absent_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Information Technology' AND (a.ATTENDANCE_STATUS = 'Absent' OR a.ATTENDANCE_STATUS IS NULL)) AS Information_Technology_Absent_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Administrative' AND a.ATTENDANCE_STATUS = 'Late') AS Administrative_Late_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Finance and Accounting' AND a.ATTENDANCE_STATUS = 'Late') AS Finance_Accounting_Late_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Human Resources' AND a.ATTENDANCE_STATUS = 'Late') AS Human_Resources_Late_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Operations' AND a.ATTENDANCE_STATUS = 'Late') AS Operations_Late_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Information Technology' AND a.ATTENDANCE_STATUS = 'Late') AS Information_Technology_Late_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Administrative' AND a.ATTENDANCE_STATUS = 'Overtime') AS Administrative_Overtime_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Finance and Accounting' AND a.ATTENDANCE_STATUS = 'Overtime') AS Finance_Accounting_Overtime_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Human Resources' AND a.ATTENDANCE_STATUS = 'Overtime') AS Human_Resources_Overtime_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Operations' AND a.ATTENDANCE_STATUS = 'Overtime') AS Operations_Overtime_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Information Technology' AND a.ATTENDANCE_STATUS = 'Overtime') AS Information_Technology_Overtime_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Administrative' AND a.ATTENDANCE_STATUS = 'Undertime') AS Administrative_Undertime_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Finance and Accounting' AND a.ATTENDANCE_STATUS = 'Undertime') AS Finance_Accounting_Undertime_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Human Resources' AND a.ATTENDANCE_STATUS = 'Undertime') AS Human_Resources_Undertime_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Operations' AND a.ATTENDANCE_STATUS = 'Undertime') AS Operations_Undertime_Count,
                    (SELECT COUNT(*) FROM attendance AS a INNER JOIN employees AS e ON a.EMPLOYEE_ID = e.EMPLOYEE_ID WHERE MONTH(a.ATTENDANCE_DATE) = @monthValue AND YEAR(a.ATTENDANCE_DATE) = @selectedYear AND e.DEPARTMENT = 'Information Technology' AND a.ATTENDANCE_STATUS = 'Undertime') AS Information_Technology_Undertime_Count
            ";

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@monthValue", monthValue);
                    command.Parameters.AddWithValue("@selectedYear", selectedYear);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        dashboardchart.ChartAreas.Add(new ChartArea("DefaultArea"));

                        Series presentsSeries = new Series("Presents");
                        presentsSeries.Points.AddXY("Administrative", Convert.ToInt32(reader["Administrative_Present_Count"]));
                        presentsSeries.Points.AddXY("Finance and Accounting", Convert.ToInt32(reader["Finance_Accounting_Present_Count"]));
                        presentsSeries.Points.AddXY("Human Resources", Convert.ToInt32(reader["Human_Resources_Present_Count"]));
                        presentsSeries.Points.AddXY("Operations", Convert.ToInt32(reader["Operations_Present_Count"]));
                        presentsSeries.Points.AddXY("Information Technology", Convert.ToInt32(reader["Information_Technology_Present_Count"]));
                        dashboardchart.Series.Add(presentsSeries);

                        Series absentsSeries = new Series("Absents");
                        int adminPresentCount = Convert.ToInt32(reader["Administrative_Present_Count"]);
                        int financePresentCount = Convert.ToInt32(reader["Finance_Accounting_Present_Count"]);
                        int hrPresentCount = Convert.ToInt32(reader["Human_Resources_Present_Count"]);
                        int operationsPresentCount = Convert.ToInt32(reader["Operations_Present_Count"]);
                        int itPresentCount = Convert.ToInt32(reader["Information_Technology_Present_Count"]);



                        int adminAbsentCount = daysInMonth - adminPresentCount;
                        int financeAbsentCount = daysInMonth - financePresentCount;
                        int hrAbsentCount = daysInMonth - hrPresentCount;
                        int operationsAbsentCount = daysInMonth - operationsPresentCount;
                        int itAbsentCount = daysInMonth - itPresentCount;


                        absentsSeries.Points.AddXY("Administrative", adminAbsentCount >= 0 ? adminAbsentCount : 0);
                        absentsSeries.Points.AddXY("Finance and Accounting", financeAbsentCount >= 0 ? financeAbsentCount : 0);
                        absentsSeries.Points.AddXY("Human Resources", hrAbsentCount >= 0 ? hrAbsentCount : 0);
                        absentsSeries.Points.AddXY("Operations", operationsAbsentCount >= 0 ? operationsAbsentCount : 0);
                        absentsSeries.Points.AddXY("Information Technology", itAbsentCount >= 0 ? itAbsentCount : 0);
                        dashboardchart.Series.Add(absentsSeries);

                        Series latesSeries = new Series("Lates");
                        latesSeries.Points.AddXY("Administrative", Convert.ToInt32(reader["Administrative_Late_Count"]));
                        latesSeries.Points.AddXY("Finance and Accounting", Convert.ToInt32(reader["Finance_Accounting_Late_Count"]));
                        latesSeries.Points.AddXY("Human Resources", Convert.ToInt32(reader["Human_Resources_Late_Count"]));
                        latesSeries.Points.AddXY("Operations", Convert.ToInt32(reader["Operations_Late_Count"]));
                        latesSeries.Points.AddXY("Information Technology", Convert.ToInt32(reader["Information_Technology_Late_Count"]));
                        dashboardchart.Series.Add(latesSeries);

                        Series overtimesSeries = new Series("Overtimes");
                        overtimesSeries.Points.AddXY("Administrative", Convert.ToInt32(reader["Administrative_Overtime_Count"]));
                        overtimesSeries.Points.AddXY("Finance and Accounting", Convert.ToInt32(reader["Finance_Accounting_Overtime_Count"]));
                        overtimesSeries.Points.AddXY("Human Resources", Convert.ToInt32(reader["Human_Resources_Overtime_Count"]));
                        overtimesSeries.Points.AddXY("Operations", Convert.ToInt32(reader["Operations_Overtime_Count"]));
                        overtimesSeries.Points.AddXY("Information Technology", Convert.ToInt32(reader["Information_Technology_Overtime_Count"]));
                        dashboardchart.Series.Add(overtimesSeries);

                        Series undertimesSeries = new Series("Undertimes");
                        undertimesSeries.Points.AddXY("Administrative", Convert.ToInt32(reader["Administrative_Undertime_Count"]));
                        undertimesSeries.Points.AddXY("Finance and Accounting", Convert.ToInt32(reader["Finance_Accounting_Undertime_Count"]));
                        undertimesSeries.Points.AddXY("Human Resources", Convert.ToInt32(reader["Human_Resources_Undertime_Count"]));
                        undertimesSeries.Points.AddXY("Operations", Convert.ToInt32(reader["Operations_Undertime_Count"]));
                        undertimesSeries.Points.AddXY("Information Technology", Convert.ToInt32(reader["Information_Technology_Undertime_Count"]));
                        dashboardchart.Series.Add(undertimesSeries);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




    }
}
