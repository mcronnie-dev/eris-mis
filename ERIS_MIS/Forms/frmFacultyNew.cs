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
    public partial class frmFacultyNew : Form
    {
        string _title = "ERIS MIS";
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;

        public frmFacultyNew()
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
            validateVal();
            
        }
        private void saveData()
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
                if (MessageBox.Show("Save Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    command = new MySqlCommand("INSERT INTO table_teacher (last_name, first_name, middle_name, teacher_no, house_no, street, barangay, zip_code, " +
                        " city_address, date_of_birth, age, sex, teacher_mobile, teacher_email)values(@last_name, @first_name, @middle_name, @teacher_no, " +
                        " @house_no, @street, @barangay, @zip_code, @city_address, @date_of_birth, @age, @sex, @teacher_mobile," +
                        " @teacher_email)", connection);
                    command.Parameters.AddWithValue("@last_name", lastNameTextBox.Text);
                    command.Parameters.AddWithValue("@first_name", firstNameTextBox.Text);
                    command.Parameters.AddWithValue("@middle_name", middleNameTextBox.Text);
                    command.Parameters.AddWithValue("@teacher_no", teacherNolabel.Text);
                    command.Parameters.AddWithValue("@house_no", houseNoTextBox.Text);
                    command.Parameters.AddWithValue("@street", streetTextBox.Text);
                    command.Parameters.AddWithValue("@barangay", barangayComboBox.Text);
                    command.Parameters.AddWithValue("@zip_code", zipCodetextBox.Text);
                    command.Parameters.AddWithValue("@city_address", cityCombobox.Text);
                    command.Parameters.AddWithValue("@date_of_birth", birthDay);
                    command.Parameters.AddWithValue("@age", ageLabel.Text.ToString());
                    command.Parameters.AddWithValue("@sex", sex);
                    command.Parameters.AddWithValue("@teacher_mobile", mobileNumberTextBox.Text);
                    command.Parameters.AddWithValue("@teacher_email", emailAddressTextBox.Text);

                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Record has been updated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormAdmin.admin.facultyOpen();
                }
            }
            catch (Exception ex)
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
           
            int nyNumber = 0;
            if (count > 0)
            {
                nyNumber = count + 1000;
               
            }

            else
            {
                nyNumber = 1000;
            }
            teacherNolabel.Text = DateTime.Now.Year.ToString() + "-" + nyNumber.ToString();
        }
        private void ComboBoxItems()
        {


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

            barangayComboBox.SelectedIndex = -1;
            zipCodetextBox.Clear();
            string query = "SELECT * FROM table_city INNER JOIN table_zip_code ON table_city.city_id = table_zip_code.city_id INNER JOIN table_barangay ON table_zip_code.zip_id = table_barangay.zip_id WHERE table_city.name='" + cityCombobox.Text + "' ORDER BY LENGTH(table_barangay.barangay_name), table_barangay.barangay_name ASC";
            FillBarangayCombobox(query);
            if (!string.IsNullOrEmpty(cityCombobox.Text))
            {
                barangayComboBox.Enabled = true;
            }
        }
        private void FillCityCombobox()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string query = "SELECT name from table_city ORDER BY name ASC";
                MySqlCommand command = new MySqlCommand(query, connection);
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

        private void FillBarangayCombobox(string query)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                barangayComboBox.Items.Clear();
                while (reader.Read())
                {
                    barangayComboBox.Items.Add(reader.GetString("barangay_name"));

                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
       

        private void validateVal ()
        {
            TextBox[] newTextBox = { lastNameTextBox, firstNameTextBox, middleNameTextBox, houseNoTextBox, streetTextBox , mobileNumberTextBox, emailAddressTextBox };
            for (int inti = 0; inti < newTextBox.Length; inti++)
            {
                if (newTextBox[inti].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the text box");
                    newTextBox[inti].Focus();
                    newTextBox[inti].BackColor = Color.FromArgb(251, 239, 239);
                    return;
                }
                else
                {
                    newTextBox[inti].BackColor = Color.White;
                }
            }

            ComboBox[] newcomboBox = { cityCombobox, barangayComboBox };
            for (int intx = 0; intx < newcomboBox.Length; intx++)
            {
                if (newcomboBox[intx].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the combox value");
                    newcomboBox[intx].Focus();
                    newcomboBox[intx].BackColor = Color.FromArgb(251, 239, 239);
                    return;
                }
                else
                {
                    newcomboBox[intx].BackColor = Color.White;
                }
            }

            RadioButton[] newradioButton = { maleRadioButton, femaleRadioButton };
            for (int inty = 0; inty < newradioButton.Length; inty++)
            {
                if (newradioButton[inty].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the combox value");
                    newradioButton[inty].Focus();
                    newradioButton[inty].BackColor = Color.FromArgb(251, 239, 239);
                    return;
                }
                else
                {
                    newradioButton[inty].BackColor = Color.White;
                }
            }

            DateTimePicker[] newDateTimePicker = { bdayDateTimePicker};
            for (int intz = 0; intz < newDateTimePicker.Length; intz++)
            {
                if (newDateTimePicker[intz].Text == string.Empty)
                {
                    MessageBox.Show("Please fill the Birthday value");
                    newDateTimePicker[intz].Focus();
                    newDateTimePicker[intz].BackColor = Color.FromArgb(251, 239, 239);
                    return;
                }
                else
                {
                    newDateTimePicker[intz].BackColor = Color.White;
                }
            }

            saveData();


        }
        private void zipCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void barangayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillZipCodeText();
        }
        private void FillZipCodeText()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string sql = "SELECT * FROM table_zip_code INNER JOIN table_barangay ON table_zip_code.zip_id = table_barangay.zip_id WHERE table_barangay.barangay_name ='" + barangayComboBox.Text + "'";
                MySqlCommand com = new MySqlCommand(sql, connection);
                MySqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    zipCodetextBox.Text = rdr.GetString("zip_code");
                }
                rdr.Close();
                //connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
