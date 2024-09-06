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

namespace EVENT
{
    public partial class EventsF : Form
    {
        string conn = "server=localhost;database=eventmanager;user=root;password=''";
        public static int event_id;
        public EventsF()
        {
            InitializeComponent();
        }

        private void editEventsBtn_Click(object sender, EventArgs e)
        {

            if (isClicked == true && isNotNull == true)
            {
                Edit_Event edit_Event = new Edit_Event();
                edit_Event.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please Select an Event to Edit.");
            }
            isNotNull = false;
            isClicked = false;
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

        private void Events_Load(object sender, EventArgs e)
        {
            userProfile.Text = Login.login_id.ToString();
            all = true;
            btnClicked(allEventFilter);
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            String sql = "SELECT e.event_id AS `Event ID`, CONCAT(client_lname, ', ', client_fname, ' ', client_mi) AS \"Client Name\", event_name AS `Event Name`, event_date AS `Date of Event`, TIME_FORMAT(event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(event_end, '%H:%i') AS `End Time of Event`, event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e INNER JOIN client_details c ON e.client_id=c.client_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "event_details");
            bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
            connection.Close();

        }

        DataGridViewRow row;
        
        Boolean isClicked = false;
        Boolean isNotNull = false;
        private void bookedEventsData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            isClicked = true;
            if (e.RowIndex >= 0)
            {
                row = bookedEventsData.Rows[e.RowIndex];
                if (!DBNull.Value.Equals(row.Cells[0].Value))
                {
                    isNotNull = true;
                    event_id = Convert.ToInt32(row.Cells[0].Value);
                }
                else
                {
                    MessageBox.Show("No Registered User.");
                }
            }

            Edit_Event.event_id = event_id;

        }

        private void bookedEventsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string search = searchBox.Text;
            string sql;
            if (all == true)
            {
                sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e INNER JOIN client_details c ON e.client_id = c.client_id WHERE e.event_id LIKE '%" + search + "%' OR e.event_name LIKE '%" + search + "%' OR e.event_pax LIKE '%" + search + "%' OR e.event_start LIKE '%" + search + "%' OR e.event_end LIKE '%" + search + "%' OR e.event_date LIKE '%" + search + "%' OR CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) LIKE '%" + search + "%' OR event_remarks LIKE '%" + search + "%'";
                using (MySqlConnection connect = new MySqlConnection(conn))
                {
                    connect.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "event_details");
                    bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
                    connect.Close();
                }
            }
            else if (upcoming == true)
            {
                sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e " +
      "INNER JOIN client_details c ON e.client_id = c.client_id " +
      "WHERE (e.event_id LIKE '%" + search + "%' OR e.event_name LIKE '%" + search + "%' OR e.event_pax LIKE '%" + search + "%' OR e.event_start LIKE '%" + search + "%' OR e.event_end LIKE '%" + search + "%' OR e.book_date LIKE '%" + search + "%' OR CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) LIKE '%" + search + "%' OR event_remarks LIKE '%" + search + "%' OR event_remarks LIKE '%" + search + "%') " +
      "AND e.event_status = 'Upcoming'";


                using (MySqlConnection connect = new MySqlConnection(conn))
                {
                    connect.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "event_details");
                    bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
                    connect.Close();
                }
            }
            else if (complete == true)
            {
                sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e " +
      "INNER JOIN client_details c ON e.client_id = c.client_id " +
      "WHERE (e.event_id LIKE '%" + search + "%' OR e.event_name LIKE '%" + search + "%' OR e.event_pax LIKE '%" + search + "%' OR e.event_start LIKE '%" + search + "%' OR e.event_end LIKE '%" + search + "%' OR e.book_date LIKE '%" + search + "%' OR CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) LIKE '%" + search + "%' OR event_remarks LIKE '%" + search + "%') " +
      "AND e.event_status = 'Completed'";

                using (MySqlConnection connect = new MySqlConnection(conn))
                {
                    connect.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "event_details");
                    bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
                    connect.Close();
                }
            }
            else if (cancel == true)
            {
                sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e " +
      "INNER JOIN client_details c ON e.client_id = c.client_id " +
      "WHERE (e.event_id LIKE '%" + search + "%' OR e.event_name LIKE '%" + search + "%' OR e.event_pax LIKE '%" + search + "%' OR e.event_start LIKE '%" + search + "%' OR e.event_end LIKE '%" + search + "%' OR e.book_date LIKE '%" + search + "%' OR CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) LIKE '%" + search + "%' OR event_remarks LIKE '%" + search + "%') " +
      "AND e.event_status = 'Cancelled'";

                using (MySqlConnection connect = new MySqlConnection(conn))
                {
                    connect.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "event_details");
                    bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
                    connect.Close();
                }
            }

        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string search = searchBox.Text;
            string sql;
            if (all == true)
            {
                sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e INNER JOIN client_details c ON e.client_id = c.client_id WHERE e.event_id LIKE '%" + search + "%' OR e.event_name LIKE '%" + search + "%' OR e.event_pax LIKE '%" + search + "%' OR e.event_start LIKE '%" + search + "%' OR e.event_end LIKE '%" + search + "%' OR e.event_date LIKE '%" + search + "%' OR CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) LIKE '%" + search + "%' OR event_remarks LIKE '%" + search + "%'";
                using (MySqlConnection connect = new MySqlConnection(conn))
                {
                    connect.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "event_details");
                    bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
                    connect.Close();
                }
            }
            else if (upcoming == true)
            {
                sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e " +
      "INNER JOIN client_details c ON e.client_id = c.client_id " +
      "WHERE (e.event_id LIKE '%" + search + "%' OR e.event_name LIKE '%" + search + "%' OR e.event_pax LIKE '%" + search + "%' OR e.event_start LIKE '%" + search + "%' OR e.event_end LIKE '%" + search + "%' OR e.event_date LIKE '%" + search + "%' OR CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) LIKE '%" + search + "%' OR event_remarks LIKE '%" + search + "%' OR event_remarks LIKE '%" + search + "%') " +
      "AND e.event_status = 'Upcoming'";


                using (MySqlConnection connect = new MySqlConnection(conn))
                {
                    connect.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "event_details");
                    bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
                    connect.Close();
                }
            }
            else if (complete == true)
            {
                sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e " +
      "INNER JOIN client_details c ON e.client_id = c.client_id " +
      "WHERE (e.event_id LIKE '%" + search + "%' OR e.event_name LIKE '%" + search + "%' OR e.event_pax LIKE '%" + search + "%' OR e.event_start LIKE '%" + search + "%' OR e.event_end LIKE '%" + search + "%' OR e.event_date LIKE '%" + search + "%' OR CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) LIKE '%" + search + "%' OR event_remarks LIKE '%" + search + "%') " +
      "AND e.event_status = 'Completed'";

                using (MySqlConnection connect = new MySqlConnection(conn))
                {
                    connect.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "event_details");
                    bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
                    connect.Close();
                }
            }
            else if (cancel == true)
            {
                sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e " +
      "INNER JOIN client_details c ON e.client_id = c.client_id " +
      "WHERE (e.event_id LIKE '%" + search + "%' OR e.event_name LIKE '%" + search + "%' OR e.event_pax LIKE '%" + search + "%' OR e.event_start LIKE '%" + search + "%' OR e.event_end LIKE '%" + search + "%' OR e.event_date LIKE '%" + search + "%' OR CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) LIKE '%" + search + "%' OR event_remarks LIKE '%" + search + "%') " +
      "AND e.event_status = 'Cancelled'";

                using (MySqlConnection connect = new MySqlConnection(conn))
                {
                    connect.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, connect);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "event_details");
                    bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
                    connect.Close();
                }
            }
           

            
        }

        Boolean all, upcoming, complete, cancel = false;

        private void compEventFilter_Click(object sender, EventArgs e)
        {
            all = false;
            upcoming = false;
            complete = true;
            btnClicked(compEventFilter);
            cancel = false;
            btnNotClicked(allEventFilter);
            btnNotClicked(ekisEventFilter);
            btnNotClicked(upcEventFilter);
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            String sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e INNER JOIN client_details c ON e.client_id=c.client_id WHERE event_status = 'Completed'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "event_details");
            bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
            connection.Close();
        }

        private void ekisEventFilter_Click(object sender, EventArgs e)
        {
            all = false;
            upcoming = false;
            complete = false;
            cancel = true;
            btnClicked(ekisEventFilter);
            btnNotClicked(allEventFilter);
            btnNotClicked(compEventFilter);
            btnNotClicked(upcEventFilter);

            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            String sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Remarks` FROM event_details e INNER JOIN client_details c ON e.client_id=c.client_id WHERE event_status = 'Cancelled'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "event_details");
            bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
            connection.Close();
        }

        private void upcEventFilter_Click(object sender, EventArgs e)
        {
            all = false;
            upcoming = true;
            btnClicked(upcEventFilter);
            complete = false;
            cancel = false;
            btnNotClicked(allEventFilter);
            btnNotClicked(compEventFilter);
            btnNotClicked(ekisEventFilter);

            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            String sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e INNER JOIN client_details c ON e.client_id=c.client_id WHERE event_status = 'Upcoming'";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "event_details");
            bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
            connection.Close();
        }

        private void userProfile_Click(object sender, EventArgs e)
        {
            Admin_Profile admin = new Admin_Profile();
            admin.Show();
            this.Hide();
        }

        private void staffBtn_Click(object sender, EventArgs e)
        {
            Staff_Records staff = new Staff_Records();
            staff.Show();
            this.Hide();
        }

        private void allEventFilter_Click(object sender, EventArgs e)
        {
            
            all = true;
            btnClicked(allEventFilter);
            upcoming = false;
            complete = false;
            cancel = false;
            btnNotClicked(upcEventFilter);
            btnNotClicked(compEventFilter);
            btnNotClicked(ekisEventFilter);

            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            String sql = "SELECT e.event_id AS `Event ID`, CONCAT(c.client_lname, ', ', c.client_fname, ' ', c.client_mi) AS \"Client Name\", e.event_name AS `Event Name`, e.event_date AS `Date of Event`, TIME_FORMAT(e.event_start, '%H:%i') AS `Start Time of Event`, TIME_FORMAT(e.event_end, '%H:%i') AS `End Time of Event`, e.event_status AS `Event Status`, event_remarks AS `Event Remarks` FROM event_details e INNER JOIN client_details c ON e.client_id=c.client_id";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "event_details");
            bookedEventsData.DataSource = ds.Tables["event_details"].DefaultView;
            connection.Close();
        }

        private void btnClicked (Button butt)
        {
            butt.BackColor = Color.FromArgb(17, 84, 100);
            butt.ForeColor = Color.White;
        }

        private void btnNotClicked(Button butt)
        {
            butt.BackColor = SystemColors.Control;
            butt.ForeColor = Color.FromArgb(17, 84, 100);
        }
    }
}
