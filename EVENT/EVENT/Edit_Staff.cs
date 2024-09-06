using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace EVENT
{
    public partial class Edit_Staff : Form
    {
        public Edit_Staff()
        {
            InitializeComponent();
        }
        public static int staff_id = Staff_Records.staff_id;
        string conn = "server=localhost;database=eventmanager;user=root;password=''";
        public static string pos, stat;
        string position = Login.pos;
        private void Edit_Staff_Load(object sender, EventArgs e)
        {
            userProfile.Text = Login.login_id.ToString();
            dateHire.Format = DateTimePickerFormat.Custom;
            dateHire.CustomFormat = "MMMM dd, yyyy";
            MySqlConnection connection = new MySqlConnection(conn);
            string displayClient = "SELECT staff_lname, staff_fname, staff_mi, staff_num, staff_email, staff_address, staff_position, staff_hired, staff_status, staff_password FROM staff_details WHERE staff_id = " + staff_id + "";
            connection.Open();
            MySqlCommand dispClient = new MySqlCommand(displayClient, connection);
            MySqlDataReader readClient = dispClient.ExecuteReader();
            if (readClient.Read())
            {
                lnameTbx.Text = readClient.GetString("staff_lname");
                fnameTbx.Text = readClient.GetString("staff_fname");
                empIDTbx.Text = staff_id.ToString();
                miTbx.Text = readClient.GetString("staff_mi");
                numTbx.Text = readClient.GetString("staff_num");
                addressTbx.Text = readClient.GetString("staff_address");
                emailTbx.Text = readClient.GetString("staff_email");
                pwTbx.Text = readClient.GetString("staff_password");
                dateHire.Value = readClient.GetDateTime("staff_hired");
                pos = readClient.GetString("staff_position");
                stat = readClient.GetString("staff_status");
            }

            connection.Close();

            if (position == "Admin")
            {
                positionCbox.Items.Clear();
                positionCbox.Items.AddRange(new object[] { "Staff", "Manager", "Admin" });
            }
            else
            {
                positionCbox.Items.Clear();
                positionCbox.Items.Add("Staff");
            }

            if (pos == "Staff")
            {
                
                positionCbox.SelectedIndex = 0;
                

            }
            else if (pos == "Manager")
            {
                
                positionCbox.SelectedIndex = 1;
            }
            else
            {
                
                positionCbox.SelectedIndex = 2;
            }

            if (stat == "Active")
            {
                staffStat.SelectedIndex = 0;
            }
            else
            {
                staffStat.SelectedIndex = 1;
            }

            
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Staff_Records sRec = new Staff_Records();
            sRec.Show();
            this.Hide();
        }

        private void calendarBtn_Click(object sender, EventArgs e)
        {
            Calendar calendar = new Calendar();
            calendar.Show();
            this.Hide();
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            Dashboard dboard = new Dashboard();
            dboard.Show();
            this.Hide();
        }

        private void eventsBtn_Click(object sender, EventArgs e)
        {
            EventsF eventf = new EventsF();
            eventf.Show();
            this.Hide();

        }
        string lname, fname, mi, num, add, email;
        Boolean isClicked = true;
        private void viewPw_Click(object sender, EventArgs e)
        {
            if (isClicked)
            {
                viewPw.Image = EVENT.Properties.Resources.VIEW_PWC2;
                pwTbx.PasswordChar = '\0';
                isClicked = false;

            }
            else if (isClicked == false)
            {

                viewPw.Image = EVENT.Properties.Resources.VIEW_PW;
                pwTbx.PasswordChar = '*';
                isClicked = true;
            }
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

        public static Boolean isCilcked = false;
        private void saveBtn_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("Are you sure you want to save changes?", "Save Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                MySqlConnection connection2 = new MySqlConnection(conn);
                lname = lnameTbx.Text;
                fname = fnameTbx.Text;
                mi = miTbx.Text;
                num = numTbx.Text;
                add = addressTbx.Text;
                email = emailTbx.Text;
                
                connection2.Open();
                string insertClientQuery = "UPDATE staff_details SET staff_lname = @lname, staff_fname = @fname, staff_mi = @mi, staff_num = @num, staff_email = @email, staff_address = @address, staff_position = @position, staff_password = @pw, staff_hired = @dateHire, staff_status = @staffStat WHERE staff_id = "+ staff_id +"";
                MySqlCommand insertClientCommand = new MySqlCommand(insertClientQuery, connection2);
                insertClientCommand.Parameters.AddWithValue("@lname", lname);
                insertClientCommand.Parameters.AddWithValue("@fname", fname);
                insertClientCommand.Parameters.AddWithValue("@mi", mi);
                insertClientCommand.Parameters.AddWithValue("@num", num);
                insertClientCommand.Parameters.AddWithValue("@address", add);
                insertClientCommand.Parameters.AddWithValue("@email", email);
                insertClientCommand.Parameters.AddWithValue("@position", positionCbox.SelectedItem.ToString());
                insertClientCommand.Parameters.AddWithValue("@pw", pwTbx.Text);
                insertClientCommand.Parameters.AddWithValue("@dateHire", dateHire.Value.ToString("yyyy-MM-dd"));
                insertClientCommand.Parameters.AddWithValue("@staffStat", staffStat.SelectedItem.ToString());
                insertClientCommand.ExecuteNonQuery();
                isCilcked = true;
                connection2.Close();
                MessageBox.Show("Saved.");

                Staff_Records staff = new Staff_Records();
                staff.Show();
                this.Close();
            }
        }

        private void userProfile_Click(object sender, EventArgs e)
        {
            Admin_Profile aprof = new Admin_Profile();
            aprof.Show();
            this.Hide();
        }
    }
}
