using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace EVENT
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        public static List<Form> hiddenForms = new List<Form>();
        string conn = "server=localhost;database=eventmanager;user=root;password=''";

        

       
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

        private void staffBtn_Click(object sender, EventArgs e)
        {
            Staff_Records staff = new Staff_Records();
            staff.Show();
            
            this.Hide();
        }

        private void userProfile_Click(object sender, EventArgs e)
        {
            Admin_Profile admin = new Admin_Profile();
            admin.Show();
            
            this.Hide();
        }

        int user_id = Login.login_id;
        private void Dashboard_Load(object sender, EventArgs e)
        {
            userProfile.Text = user_id.ToString();


            String time;
            LoadBookingData();
            totalBookings(bookingCount);
            countBookings("Upcoming", upcCount);
            countBookings("Completed", compCount);
            countBookings("Cancelled", ekisCount);
            displaySched();
            DateTime now = DateTime.Now.Date;
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();
                string query = "SELECT event_name, event_date, TIME_FORMAT(event_start, '%H:%i') AS formatted_start, TIME_FORMAT(event_end, '%H:%i') AS formatted_end, event_pax FROM event_details WHERE event_date = ?";
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Parameters.AddWithValue("event_date", now);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    eventNameTxt.Text = reader["event_name"].ToString();
                    eventDate.Text = reader.GetDateTime("event_date").ToString("yyyy-MM-dd");
                    string startTime = reader["formatted_start"].ToString();
                    string endTime = reader["formatted_end"].ToString();
                    time = startTime + " - " + endTime;
                    paxLbl.Text = reader["event_pax"].ToString();
                    eventTime.Text = time;
                }
                else
                {
                    eventNameTxt.Text = "NO EVENT TODAY";
                }
                reader.Dispose();
                command.Dispose();
                connection.Close();
                pplLbl.Location = new Point(paxLbl.Width + 5, 3);

            }
        }

        private void LoadBookingData()
        {
            chart1.Size = new Size (570, 258);
            chart1.BackColor = Color.FromArgb(248, 241, 241);
            // Create the database connection
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                // Construct the SQL query to retrieve the booking data
                string query = "SELECT DATE_FORMAT(event_date, '%Y-%m-01') AS BookingMonth, COUNT(*) AS BookingCount FROM event_details GROUP BY BookingMonth";

                // Create a new DataTable to hold the booking data
                DataTable originalData = new DataTable();

                // Open the database connection
                connection.Open();

                // Create a MySqlCommand object with the SQL query and connection
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Create a MySqlDataAdapter to retrieve the data into the DataTable
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        // Fill the DataTable with the retrieved data
                        adapter.Fill(originalData);
                    }
                }

                // Close the database connection
                connection.Close();

                // Create a new DataTable with the desired column data type
                DataTable bookingData = new DataTable();
                bookingData.Columns.Add("BookingMonth", typeof(DateTime));
                bookingData.Columns.Add("BookingCount", typeof(int));

                // Copy data from the original DataTable to the new DataTable
                foreach (DataRow row in originalData.Rows)
                {
                    DateTime bookingMonth = DateTime.Parse(row["BookingMonth"].ToString());
                    int bookingCount = int.Parse(row["BookingCount"].ToString());
                    bookingData.Rows.Add(bookingMonth, bookingCount);
                }

                // Bind the DataTable to the chart
                chart1.DataSource = bookingData;

                // Configure the chart series
                chart1.Series.Clear();
                chart1.Series.Add("Bookings");
                chart1.Series["Bookings"].ChartType = SeriesChartType.Line;
                chart1.Series["Bookings"].XValueType = ChartValueType.DateTime;
                chart1.Series["Bookings"].XValueMember = "BookingMonth";
                chart1.Series["Bookings"].YValueMembers = "BookingCount";
              

                // Customize chart appearance
                chart1.ChartAreas[0].AxisX.Title = "MONTH";
                chart1.ChartAreas[0].AxisY.Title = "NUMBER OF BOOKINGS";
                chart1.ChartAreas[0].AxisX.TitleFont = new Font("Tw Cen MT", 12, FontStyle.Bold);
                chart1.ChartAreas[0].AxisY.TitleFont = new Font("Tw Cen MT", 10, FontStyle.Bold);
                chart1.ChartAreas[0].AxisX.TitleForeColor = Color.FromArgb(17, 84, 100);
                chart1.ChartAreas[0].AxisY.TitleForeColor = Color.FromArgb(17, 84, 100);

                // Set the X-axis labels to month names
                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MMM";
                chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(17, 84, 100);
                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Tw Cen MT", 12, FontStyle.Regular);
                chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(17, 84, 100);
                chart1.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Tw Cen MT", 12, FontStyle.Regular);

                // Add a horizontal line to the chart
                chart1.Series.Add("Average");
                chart1.Series["Average"].ChartType = SeriesChartType.Line;
                chart1.Series["Average"].Points.AddXY(bookingData.Rows[0]["BookingMonth"], bookingData.Compute("AVG(BookingCount)", string.Empty));
                chart1.Series["Average"].Points.AddXY(bookingData.Rows[bookingData.Rows.Count - 1]["BookingMonth"], bookingData.Compute("AVG(BookingCount)", string.Empty));
                chart1.Series["Average"].Color = System.Drawing.Color.Red;
                chart1.Series["Average"].BorderDashStyle = ChartDashStyle.Dash;
               

                // Refresh the chart to update the display
                chart1.DataBind();
            }
        }
        private void displaySched()
        {
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            String sql = "SELECT DATE_FORMAT(event_date, '%m/%d/%Y') AS `Date of the Event`, event_name AS `Event Name`, CONCAT(\r\n        TIME_FORMAT(event_start, '%H:%i'),\r\n        ' - ',\r\n        SUBSTRING_INDEX(TIME_FORMAT(event_end, '%H:%i'), ':', 2)\r\n    ) AS `Time of Event`, event_pax AS `Number of Attendees` \r\nFROM event_details \r\nWHERE event_date > CURDATE()\r\nGROUP BY event_date;";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            da.Fill(ds, "event_details");
            upcomingEventsData.DataSource = ds.Tables["event_details"].DefaultView;
            connection.Close();
        }
        private void countBookings(string status, Label countlbl)
        {
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();
                string sql = "SELECT COUNT(*) AS EventCount FROM event_details WHERE event_status = @stat";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@stat", status);

                MySqlDataReader readClient = command.ExecuteReader();
                if (readClient.Read())
                {
                    if (!readClient.IsDBNull(readClient.GetOrdinal("EventCount")))
                    {
                        int eventCount = readClient.GetInt32("EventCount");
                        string countText = eventCount.ToString().PadLeft(2, '0');
                        countlbl.Text = countText;
                    }
                    
                }
                connection.Close();
            }
        }

        private void totalBookings(Label countlbl)
        {
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();
                string sql = "SELECT COUNT(*) AS TotalCount FROM event_details WHERE event_status IN ('Upcoming', 'Completed')";
                MySqlCommand command = new MySqlCommand(sql, connection);
               

                MySqlDataReader readClient = command.ExecuteReader();
                if (readClient.Read())
                {
                    if (!readClient.IsDBNull(readClient.GetOrdinal("TotalCount")))
                    {
                        int eventCount = readClient.GetInt32("TotalCount");
                        string countText = eventCount.ToString().PadLeft(2, '0');
                        countlbl.Text = countText;
                        
                    }

                }
                connection.Close();
            }
        }
    }
}
