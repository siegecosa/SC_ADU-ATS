using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;

namespace EVENT
{
    public partial class Book_Event : Form
    {
        public Book_Event()
        {
            InitializeComponent();
        }
        string conn = "server=localhost;database=eventmanager;user=root;password=''";
        public string properCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            if (input.ToUpper() == input)
                return input.ToLower();

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(input);
        }
        Boolean admin = Login.isAdmin;
        private void Book_Event_Load(object sender, EventArgs e)
        {
            displayItems(hoursComboBox);
            displayItems(hoursComboBox2);
            dispBookDate();
            eventStat.SelectedIndex = 0;
            if (admin)
            {
                eventDate = Calendar.statMonthname + " " + CalendarDays.statDay + ", " + Calendar.statYear;
                dateTbx.Text = eventDate;
                dbDate = Calendar.statYear + "-" + Calendar.statMonth + "-" + CalendarDays.statDay;
            }
            else
            {
                eventDate = Staff_Calendar.statMonthname + " " + CalendarDays.statDay + ", " + Staff_Calendar.statYear;
                dateTbx.Text = eventDate;
                dbDate = Staff_Calendar.statYear + "-" + Staff_Calendar.statMonth + "-" + CalendarDays.statDay;
            }
            
        }
        public static string eventName, eventDate, eventStrtTime, eventEndTime, dbDate, event_status, lname, fname, mi, num, enumb, email, compName;
        
        private void hoursComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void hoursComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            

        }

        string[] hours = new string[24];
        private void displayItems(System.Windows.Forms.ComboBox hoursBox)
        {

            hoursBox.Items.Clear();
            
            for (int i = 0; i < 24; i++)
            {
                hours[i] = i.ToString("00") + ":" + "00"; 
            }

            hoursBox.Items.AddRange(hours);
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        string date;
        private void dispBookDate()
        {
            DateTime now = DateTime.Now;
            date = now.ToString("yyyy-MM-dd");
            bookDate.Text = date;

        }

        public static string eventPax;
        public static int eventID;
        public static int staff_id;
        string start, end;
        private void bookEventBtn_Click(object sender, EventArgs e)
        {

            if (lnameTbx.Text == "" || fnameTbx.Text == "" || numTbx.Text == "" || enumTbx.Text == "" || emailTbx.Text == "" || eventNameTbx.Text == "" || hoursComboBox.SelectedIndex == -1 || hoursComboBox2.SelectedIndex == -1 || paxTbx.Text == "")
            {
                MessageBox.Show("Empty Fields Detected.");
            }
            else
            {
                if (miTbx.Text == "")
                {
                    miTbx.Text = "";
                }
                else if (companyTbx.Text == "")
                {
                    companyTbx.Text = "";
                }
                else if (miTbx.Text == "" && companyTbx.Text == "")
                {
                    miTbx.Text = "";
                    companyTbx.Text = "";
                }

                start = hoursComboBox.SelectedItem.ToString();
                end = hoursComboBox2.SelectedItem.ToString();
                TimeSpan maxDuration = TimeSpan.FromHours(6);
                TimeSpan startTime = TimeSpan.ParseExact(start, @"hh\:mm", CultureInfo.InvariantCulture);
                TimeSpan endTime = TimeSpan.ParseExact(end, @"hh\:mm", CultureInfo.InvariantCulture);

                TimeSpan duration = endTime - startTime;

                if (duration.TotalHours <= maxDuration.TotalHours && (duration.TotalHours != 0 || startTime != endTime))
                {
                    lname = properCase(lnameTbx.Text);
                    fname = properCase(fnameTbx.Text);
                    mi = properCase(miTbx.Text);
                    num = properCase(numTbx.Text);
                    enumb = properCase(enumTbx.Text);
                    email = emailTbx.Text;
                    eventName = properCase(eventNameTbx.Text);
                    compName = properCase(companyTbx.Text);

                    eventPax = paxTbx.Text;
                    staff_id = Login.login_id;
                    event_status = eventStat.SelectedItem.ToString();
                    

                    string query = "INSERT INTO event_details (event_id, event_name, event_date, event_pax, event_start, event_end, book_date, event_status, event_remarks, client_id, staff_id) VALUES (NULL, @eventName, @dbDate, @eventPax, @eventStartTime, @eventEndTime, @book_date, @event_status, 'Successfully Booked', 0, @staff_id)";
                    using (MySqlConnection connection = new MySqlConnection(conn))
                    {
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@eventName", eventName);
                        command.Parameters.AddWithValue("@dbDate", dbDate);
                        command.Parameters.AddWithValue("@eventPax", eventPax);
                        command.Parameters.AddWithValue("@eventStartTime", start);
                        command.Parameters.AddWithValue("@eventEndTime", end);
                        command.Parameters.AddWithValue("@book_date", date);
                        command.Parameters.AddWithValue("@event_status", event_status);
                        command.Parameters.AddWithValue("@staff_id", staff_id);
                        command.ExecuteNonQuery();

                        string selectLastID = "SELECT LAST_INSERT_ID()";
                        MySqlCommand selectCmd = new MySqlCommand(selectLastID, connection);
                        int eventID = Convert.ToInt32(selectCmd.ExecuteScalar());

                        string checkExistingClientQuery = "SELECT client_id FROM client_details WHERE client_fname = @fname AND client_lname = @lname";
                        MySqlCommand checkExistingClientCommand = new MySqlCommand(checkExistingClientQuery, connection);
                        checkExistingClientCommand.Parameters.AddWithValue("@fname", fnameTbx.Text);
                        checkExistingClientCommand.Parameters.AddWithValue("@lname", lnameTbx.Text);
                        int clientID = Convert.ToInt32(checkExistingClientCommand.ExecuteScalar());

                        if (clientID == 0)
                        {
                            string insertClientQuery = "INSERT INTO client_details (client_id, client_lname, client_fname, client_mi, company_name, client_num, client_emergency, client_email, staff_id) VALUES (NULL, @lname, @fname, @mi, @comp, @num, @emergency, @email, @staff_id)";
                            MySqlCommand insertClientCommand = new MySqlCommand(insertClientQuery, connection);
                            insertClientCommand.Parameters.AddWithValue("@lname", lname);
                            insertClientCommand.Parameters.AddWithValue("@fname", fname);
                            insertClientCommand.Parameters.AddWithValue("@mi", mi);
                            insertClientCommand.Parameters.AddWithValue("@comp", compName);
                            insertClientCommand.Parameters.AddWithValue("@num", num);
                            insertClientCommand.Parameters.AddWithValue("@emergency", enumb);
                            insertClientCommand.Parameters.AddWithValue("@email", email);
                            insertClientCommand.Parameters.AddWithValue("@staff_id", staff_id);
                            insertClientCommand.ExecuteNonQuery();

                            string selectNewClientID = "SELECT LAST_INSERT_ID()";
                            MySqlCommand selectNewClientIDCmd = new MySqlCommand(selectNewClientID, connection);
                            clientID = Convert.ToInt32(selectNewClientIDCmd.ExecuteScalar());
                        }

                        string updateQuery = "UPDATE event_details SET client_id = @clientID WHERE event_id = @eventID";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@clientID", clientID);
                        updateCommand.Parameters.AddWithValue("@eventID", eventID);
                        updateCommand.ExecuteNonQuery();

                        MessageBox.Show("Saved");
                        connection.Close();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("The range of start and end times cannot exceed 6 hours.");
                }
            }



        }
    }   
}
