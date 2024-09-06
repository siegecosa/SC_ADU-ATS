using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace EVENT
{
    public partial class Login : Form
    {
        string conn = "server=localhost;database=eventmanager;user=root;password=''";
        public Login()
        {
            InitializeComponent();
        }
        public static int login_id;
        Boolean none = false;
        Boolean read = false;
        public static Boolean isAdmin = false;
        public static string pos, stat;
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string uname = unameTbx.Text;
            string pw = pwTbx.Text;

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                connection.Open();

                string sql = "SELECT * FROM staff_details WHERE staff_id = @uname AND staff_password = @pw";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@pw", pw);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (String.IsNullOrEmpty(uname) || String.IsNullOrEmpty(pw))
                {
                    MessageBox.Show("Empty Fields Detected");
                }
                else if (reader.Read())
                {
                    string staffStatus = reader["staff_status"].ToString();

                    if (staffStatus == "Active")
                    {
          
                        using (MySqlConnection connect = new MySqlConnection(conn))
                        {

                            string query = "SELECT staff_id FROM staff_details WHERE staff_id = @username AND staff_password = @password AND staff_status = 'Active'";
                            using (MySqlCommand cmd2 = new MySqlCommand(query, connect))
                            {
                                cmd2.Parameters.AddWithValue("@username", uname);
                                cmd2.Parameters.AddWithValue("@password", pw);
                                connect.Open();
                                Object result = cmd2.ExecuteScalar();

                                if (result != null && result != DBNull.Value)
                                {
                                    login_id = Convert.ToInt32(result);
                                }
                                else
                                {
                                    MessageBox.Show("NOW");
                                }
                                connect.Close();
                            }

                            string positionSql = "SELECT staff_position FROM staff_details WHERE staff_id = @username";
                            using (MySqlCommand positionCmd = new MySqlCommand(positionSql, connect))
                            {
                                positionCmd.Parameters.AddWithValue("@username", uname);
                                connect.Open();
                                object result = positionCmd.ExecuteScalar();

                                if (result != null && result != DBNull.Value)
                                {
                                    pos = result.ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Credentials");
                                }
                                connect.Close();
                            }

                            if (pos == "Staff")
                            {
                                Staff_Calendar s_cal = new Staff_Calendar();
                                s_cal.Show();
                                unameTbx.Text = "";
                                pwTbx.Text = "";
                                this.Hide();
                                
                            }
                            else
                            {
                                isAdmin = true;
                                Dashboard form1 = new Dashboard();
                                form1.Show();
                                unameTbx.Text = "";
                                pwTbx.Text = "";
                                this.Hide();
                                
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Credentials are not valid");
                        unameTbx.Text = "";
                        pwTbx.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Wrong Credentials");
                    unameTbx.Text = "";
                    pwTbx.Text = "";
                }

                reader.Close();
                connection.Close();
            }
        }
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

        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Exit the Application?", "Exit Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
            
        }

       

        private void exitPanel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Exit the Application?", "Exit Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            viewPw.Image = EVENT.Properties.Resources.VIEW_PW;
            this.Focus();
            loginBtn.Focus();
            
        }
    }
}
