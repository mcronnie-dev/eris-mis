using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERIS_MIS.UserControls;
using ERIS_MIS.Forms;
using MySql.Data.MySqlClient;
using ERIS_MIS.Config;


namespace ERIS_MIS.Forms
{
    public partial class frmFacultyInfo1 : Form
    {
        string _title = "ERIS MIS";
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;

        public frmFacultyInfo1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            this.Dispose();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
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
            try
            {
                if (MessageBox.Show("Update Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    command = new MySqlCommand("UPDATE table_teacher SET last_name=@last_name, first_name=@first_name, middle_name=@middle_name, teacher_no=@teacher_no, house_no=@house_no, street=@street, barangay=@barangay, zip_code=@zip_code, " +
                        " city_address=@city_address, date_of_birth=@date_of_birth, age=@age, sex=@sex, teacher_mobile=@teacher_mobile, teacher_email=@teacher_email WHERE teacher_no=@teacher_no", connection);
                    command.Parameters.AddWithValue("@last_name", lastNameTextBox.Text);
                    command.Parameters.AddWithValue("@first_name", firstNameTextBox.Text);
                    command.Parameters.AddWithValue("@middle_name", middleNameTextBox.Text);
                    command.Parameters.AddWithValue("@teacher_no", teacherNolabel.Text);
                    command.Parameters.AddWithValue("@house_no", lastNameTextBox.Text);
                    command.Parameters.AddWithValue("@street", firstNameTextBox.Text);
                    command.Parameters.AddWithValue("@barangay", middleNameTextBox.Text);
                    command.Parameters.AddWithValue("@zip_code", zipCombobox.Text);
                    command.Parameters.AddWithValue("@city_address", cityCombobox.Text);
                    command.Parameters.AddWithValue("@date_of_birth", birthDay);
                    command.Parameters.AddWithValue("@age", ageLabel.Text.ToString());
                    command.Parameters.AddWithValue("@sex", sex);
                    command.Parameters.AddWithValue("@teacher_mobile", mobileNumberTextBox.Text);
                    command.Parameters.AddWithValue("@teacher_email", emailAddressTextBox.Text);
                   
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Record has been updated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch(Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void frmStudentInfo_Load(object sender, EventArgs e)
        {
            ComboBoxItems();
            FillCityCombobox();
            bdayDateTimePicker.MinDate = new DateTime(1900, 1, 1);
            bdayDateTimePicker.MaxDate = new DateTime(2000, 1, 1);
            bdayDateTimePicker.Value = new DateTime(2000, 1, 1);


            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            string query = "Select COUNT(teacher_no) From table_teacher";
            MySqlCommand command = new MySqlCommand(query, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());
           
            
        }
        private void ComboBoxItems()
        {


        }
      
       
        private void FillCityCombobox()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
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

        private void departmentCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            String age = (DateTime.Today - bdayDateTimePicker.Value).TotalDays.ToString();
            int ageInt = int.Parse(age) / 365;
            ageLabel.Text = ageInt.ToString();
        }

        private void cityCombobox_SelectedIndexChanged(object sender, EventArgs e)
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
                
                command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                zipCombobox.Items.Clear();
                while (reader.Read())
                {
                    zipCombobox.Items.Add(reader.GetString("zip_code"));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void zipCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close Editing Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Close Editing Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }
    }
}
