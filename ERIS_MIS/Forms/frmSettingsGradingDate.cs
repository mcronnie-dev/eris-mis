﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERIS_MIS.Config;


namespace ERIS_MIS.Forms
{
    public partial class frmSettingsGradingDate : Form
    {
        
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        //MySqlCommand command;

        SystemGeneralData data = new SystemGeneralData();


        DateTime now = DateTime.Now;
        DateTime startGradingDate;
        DateTime endGradingDate;
        private string _title = "Set Date of Encoding";

        public frmSettingsGradingDate()
        {
            InitializeComponent();
        }

        private void frmSettingsGradingDate_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void LoadControls() {
            startGradingDatePicker.Format = DateTimePickerFormat.Short;
            startGradingDatePicker.Value = DateTime.Today;

            endGradingDatePicker.Format = DateTimePickerFormat.Short;
            endGradingDatePicker.Value = DateTime.Today;

            label5.Text = data.GetActiveGradingPeriod();
            gradingPeriodComboBox.Text = data.GetActiveGradingPeriod();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            data.SetIsGradeEncodingActive(now, startGradingDate, endGradingDate, gradingPeriodComboBox.Text);

            if (gradingPeriodComboBox.Text == "1st")
            {
                gradingPeriodComboBox.Items.Clear();
                gradingPeriodComboBox.Items.Add("1st");
                gradingPeriodComboBox.Items.Add("2nd");
            }
            else if (gradingPeriodComboBox.Text == "2nd")
            {
                gradingPeriodComboBox.Items.Clear();
                gradingPeriodComboBox.Items.Add("1st");
                gradingPeriodComboBox.Items.Add("2nd");
                gradingPeriodComboBox.Items.Add("3rd");
            }
            else if (gradingPeriodComboBox.Text == "3rd")
            {
                gradingPeriodComboBox.Items.Clear();
                gradingPeriodComboBox.Items.Add("1st");
                gradingPeriodComboBox.Items.Add("2nd");
                gradingPeriodComboBox.Items.Add("3rd");
                gradingPeriodComboBox.Items.Add("4th");
            }
            else
            {
                gradingPeriodComboBox.Items.Clear();
                gradingPeriodComboBox.Items.Add("1st");
                gradingPeriodComboBox.Items.Add("2nd");
                gradingPeriodComboBox.Items.Add("3rd");
                gradingPeriodComboBox.Items.Add("4th");
            }

            LoadControls();


            //System.TimeSpan diff = endGradingDate.Subtract(startGradingDate);
            //System.TimeSpan diff1 = endGradingDate - startGradingDate;
            //String diff2 = (endGradingDate - startGradingDate).TotalDays.ToString();
            //while (diff2 == DateTime.MinValue.ToString()) {
            //    MessageBox.Show(diff1.ToString());


        }
       


        

        private void startGradingDatePicker_ValueChanged_1(object sender, EventArgs e)
        {
            startGradingDate = startGradingDatePicker.Value;
        }

        private void endGradingDatePicker_ValueChanged_1(object sender, EventArgs e)
        {
            endGradingDate = endGradingDatePicker.Value;
        }

        private void frmSettingsGradingDate_Load_1(object sender, EventArgs e)
        {
            label5.Text = data.GetActiveGradingPeriod();
            gradingPeriodComboBox.Text = data.GetActiveGradingPeriod();

            if (data.GetActiveGradingPeriodID() == 1)
            {
                gradingPeriodComboBox.Items.Clear();
                gradingPeriodComboBox.Items.Add(data.GetActiveGradingPeriod());
            }
            else if (data.GetActiveGradingPeriodID() == 2)
            {
                gradingPeriodComboBox.Items.Clear();
                gradingPeriodComboBox.Items.Add("1st");
                gradingPeriodComboBox.Items.Add(data.GetActiveGradingPeriod());
            }
            else if (data.GetActiveGradingPeriodID() == 3)
            {
                gradingPeriodComboBox.Items.Clear();
                gradingPeriodComboBox.Items.Add("1st");
                gradingPeriodComboBox.Items.Add("2nd");
                gradingPeriodComboBox.Items.Add(data.GetActiveGradingPeriod());  
            }
            else if (data.GetActiveGradingPeriodID() == 4)
            {
                gradingPeriodComboBox.Items.Clear();
                gradingPeriodComboBox.Items.Add("1st");
                gradingPeriodComboBox.Items.Add("2nd");
                gradingPeriodComboBox.Items.Add("3rd");
                gradingPeriodComboBox.Items.Add(data.GetActiveGradingPeriod());
            }
        }

        private void gradingPeriodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
                {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
               
                string cmd = "SELECT table_grade_encoding.start_date, table_grade_encoding.end_date FROM table_grade_encoding INNER JOIN table_grading_period ON table_grade_encoding.grading_period_id =table_grading_period.grading_period_id WHERE table_grading_period.grading_period ='"+gradingPeriodComboBox.Text+"' AND table_grade_encoding.sy_id = '"+data.GetActiveAcademicYearID()+"'";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    startGradingDate = Convert.ToDateTime(reader.GetString("start_date"));
                    endGradingDate = Convert.ToDateTime(reader.GetString("end_date"));

                }
                

                if (reader.HasRows)
                {
                    
                    startGradingDatePicker.Value = startGradingDate;
                    endGradingDatePicker.Value = endGradingDate;
                    
                }
                else {
                    startGradingDatePicker.Value = DateTime.Now;
                    endGradingDatePicker.Value = DateTime.Now;
                }

                reader.Close();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
