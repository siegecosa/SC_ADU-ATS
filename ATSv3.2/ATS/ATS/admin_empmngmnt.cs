using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Encoders;
using System.IO;
using QRCoder;
using Org.BouncyCastle.Utilities.Collections;
using System.Windows.Shapes;


namespace ATS
{
    public partial class admin_empmngmnt : Form
    {
        public admin_empmngmnt()
        {
            InitializeComponent();
        }

        // DB stuff starts here
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;

        private void LoadData()
        {
            connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password=");
            dataTable = new DataTable();
            try
            {
                string selectQuery = "SELECT EMPLOYEE_ID as 'Employee I.D.', EMPLOYEE_FN as 'First Name', EMPLOYEE_MN as 'Middle Name', EMPLOYEE_LN as 'Last Name', EMPLOYEE_EMAIL as 'Email', SEX as 'Sex', BIRTHDATE as 'Date of Birth', AGE as 'Age', PHONE as 'Phone Number', ADDRESS as 'Address', HIRE_DATE as 'Hire Date', JOB_TITLE as 'Position', MONTHLY_SALARY as 'Monthly Salary', LEAVE_BAL as 'Leave Balance', EMPLOYMENT_TYPE as 'Employment Type', STATUS as 'Status', DEPARTMENT as 'Department' FROM employees";
                string maxIDQuery = "SELECT MAX(employee_id) FROM employees";

                connection.Open();
                // Fill the DataTable with employee data
                command = new MySqlCommand(selectQuery, connection);
                adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
                dgvEmployeeList.DataSource = dataTable;

                // Get the maximum employee ID
                command = new MySqlCommand(maxIDQuery, connection);
                object result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    int recentEmployeeID = Convert.ToInt32(result);
                    int newEmployeeID = recentEmployeeID + 1;
                    tb_employeeid.Text = newEmployeeID.ToString();
                }
                else
                {
                    tb_employeeid.Text = "20230001";
                }

                tb_employeeid.Focus();
                tb_employeeid.Select(0, 0);
                cb_usertype.SelectedIndex = -1;
                pb_emppicture.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        private void admin_dashboard_Load(object sender, EventArgs e)
        {
            //all happens when the form loads
            LoadData();
        }
        

        


        private void btn_employeemanagement_Click(object sender, EventArgs e)
        {
            //stay forms
        }

        private void btn_admindashboard_Click(object sender, EventArgs e)
        {
            admin_dashboard nextForm = new admin_dashboard();
            nextForm.Show();
            this.Hide(); 
        }

        private void btn_leavemanagement_Click(object sender, EventArgs e)
        {
            admin_leave nextForm = new admin_leave();
            nextForm.Show(); 
            this.Hide();
        }

        private void btn_signout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to sign out?", "Sign Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide(); form_login nextForm = new form_login();
                nextForm.ShowDialog(); this.Close();
            }
        }


        private void cb_deparment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_jobtitle.Items.Clear(); // Clear existing items in ComboBox2

            // Add new items to ComboBox2 based on the selected item in ComboBox1
            if (cb_department.SelectedItem != null)
            {
                string selectedItem = cb_department.SelectedItem.ToString();

                //For Administrative
                if (selectedItem == "Administrative")
                {
                    cb_jobtitle.Items.Add("Administrative Assistant");
                    cb_jobtitle.Items.Add("Executive Assistant");
                    cb_jobtitle.Items.Add("Receptionist");
                    cb_jobtitle.Items.Add("Data Entry Clerk");
                    cb_jobtitle.Items.Add("Office Manager");
                }

                //For Finance and Accounting
                else if (selectedItem == "Finance and Accounting")
                {
                    cb_jobtitle.Items.Add("Chief Financial Officer");
                    cb_jobtitle.Items.Add("Financial Analyst");
                    cb_jobtitle.Items.Add("Accountant");
                    cb_jobtitle.Items.Add("Payroll Manager");
                    cb_jobtitle.Items.Add("Clerk");
                }

                //For Human Resources
                else if (selectedItem == "Human Resources")
                {
                    cb_jobtitle.Items.Add("HR Manager");
                    cb_jobtitle.Items.Add("Talent Acquisition Specialist");
                    cb_jobtitle.Items.Add("Training and Development Coordinator");
                    cb_jobtitle.Items.Add("HR Business Partner");
                    cb_jobtitle.Items.Add("Employee Relations Specialist");
                }

                //For Operations
                else if (selectedItem == "Operations")
                {
                    cb_jobtitle.Items.Add("Operations Manager");
                    cb_jobtitle.Items.Add("Supply Chain Manager");
                    cb_jobtitle.Items.Add("Production Supervisor");
                    cb_jobtitle.Items.Add("Quality Assurance Analyst");
                    cb_jobtitle.Items.Add("Logistics Coordinator");
                }

                //For Information Technology
                else if (selectedItem == "Information Technology")
                {
                    cb_jobtitle.Items.Add("Chief Information Officer");
                    cb_jobtitle.Items.Add("IT Manager");
                    cb_jobtitle.Items.Add("Systems Administrator");
                    cb_jobtitle.Items.Add("Network Engineer");
                    cb_jobtitle.Items.Add("Help Desk Support Specialist");
                }
            }
            
        }


        //START MAIN FUNCTIONS HERE, PIECE OF SHIT



        private void tb_employeeid_TextChanged(object sender, EventArgs e)
        {
            clearEmpData();
            //Query and load the data for the Fields
            if (int.TryParse(tb_employeeid.Text, out int employeeID))
            {
                string query = "SELECT EMPLOYEE_ID, EMPLOYEE_FN, EMPLOYEE_MN, EMPLOYEE_LN, EMPLOYEE_EMAIL, SEX, BIRTHDATE, PHONE, ADDRESS, HIRE_DATE, JOB_TITLE, MONTHLY_SALARY, LEAVE_BAL, EMPLOYMENT_TYPE, STATUS, DEPARTMENT, EMPLOYEE_IMAGE FROM employees WHERE employee_id = @employeeID";

                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@employeeID", employeeID);
                try
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            btn_add.Enabled = false;
                            btn_update.Enabled = true;
                            btn_resetpass.Enabled = true;
                            loadEmpData(reader);
                        }
                        else
                        {
                            btn_add.Enabled = true;
                            btn_update.Enabled = false;
                            btn_resetpass.Enabled = false;
                        }
                    }

                    //================================USERTYPE RETRIEVAL
                    string userTypeQuery = "SELECT USER_TYPE FROM user WHERE employee_id = @employeeID";
                    MySqlCommand userTypeCommand = new MySqlCommand(userTypeQuery, connection);
                    userTypeCommand.Parameters.AddWithValue("@employeeID", employeeID);
                    int userType = 0; // Default value if no data is found
                    try
                    {
                        using (MySqlDataReader userTypeReader = userTypeCommand.ExecuteReader())
                        {
                            if (userTypeReader.Read()) { userType = Convert.ToInt32(userTypeReader["USER_TYPE"]); }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error retrieving USER_TYPE: " + ex.Message); }
                    // Set the text of cb_user based on USER_TYPE
                    if (userType == 0) { cb_usertype.Text = "Admin"; }
                    else if (userType == 1) { cb_usertype.Text = "User"; }
                    //Just a rechecker part for the cb_usertype combobox; dont remove
                    using (MySqlDataReader reader = command.ExecuteReader()) { if (!reader.Read()) { cb_usertype.SelectedIndex = -1; } }



                    //===========================SHIFT RETRIEVEAL
                    string shiftQuery = "SELECT SHIFT_START_TIME, SHIFT_END_TIME FROM shift_schedule WHERE employee_id = @employeeID";
                    MySqlCommand shiftCommand = new MySqlCommand(shiftQuery, connection);
                    shiftCommand.Parameters.AddWithValue("@employeeID", employeeID);
                    try
                    {
                        using (MySqlDataReader shiftReader = shiftCommand.ExecuteReader())
                        {
                            if (shiftReader.Read())
                            {
                                string shiftStart = shiftReader["SHIFT_START_TIME"].ToString();
                                string shiftEnd = shiftReader["SHIFT_END_TIME"].ToString();
                                cb_shift_start.SelectedItem = shiftStart;  cb_shift_end.SelectedItem = shiftEnd;
                            }
                            else { cb_shift_start.SelectedIndex = -1;   cb_shift_end.SelectedIndex = -1;}
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("Error retrieving shift schedule: " + ex.Message); }
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }

        }


        private void loadEmpData(MySqlDataReader reader)
        {
            tb_firstname.Text = reader["EMPLOYEE_FN"].ToString();
            tb_middlename.Text = reader["EMPLOYEE_MN"].ToString();
            tb_lastname.Text = reader["EMPLOYEE_LN"].ToString();
            tb_email.Text = reader["EMPLOYEE_EMAIL"].ToString();
            tb_phone.Text = reader["PHONE"].ToString();
            date_bday.Value = Convert.ToDateTime(reader["BIRTHDATE"]);
            tb_address.Text = reader["ADDRESS"].ToString();

            string gender = reader["SEX"].ToString();
            rb_male.Checked = (gender == "Male");
            rb_female.Checked = (gender == "Female");

            date_hiredate.Value = Convert.ToDateTime(reader["HIRE_DATE"]);
            cb_department.SelectedItem = reader["DEPARTMENT"].ToString();
            cb_jobtitle.SelectedItem = reader["JOB_TITLE"].ToString();
            cb_emptype.SelectedItem = reader["EMPLOYMENT_TYPE"].ToString();
            cb_empstatus.SelectedItem = reader["STATUS"].ToString();
            num_salary.Value = Convert.ToDecimal(reader["MONTHLY_SALARY"]);
            lbl_leavebal.Text = "Leave Balance: " + reader["LEAVE_BAL"];

            string imageString = reader["EMPLOYEE_IMAGE"].ToString();
            if (!string.IsNullOrEmpty(imageString))
            {
                try
                {
                    byte[] imageBytes = Convert.FromBase64String(imageString);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pb_emppicture.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employee image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Handle the error or display a default image
                    pb_emppicture.Image = null; // Display a default image or clear the PictureBox

                    // Debugging: Output the problematic imageString
                    Console.WriteLine("Problematic imageString: " + imageString);
                }
            }
            else
            {
                // No image available, display a default image or clear the PictureBox
                pb_emppicture.Image = null; // Display a default image or clear the PictureBox
            }
        }

        private void LoadShiftTimes(int employeeID)
        {
            string shiftQuery = "SELECT DISTINCT SHIFT_START_TIME, SHIFT_END_TIME FROM shift_schedule WHERE employee_id = @employeeID";
            command = new MySqlCommand(shiftQuery, connection);
            command.Parameters.AddWithValue("@employeeID", employeeID);

            try
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cb_shift_start.SelectedItem = reader["SHIFT_START_TIME"].ToString();
                        cb_shift_end.SelectedItem = reader["SHIFT_END_TIME"].ToString();
                    }
                    else
                    {
                        cb_shift_start.SelectedItem = "00:00:00";
                        cb_shift_end.SelectedItem = "00:00:00";
                    }
                }
            }
            catch (Exception ex){  MessageBox.Show("Error: " + ex.Message);}
        }


        private void clearEmpData()
        {
            tb_firstname.Text = string.Empty;
            tb_middlename.Text = string.Empty;
            tb_lastname.Text = string.Empty;
            tb_email.Text = string.Empty;
            tb_phone.Text = string.Empty;
            date_bday.Value = DateTime.Now;
            tb_address.Text = string.Empty;
            rb_male.Checked = false;
            rb_female.Checked = false;
            date_hiredate.Value = DateTime.Now;
            cb_department.SelectedItem = null;
            cb_jobtitle.SelectedItem = null;
            cb_emptype.SelectedItem = null;
            cb_empstatus.SelectedItem = null;
            num_salary.Value = 0;
            pb_emppicture.Image = null;
            emppic = null;
        }
        void refresh_dgv()
        {
            connection.Open();
            string query = @"SELECT EMPLOYEE_ID AS 'Employee I.D.',
                    CONCAT(EMPLOYEE_LN, ', ', EMPLOYEE_FN, ' ', EMPLOYEE_MN) AS 'Full Name',
                    EMPLOYEE_EMAIL AS 'Email',
                    SEX AS 'Sex',
                    BIRTHDATE AS 'D.O.B',
                    PHONE AS 'Mobile No.',
                    ADDRESS AS 'Address',
                    HIRE_DATE AS 'Hire Date',
                    JOB_TITLE AS 'Position',
                    MONTHLY_SALARY AS 'Monthly Salary',
                    LEAVE_BAL AS 'Leaves',
                    EMPLOYMENT_TYPE AS 'Employment Type',
                    Status AS 'Status',
                    DEPARTMENT AS 'Department'
                    FROM employees
                    ORDER BY EMPLOYEE_ID DESC;";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dgvEmployeeList.DataSource = dataTable;
            connection.Close();
        }
        string sex;
        string picbase64;
        Image emppic = null;
        string imagebase64copy = null;
        private void btn_upload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog uploadImg = new OpenFileDialog())
            {
                uploadImg.Filter = "choose image(*.jpg;*.png;)|*.jpg;*.png";
                if (uploadImg.ShowDialog() == DialogResult.OK)
                {
                    emppic = Image.FromFile(uploadImg.FileName);
                    pb_emppicture.Image = emppic;
                }
            }
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            
            //check if any fields are empty1
            if (string.IsNullOrWhiteSpace(tb_employeeid.Text) || string.IsNullOrWhiteSpace(tb_firstname.Text) ||
        string.IsNullOrWhiteSpace(tb_middlename.Text) || string.IsNullOrWhiteSpace(tb_lastname.Text) ||
        string.IsNullOrWhiteSpace(tb_email.Text) || string.IsNullOrWhiteSpace(tb_phone.Text) ||
        string.IsNullOrWhiteSpace(tb_address.Text) || cb_department.SelectedIndex == -1 ||
        cb_jobtitle.SelectedIndex == -1 || cb_emptype.SelectedIndex == -1 || cb_empstatus.SelectedIndex == -1 ||
        string.IsNullOrWhiteSpace(num_salary.Text) || (!rb_male.Checked && !rb_female.Checked) ||
        cb_shift_start.SelectedIndex == -1 || cb_shift_end.SelectedIndex == -1 || cb_usertype.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill up the necessary information", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; // Stop execution if any field is empty
            }

            string empName = tb_firstname.Text + " " + tb_middlename.Text + " " + tb_lastname.Text;
            string QRdata = empName + ", " + cb_department.Text + ", " + tb_employeeid.Text;
            MySqlCommand cmd2;
            QRCodeGenerator generateQR = new QRCodeGenerator();
            QRCodeData data = generateQR.CreateQrCode(QRdata, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            Image qr = code.GetGraphic(10);

            MemoryStream stream = new MemoryStream();
            qr.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            string qrbase64 = Convert.ToBase64String(stream.ToArray());

            date_bday.CustomFormat = "yyyy-MM-dd";
            date_hiredate.CustomFormat = "yyyy-MM-dd";

            if(rb_male.Checked == true)
            {
                sex = "Male";
            }
            else if (rb_female.Checked == true)
            {
                sex = "Female";
            }



            if (pb_emppicture.Image != null)
            {
                MemoryStream ms2 = new MemoryStream();

                if (ms2.Length > 0)
                {
                    emppic = Image.FromStream(ms2);
                }
                emppic = pb_emppicture.Image;
            }
            else if (rb_male.Checked == true)
            {
                string path = @".\Avatars\Male.png";
                pb_emppicture.Image = Image.FromFile(path);
                emppic = pb_emppicture.Image;
            }
            else if (rb_female.Checked == true)
            {
                string path = @".\Avatars\Female.png";
                pb_emppicture.Image = Image.FromFile(path);
                emppic = pb_emppicture.Image;
            }
            
            MemoryStream ms = new MemoryStream();
            emppic.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            string picbase64 = Convert.ToBase64String(ms.ToArray());

            if (tb_employeeid.Text == "" || tb_firstname.Text == "" || tb_middlename.Text == "" || tb_lastname.Text == "" || tb_email.Text == "" || tb_phone.Text == "" || tb_address.Text == "" ||
                cb_department.SelectedIndex == -1 || cb_jobtitle.SelectedIndex == -1 || cb_emptype.SelectedIndex == -1 || cb_empstatus.SelectedIndex == -1 || num_salary.Text == "" ||
                (rb_male.Checked == false && rb_female.Checked == false) || cb_shift_start.SelectedIndex == -1 || cb_shift_end.SelectedIndex == -1 || cb_usertype.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill up the necessary information", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
               



            int usertype;
                if (cb_usertype.Text == "Admin")
                {
                    usertype = 0;
                }
                else
                {
                    usertype = 1;
                }
                int empid = int.Parse(tb_employeeid.Text);


                DateTime birthdate = date_bday.Value;
                DateTime currentDate = DateTime.Now;
                int age = currentDate.Year - birthdate.Year;

                // Check if the birthday hasn't happened yet this year
                if (birthdate > currentDate.AddYears(-age))
                {
                    age--;
                }

                string query = "INSERT INTO employees SET EMPLOYEE_ID=" + empid + ", EMPLOYEE_FN ='" + tb_firstname.Text + "', EMPLOYEE_MN='" + tb_middlename.Text + "', EMPLOYEE_LN='" + tb_lastname.Text + "', EMPLOYEE_EMAIL='" + tb_email.Text + "', SEX='" + sex + "', PHONE='" + tb_phone.Text + "', BIRTHDATE='" + date_bday.Value.ToString("yyyy-MM-dd") + "', AGE='" + age + "', ADDRESS='" + tb_address.Text + "', HIRE_DATE='" + date_hiredate.Value.ToString("yyyy-MM-dd") + "', DEPARTMENT='" + cb_department.Text + "', JOB_TITLE='" + cb_jobtitle.Text + "', EMPLOYMENT_TYPE='" + cb_emptype.Text + "', STATUS='" + cb_empstatus.Text + "', MONTHLY_SALARY='" + num_salary.Text + "', QR_CODE='" + qrbase64 + "', EMPLOYEE_IMAGE='" + picbase64 + "',LEAVE_BAL='15';" +
                    "INSERT INTO shift_schedule SET EMPLOYEE_ID=" + empid + ", SHIFT_START_TIME ='" + cb_shift_start.Text + "', SHIFT_END_TIME='" + cb_shift_end.Text + "';" +
                    "INSERT INTO user SET EMPLOYEE_ID=" + empid + ", USERNAME ='" + empid + "', PASSWORD='" + tb_lastname.Text + tb_firstname.Text + "', USER_TYPE=" + usertype + ";";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                connection.Close();
                MessageBox.Show("Added Successfully", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);


            refresh_dgv();
            clearEmpData();
            LoadData();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Image tempPic = pb_emppicture.Image;
            //check if any fields are empty
            if (string.IsNullOrWhiteSpace(tb_employeeid.Text) || string.IsNullOrWhiteSpace(tb_firstname.Text) ||
        string.IsNullOrWhiteSpace(tb_middlename.Text) || string.IsNullOrWhiteSpace(tb_lastname.Text) ||
        string.IsNullOrWhiteSpace(tb_email.Text) || string.IsNullOrWhiteSpace(tb_phone.Text) ||
        string.IsNullOrWhiteSpace(tb_address.Text) || cb_department.SelectedIndex == -1 ||
        cb_jobtitle.SelectedIndex == -1 || cb_emptype.SelectedIndex == -1 || cb_empstatus.SelectedIndex == -1 ||
        string.IsNullOrWhiteSpace(num_salary.Text) || (!rb_male.Checked && !rb_female.Checked) ||
        cb_shift_start.SelectedIndex == -1 || cb_shift_end.SelectedIndex == -1 || cb_usertype.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill up the necessary information", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return; // Stop execution if any field is empty
            }


            int empid = int.Parse(tb_employeeid.Text);
            string empName = tb_firstname.Text + " " + tb_middlename.Text + " " + tb_lastname.Text;
            string QRdata = empName + ", " + cb_department.Text + ", " + tb_employeeid.Text;
            string query2;
            MySqlCommand cmd2;
            QRCodeGenerator generateQR = new QRCodeGenerator();
            QRCodeData data = generateQR.CreateQrCode(QRdata, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            Image qr = code.GetGraphic(10);
           connection.Close();

            MemoryStream stream = new MemoryStream();
            qr.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            string qrbase64 = Convert.ToBase64String(stream.ToArray());
            string imagePath = pb_emppicture.ImageLocation;

            //If image is not uploaded
            if (pb_emppicture.Image == null)
            {
                if (rb_male.Checked == true)
                {
                    string path = @".\Avatars\Male.png";
                    pb_emppicture.Image = Image.FromFile(path);
                }
                else if (rb_female.Checked == true)
                {
                    string path = @".\Avatars\Female.png";
                    pb_emppicture.Image = Image.FromFile(path);
                }
            }
            if (rb_male.Checked == true)
            {
                pb_emppicture.Image = null;
                string path = @".\Avatars\Male.png";
                pb_emppicture.Image = Image.FromFile(path);
                sex = "Male";
            }
            else if (rb_female.Checked == true)
            {
                pb_emppicture.Image = null;
                string path = @".\Avatars\Female.png";
                pb_emppicture.Image = Image.FromFile(path);
                sex = "Female";
            }
            else
            {
                MemoryStream ms2 = new MemoryStream();
                
                    
                    if (ms2.Length > 0)
                    {
                        emppic = Image.FromStream(ms2);
                    }
                
            }

            MemoryStream ms = new MemoryStream();
            tempPic.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            string picbase64 = Convert.ToBase64String(ms.ToArray());

            DateTime birthdate = date_bday.Value;
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - birthdate.Year;

            // Check if the birthday hasn't happened yet this year
            if (birthdate > currentDate.AddYears(-age))
            {
                age--;
            }

            string query = "UPDATE employees SET EMPLOYEE_FN ='" + tb_firstname.Text + "', EMPLOYEE_MN='" + tb_middlename.Text + "', EMPLOYEE_LN='" + tb_lastname.Text + "', EMPLOYEE_EMAIL='" + tb_email.Text + "', SEX='" + sex + "', PHONE='" + tb_phone.Text + "', BIRTHDATE='" + date_bday.Value.ToString("yyyy-MM-dd") + "', AGE='" + age + "', ADDRESS='" + tb_address.Text + "', HIRE_DATE='" + date_hiredate.Value.ToString("yyyy-MM-dd") + "', DEPARTMENT='" + cb_department.Text + "', JOB_TITLE='" + cb_jobtitle.Text + "', EMPLOYMENT_TYPE='" + cb_emptype.Text + "', STATUS='" + cb_empstatus.Text + "', MONTHLY_SALARY='" + num_salary.Text + "', EMPLOYEE_IMAGE='" + picbase64 + "', QR_CODE='" + qrbase64 + "' WHERE EMPLOYEE_ID=" + empid + "; ";
            query += "UPDATE shift_schedule SET EMPLOYEE_ID = " + int.Parse(tb_employeeid.Text) + ", SHIFT_START_TIME = '" + cb_shift_start.Text + "', SHIFT_END_TIME = '" + cb_shift_end.Text + "' WHERE EMPLOYEE_ID = " + empid + ";";

            if (cb_usertype.Text == "Admin")
            {
                query += "UPDATE user SET USER_TYPE = 0 WHERE EMPLOYEE_ID=" + empid + ";";
            }
            else //if plain user
            {
                query += "UPDATE user SET USER_TYPE = 1 WHERE EMPLOYEE_ID=" + empid + ";";
            }

            connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Updated successfully!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            refresh_dgv();
            LoadData();
        }
        
        

        private void btn_resetpass_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(tb_employeeid.Text);
            string firstName = tb_firstname.Text;
            string lastName = tb_lastname.Text;
            string newPassword = lastName + firstName;

            DialogResult confirmReset = MessageBox.Show("Are you sure you want to reset the password?", "Confirmation Required", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmReset == DialogResult.Yes)
            {
                string connectionString = "server=localhost;database=atsdb;uid=root;password=";
                string query = "UPDATE user SET PASSWORD = @newPassword WHERE EMPLOYEE_ID = @empid";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@newPassword", newPassword);
                        command.Parameters.AddWithValue("@empid", empid);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Password reset successfully.");
                        }
                        catch (Exception ex){ MessageBox.Show("Error resetting password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);}
                    }
                }
            }
        }

    }
}
