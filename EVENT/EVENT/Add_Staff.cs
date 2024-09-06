using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace EVENT
{
    public partial class Add_Staff : Form
    {
        string conn = "server=localhost;database=eventmanager;user=root;password=''";

        public Add_Staff()
        {
            InitializeComponent();
        }
        public static Boolean isCilcked = false;
        public static string lname, fname, mi, num, email, add;
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

        private void positionCbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPosition = positionCbox.SelectedItem.ToString();
            switch (selectedPosition)
            {
                case "Admin":
                    pwTbx.Text = "Admin123";
                    break;
                case "Manager":
                    pwTbx.Text = "Manager123";
                    break;
                default:
                    pwTbx.Text = "Staff123";
                    break;
            }
        }

        public string properCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            if (input.ToUpper() == input)
                return input.ToLower();

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(input);
        }

        private void addStaffBtn_Click(object sender, EventArgs e)
        {

            if (lnameTbx.Text == "" || fnameTbx.Text == "" || numTbx.Text == "" || emailTbx.Text == "" || addressTbx.Text == "" || positionCbox.SelectedIndex == -1 || staffStat.SelectedIndex == -1)
            {
                MessageBox.Show("Empty Fields Detected");
            }
            else
            {
                lname = properCase(lnameTbx.Text);
                fname = properCase(fnameTbx.Text);
                mi = properCase(miTbx.Text);
                num = properCase(numTbx.Text);
                add = properCase(addressTbx.Text);
                email = emailTbx.Text;
                MySqlConnection connection = new MySqlConnection(conn);

                connection.Open();
                string insertClientQuery = "INSERT INTO staff_details (staff_id, staff_lname, staff_fname, staff_mi, staff_num, staff_email, staff_address, staff_position, staff_password, staff_hired, staff_status) VALUES (NULL, @lname, @fname, @mi, @num, @email, @address, @position, @pw, @dateHire, @staffStat)";
                MySqlCommand insertClientCommand = new MySqlCommand(insertClientQuery, connection);
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
                connection.Close();
                MessageBox.Show("Saved.");

            }
           
        }
        string pos;
        private void Add_Staff_Load(object sender, EventArgs e)
        {
            
            //empIDTbx.Text = Staff_Records.staff_id.ToString();
            dateHire.Format = DateTimePickerFormat.Custom;
            dateHire.CustomFormat = "MMMMdd, yyyy";
            staffStat.SelectedIndex = 0;
            
            MySqlConnection connection = new MySqlConnection(conn);

            string sql = "SELECT staff_position FROM staff_details WHERE staff_id = " + Login.login_id + "";
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    string position = result.ToString();
                    pos = position;
                }
                
            }
            connection.Close();
            if (pos == "Admin")
            {
                positionCbox.Items.Clear();
                positionCbox.Items.AddRange(new object[] { "Staff", "Manager", "Admin" }); ;

            }
            else if (pos == "Manager")
            {
                positionCbox.Items.Clear();
                positionCbox.Items.Add("Staff") ;
            }

            string query = "SELECT AUTO_INCREMENT FROM information_schema.TABLES WHERE TABLE_SCHEMA = 'eventmanager' AND TABLE_NAME = 'staff_details'";
            connection.Open();
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    int nextStaffID = Convert.ToInt32(result);
                    empIDTbx.Text = nextStaffID.ToString();
                }
            }
            connection.Close();
        }
       
    }
}
