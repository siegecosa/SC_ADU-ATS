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
    public partial class CalendarDays : UserControl
    {
        public static string statDay;
        string conn = "server=localhost;database=eventmanager;user=root;password=''";
        public CalendarDays()
        {
            InitializeComponent();
        }

        public static Boolean isAdmin = Login.isAdmin;
        private void CalendarDays_Load(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                dispEvent();
            }
            else
            {
                dispEventS();
            }
        }

        public void addDays (int numdays)
        {
            dispDay.Text = numdays + "";
        }

        public Label display()
        {
            return dispDay;
        }

        public static string eventName;
        public static int eventID;
        public static int selectedYear;
        Boolean imAdmin = Login.isAdmin;
        string selectDate;
        private void CalendarDays_Click(object sender, EventArgs e)
        {
            statDay = dispDay.Text;
            
            
            int selectDay = Convert.ToInt32(statDay);
            DateTime dt = DateTime.Now.Date;
            int day = dt.Day;
            int year = dt.Year;
            DateTime compareDate = dt.AddDays(3);
            if (imAdmin)
            {
                selectedYear = Calendar.statYear;
                selectDate = Calendar.statYear + "-" + Calendar.statMonth + "-" + dispDay.Text;
            }
            else
            {
                selectedYear = Staff_Calendar.statYear;
                selectDate = Staff_Calendar.statYear + "-" + Staff_Calendar.statMonth + "-" + dispDay.Text;
            }
            
            DateTime date = DateTime.Parse(selectDate);
            timer1.Start();
            
            if (eventLbl.Text == "" && date >= dt && date >= compareDate)
            {
                Book_Event bookEvent = new Book_Event();
                bookEvent.ShowDialog();
            }
            else
            {
                if (eventLbl.Text != "")
                {
                    MessageBox.Show("An Event is already Booked.");
                }
                else if (date < dt)
                {

                    MessageBox.Show("Date is invalid.");
                    
                }
                else
                {
                    MessageBox.Show("Please book at least 3 days in advance.");
                }
                
            }
               

            if (isAdmin)
            {
                dispEvent();
            }
            else
            {
                dispEventS();
            }

        }
        public static string dday;
        private void dispEvent()
        {
            eventLbl.Font = new Font ("AvenirNext LT Pro Regular", 12, FontStyle.Bold);
            eventLbl.ForeColor = Color.FromArgb(17, 84, 100);
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            string query = "SELECT * FROM event_details WHERE event_date = ? AND (event_status = 'Upcoming' OR event_status = 'Completed')"; ;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("event_date", Calendar.statYear + "-" + Calendar.statMonth + "-" + dispDay.Text);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string eventName = reader["event_name"].ToString();
                if (eventName.Length > 10)
                {
                    eventLbl.Text = eventName.Substring(0, 10) + "...";
                }
                else
                {
                    eventLbl.Text = eventName;
                }

            }
            reader.Dispose();
            command.Dispose();
            connection.Close();

            
        }

        private void dispEventS()
        {
            eventLbl.Font = new Font("AvenirNext LT Pro Regular", 12, FontStyle.Bold);
            eventLbl.ForeColor = Color.FromArgb(17, 84, 100);
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            string query = "SELECT * FROM event_details WHERE event_date = ? AND (event_status = 'Upcoming' OR event_status = 'Completed')";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            command.Parameters.AddWithValue("event_date", Staff_Calendar.statYear + "-" + Staff_Calendar.statMonth + "-" + dispDay.Text);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string eventName = reader["event_name"].ToString();
                if (eventName.Length > 10)
                {
                    eventLbl.Text = eventName.Substring(0, 10) + "...";
                }
                else
                {
                    eventLbl.Text = eventName;
                }

            }
            reader.Dispose();
            command.Dispose();
            connection.Close();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isAdmin)
            {
                dispEvent();
            }
            else
            {
                dispEventS();
            }
        }

        private void eventLbl_Click(object sender, EventArgs e)
        {
            dday = dispDay.Text;
            Calendar_Popup popup = new Calendar_Popup();
            popup.ShowDialog();
        }
    }
}
