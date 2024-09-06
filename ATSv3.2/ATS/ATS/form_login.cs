using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace ATS
{
    public partial class form_login : Form
    {
        public form_login()
        {
            InitializeComponent();
        }
        public static int empid;
        public static int usertype;
        public static string savePass;
        string firstName, lastName;
        public void Userpass()
        {
           
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text;
            string password = tb_password.Text;
            tb_password.Text = "";
            tb_username.Text = "";


            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter a valid username and password.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(username, out form_login.empid))
            {
                MessageBox.Show("Please enter a valid username and password.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password="))
            {
                string query = $"SELECT USER_TYPE FROM user WHERE BINARY USERNAME = '{username}' AND BINARY PASSWORD = '{password}'";

                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        usertype = Convert.ToInt32(result);
                        string sqlQuery = "SELECT EMPLOYEE_FN, EMPLOYEE_LN FROM Employees WHERE EMPLOYEE_ID = @empid";
                        MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, connection);

                        // Add the parameter
                        sqlCommand.Parameters.AddWithValue("@empid", empid);

                        using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                firstName = reader.GetString("EMPLOYEE_FN");
                                lastName = reader.GetString("EMPLOYEE_LN");
                            }
                        }


                        int userType = Convert.ToInt32(result);
                        string DPass = lastName + firstName;
                        savePass = DPass;
                        if (DPass == password)
                        {
                            MessageBox.Show("It's your first time login.\nYour password is set to default.\nPlease change it.", "First Time Login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            emp_changepass newForm = new emp_changepass(this);
                            this.Hide();
                            newForm.ShowDialog();

                        }
                        else
                        {
                            if (userType == 0)
                            {
                               
                                admin_dashboard nextForm = new admin_dashboard();
                                this.Hide();
                                nextForm.ShowDialog();
                            }
                            else if (userType == 1)
                            {
                                emp_dashboard nextForm = new emp_dashboard();
                                this.Hide();
                                nextForm.ShowDialog();
                            }
                            tb_username.Text = string.Empty;
                            tb_password.Text = string.Empty;
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void form_login_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_showpass_Click(object sender, EventArgs e)
        {
            tb_password.UseSystemPasswordChar = !tb_password.UseSystemPasswordChar;
            btn_showpass.Text = tb_password.UseSystemPasswordChar ? "Show" : "Hide";
        }
    }
}
