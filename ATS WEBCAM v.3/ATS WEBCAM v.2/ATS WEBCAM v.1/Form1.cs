using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Threading;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace ATS_WEBCAM_v._1
{
    public partial class Form1 : Form
    {
        FilterInfoCollection filter;
        VideoCaptureDevice captureDevice;
        VideoCaptureDevice captureDevice2;
        MySqlConnection Con;
        MySqlCommand execsql;
        string sql;
        int attendanceIdCounter = 1;
        bool barcodeDetected = false;
        string employeeIdDetected = "";
        string name;
        string dept;
        int empid;
        DateTime currentTime = DateTime.Now;
        string formattedTime;

        public Form1()
        {
            InitializeComponent();
            currentTime = DateTime.Now;
            formattedTime = currentTime.ToString("HH:mm:ss");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filter)
            {
                comboBox1.Items.Add(filterInfo.Name);
            }
            comboBox1.SelectedIndex = 0;
            Con = new MySqlConnection();
            Con.ConnectionString = "server=localhost;user=root;password='';database=atsdb";
            employee_ID.Text = "EmployeeID ";
            time.Text = "Time";

        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Time_in.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void CaptureDevice_NewFrame2(object sender, NewFrameEventArgs eventArgs)
        {
            Time_out.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Time_in.Image != null && !barcodeDetected)
            {
                BarcodeReader barcode = new BarcodeReader();
                Result result = barcode.Decode((Bitmap)Time_in.Image);
                if (result != null)
                {
                    string[] textArray = result.ToString().Split(',');
                    if (textArray.Length >= 3)
                    {
                        name = textArray[0];
                        dept = textArray[1];
                        empid = int.Parse(textArray[2]);
                        employee_ID.Text = textArray[2];
                        employee_name.Text = textArray[0];  
                        time.Text = formattedTime;

                        employeeIdDetected = textArray[2];
                    }

                    else
                    {
                        MessageBox.Show("QR Code is Invalid. Please try again.");
                        closed();
                        this.Close();
                        Application.Restart();
                    }

                    try
                    {
                        Con.Open();
                        sql = "SELECT MAX(ATTENDANCE_ID) FROM attendance";
                        execsql = new MySqlCommand(sql, Con);
                        object maxAttendanceId = execsql.ExecuteScalar();
                        if (maxAttendanceId != DBNull.Value)
                        {
                            attendanceIdCounter = Convert.ToInt32(maxAttendanceId) + 1;
                        }
                        Con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        Con.Close();
                    }

                    try
                    {
                        Con.Open();

                        // Check if the employee has already timed in today
                        sql = "SELECT COUNT(*) FROM attendance WHERE EMPLOYEE_ID = @EMPLOYEE_ID AND ATTENDANCE_DATE = @ATTENDANCE_DATE AND TIME_IN IS NOT NULL";
                        execsql = new MySqlCommand(sql, Con);
                        execsql.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                        execsql.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                        int count = Convert.ToInt32(execsql.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("You have already Timed in");
                            Con.Close();
                            closed();
                            this.Close();
                            Application.Restart();
                            return;
                        }

                        // Insert a new row into the attendance table for the employee and date
                        sql = "INSERT INTO attendance (ATTENDANCE_ID, EMPLOYEE_ID, ATTENDANCE_DATE, TIME_IN) VALUES (@ATTENDANCE_ID, @EMPLOYEE_ID, @ATTENDANCE_DATE, @TIME_IN)";
                        execsql = new MySqlCommand(sql, Con);
                        execsql.Parameters.AddWithValue("@ATTENDANCE_ID", attendanceIdCounter);
                        execsql.Parameters.AddWithValue("@EMPLOYEE_ID", textArray[2]);
                        execsql.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                        execsql.Parameters.AddWithValue("@TIME_IN", DateTime.Now.TimeOfDay);
                        execsql.ExecuteNonQuery();

                        // Determine attendance status based on shift start time
                        // Get the employee's shift schedule for today
                        sql = "SELECT SHIFT_START_TIME, SHIFT_END_TIME FROM shift_schedule WHERE EMPLOYEE_ID = @EMPLOYEE_ID AND DATE(SHIFT_START_TIME) = @TODAY";
                        execsql = new MySqlCommand(sql, Con);
                        execsql.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                        execsql.Parameters.AddWithValue("@TODAY", DateTime.Now.Date);
                        MySqlDataReader readerSchedule = execsql.ExecuteReader();

                        if (readerSchedule.HasRows)
                        {
                            readerSchedule.Read();
                            TimeSpan shiftStartTime = readerSchedule.GetTimeSpan("SHIFT_START_TIME");
                            TimeSpan shiftEndTime = readerSchedule.GetTimeSpan("SHIFT_END_TIME");
                            readerSchedule.Close();

                            // Determine the attendance status based on the current time and shift start time
                            TimeSpan timeIn = DateTime.Now.TimeOfDay;
                            TimeSpan timeDifference = timeIn.Subtract(shiftStartTime);
                            string attendanceStatus = "";
                            if (timeDifference.TotalMinutes <= 15)
                            {
                                attendanceStatus = "Present";
                            }
                            else
                            {
                                attendanceStatus = "Late";
                            }

                            // Update the attendance record
                            sql = "UPDATE attendance SET ATTENDANCE_STATUS = @ATTENDANCE_STATUS, TIME_IN = @TIME_IN WHERE EMPLOYEE_ID = @EMPLOYEE_ID AND ATTENDANCE_DATE = @ATTENDANCE_DATE";
                            execsql = new MySqlCommand(sql, Con);
                            execsql.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                            execsql.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                            execsql.Parameters.AddWithValue("@ATTENDANCE_STATUS", attendanceStatus);
                            execsql.Parameters.AddWithValue("@TIME_IN", timeIn);
                            execsql.ExecuteNonQuery();

                            sql = "SELECT CONCAT(EMPLOYEE_FN,' ', EMPLOYEE_LN) AS 'ENAME', EMPLOYEE_IMAGE FROM employees WHERE EMPLOYEE_ID=" + employeeIdDetected;
                            execsql = new MySqlCommand(sql, Con);
                            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(execsql);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            MySqlDataReader dataReader = execsql.ExecuteReader();

                            if (dataReader.Read())
                            {
                                string base64String = (!Convert.IsDBNull(dataReader["EMPLOYEE_IMAGE"])) ? dataReader["EMPLOYEE_IMAGE"].ToString() : "";
                                byte[] imageBytes = Convert.FromBase64String(base64String);
                                MemoryStream stream = new MemoryStream(imageBytes);
                                employee_picture.Image = Image.FromStream(stream);

                                employee_name.Text = (!Convert.IsDBNull(dataReader["ENAME"])) ? dataReader["ENAME"].ToString() : "";
                            }

                            lbl_time.Text = "Time in:";

                            display_eDetails();

                            //MessageBox.Show("Timed in. " + textArray[2]);
                        }
                        else
                        {
                            readerSchedule.Close();
                            MessageBox.Show("Employee has no shift schedule for today. " + employeeIdDetected);
                        }
                        Con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        Con.Close();
                    }

                }
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            closed();
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Time_out.Image != null && !barcodeDetected)
            {
                BarcodeReader barcode = new BarcodeReader();
                Result result = barcode.Decode((Bitmap)Time_out.Image);
                if (result != null)
                {
                    string[] textArray = result.ToString().Split(',');
                    if (textArray.Length >= 3)
                    {
                        name = textArray[0];
                        dept = textArray[1];
                        empid = int.Parse(textArray[2]);
                        employee_ID.Text = textArray[2];
                        time.Text = formattedTime;
                        employee_name.Text = textArray[0];
                        lbl_time.Text = "Time out:";
                        display_eDetails();
                        employeeIdDetected = textArray[2];
                    }
                    else
                    {
                        MessageBox.Show("QR Code is Invalid. Please try again.");
                        closed();
                        this.Close();
                        Application.Restart();
                    }

                    try
                    {
                        Con.Open();

                        // Check if the employee has already timed out today
                        sql = "SELECT COUNT(*) FROM attendance WHERE EMPLOYEE_ID = @EMPLOYEE_ID AND ATTENDANCE_DATE = @ATTENDANCE_DATE AND TIME_OUT IS NOT NULL";
                        execsql = new MySqlCommand(sql, Con);
                        execsql.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                        execsql.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                        int count = Convert.ToInt32(execsql.ExecuteScalar());
                        if (count > 0)
                        {
                            // Employee has already timed out today, do nothing
                            MessageBox.Show("You have already timed out today");
                            Con.Close();
                            closed();
                            this.Close();
                            Application.Restart();
                            return;
                        }

                        sql = "SELECT COUNT(*) FROM attendance WHERE EMPLOYEE_ID = @EMPLOYEE_ID AND ATTENDANCE_DATE = @ATTENDANCE_DATE AND TIME_OUT IS NULL";
                        execsql = new MySqlCommand(sql, Con);
                        execsql.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                        execsql.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                        count = Convert.ToInt32(execsql.ExecuteScalar());
                        if (count == 0)
                        {
                            // Employee has timed out without timing in
                            MessageBox.Show("You have timed out without timing in");
                            Con.Close();
                            return;
                        }

                        sql = "UPDATE attendance SET TIME_OUT = @TIME_OUT WHERE EMPLOYEE_ID = @EMPLOYEE_ID AND ATTENDANCE_DATE = @ATTENDANCE_DATE AND TIME_OUT IS NULL";
                        MySqlCommand updateTimeoutCmd = new MySqlCommand(sql, Con);
                        updateTimeoutCmd.Parameters.AddWithValue("@TIME_OUT", DateTime.Now.TimeOfDay);
                        updateTimeoutCmd.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                        updateTimeoutCmd.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                        updateTimeoutCmd.ExecuteNonQuery();

                        // Fetch attendance details
                        sql = "SELECT a.TIME_IN, a.TIME_OUT, s.SHIFT_START_TIME, s.SHIFT_END_TIME FROM attendance a JOIN shift_schedule s ON a.ATTENDANCE_ID = s.SCHEDULE_ID WHERE a.EMPLOYEE_ID = @EMPLOYEE_ID AND a.ATTENDANCE_DATE = @ATTENDANCE_DATE";
                        MySqlCommand selectAttendanceCmd = new MySqlCommand(sql, Con);
                        selectAttendanceCmd.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                        selectAttendanceCmd.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                        MySqlDataReader reader = selectAttendanceCmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            TimeSpan timeIn = reader.GetTimeSpan("TIME_IN");
                            TimeSpan timeOut = reader.GetTimeSpan("TIME_OUT");
                            TimeSpan workHoursTime = timeOut.Subtract(timeIn);
                            TimeSpan shiftStartTime = reader.GetTimeSpan("SHIFT_START_TIME");
                            TimeSpan shiftEndTime = reader.GetTimeSpan("SHIFT_END_TIME");
                            reader.Close();

                            // Update the work hours time
                            sql = "UPDATE attendance SET WORK_HOURS_TIME = @WORK_HOURS_TIME WHERE EMPLOYEE_ID = @EMPLOYEE_ID AND ATTENDANCE_DATE = @ATTENDANCE_DATE AND TIME_OUT IS NOT NULL";
                            execsql = new MySqlCommand(sql, Con);
                            execsql.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                            execsql.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                            execsql.Parameters.AddWithValue("@WORK_HOURS_TIME", workHoursTime.ToString("hh\\:mm\\:ss"));
                            execsql.ExecuteNonQuery();

                            string shiftScheduleSql = "SELECT SHIFT_END_TIME FROM shift_schedule WHERE EMPLOYEE_ID = @EMPLOYEE_ID";
                            execsql = new MySqlCommand(shiftScheduleSql, Con);
                            execsql.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                            MySqlDataReader shiftReader = execsql.ExecuteReader();
                            if (shiftReader.Read())
                            {
                                shiftReader.Close();

                                TimeSpan workDuration = timeOut.Subtract(timeIn);

                                // Check the work duration and update the WORK_HOURS_STATUS accordingly
                                if (workDuration >= new TimeSpan(8, 30, 0))
                                {
                                    // Overtime
                                    sql = "UPDATE attendance SET WORK_HOURS_STATUS = 'Overtime' WHERE EMPLOYEE_ID = @EMPLOYEE_ID AND ATTENDANCE_DATE = @ATTENDANCE_DATE AND TIME_OUT IS NOT NULL";
                                    execsql = new MySqlCommand(sql, Con);
                                    execsql.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                                    execsql.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                                    execsql.ExecuteNonQuery();
                                }
                                else if (workDuration >= new TimeSpan(7, 45, 0) && workDuration <= new TimeSpan(8, 15, 0))
                                {
                                    // On-time
                                    sql = "UPDATE attendance SET WORK_HOURS_STATUS = 'On-time' WHERE EMPLOYEE_ID = @EMPLOYEE_ID AND ATTENDANCE_DATE = @ATTENDANCE_DATE AND TIME_OUT IS NOT NULL";
                                    execsql = new MySqlCommand(sql, Con);
                                    execsql.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                                    execsql.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                                    execsql.ExecuteNonQuery();
                                }
                                else
                                {
                                    // Undertime
                                    sql = "UPDATE attendance SET WORK_HOURS_STATUS = 'Undertime' WHERE EMPLOYEE_ID = @EMPLOYEE_ID AND ATTENDANCE_DATE = @ATTENDANCE_DATE AND TIME_OUT IS NOT NULL";
                                    execsql = new MySqlCommand(sql, Con);
                                    execsql.Parameters.AddWithValue("@EMPLOYEE_ID", employeeIdDetected);
                                    execsql.Parameters.AddWithValue("@ATTENDANCE_DATE", DateTime.Now.Date);
                                    execsql.ExecuteNonQuery();
                                }
                            }

                            sql = "SELECT CONCAT(EMPLOYEE_FN, ' ', EMPLOYEE_LN) AS 'ENAME', EMPLOYEE_IMAGE FROM employees WHERE EMPLOYEE_ID=" + employeeIdDetected;
                            execsql = new MySqlCommand(sql, Con);
                            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(execsql);
                            DataTable dataTable = new DataTable();
                            dataAdapter.Fill(dataTable);
                            MySqlDataReader dataReader = execsql.ExecuteReader();

                            if (dataReader.Read())
                            {
                                string base64String = (!Convert.IsDBNull(dataReader["EMPLOYEE_IMAGE"])) ? dataReader["EMPLOYEE_IMAGE"].ToString() : "";
                                byte[] imageBytes = Convert.FromBase64String(base64String);
                                MemoryStream stream = new MemoryStream(imageBytes);
                                employee_picture.Image = Image.FromStream(stream);

                                employee_name.Text = (!Convert.IsDBNull(dataReader["ENAME"])) ? dataReader["ENAME"].ToString() : "";
                            }

                            lbl_time.Text = "Time out:";

                            display_eDetails();

                            //MessageBox.Show("Timed Out. " + textArray[2]);
                        }
                        else
                        {
                            reader.Close();
                        }

                        Con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        Con.Close();
                    }
                }
            }
        }

        private void timein_Click(object sender, EventArgs e)
        {
            captureDevice = new VideoCaptureDevice(filter[comboBox1.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            Time_in.Enabled = true;
            Time_in.Visible = true;
            timer1.Start();
        }

        private void timeout_Click(object sender, EventArgs e)
        {
            captureDevice2 = new VideoCaptureDevice(filter[comboBox1.SelectedIndex].MonikerString);
            captureDevice2.NewFrame += CaptureDevice_NewFrame2;
            captureDevice2.Start();
            Time_out.Enabled = true;
            Time_out.Visible = true;
            Time_out.BringToFront();
            Time_in.SendToBack();
            timer2.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closed();
        }

        private void closed()
        {
            if (captureDevice != null && captureDevice.IsRunning)
            {
                captureDevice.SignalToStop();
                captureDevice.WaitForStop();
            }

            if (captureDevice2 != null && captureDevice2.IsRunning)
            {
                captureDevice2.SignalToStop();
                captureDevice2.WaitForStop();
            }
        }

        private void display_eDetails()
        {
            Details.Visible = true;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 5000;

            timer.Tick += (s, args) =>
            {
                Details.Visible = false;
                timer.Stop();
                timer.Dispose();
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    closed();
                    this.Close();
                    Application.Restart();
                }
                else if (timer2.Enabled)
                {
                    timer2.Stop();
                    closed();
                    this.Close();
                    Application.Restart();
                }
            };

            timer.Start();
        }

    }
}
