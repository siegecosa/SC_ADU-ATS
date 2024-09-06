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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ATS
{
    public partial class admin_leave : Form
    {
        public admin_leave()
        {
            InitializeComponent();
            datagridleaves.DataBindingComplete += (sender, e) =>
            {
                // Make the columns aside from checkbox column readonly
                List<string> readOnlyColumns = new List<string>
                { "LEAVE_ID", "EMPLOYEE_ID", "LEAVE_TYPE", "LEAVE_STATUS", "LEAVE_DESC", "LEAVE_ATTACHMENT"};

                foreach (DataGridViewColumn column in datagridleaves.Columns)
                { if (readOnlyColumns.Contains(column.HeaderText)) { column.ReadOnly = true; } }
            };
        }

        // DB stuff starts here
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;


        private void admin_empmanagement_Load(object sender, EventArgs e)
        {
            cb_leavestatus.SelectedIndex = 0;
        }

        private void btn_admindashboard_Click(object sender, EventArgs e)
        {
            admin_dashboard nextForm = new admin_dashboard();
            nextForm.Show(); 
            this.Hide(); 
        }

        private void btn_employeemanagement_Click(object sender, EventArgs e)
        {
            admin_empmngmnt nextForm = new admin_empmngmnt();
            nextForm.Show(); 
            this.Hide(); 
        }

        private void btn_leavemanagement_Click(object sender, EventArgs e)
        {
            //stay
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
        private void View_Click(object sender, EventArgs e)
        {
           
        }

        private void cb_leavestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password=");
            dataTable = new DataTable();
            string selectedStatus = cb_leavestatus.SelectedItem.ToString();

            // Filter the DataGridView based on the selected status
            string selectQuery;
            if (selectedStatus == "All") { selectQuery = "SELECT LEAVE_ID as 'Leave I.D.', EMPLOYEE_ID as 'Employee I.D.', LEAVE_TYPE as 'Type', LEAVE_STATUS as 'Status', LEAVE_DESC as 'Description', LEAVE_ATTACHMENT as 'Attachment', START_DATE as 'Start Date', END_DATE as 'End Date' FROM leaves"; }
            else { selectQuery = "SELECT LEAVE_ID as 'Leave I.D.', EMPLOYEE_ID as 'Employee I.D.', LEAVE_TYPE as 'Type', LEAVE_STATUS as 'Status', LEAVE_DESC as 'Description', LEAVE_ATTACHMENT as 'Attachment', START_DATE as 'Start Date', END_DATE as 'End Date' FROM leaves WHERE LEAVE_STATUS = @status"; }

            try
            {
                connection.Open();
                command = new MySqlCommand(selectQuery, connection);
                if (selectedStatus != "All") {  command.Parameters.AddWithValue("@status", selectedStatus); }
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                datagridleaves.DataSource = dataTable;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { connection.Close(); }
        }

        private void btn_approve_Click(object sender, EventArgs e)
        {
            //CHECKBOX CHECKER HERE
            bool isAnyCheckBoxChecked = false;
            foreach (DataGridViewRow row in datagridleaves.Rows)
            {
                DataGridViewCheckBoxCell checkboxCell = row.Cells["checkbox1"] as DataGridViewCheckBoxCell;
                if (checkboxCell != null && checkboxCell.Value != null && (bool)checkboxCell.Value)
                {
                    isAnyCheckBoxChecked = true;
                    string leaveId = row.Cells["Leave I.D."].Value.ToString();
                    string employeeId = row.Cells["Employee I.D."].Value.ToString();
                    UpdateLeaveStatus(leaveId, employeeId, "Approved");
                }
            }

            if (isAnyCheckBoxChecked)
            {   MessageBox.Show("The selected leave/s have been approved!", "Approved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reloaddgv(); }
            else {
                MessageBox.Show("Please select at least one leave to approve by checking the box beside it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);}
        }


        private void btn_reject_Click(object sender, EventArgs e)
        {
            bool isAnyCheckBoxChecked = false;
            foreach (DataGridViewRow row in datagridleaves.Rows)
            {
                DataGridViewCheckBoxCell checkboxCell = row.Cells["checkbox1"] as DataGridViewCheckBoxCell;
                if (checkboxCell != null && checkboxCell.Value != null && (bool)checkboxCell.Value)
                {
                    isAnyCheckBoxChecked = true;

                    // Get the LEAVE_ID and EMPLOYEE_ID from the selected row
                    string leaveId = row.Cells["Leave I.D."].Value.ToString();
                    string employeeId = row.Cells["Employee I.D."].Value.ToString();

                    // Update the LEAVE_STATUS in the database
                    UpdateLeaveStatus(leaveId, employeeId, "Rejected");
                }
            }

            if (isAnyCheckBoxChecked)
            {   MessageBox.Show("Selected leave/s have been rejected.", "Rejected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reloaddgv(); }
            else { MessageBox.Show("Please select at least one leave to approve by checking the box beside it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void reloaddgv()
        {
            connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password=");
            dataTable = new DataTable();
            string selectedStatus = cb_leavestatus.SelectedItem.ToString();
            string selectQuery;
            if (selectedStatus == "All") { selectQuery = "SELECT LEAVE_ID as 'Leave I.D.', EMPLOYEE_ID as 'Employee I.D.', LEAVE_TYPE as 'Type', LEAVE_STATUS as 'Status', LEAVE_DESC as 'Description', LEAVE_ATTACHMENT as 'Attachment', START_DATE as 'Start Date', END_DATE as 'End Date' FROM leaves"; }
            else { selectQuery = "SELECT LEAVE_ID as 'Leave I.D.', EMPLOYEE_ID as 'Employee I.D.', LEAVE_TYPE as 'Type', LEAVE_STATUS as 'Status', LEAVE_DESC as 'Description', LEAVE_ATTACHMENT as 'Attachment', START_DATE as 'Start Date', END_DATE as 'End Date' FROM leaves WHERE LEAVE_STATUS = @status"; }
            try
            {
                connection.Open();
                command = new MySqlCommand(selectQuery, connection);
                if (selectedStatus != "All") { command.Parameters.AddWithValue("@status", selectedStatus); }
                adapter = new MySqlDataAdapter(command);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                datagridleaves.DataSource = dataTable;
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            finally { connection.Close(); }
        }

        private void UpdateLeaveStatus(string leaveId, string employeeId, string status)
        {
            using (MySqlConnection connection = new MySqlConnection("server=localhost;database=atsdb;uid=root;password="))
            {
                string updateQuery = "UPDATE leaves SET LEAVE_STATUS = @status WHERE LEAVE_ID = @leaveId AND EMPLOYEE_ID = @employeeId";
                using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@leaveId", leaveId);
                    command.Parameters.AddWithValue("@employeeId", employeeId);
                    try { connection.Open();  command.ExecuteNonQuery(); }
                    catch (Exception ex) {  MessageBox.Show("Error updating leave status: " + ex.Message); }
                }
            }
        }

        private void datagridleaves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                connection.Open();
                int clickableColumnIndex = 6;
                if (e.RowIndex >= 0 && e.ColumnIndex == clickableColumnIndex)
                {
                    DataGridViewCell cell = datagridleaves.Rows[e.RowIndex].Cells["Leave_ID"];
                    if (cell.Value != null && !DBNull.Value.Equals(cell.Value))
                    {
                        int leaveId = Convert.ToInt32(cell.Value);

                        string query = "SELECT LEAVE_ATTACHMENT FROM LEAVES WHERE LEAVE_ID = @leaveid";
                        using (MySqlCommand cmd = new MySqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@leaveid", leaveId);
                            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd))
                            {
                                DataTable dataTable = new DataTable();
                                dataAdapter.Fill(dataTable);

                                if (dataTable.Rows.Count > 0 && !Convert.IsDBNull(dataTable.Rows[0]["LEAVE_ATTACHMENT"]))
                                {
                                    admin_pdfviewer form = new admin_pdfviewer();
                                    
                                        form.Focus();
                                        form.Show();
                                        form.axAcroPDF1.src = Application.StartupPath + "\\PDF\\" + dataTable.Rows[0]["LEAVE_ATTACHMENT"].ToString();
                                    
                                }
                                else
                                {
                                    MessageBox.Show("No attachment attached.", "Empty Attachment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Leave ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
