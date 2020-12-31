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

namespace ERIS_MIS.Forms
{
    public partial class frmStudentEdit : Form
    {
        string _title = "ERIS MIS";
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='eris_mis';username=root;password=");
        MySqlCommand command;
        MySqlDataAdapter adapter;

        public frmStudentEdit()
        {
            InitializeComponent();
        }

       

        private void frmEnrollmentStudentInfo_Load(object sender, EventArgs e)
        {
            
            FillCityCombobox();
            bdayDateTimePicker.Value = DateTime.Today;
            this.AutoScroll = false;
            this.VerticalScroll.Value = 0;
            groupBox6.Select();
            this.HorizontalScroll.Visible = false;
            this.HorizontalScroll.Enabled = false;
            this.AutoScroll = true;
            //panel3.Hide();
            //openPanel();
            radioButton3.Checked = true;

            //saveEnrollment();
            bdayDateTimePicker.MinDate = new DateTime(1900, 6, 20);
            bdayDateTimePicker.MaxDate = new DateTime(2010, 2, 20);
            bdayDateTimePicker.Value = new DateTime(2010, 2, 20);

            selectSEction();
            countNum();
            
            

        }
        private void countNum ()
        {
            connection.Open();
            string query = "Select COUNT(student_no) From table_students";
            MySqlCommand command = new MySqlCommand(query, connection);
            int count = Convert.ToInt32(command.ExecuteScalar());

            int nyNumber = 0;
            if (count > 0)
            {
                nyNumber = count + 10000;

            }

            else
            {
                nyNumber = 10000;
            }
            studnoLabel.Text = DateTime.Now.Year.ToString() + "-" + nyNumber.ToString();
            connection.Close();

        }



        private void tryInsert ()
        {

        }
        private void openPanel()
        {
            if (radioButton3.Checked == true)
            {
                panel3.Show();
            }
            else if (radioButton4.Checked == true)
            {
                panel3.Show();
            }
        }
       

        
        private void saveData()
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
                if (MessageBox.Show("Save Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    connection.Open();
                    MySqlCommand command = new MySqlCommand("INSERT INTO table_students (last_name, first_name, middle_name, student_no, date_of_birth, age, sex," +
                        "house_no, street, city, zip, father_name, father_mobile, father_occupation, mother_name, mother_mobile, mother_occupation, " +
                        "guardian_name, guardian_mobile, guardian_occupation, psa, good_moral, form9, form10, last_grade, last_school, last_school_address, last_sy, last_school_id )" + /*psa, good_moral, form_138a, form137a*/
                        "values(@last_name, @first_name, @middle_name, @student_no, @date_of_birth, @age, @sex, @house_no, @street, @city, @zip, " +
                        "@father_name, @father_mobile, @father_occupation, @mother_name, @mother_mobile, @mother_occupation, @guardian_name, @guardian_mobile, @guardian_occupation, @psa, @good_moral, @form9, " +
                        "@form10, @last_grade, @last_school, @last_school_address, @last_sy, @last_school_id " +
                        ")", connection); /*@psa, @good_moral, @form_138a, @form137a*/


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

                    MessageBox.Show("Hello");
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
       
        private int getStudentID() {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            MySqlCommand com = new MySqlCommand("SELECT student_id FROM table_students WHERE student_no = '"+studnoLabel.Text+"'", connection);
            MySqlDataReader reader = com.ExecuteReader();
            int studID = 0;
            while (reader.Read()) {
                studID = int.Parse(reader.GetString("student_id"));
            }
            reader.Close();
            return studID;
        }
        DateTime now = new DateTime();
        int userID=1;

        private void saveEnrollment()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            MySqlCommand com = new MySqlCommand("INSERT INTO table_enrollment(student_id, class_id, enrolled_date, enrolled_by, status_inactive) " +
                "SELECT @student_id, table_class.class_id, @enrolled_date, @enrolled_by, @status_inactive FROM table_class " +
                "INNER JOIN table_level_section ON table_class.level_section_id=table_level_section.level_section_id " +
                "INNER JOIN table_grade_level ON table_level_section.grade_level_id=table_grade_level.grade_level_id WHERE table_level_section.section = '"+ comboBox3.Text+ "'", connection);
            MessageBox.Show(getStudentID().ToString());
            com.Parameters.AddWithValue("@student_id", getStudentID() );
            com.Parameters.AddWithValue("@enrolled_date", now.ToString());
            com.Parameters.AddWithValue("@enrolled_by", UserInfo.userID);
            com.Parameters.AddWithValue("@status_inactive", 1);
            com.ExecuteNonQuery();
        }

        int studId = 0;
        protected void GetStudId(string query)
        {

            try
            {

                connection.Open();
                command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    studId=reader.GetInt32("student_id");
                }
                reader.Close();

                  connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            saveData();
            saveEnrollment();
            addGradingData();
        }


        private void addGradingData()
        {
            SystemGeneralData data = new SystemGeneralData();
            DateTime now = new DateTime();
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                    MessageBox.Show("The connection is open");
                }
                for (int i = 0; i < 4; i++)
                {
                    string cmd = "INSERT INTO table_grades" +
                                  "(student_id, sy_id, student_grade, grading_period_id, assignment_id, encode_date, encode_by) " +
                                  "VALUES (@student_id,  @sy_id, @student_grade,  @grading_period_id, @assignment_id, @encode_date, @encode_by)  ";
                    MySqlCommand command = new MySqlCommand(cmd, connection);
                    command.Parameters.AddWithValue("@student_id", getStudentID());
                    command.Parameters.AddWithValue("@sy_id", data.GetActiveAcademicYearID());
                    command.Parameters.AddWithValue("@student_grade", 0);
                    command.Parameters.AddWithValue("@grading_period_id", i+1);
                    command.Parameters.AddWithValue("@assignment_id", 0);
                    command.Parameters.AddWithValue("@encode_date", now.ToString());
                    command.Parameters.AddWithValue("@encode_by", userID);
                    command.ExecuteNonQuery();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void enrollmentLocation()
        {
            frmEnrollment f = new frmEnrollment();
            f.panel2.Location = new System.Drawing.Point(40, 12);
            f.panel4.Location = new System.Drawing.Point(35, 17);
            f.dataGridView2.Size = new System.Drawing.Size(1239, 507);
            f.dataGridView2.Location = new System.Drawing.Point(54, 126);
            f.button2.Location = new System.Drawing.Point(1038, 649);
        }
        public int testVal = 0;

        public int grade8 = 0;
        private void button9_Click(object sender, EventArgs e)
        {
            grade8 = 8;
            frmEnrollment f = new frmEnrollment();

            testVal = 1;
            FormAdmin.admin.openEnrollment1();


            f.panel2.Show();


            //frmEnrollment f = new frmEnrollment();
            //f.WindowState = FormWindowState.Normal;
            //f.Size = new System.Drawing.Size(1285, 638);

            //enrollmentLocation();
            //f.ShowDialog();

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

            //if (cityCombobox.Text == "Manila")
            //{
            //    city = "1";
            //}
            //else if (cityCombobox.Text == "Mandaluyong")
            //{
            //    city = "2";
            //}
            //else
            //{
            //    city = "3";
            //}
            //string query = "SELECT * FROM table_zip_code INNER JOIN table_city ON table_zip_code.city_id = table_city.city_id WHERE table_zip_code.city_id='" + city.ToString() + "'";
            //FillCombobox(query);
            //if (!string.IsNullOrEmpty(cityCombobox.Text))
            //{
            //    zipCombobox.Enabled = true;
            //}
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

        private void selectSEction()
        {
            string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='Grade 7'";
            FillComboboxForSelectSection(query);
        }

        protected void FillComboboxForSelectSection(string query)
        {

            try
            {
                connection.Open();
                command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                comboBox3.Items.Clear();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString("section"));
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //List<ZipCode> zipCodes = new List<ZipCode>();
        //private class ZipCode
        //{
        //    public int Id { get; set; } 
        //    public string Zip { get; set; }

        //    public string Display
        //    {
        //        get
        //        {
        //            return string.Format("{0}", Zip);
        //        }
        //    }
        //}

        //BindingSource zipBinding = new BindingSource();

        //protected void FillCombobox(string query)
        //{

        //    try
        //    {
        //        connection.Open();
        //        command = new MySqlCommand(query, connection);
        //        MySqlDataReader reader = command.ExecuteReader();
        //        zipCombobox.Items.Clear();
        //        zipCodes.Clear();
        //        while (reader.Read())
        //        {
        //            zipCodes.Add( new ZipCode { Id = reader.GetInt32("zip id"), Zip = reader.GetString("zip_code") } );


        //            //zipCombobox.Items.Add(reader.GetString("zip_code"));
        //        }


        //        zipBinding.DataSource = zipCodes;

        //        zipCombobox.DataSource = zipBinding;
        //        zipCombobox.DisplayMember = "Display";
        //        zipCombobox.ValueMember = "Display";

        //        connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lastNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(lastNameTextBox.Text.Trim()))
            {
                errorProvider1.SetError(lastNameTextBox, "Name is required.");
            }
            else
            {
                errorProvider1.SetError(lastNameTextBox, string.Empty);
            }
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
    }
}
