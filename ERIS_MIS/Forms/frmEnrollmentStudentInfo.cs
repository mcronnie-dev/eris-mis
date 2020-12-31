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
    public partial class frmEnrollmentStudentInfo : Form
    {
        string _title = "ERIS MIS";
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        
        MySqlDataAdapter adapter;
        SystemGeneralData data = new SystemGeneralData();

        public frmEnrollmentStudentInfo()
        {
            InitializeComponent();
        }

       

        private void frmEnrollmentStudentInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            panel7.Hide();
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
            activeAY.Text = data.GetActiveAcademicYear();
            
            

        }
        private void countNum ()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
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

            MySqlCommand com = new MySqlCommand("SELECT * FROM table_sy WHERE status = '1'", connection);
            MySqlDataReader reader = com.ExecuteReader();
            int startyear = 0;
            while (reader.Read())
            {
                startyear = int.Parse(reader.GetString("start_year"));
            }
            reader.Close();
            studnoLabel.Text = startyear + "-" + nyNumber.ToString();
            //studnoLabel.Text = DateTime.Now.Year.ToString() + "-" + nyNumber.ToString();
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

                    if (connection.State != ConnectionState.Open)
                    {
                       
                        connection.Open();
                    }
                    MySqlCommand command = new MySqlCommand("INSERT INTO table_students (last_name, first_name, middle_name, student_no, date_of_birth, age, sex," +
                        "house_no, street, barangay, city, zip, father_name, father_mobile, father_occupation, mother_name, mother_mobile, mother_occupation, " +
                        "guardian_name, guardian_mobile, guardian_occupation, psa, good_moral, form9, form10, last_grade, last_school, last_school_address, last_sy, last_school_id )" + /*psa, good_moral, form_138a, form137a*/
                        "values(@last_name, @first_name, @middle_name, @student_no, @date_of_birth, @age, @sex, @house_no, @street, @barangay, @city, @zip, " +
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
                    command.Parameters.AddWithValue("@barangay", barangayComboBox.Text);
                    command.Parameters.AddWithValue("@city", cityCombobox.Text);
                    command.Parameters.AddWithValue("@zip", zipCodetextBox.Text);
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
                "INNER JOIN table_grade_level ON table_level_section.grade_level_id=table_grade_level.grade_level_id WHERE table_level_section.section = '"+ sectionComboBox.Text+ "' AND table_class.sy_id = '"+data.GetActiveAcademicYearID()+"'", connection);
            
            com.Parameters.AddWithValue("@student_id", getStudentID() );
            com.Parameters.AddWithValue("@enrolled_date", now.ToString());
            com.Parameters.AddWithValue("@enrolled_by", UserInfo.userID);
            com.Parameters.AddWithValue("@status_inactive", 0);
            com.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Record has been saved succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        int studId = 0;
        protected void GetStudId(string query)
        {

            try
            {

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand(query, connection);
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
            try
            {
                int studAllowed = Convert.ToInt32(studentsAllowed.Text);
                if (studAllowed != 0)
                {
                    validateVal();
                    

                }
                else
                {
                    DialogResult dresult = MessageBox.Show("Section is already Full! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        int counter = 0;
        int[] array = new int[8];
        private void addGradingData()
        {
            SystemGeneralData data = new SystemGeneralData();
            DateTime now = new DateTime();
            try
            {
                
                if (connection.State != ConnectionState.Open)
                {
                  
                    connection.Open();
                    
                }
                
                string l = "SELECT DISTINCT table_timesched.assignment_id FROM table_timesched INNER JOIN table_class ON table_timesched.class_id = table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id=table_level_section.level_section_id INNER JOIN table_grade_level ON table_level_section.grade_level_id=table_grade_level.grade_level_id INNER JOIN table_subject_assignment ON table_timesched.assignment_id=table_subject_assignment.assignment_id WHERE table_class.sy_id='"+data.GetActiveAcademicYearID()+"' AND table_grade_level.grade_level='"+glevel.Text+"' AND table_level_section.section = '"+sectionComboBox.Text+"' AND table_subject_assignment.subject_id<>'1'";//exclude Homeroom subject ID is 1
                MySqlCommand mc = new MySqlCommand(l, connection);
                MySqlDataReader read = mc.ExecuteReader();
             
                
                while (read.Read())
                {
                    array[counter] = read.GetInt32("assignment_id");
                    counter = counter+ 1;
                    

                }
               
                read.Close();

                foreach (int x in array)
                {
                    

                    for (int i = 0; i < 4; i++)
                    {
                        
                        string cmd = "INSERT INTO table_grades" +
                                      "(student_id, sy_id, student_grade, grading_period_id, assignment_id, encode_date, encode_by) " +
                                      "VALUES (@student_id,  @sy_id, @student_grade,  @grading_period_id, @assignment_id, @encode_date, @encode_by)  ";
                        MySqlCommand command = new MySqlCommand(cmd, connection);
                        command.Parameters.AddWithValue("@student_id", getStudentID());
                        command.Parameters.AddWithValue("@sy_id", data.GetActiveAcademicYearID());
                        command.Parameters.AddWithValue("@student_grade", 0);
                        command.Parameters.AddWithValue("@grading_period_id", i + 1);
                        command.Parameters.AddWithValue("@assignment_id", x);
                        command.Parameters.AddWithValue("@encode_date", now.ToString());
                        command.Parameters.AddWithValue("@encode_by", userID);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                counter = 0;
                FormAdmin.admin.newEnrollmentOpen();


            }
            catch (Exception ex)
            {
                connection.Close();
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
                if (connection.State != ConnectionState.Open) { 
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

        private void selectSEction()
        {
            string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
               "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
               "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
               "WHERE table_sy.status = '1' AND grade_level='" + g7 + "'";
            FillComboboxForSelectSection(query);
        }

        protected void FillComboboxForSelectSection(string query)
        {

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                sectionComboBox.Items.Clear();
                while (reader.Read())
                {
                    sectionComboBox.Items.Add(reader.GetString("section"));
                    
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

       

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            panel5.Hide();
            comboBox1.Hide();
            glevel.Text = "Grade 7";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
           
            panel5.Show();
            comboBox1.Show();
            transfereeCombo();
            comboBox1.Location = new System.Drawing.Point(247, 109);
        }
        private void transfereeCombo()
        {
            comboBox1.Items.Add("Grade 7");
            comboBox1.Items.Add("Grade 8");
            comboBox1.Items.Add("Grade 9");
            comboBox1.Items.Add("Grade 10");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + comboBox1.Text + "'";
            string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
                "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
                "WHERE table_sy.status = '1' AND grade_level='" + comboBox1.Text + "'";

            FillCombobox1(query);
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                sectionComboBox.Enabled = true;
            }
        }

        protected void FillCombobox1(string query)
        {

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                sectionComboBox.Items.Clear();
                while (reader.Read())
                {
                    sectionComboBox.Items.Add(reader.GetString("section"));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        string g7 = "Grade 7";
        string g8 = "Grade 8";
        string g9 = "Grade 9";
        string g10 = "Grade 10";
        public void searchData1()
        {
            string query = "SELECT table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section', table_students.sex as 'Gender'   " +
                   "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " + "AND (table_enrollment.status_inactive IS NULL OR table_enrollment.status_inactive = 0) " +
                   "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                   "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                   "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                   "ORDER BY grade_level + 0, section, first_name, last_name, student_no, sex";
            MySqlCommand command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            DataTable table1 = new DataTable();
            adapter.Fill(table1);
            dataGridView1.DataSource = table1;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = dataGridView1.DataSource;

            string filter = "";

            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                if (comboBox1.Text == "Grade 7")
                {
                    filter += "[Year Level] LIKE '%" + g8 + "%' ";
                }

                else if (comboBox1.Text == "Grade 8")
                {
                    filter += "[Year Level] LIKE '%" + g9 + "%' ";
                }

                else
                {
                    filter += "[Year Level] LIKE '%" + g10 + "%' ";
                }


            }

            if (!string.IsNullOrEmpty(sectionComboBox.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Section] LIKE '%" + sectionComboBox.Text + "%' ";
            }

            bs1.Filter = filter;
            dataGridView1.DataSource = bs1;


        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchData1();

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            string query = "Select * from table_enrollment_settings INNER JOIN table_level_section  ON table_enrollment_settings.level_section_id = table_level_section.level_section_id  " +
             "WHERE table_level_section.section ='" + sectionComboBox.Text + "'";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                studentsAllowed.Text = (reader.GetString("max_students"));
            }
            connection.Close();

            if (dataGridView1.Rows != null && dataGridView1.Rows.Count != 0)
            {
                
                studentsEnrolled.Text = dataGridView1.Rows.Count.ToString();
                int x = dataGridView1.Rows.Count;
                int maxstud = Convert.ToInt32(studentsAllowed.Text);
                int y = maxstud - x;
                availableSlots.Text = y.ToString();
                var countMale = dataGridView1.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[5].Value.ToString().Trim() == "Male");
                var countFemale = dataGridView1.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[5].Value.ToString().Trim() == "Female");
                male.Text = countMale.ToString();
                female.Text = countFemale.ToString();
            }
            else
            {
                studentsEnrolled.Text = "0";
                availableSlots.Text = "50";
                male.Text = "0";
                female.Text = "0";
            }

            panel7.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            validateVal();
            
        }

        private void validateVal ()
        {
            TextBox[] newTextBox = { lastNameTextBox, firstNameTextBox, middleNameTextBox, houseNoTextBox, streetTextBox, zipCodetextBox };
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
            if (guardianNameTextBox.Text == "")
            {
                
                TextBox[] newTextBox3 = { fatherNameTextBox, fatherOccupationTextBox, fatherContactTextBox, motherNameTextBox, motherOccupationTextBox, motherContactTextBox};
                for (int inti = 0; inti < newTextBox3.Length; inti++)
                {
                    if (newTextBox3[inti].Text == string.Empty)
                    {
                        MessageBox.Show("Please fill the text box");
                        newTextBox3[inti].Focus();
                        newTextBox3[inti].BackColor = Color.FromArgb(251, 239, 239);
                        return;
                    }
                    else
                    {
                        newTextBox3[inti].BackColor = Color.White;
                    }
                }
            }
            if (fatherNameTextBox.Text == "")
            {
               
                TextBox[] newTextBox2 = { guardianNameTextBox, guardianOccupationTextBox, guardianContactTextBox};
                for (int inti = 0; inti < newTextBox2.Length; inti++)
                {
                    if (newTextBox2[inti].Text == string.Empty)
                    {
                        MessageBox.Show("Please fill the text box");
                        newTextBox2[inti].Focus();
                        newTextBox2[inti].BackColor = Color.FromArgb(251, 239, 239);
                        return;
                    }
                    else
                    {
                        newTextBox2[inti].BackColor = Color.White;
                    }
                }
            }
            if(radioButton4.Checked == true)
            {
                TextBox[] newTextBox1 = {lastGrade, schoolName, schoolAddress, lastSY, schoolId };
                for (int inti = 0; inti < newTextBox1.Length; inti++)
                {
                    if (newTextBox1[inti].Text == string.Empty)
                    {
                        MessageBox.Show("Please fill the text box");
                        newTextBox1[inti].Focus();
                        newTextBox1[inti].BackColor = Color.FromArgb(251, 239, 239);
                        return;
                    }
                    else
                    {
                        newTextBox1[inti].BackColor = Color.White;
                    }
                }
            }
            ComboBox[] newcomboBox = { cityCombobox, sectionComboBox, barangayComboBox };
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
                    newTextBox[inty].BackColor = Color.White;
                }
            }

            saveData();
            saveEnrollment();
            addGradingData();

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

       

    }
}
