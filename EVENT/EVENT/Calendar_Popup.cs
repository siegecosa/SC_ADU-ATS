using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EVENT
{
    public partial class Calendar_Popup : Form
    {
        public Calendar_Popup()
        {
            InitializeComponent();
        }
        string conn = "server=localhost;database=eventmanager;user=root;password=''";
        public static Boolean isAdmin = Login.isAdmin;
        private void Calendar_Popup_Load(object sender, EventArgs e)
        {
            this.Focus(); // Set focus to the form
            button1.Select();
            CalendarDays dayLbl = new CalendarDays();
            Label dispDay = dayLbl.display();
            if (isAdmin)
            {
                panel1.Controls["paxLbl"].Focus();
                admin_popup();
            }
            else
            {
                staff_popup();
            }

        }

        private void admin_popup()
        {
            string time;
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            string query = "SELECT event_name, event_date, TIME_FORMAT(event_start, '%H:%i') AS formatted_start, TIME_FORMAT(event_end, '%H:%i') AS formatted_end, event_pax FROM event_details WHERE event_date = ?";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("event_date", Calendar.statYear + "-" + Calendar.statMonth + "-" + CalendarDays.dday);
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
            reader.Dispose();
            command.Dispose();
            connection.Close();


            //editPbox.Location = new Point(eventName.Width + 15, 30);
            pplLbl.Location = new Point(paxLbl.Width + 10, 64);
           
        }

        private void staff_popup()
        {
            string time;
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            string query = "SELECT event_name, event_date, TIME_FORMAT(event_start, '%H:%i') AS formatted_start, TIME_FORMAT(event_end, '%H:%i') AS formatted_end, event_pax FROM event_details WHERE event_date = ?";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("event_date", Staff_Calendar.statYear + "-" + Staff_Calendar.statMonth + "-" + CalendarDays.dday);
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
            reader.Dispose();
            command.Dispose();
            connection.Close();

            pplLbl.Location = new Point(paxLbl.Width + 10, 64);
        }
    }
}
