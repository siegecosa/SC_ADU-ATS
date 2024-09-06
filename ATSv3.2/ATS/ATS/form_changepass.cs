using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySqlX.XDevAPI.Common;

namespace ATS
{
    public partial class emp_changepass : Form
    {
        private Form previousForm;

        public emp_changepass(Form previousForm)
        {
            this.previousForm = previousForm;
            InitializeComponent();
        }


        int empid;
        int usertype;
        string thepass;

        private MySqlConnection connection;
        private MySqlCommand command;

        private void emp_changepass_Load(object sender, EventArgs e)
        {
            empid = form_login.empid;
            usertype = form_login.usertype;

            // Define your database connection string
            string connectionString = "server=localhost;database=atsdb;uid=root;password=";

            // Define the SQL query to retrieve the password
            string query = "SELECT PASSWORD FROM user WHERE EMPLOYEE_ID = @EmployeeID";

            // Create a connection to the database
            using (connection = new MySqlConnection(connectionString))
            {
                // Create a MySqlCommand with the query and connection
                using (command = new MySqlCommand(query, connection))
                {
                    // Add the EmployeeID parameter to the command
                    command.Parameters.AddWithValue("@EmployeeID", empid);

                    // Open the database connection
                    connection.Open();

                    // Execute the query and retrieve the password
                    object result = command.ExecuteScalar();

                    // Check if a password was found
                    if (result != null)
                    {
                        thepass = result.ToString();
                        // Use the password as needed
                    }
                    else
                    {
                        // Handle the case where no password was found
                    }
                }
            }

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            string oldPassword = oldPasswordTextBox.Text;
            string newPassword = newPasswordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            // Check if any of the fields are empty
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return; // Exit the method
            }

            else if (oldPassword != thepass)
            {
                MessageBox.Show("Old password is incorrect.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if old password is the same as new password or confirm password
            else if (oldPassword == newPassword || oldPassword == confirmPassword)
            {
                MessageBox.Show("Old password cannot be the same as new password or confirm password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if new password is not the same as confirm password
            else if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if password meets the criteria
            else if (!IsPasswordValid(newPassword))
            {
                MessageBox.Show("Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one numeric digit, and one special character.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult changeyesno = MessageBox.Show("Are you sure you want to change your password?", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (changeyesno == DialogResult.Yes)
                {
                    string query = "UPDATE user SET PASSWORD = @newPassword WHERE EMPLOYEE_ID = @empid;";
                    using (connection)
                    {
                        try
                        {
                            command = new MySqlCommand(query, connection);
                            command.Parameters.AddWithValue("@newPassword", confirmPasswordTextBox.Text);
                            command.Parameters.AddWithValue("@empid", empid);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();

                            MessageBox.Show("Password successfully updated.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        this.Close(); previousForm.Show();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private bool IsPasswordValid(string password)
        {
            // Check if password is at least 8 characters long
            if (password.Length < 8)
                return false;

            // Check if password contains at least one uppercase letter
            if (!password.Any(char.IsUpper))
                return false;

            // Check if password contains at least one lowercase letter
            if (!password.Any(char.IsLower))
                return false;

            // Check if password contains at least one numeric digit
            if (!password.Any(char.IsDigit))
                return false;

            // Check if password contains at least one special character
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                return false;

            return true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            //form_login loginForm = new form_login();
            this.Close(); previousForm.Show();
            //loginForm.Show();
        }

        private void btn_show1_Click(object sender, EventArgs e)
        {
            oldPasswordTextBox.UseSystemPasswordChar = !oldPasswordTextBox.UseSystemPasswordChar;
            btn_show1.Text = oldPasswordTextBox.UseSystemPasswordChar ? "Show" : "Hide";
        }

        private void btn_show2_Click(object sender, EventArgs e)
        {
            newPasswordTextBox.UseSystemPasswordChar = !newPasswordTextBox.UseSystemPasswordChar;
            btn_show2.Text = newPasswordTextBox.UseSystemPasswordChar ? "Show" : "Hide";
        }

        private void btn_show3_Click(object sender, EventArgs e)
        {
            confirmPasswordTextBox.UseSystemPasswordChar = !confirmPasswordTextBox.UseSystemPasswordChar;
            btn_show3.Text = confirmPasswordTextBox.UseSystemPasswordChar ? "Show" : "Hide";
        }
    }
}
