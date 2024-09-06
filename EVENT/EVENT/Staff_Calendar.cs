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

namespace EVENT
{
    public partial class Staff_Calendar : Form
    {
        int month, year;
        public static int statMonth, statYear;

        private void Staff_Calendar_Load(object sender, EventArgs e)
        {
            userProfile.Text = Login.login_id.ToString();
            dispDefault();
            monthPanel();
            yearPanel();
        }

        public static string statMonthname;
        public Staff_Calendar()
        {
            InitializeComponent();
        }
        private void dispDefault()
        {
            DateTime now = DateTime.Now;
            int monthDefault = now.Month;
            int monthDefaultDisp = now.Month - 1;
            dispDays(yearNum[0], monthDefault);
            monthDisp.Text = monthNames[monthDefaultDisp];
            yearDisp.Text = yearNum[0].ToString();
            monthNumber = now.Month;
        }
        String date;

        private void dispDays(int yearNo, int monthNo)
        {
            DateTime dt = new DateTime(yearNo, monthNo, 1);
            date = dt.ToString("yyyy-MM-dd");
            month = dt.Month;
            year = dt.Year;
            statMonth = month;
            statYear = year;
            String monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            statMonthname = monthName;
            DateTime startMonth = new DateTime(year, month, 1);
            int dayCount = DateTime.DaysInMonth(dt.Year, dt.Month);
            int startMonthNum = Convert.ToInt32(startMonth.DayOfWeek.ToString("d")) + 1;
            for (int i = 1; i < startMonthNum; i++)
            {
                CalendarSpace calendarSpace = new CalendarSpace();
                dateContainer.Controls.Add(calendarSpace);
            }
            for (int i = 1; i <= dayCount; i++)
            {
                CalendarDays calendarDays = new CalendarDays();
                calendarDays.addDays(i);
                dateContainer.Controls.Add(calendarDays);
            }
        }
        public static int monthsize = 12;
        Button[] monthButtons = new Button[monthsize];
        String[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September",
                                    "October", "November", "December"};


        public void monthPanel()
        {

            int x = 2;
            int y = 3;
            for (int i = 0; i < monthsize; i++)
            {

                monthButtons[i] = new Button();
                monthButtons[i].Size = new Size(143, 23);
                monthButtons[i].Location = new Point(x, y);
                monthButtons[i].FlatAppearance.BorderSize = 0;
                monthButtons[i].FlatStyle = FlatStyle.Flat;
                monthButtons[i].Font = new Font("Couture", 11);
                monthButtons[i].ForeColor = Color.FromArgb(17, 84, 100);
                monthButtons[i].Text = monthNames[i];
                int monthIndex = i; // Capture the current value of 'i' in a separate variable
                monthButtons[i].Click += (sender, e) => MonthButton_Click(sender, e, monthIndex);
                monthContainer.Controls.Add(monthButtons[i]);

                y += 25;

            }


        }
        public static int monthNumber;
        public static int yearNumber;
        private void MonthButton_Click(object sender, EventArgs e, int monthIndex)
        {
            Button clickedButton = (Button)sender;
            string buttonText = clickedButton.Text;
            monthNumber = monthIndex + 1;
            dateContainer.Controls.Clear();
            dispDays(yearNum[yearNumber], monthNumber);
        
            monthDisp.Text = buttonText;

            //MessageBox.Show("Clicked: " + buttonText + " (Month Number: " + (monthNumber) + ")");

        }

        public static int yearsize = 10;
        Button[] yearButtons = new Button[yearsize];
        int[] yearNum = { 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030, 2031, 2032, 2033 };

        private void monthDropDown_Click(object sender, EventArgs e)
        {
            if (monthContainer.Visible == false)
            {
                monthContainer.Visible = true;
            }
            else
            {
                monthContainer.Visible = false;
            }
        }

        private void yearDropDown_Click(object sender, EventArgs e)
        {
            if (yearContainer.Visible == false)
            {
                yearContainer.Visible = true;
            }
            else
            {
                yearContainer.Visible = false;
            }
        }

        private void eventsBtn_Click(object sender, EventArgs e)
        {
            Staff_Events s_event = new Staff_Events();
            s_event.Show();
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

        private void userProfile_Click(object sender, EventArgs e)
        {
            Staff_Profile s_prof = new Staff_Profile();
            s_prof.Show();
            this.Hide();
        }

        public void yearPanel()
        {
            int x = 2;
            int y = 3;
            for (int i = 0; i < yearsize; i++)
            {

                yearButtons[i] = new Button();
                yearButtons[i].Size = new Size(143, 23);
                yearButtons[i].Location = new Point(x, y);
                yearButtons[i].FlatAppearance.BorderSize = 0;
                yearButtons[i].FlatStyle = FlatStyle.Flat;
                yearButtons[i].Font = new Font("Couture", 11);
                yearButtons[i].ForeColor = Color.FromArgb(17, 84, 100);
                yearButtons[i].Text = yearNum[i] + "";
                yearContainer.Controls.Add(yearButtons[i]);
                yearButtons[i].Text = yearNum[i].ToString();
                int yearIndex = i; // Capture the current value of 'i' in a separate variable
                yearButtons[i].Click += (sender, e) => YearButton_Click(sender, e, yearIndex);
                yearContainer.Controls.Add(yearButtons[i]);

                y += 25;
            }

        }

        private void YearButton_Click(object sender, EventArgs e, int yearIndex)
        {

            Button clickedButton = (Button)sender;
            string buttonText = clickedButton.Text;
            yearNumber = yearIndex;
            dateContainer.Controls.Clear();
            dispDays(yearNum[yearNumber], monthNumber);
           
            yearDisp.Text = buttonText;

        }
    }
}
