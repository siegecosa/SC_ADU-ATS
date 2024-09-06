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
    public partial class Staff_Profile : Form
    {
        public Staff_Profile()
        {
            InitializeComponent();
        }
        string conn = "server=localhost;database=eventmanager;user=root;password=''";
        int user_id = Login.login_id;
        private void Staff_Profile_Load(object sender, EventArgs e)
        {
            userID.Text = user_id.ToString();
            userProfile.Text = user_id.ToString();

            pwTbx.PasswordChar = '*';
            rpwTbx.PasswordChar = '*';
            
            MySqlConnection connection = new MySqlConnection(conn);
            connection.Open();
            string displayClient = "SELECT staff_lname, staff_fname, staff_mi, staff_num, staff_email, staff_address, staff_password, staff_hired FROM staff_details WHERE staff_id = " + user_id + "";
            MySqlCommand dispClient = new MySqlCommand(displayClient, connection);
            MySqlDataReader readClient = dispClient.ExecuteReader();
            if (readClient.Read())
            {
                lnameTbx.Text = readClient.GetString("staff_lname");
                fnameTbx.Text = readClient.GetString("staff_fname");
                miTbx.Text = readClient.GetString("staff_mi");
                numTbx.Text = readClient.GetString("staff_num");
                addressTbx.Text = readClient.GetString("staff_address");
                emailTbx.Text = readClient.GetString("staff_email");
                pwTbx.Text = readClient.GetString("staff_password");
                dateHired.Text = readClient.GetDateTime("staff_hired").ToString("yyyy-MM-dd");
            }

            connection.Close();
        }
        Boolean isClicked = true;
        Boolean isClicked2 = true;
        private void viewPw1_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {

                viewPw1.Image = EVENT.Properties.Resources.VIEW_PWC2;
                pwTbx.PasswordChar = '\0';
                isClicked = false;

            }
            else if (isClicked == false)
            {

                viewPw1.Image = EVENT.Properties.Resources.VIEW_PW;
                pwTbx.PasswordChar = '*';
                isClicked = true;
            }
        }

        private void viewPw2_Click(object sender, EventArgs e)
        {
            if (isClicked2)
            {
                viewPw2.Image = EVENT.Properties.Resources.VIEW_PWC2;
                rpwTbx.PasswordChar = '\0';
                isClicked2 = false;

            }
            else if (isClicked == false)
            {

                viewPw2.Image = EVENT.Properties.Resources.VIEW_PW;
                rpwTbx.PasswordChar = '*';
                isClicked2 = true;
            }
        }
         Boolean pw = false;

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (pwTbx.Text == rpwTbx.Text)
            {
                MySqlConnection connection = new MySqlConnection(conn);
                connection.Open();
                string displayClient = "UPDATE staff_details SET staff_lname = '" + lnameTbx.Text + "', staff_fname  = '" + fnameTbx.Text + "', staff_mi  = '" + miTbx.Text + "', staff_num  = '" + numTbx.Text + "', staff_email  = '" + emailTbx.Text + "', staff_address  = '" + addressTbx.Text + "' , staff_password  = '" + pwTbx.Text + "' WHERE staff_id = " + user_id + "";
                MySqlCommand dispClient = new MySqlCommand(displayClient, connection);
                dispClient.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Saved");
                rpwTbx.Text = "";
                
            }
            else
            {
                if (rpwTbx.Text == "")
                {
                    MessageBox.Show("Please Reenter password for Confirmation.");
                }
                else if (rpwTbx.Text != pwTbx.Text)
                {
                    MessageBox.Show("Passwords Do Not Match.");
                }
            }
            pw = false;
        }

        private void pwTbx_TextChanged(object sender, EventArgs e)
        {
            pw = true;
        }

        private void calendarBtn_Click(object sender, EventArgs e)
        {
            Staff_Calendar cal = new Staff_Calendar();
            cal.Show();
            this.Hide();
        }

        private void eventsBtn_Click(object sender, EventArgs e)
        {
            Staff_Events eventsf = new Staff_Events();
            eventsf.Show();
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
    }
}
