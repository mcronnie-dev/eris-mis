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
using ERIS_MIS.Config;


namespace ERIS_MIS.Forms
{
    public partial class frmEnrollmentInfo : Form
    {
        MySqlConnection mySqlConnection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;

        //variables
        private string levelSectionID = "";
        private string schoolYear = "2020";
        string _title = "Enrollment Settings";
        
      


        public frmEnrollmentInfo()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void GradeLevelComboBox()
        {
            gradeLevelComboBox.Items.Add("Grade 7");
            gradeLevelComboBox.Items.Add("Grade 8");
            gradeLevelComboBox.Items.Add("Grade 9");
            gradeLevelComboBox.Items.Add("Grade 10");

        }
        private void frmEnrollmentInfo_Load(object sender, EventArgs e)
        {
           
            GradeLevelComboBox();
            updateButton.Enabled = false;
            maxStudentsTextBox.Enabled = false;

        }

        //To Load the Grade_Level and Section of the teacher_adviser
        private void LoadGradeLevelAndSection()
        {

            try
            {

                if (mySqlConnection.State != ConnectionState.Open)
                {
                    mySqlConnection.Open();
                }
                //WHERE table_grade_level.grade_level = '" + gradeLevelComboBox.Text + "' AND table_level_section.section = '" + sectionComboBox.Text + "'
                string query = "Select DISTINCT table_grade_level.grade_level, table_level_section.section FROM table_level_section INNER JOIN table_grade_level ON table_grade_level.grade_level_id = table_level_section.grade_level_id  ";
                command = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();
                gradeLevelComboBox.Items.Clear();
                sectionComboBox.Items.Clear();
                while (reader.Read())
                {
                    gradeLevelComboBox.Items.Add(reader.GetString("grade_level"));
                    sectionComboBox.Items.Add(reader.GetString("section"));
                }

                mySqlConnection.Close();
                sectionComboBox.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void sectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetLevelSectionID();
        }

        private void GetLevelSectionID()
        {
            if (mySqlConnection.State != ConnectionState.Open)
            {
                mySqlConnection.Open();
            }
            string query = "SELECT table_level_section.level_section_id  FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id  WHERE table_grade_level.grade_level = '" + gradeLevelComboBox + "' AND table_level_section.section = '" + sectionComboBox.Text + "'";
            command = new MySqlCommand(query, mySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                levelSectionID = Convert.ToString(reader.GetString("level_section_id"));
            }
            mySqlConnection.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void gradeLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            sectionComboBox.Enabled = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Update Max Enrollees? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (mySqlConnection.State != ConnectionState.Open)
                    {
                        mySqlConnection.Open();
                    }
                    MySqlCommand command = new MySqlCommand("UPDATE table_enrollment_settings SET max_students=@max_students WHERE enrollment_settings_id=@enrollment_settings_id", mySqlConnection);

                    command.Parameters.AddWithValue("@max_students", maxStudentsTextBox.Text);
                    command.Parameters.AddWithValue("@enrollment_settings_id", enrollmentSettingsNo.Text);
                   
                    command.ExecuteNonQuery();
                    mySqlConnection.Close();

                    MessageBox.Show("Max Enrollees has been updated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                mySqlConnection.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void gradeLevelComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            maxStudentsTextBox.Clear();
            maxStudentsTextBox.Enabled = false;
            updateButton.Enabled = false;

            string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
               "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
               "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
               "WHERE table_sy.status = '1' AND grade_level='" + gradeLevelComboBox.Text + "'";

            //string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + comboBox1.Text + "'";
            FillCombobox(query);
            if (!string.IsNullOrEmpty(sectionComboBox.Text))
            {
                sectionComboBox.Enabled = true;
            }
        }
        protected void FillCombobox(string query)
        {

            try
            {
                if (mySqlConnection.State != ConnectionState.Open)
                {
                    mySqlConnection.Open();
                }
                command = new MySqlCommand(query, mySqlConnection);
                MySqlDataReader reader = command.ExecuteReader();
                sectionComboBox.Items.Clear();
                while (reader.Read())
                {
                    sectionComboBox.Items.Add(reader.GetString("section"));
                }
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void sectionComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            maxStudentsTextBox.Clear();
            maxStudentsTextBox.Enabled = true;
            updateButton.Enabled = true;


            if (mySqlConnection.State != ConnectionState.Open)
            {
                mySqlConnection.Open();
            }
            string query = "Select * from table_enrollment_settings INNER JOIN table_level_section  ON table_enrollment_settings.level_section_id = table_level_section.level_section_id  " +
             "WHERE table_level_section.section ='" + sectionComboBox.Text + "'";
            command = new MySqlCommand(query, mySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                maxStudentsTextBox.Text = (reader.GetString("max_students"));
                enrollmentSettingsNo.Text = (reader.GetString("enrollment_settings_id"));
            }
            mySqlConnection.Close();

        }

       
       

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
