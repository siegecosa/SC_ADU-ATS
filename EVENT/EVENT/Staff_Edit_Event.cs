using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace EVENT
{
    public partial class Staff_Edit_Event : Form
    {
        public Staff_Edit_Event()
        {
            InitializeComponent();
        }
        string conn = "server=localhost;database=eventmanager;user=root;password=''";
        public static int event_id = Staff_Events.event_id;
        string event_status;
        string start, end;
        string[] hours = new string[24];
        private void displayItems(System.Windows.Forms.ComboBox hoursBox)
        {

            hoursBox.Items.Clear();
            hoursBox.ForeColor = Color.FromArgb(17, 84, 100);

            // Populate the hours and minutes arrays
            for (int i = 0; i < 24; i++)
            {
                hours[i] = i.ToString("00") + ":" + "00"; // Format hours with leading zero
            }

            // Populate the ComboBox controls with the hours and minutes arrays
            hoursBox.Items.AddRange(hours);

        }
        private void Staff_Edit_Event_Load(object sender, EventArgs e)
        {
            userProfile.Text = Login.login_id.ToString();
            displayItems(hoursComboBox);
            displayItems(hoursComboBox2);

            int eventId = event_id; // Replace with the actual event ID

            // Retrieve the start time from the database
            TimeSpan startTime = getStartTimeFromDatabase(eventId);
            TimeSpan endTime = getEndTimeFromDatabase(eventId);

            // Set the selected item in the hoursComboBox to match the start time
            searchTime(startTime, hoursComboBox);
            searchTime(endTime, hoursComboBox2);


            dateDisplay.Format = DateTimePickerFormat.Custom;
            dateDisplay.CustomFormat = "MMMM dd, yyyy";
            string sql = "SELECT event_name, event_date, event_pax, event_start, event_end, event_status FROM event_details WHERE event_id = " + event_id + "";
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                eventNameTbx.Text = reader.GetString("event_name");
                dateDisplay.Value = reader.GetDateTime("event_date");
                paxTbx.Text = reader.GetString("event_pax");
                string start = reader.GetString("event_start");
                string end = reader.GetString("event_end");
                event_status = reader.GetString("event_status");

            }
            connection.Close();

            if (event_status == "Upcoming")
            {
                eventStat.SelectedIndex = 0;
            }
            else if (event_status == "Completed")
            {
                eventStat.SelectedIndex = 1;
            }
            
            connection.Open();
            string selectNewClientID = "SELECT client_id FROM event_details WHERE event_id = " + event_id + "";
            MySqlCommand selectNewClientIDCmd = new MySqlCommand(selectNewClientID, connection);
            int clientID = Convert.ToInt32(selectNewClientIDCmd.ExecuteScalar());
            connection.Close();

            string displayClient = "SELECT client_lname, client_fname, client_mi, client_num, client_emergency, client_email FROM client_details WHERE client_id = " + clientID + "";
            connection.Open();
            MySqlCommand dispClient = new MySqlCommand(displayClient, connection);
            MySqlDataReader readClient = dispClient.ExecuteReader();
            if (readClient.Read())
            {
                lnameTbx.Text = readClient.GetString("client_lname");
                fnameTbx.Text = readClient.GetString("client_fname");
                miTbx.Text = readClient.GetString("client_mi");
                numTbx.Text = readClient.GetString("client_num");
                enumTbx.Text = readClient.GetString("client_emergency");
                emailTbx.Text = readClient.GetString("client_email");
                    
            }

            connection.Close();
        }

        private TimeSpan getStartTimeFromDatabase(int eventId)
        {
            TimeSpan startTime = TimeSpan.Zero;

            using (MySqlConnection connect = new MySqlConnection(conn))
            {
                string query = "SELECT event_start FROM event_details WHERE event_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@id", eventId);
                    connect.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("event_start")))
                            {
                                startTime = reader.GetTimeSpan("event_start");
                            }
                        }
                    }
                }

            }
            return startTime;
        }

        private TimeSpan getEndTimeFromDatabase(int eventId)
        {
            TimeSpan endTime = TimeSpan.Zero;

            using (MySqlConnection connect = new MySqlConnection(conn))
            {
                string query = "SELECT event_end FROM event_details WHERE event_id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, connect))
                {
                    cmd.Parameters.AddWithValue("@id", eventId);
                    connect.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("event_end")))
                            {
                                endTime = reader.GetTimeSpan("event_end");
                            }
                        }
                    }
                }

            }
            return endTime;
        }

        private void searchTime(TimeSpan startTime, ComboBox hoursBox)
        {
            for (int i = hoursBox.Items.Count - 1; i >= 0; i--)
            {
                string item = hoursBox.Items[i].ToString();
                TimeSpan itemTime = TimeSpan.Parse(item);

                if (itemTime.Hours == startTime.Hours && itemTime.Minutes == startTime.Minutes)
                {
                    hoursBox.SelectedIndex = i;
                    break;
                }
            }
        }

        int count;
        string stat, eventName;
        public string properCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            if (input.ToUpper() == input)
                return input.ToLower();

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(input);
        }
        private void saveBtn_Click(object sender, EventArgs e)
        {
            eventName = properCase(eventNameTbx.Text);
            DateTime now = DateTime.Now.Date;
            int month = now.Month;
            int year = now.Year;
            DateTime selectedDate = dateDisplay.Value.Date;
            int selectedYear = selectedDate.Year;
            int selectedMonth = selectedDate.Month;
            start = hoursComboBox.SelectedItem.ToString();
            end = hoursComboBox2.SelectedItem.ToString();

            TimeSpan maxDuration = TimeSpan.FromHours(6);
            TimeSpan startTime = TimeSpan.ParseExact(start, @"hh\:mm", CultureInfo.InvariantCulture);
            TimeSpan endTime = TimeSpan.ParseExact(end, @"hh\:mm", CultureInfo.InvariantCulture);

            TimeSpan duration;
            if (endTime < startTime)
            {
                // Handle the case where end time is before start time (e.g., end time is 01:00, start time is 03:00)
                duration = TimeSpan.FromHours(24) - startTime + endTime;
            }
            else
            {
                duration = endTime - startTime;
            }

            DateTime compareDate = now.AddDays(3);

            if (duration.TotalHours <= maxDuration.TotalHours && (duration.TotalHours != 0 || startTime != endTime))
            {
                if (selectedDate >= now && selectedYear <= 2032 && selectedDate >= compareDate)
                {
                    using (MySqlConnection connection = new MySqlConnection(conn))
                    {
                        connection.Open();
                        string query = "SELECT COUNT(*) AS EventCount, event_status FROM event_details WHERE event_date = @selectedDate AND event_id != @eventId";
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@selectedDate", selectedDate.Date);
                        command.Parameters.AddWithValue("@eventId", event_id);

                        MySqlDataReader readClient = command.ExecuteReader();
                        if (readClient.Read())
                        {
                            if (!readClient.IsDBNull(readClient.GetOrdinal("EventCount")))
                            {
                                count = readClient.GetInt32("EventCount");
                            }
                            stat = readClient.IsDBNull(readClient.GetOrdinal("event_status")) ? string.Empty : readClient.GetString("event_status");
                        }
                        connection.Close();

                        if (count > 0 && stat == "Upcoming")
                        {
                            MessageBox.Show("Selected date is already present in the database.");
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Are you sure you want to save changes?", "Save Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                            {
                                connection.Open();
                                string sql = "UPDATE event_details SET event_name = @name, event_date = '" + dateDisplay.Value.ToString("yyyy-MM-dd") + "', event_pax = '" + paxTbx.Text + "', event_start =  @start, event_end = @end, event_status = '" + eventStat.SelectedItem.ToString() + "', staff_id = " + Login.login_id + " WHERE event_id = " + event_id + "";
                                MySqlCommand cmd = new MySqlCommand(sql, connection);
                                cmd.Parameters.AddWithValue("@name", eventName);
                                cmd.Parameters.AddWithValue("@start", hoursComboBox.SelectedItem.ToString());
                                cmd.Parameters.AddWithValue("@end", hoursComboBox2.SelectedItem.ToString());
                                cmd.ExecuteNonQuery();
                                connection.Close();

                                connection.Open();
                                string selectNewClientID = "SELECT client_id FROM event_details WHERE event_id = " + event_id + "";
                                MySqlCommand selectNewClientIDCmd = new MySqlCommand(selectNewClientID, connection);
                                int clientID = Convert.ToInt32(selectNewClientIDCmd.ExecuteScalar());
                                connection.Close();

                                connection.Open();
                                string sql2 = "UPDATE client_details SET client_lname = '" + lnameTbx.Text + "', client_fname = '" + fnameTbx.Text + "', client_mi = '" + miTbx.Text + "', client_num = '" + numTbx.Text + "', client_emergency = '" + enumTbx.Text + "', client_email = '" + emailTbx.Text + "', staff_id = " + Login.login_id + " WHERE client_id = " + clientID + "";
                                MySqlCommand cmd2 = new MySqlCommand(sql2, connection);
                                cmd2.ExecuteNonQuery();
                                connection.Close();

                                Staff_Events edit = new Staff_Events();
                                edit.Show();
                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Selected Date is Out of Range");
                }
            }
            else
            {
                MessageBox.Show("The range of start and end times cannot exceed 6 hours.");
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            reset();
            Staff_Events edit = new Staff_Events();
            edit.Show();
            this.Close();
        }

        private void reset()
        {
            lnameTbx.Text = "";
            fnameTbx.Text = "";
            miTbx.Text = "";
            numTbx.Text = "";
            enumTbx.Text = "";
            emailTbx.Text = "";
            eventNameTbx.Text = "";
            paxTbx.Text = "";

        }

        private void calendarBtn_Click(object sender, EventArgs e)
        {
            Staff_Calendar calendar = new Staff_Calendar();
            calendar.Show();
            this.Hide();
        }

        private void userProfile_Click(object sender, EventArgs e)
        {
            Staff_Profile staff = new Staff_Profile();
            staff.Show();
            this.Hide();
        }

        
    }
}
