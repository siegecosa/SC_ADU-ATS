using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATS
{
    public partial class emp_time : Form
    {
        public emp_time()
        {
            InitializeComponent();
        }

        private void lbl_dashboard_Click(object sender, EventArgs e)
        {
            emp_dashboard nextForm = new emp_dashboard();
            nextForm.Show();
            this.Hide();
        }

        private void lbl_timeinout_Click(object sender, EventArgs e)
        {
            //do nothing
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
        int empid = form_login.empid;
        private void emp_time_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password=");
                connection.Open();

                // Create a SQL query to retrieve attendance for the specified empid
                string query = "SELECT ATTENDANCE_ID as 'Attendance I.D.', ATTENDANCE_DATE as 'Date', TIME_IN as 'Time-in', TIME_OUT as 'Time-out', ATTENDANCE_STATUS as 'Status', WORK_HOURS_TIME as 'Work Duration', WORK_HOURS_STATUS as 'Work Status' FROM attendance WHERE EMPLOYEE_ID = @empid";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@empid", empid);

                // Execute the query and retrieve the results
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Bind the DataTable to the DataGridView
                datagridtime.DataSource = dataTable;

                connection.Close();
            }
            catch (Exception ex)
            {
                // Handle any exception that occurred
                MessageBox.Show("An error occurred: " + ex.Message);
            }


        }



    }
}
