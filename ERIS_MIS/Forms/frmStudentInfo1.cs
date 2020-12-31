using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ERIS_MIS.Config;


namespace ERIS_MIS.Forms
{
    public partial class frmStudentInfo1 : Form
    {
        string _title = "ERIS MIS";
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;
        SystemGeneralData data = new SystemGeneralData();

        public frmStudentInfo1()
        {
            InitializeComponent();
        }

       

        private void frmEnrollmentStudentInfo_Load(object sender, EventArgs e)
        {
            studnoLabel.Focus();


            FillCityCombobox();
            bdayDateTimePicker.Value = DateTime.Today;
            this.AutoScroll = false;
            this.VerticalScroll.Value = 0;
            this.HorizontalScroll.Visible = false;
            this.HorizontalScroll.Enabled = false;
            this.AutoScroll = true;
            //panel3.Hide();
            //openPanel();


            //saveEnrollment();
            bdayDateTimePicker.MinDate = new DateTime(1900, 1, 1);
            bdayDateTimePicker.MaxDate = new DateTime(2010, 1, 1);
            bdayDateTimePicker.Value = new DateTime(2010, 1, 1);

           
            

        }
       



        
        private void updateData()
        {
            int form9 = 0,
           form10 = 0,
           psa = 0,
           gmc = 0;
            string birthDay = (bdayDateTimePicker.Value).ToShortDateString();
            string sex = "";
            if (maleRadioButton.Checked == true)
            {
                sex = "Male";
            }
            else
            {
                sex = "Female";
            }
            //Form 138-A
            if (form138CheckBox.Checked == true)
                form9 = 1;
            else
                form9 = 0;

            //Form 137-A
            if (form137CheckBox.Checked == true)
            {
                form10 = 1;
            }
                
            else
            {
                form10 = 0;
            }
            //PSA Clearance
            if (clearanceCheckBox.Checked == true)
            {
                psa = 1; ;
            }
                
            else
            {

                psa = 0;
            }

            //Good Morla Envelope
            if (envelopeCheckBox.Checked == true)
            {
                gmc = 1;
            }
                
            else
            {
                gmc = 0;
            }
                
            try
            {
                if (MessageBox.Show("Update Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    MySqlCommand command = new MySqlCommand("UPDATE table_students SET last_name=@last_name, first_name=@first_name, middle_name=@middle_name, date_of_birth=@date_of_birth, age=@age, sex=@sex," +
                        "house_no=@house_no, street=@street, city=@city, zip=@zip, father_name=@father_name, father_mobile=@father_mobile, father_occupation=@father_occupation, mother_name=@mother_name, mother_mobile=@mother_mobile, " +
                        "mother_occupation=@mother_occupation, guardian_name=@guardian_name, guardian_mobile=@guardian_mobile, guardian_occupation=@guardian_occupation, psa=@psa, good_moral=@good_moral, form9=@form9, form10=@form10, " +
                        "last_grade=@last_grade, last_school=@last_school, last_school_address=@last_school_address, last_sy=@last_sy, last_school_id=@last_school_id  WHERE student_no=@student_no", connection);
                    
                    command.Parameters.AddWithValue("@last_name", lastNameTextBox.Text);
                    command.Parameters.AddWithValue("@first_name", firstNameTextBox.Text);
                    command.Parameters.AddWithValue("@middle_name", middleNameTextBox.Text);
                    command.Parameters.AddWithValue("@student_no", studnoLabel.Text);
                    command.Parameters.AddWithValue("@date_of_birth", birthDay);
                    command.Parameters.AddWithValue("@age", ageLabel.Text);
                    command.Parameters.AddWithValue("@sex", sex);
                    command.Parameters.AddWithValue("@house_no", houseNoTextBox.Text);
                    command.Parameters.AddWithValue("@street", streetTextBox.Text);
                    command.Parameters.AddWithValue("@barangay", barangayTextBox.Text);
                    command.Parameters.AddWithValue("@city", cityCombobox.Text);
                    command.Parameters.AddWithValue("@zip", zipCombobox.Text);
                    command.Parameters.AddWithValue("@father_name", fatherNameTextBox.Text);
                    command.Parameters.AddWithValue("@father_mobile", fatherOccupationTextBox.Text);
                    command.Parameters.AddWithValue("@father_occupation", fatherContactTextBox.Text);
                    command.Parameters.AddWithValue("@mother_name", motherNameTextBox.Text);
                    command.Parameters.AddWithValue("@mother_mobile", motherContactTextBox.Text);
                    command.Parameters.AddWithValue("@mother_occupation", motherOccupationTextBox.Text);
                    command.Parameters.AddWithValue("@guardian_name", guardianNameTextBox.Text);
                    command.Parameters.AddWithValue("@guardian_mobile", guardianContactTextBox.Text);
                    command.Parameters.AddWithValue("@guardian_occupation", guardianOccupationTextBox.Text);
                    command.Parameters.AddWithValue("@psa", psa);
                    command.Parameters.AddWithValue("@good_moral", gmc);
                    command.Parameters.AddWithValue("@form9", form9);
                    command.Parameters.AddWithValue("@form10", form10);
                    command.Parameters.AddWithValue("@last_grade", lastGrade.Text);
                    command.Parameters.AddWithValue("@last_school", schoolName.Text);
                    command.Parameters.AddWithValue("@last_school_address", schoolAddress.Text);
                    command.Parameters.AddWithValue("@last_sy", lastSY.Text);
                    command.Parameters.AddWithValue("@last_school_id", schoolId.Text);
                    command.ExecuteNonQuery();
                    connection.Close();

                   
                    MessageBox.Show("Record has been updated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //string query = $"SELECT student_id from table_students WHERE student_no = {studnoLabel.Text}";
                    //GetStudId(query);


                    

                }
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
       
        private void bdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            String age = (DateTime.Today - bdayDateTimePicker.Value).TotalDays.ToString();
            int ageInt = int.Parse(age) / 365;
            ageLabel.Text = ageInt.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }


      

       
        private void button9_Click(object sender, EventArgs e)
        {
            updateData();



        }
        string city;
        private void cityTextbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM table_city INNER JOIN table_zip_code ON table_city.city_id = table_zip_code.city_id WHERE name='" + cityCombobox.Text + "'";
            FillCombobox(query);
            if (!string.IsNullOrEmpty(cityCombobox.Text))
            {
                zipCombobox.Enabled = true;
            }

            
        }

        protected void FillCombobox(string query)
        {

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                zipCombobox.Items.Clear();
                while (reader.Read())
                {
                    zipCombobox.Items.Add(reader.GetString("zip_code"));
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FillCityCombobox()
        {
            try
            {
                if (connection.State != ConnectionState.Open) { 
                    connection.Open();
                }
                string query = "SELECT name from table_city ";
                command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                cityCombobox.Items.Clear();
                while (reader.Read())
                {
                    cityCombobox.Items.Add(reader.GetString("name"));

                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

       
       
       

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void elemNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void zipCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void FillCombobox1(string query)
        {

            try
            {
                
                command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                zipCombobox.Items.Clear();
                while (reader.Read())
                {
                    zipCombobox.Items.Add(reader.GetString("zip_code"));
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }
       

        

        


    }
}
