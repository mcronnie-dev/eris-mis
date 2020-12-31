using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERIS_MIS.Config;


namespace ERIS_MIS.Forms
{
    public partial class frmSettingsAddAY : Form
    {
        
        MySqlConnection mySqlConnection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        string _title = "Enrollment Settings";
        //public static string previousAcademicYear = "";//new
        SystemGeneralData data = new SystemGeneralData();

        public frmSettingsAddAY()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Save Academic Year? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               
                try
                {
                    string startyear = "";
                    if (mySqlConnection.State != ConnectionState.Open)
                    {
                        mySqlConnection.Open();
                    }
                    string query1 = "SELECT start_year FROM table_sy  WHERE start_year = '" + startYear.Text + "' ";
                    command = new MySqlCommand(query1, mySqlConnection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        startyear = Convert.ToString(reader.GetString("start_year"));
                    }
                    mySqlConnection.Close();

                    if (startyear == startYear.Text)
                    {
                        MessageBox.Show("Duplicate Academic Year");
                    }
                    else
                    {   
                        data.setPreviousAcademicYear();
                        data.SetActiveAcademicYearID(startYear.Text, endYear.Text, startMonthdateTimePicker3.Text, endMonthdateTimePicker4.Text);
                        data.SetStudentFileStatus();
                        data.SetActiveGradingPeriodID(true);
                        

                        }

                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Current academic year is not changed", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update ? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(startYear.Text) && !string.IsNullOrEmpty(endYear.Text) && !string.IsNullOrEmpty(startMonthdateTimePicker3.Text) && !string.IsNullOrEmpty(endMonthdateTimePicker4.Text))
                {
                    try
                    {
                        MessageBox.Show("" + startYear.Text);
                        MessageBox.Show(endYear.Text);
                        MessageBox.Show(startMonthdateTimePicker3.Text);
                        MessageBox.Show(endMonthdateTimePicker4.Text);
                        if (mySqlConnection.State != ConnectionState.Open)
                        {
                            mySqlConnection.Open();
                        }
                        string query = "INSERT INTO table_sy " +
                                 "(start_year, end_year, start_month, end_month, status) " +
                                 "VALUES (@start_year,  @end_year,@start_month, @end_month, @status) ";

                        command = new MySqlCommand(query, mySqlConnection);
                        command.Parameters.AddWithValue("@start_year", startYear.Text);
                        command.Parameters.AddWithValue("@end_year", endYear.Text);
                        command.Parameters.AddWithValue("@start_month", startMonthdateTimePicker3.Text);
                        command.Parameters.AddWithValue("@end_month", endMonthdateTimePicker4.Text);
                        command.Parameters.AddWithValue("@status", 1);
                        command.ExecuteNonQuery();

                        mySqlConnection.Close();

                        MessageBox.Show("Record has been updated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("All fields must be filled out");

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

        private void frmSettingsAddAY_Load(object sender, EventArgs e)
        {
            SystemGeneralData data = new SystemGeneralData();
            string lastStartYear = data.GetEndYear();
            int lastStartYear1;
            int.TryParse(lastStartYear, out lastStartYear1);
            int startyear = lastStartYear1 + 1;
            startYear.Text = startyear.ToString();

            int endyear = startyear + 1;
            endYear.Text = endyear.ToString();

           
            startMonthdateTimePicker3.Format = DateTimePickerFormat.Custom;
            startMonthdateTimePicker3.CustomFormat = "MM";
            startMonthdateTimePicker3.MinDate = DateTime.Today;
            startMonthdateTimePicker3.Value = DateTime.Now;
            startMonthdateTimePicker3.ShowUpDown = true;

            endMonthdateTimePicker4.Format = DateTimePickerFormat.Custom;
            endMonthdateTimePicker4.CustomFormat = "MM";
            endMonthdateTimePicker4.Value = DateTime.Now.AddMonths(11);
            endMonthdateTimePicker4.ShowUpDown = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void startYear_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
