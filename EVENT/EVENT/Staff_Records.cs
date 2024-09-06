using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;

namespace EVENT
{
    public partial class Staff_Records : Form
    {
        string conn = "server=localhost;database=eventmanager;user=root;password=''";
        public Staff_Records()
        {
            InitializeComponent();
        }

        private void editStaffBtn_Click(object sender, EventArgs e)
        {
            if (isClicked == true && isNotNull == true)
            {
                Edit_Staff edit_Staff = new Edit_Staff();
                edit_Staff.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Select an Event to Edit.");
            }
            isNotNull = false;
            isClicked = false;
        }

        public static int staff_id = Login.login_id;
        private void addStaffBtn_Click(object sender, EventArgs e)
        {
           

            Add_Staff addStaff = new Add_Staff();
            addStaff.ShowDialog();
        }
        string position = Login.pos;
        private void Staff_Records_Load(object sender, EventArgs e)
        {
            userProfile.Text = Login.login_id.ToString();
            if (position == "Admin")
            {
                MySqlConnection connection = new MySqlConnection(conn);
                connection.Open();
                String sql = "SELECT staff_id AS `Staff ID`, CONCAT(staff_lname, ', ', staff_fname, ' ', staff_mi) AS \"Staff Name\", staff_position AS `Staff Position`, staff_hired AS `Date Hired`, staff_status AS `Staff Status` FROM staff_details";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds, "staff_details");
                staffData.DataSource = ds.Tables["staff_details"].DefaultView;
                connection.Close();
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(conn);
                connection.Open();
                String sql = "SELECT staff_id AS `Staff ID`, CONCAT(stafeef_lname, ', ', staff_fname, ' ', staff_mi) AS \"Staff Name\", staff_position AS `Staff Position`, staff_hired AS `Date Hired`, staff_status AS `Staff Status` FROM staff_details  WHERE staff_position = 'Staff'";
                
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                da.Fill(ds, "staff_details");
                staffData.DataSource = ds.Tables["staff_details"].DefaultView;
                connection.Close();
            }
            
        }

        private void staffData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            Staff_Records staff = new Staff_Records();
            staff.Show();
            this.Hide();
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void calendarBtn_Click(object sender, EventArgs e)
        {
            Calendar calendar = new Calendar();
            calendar.Show();
            this.Hide();
        }

        private void eventsBtn_Click(object sender, EventArgs e)
        {
            EventsF events = new EventsF();
            events.Show();
            this.Hide();
        }

        private void userProfile_Click(object sender, EventArgs e)
        {
            Admin_Profile admin = new Admin_Profile();
            admin.Show();
            this.Hide();
        }

        private void outBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Logout Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Login login = new Login();
                login.Show();
                this.Close();
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string search = searchBox.Text;
            string sql = "SELECT staff_id AS `Staff ID`, CONCAT(staff_lname, ', ', staff_fname, ' ', staff_mi) AS \"Staff Name\", staff_position AS `Staff Position`, staff_hired AS `Date Hired`, staff_status AS `Staff Status` FROM staff_details WHERE staff_id LIKE '%" + search + "%' OR CONCAT(staff_lname, ', ', staff_fname, ' ', staff_mi) LIKE '%" + search + "%' OR staff_position LIKE '%" + search + "%' OR staff_hired LIKE '%" + search + "%' OR staff_status LIKE '%" + search + "%'";

            using (MySqlConnection connect = new MySqlConnection(conn))
            {
                connect.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, connect);
                DataSet ds = new DataSet();
                da.Fill(ds, "staff_details");
                staffData.DataSource = ds.Tables["staff_details"].DefaultView;
                connect.Close();
            }
        }
        Boolean isClicked = false;
        Boolean isNotNull = false;
        DataGridViewRow row;
        private void staffData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            isClicked = true;
            if (e.RowIndex >= 0)
            {
                row = staffData.Rows[e.RowIndex];
                if (!DBNull.Value.Equals(row.Cells[0].Value))
                {
                    isNotNull = true;
                    staff_id = Convert.ToInt32(row.Cells[0].Value);
                }
                else
                {
                    MessageBox.Show("No Registered User.");
                }
            }

            Edit_Staff.staff_id = staff_id;
        }
    }
}
