using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using ERIS_MIS.UserControls;
using ERIS_MIS.Forms;
using ERIS_MIS.Config;


namespace ERIS_MIS.UserControls
{
    public partial class Reports : UserControl
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        string _title = "ERIS MIS";

        public Reports()
        {
            InitializeComponent();
            
            
            
            
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            //loadData1();
            GradeLevelComboBoxItems();
            GenderComboBoxItems();
            CityItems();
            sortByComboBoxItems();
            ShowChoices();
            


            //saveData();
            this.Size = new System.Drawing.Size(1406, 614);
            frmStudent f = new frmStudent();
            textBox3.MaxLength = 2;
            textBox4.MaxLength = 2;

           


        }

        //To show Report Choices
        private void ShowChoices ()
        {
            studentPerGrade.Checked = true;
            panel1.Show();
            this.panel1.Location = new System.Drawing.Point(3, 13);
            panel2.Hide();
        }
        //To load data on datagridview1

        private void LoadData()
        {
            string query;

            if (studentGender.Checked)
            {

                query = "SELECT table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section', table_students.sex as 'Gender'   " +
                   "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                   "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                   "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                   "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                   "ORDER BY grade_level + 0, section, first_name, last_name, student_no, sex";

            }

            else if (studentAge.Checked)
            {
               

                query = "SELECT table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section',table_students.date_of_birth as 'Birthdate' ,table_students.age as 'Age'   " +
                   "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                   "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                   "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                   "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                   "ORDER BY grade_level + 0, section, first_name, last_name, student_no ";

            }

            else if (studentCityAddress.Checked)
            {
                

                query = "SELECT table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section',table_students.city as 'City Address' " +
                   "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                   "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                   "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                   "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                   "ORDER BY grade_level + 0, section, first_name, last_name, student_no ";
            }

            else 
            {
                


                query = "SELECT table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section' " +
                   "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                   "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                   "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                   "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                   "ORDER BY grade_level + 0, section, first_name, last_name, student_no ";
            }




            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);

            

        }

        private void loadData1()
        {
           

            string query = "SELECT table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section',table_students.date_of_birth as 'Birthdate' ,table_students.age as 'Age' " +
                   "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                   "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                   "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                   "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                   "ORDER BY grade_level + 0, section, first_name, last_name, student_no ";

            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView2.DataSource = table;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            
            
            



        }


        private void saveData()
        {
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command = new MySqlCommand("UPDATE table_students SET age=@age WHERE student_no=@student_no  ", connection);
                command.Parameters.AddWithValue("@age", row.Cells[6].Value);
                command.Parameters.AddWithValue("@student_no", row.Cells["Student Number"].Value);


                command.ExecuteNonQuery();

                connection.Close();

            }
        }

        //pv to search data

        private void searchData()
        {
            
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;

            string filter = "";

            // Check if text fields are not null before adding to filter. 

            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                if (comboBox1.Text == "All Grade Level")
                {
                    filter += "";
                }
                else
                {
                    filter += "[Year Level] LIKE '%" + comboBox1.Text + "%' ";
                }
               
            }
            else if (!string.IsNullOrEmpty(comboBox10.Text))
            {
                if (comboBox10.Text == "All Grade Level")
                {
                    filter += "";
                }
                else
                {
                    filter += "[Year Level] LIKE '%" + comboBox10.Text + "%' ";
                }

            }
            else if (!string.IsNullOrEmpty(comboBox7.Text))
            {
                if (comboBox7.Text == "All Grade Level")
                {
                    filter += "";
                }
                else
                {
                    filter += "[Year Level] LIKE '%" + comboBox7.Text + "%' ";
                }

            }

           

            else if (!string.IsNullOrEmpty(comboBox12.Text))
            {
                if (comboBox12.Text == "All Grade Level")
                {
                    filter += "";
                }
                else
                {
                    filter += "[Year Level] LIKE '%" + comboBox12.Text + "%' ";
                }
            }

            

            if (!string.IsNullOrEmpty(comboBox2.Text))
            {
                if (comboBox2.Text == "Male and Female")
                {
                    if (filter.Length > 0) filter += "AND ";
                    filter += "[Gender] LIKE '%Male%' ";
                }
                else
                {
                    if (filter.Length > 0) filter += "AND ";
                    filter += "[Gender] LIKE '" + comboBox2.Text + "%' ";
                    
                }
             }

            if (studentAge.Checked)
            {
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    if (filter.Length > 0) filter += "AND ";
                    filter += "[Age] >=" + textBox3.Text + " AND [Age] <=" + textBox4.Text + " ";

                }
            }
            

            if (!string.IsNullOrEmpty(comboBox5.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[City Address] LIKE '%" + comboBox5.Text + "%' ";
            }

            

            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Section] LIKE '%" + textBox2.Text + "%' ";
            }

            //if (!string.IsNullOrEmpty(textBox3.Text))
            //{
            //    if (filter.Length > 0) filter += "AND ";
            //    filter += "[Age] LIKE '%" + textBox3.Text + "%' ";
            //}





            bs.Filter = filter;
            dataGridView1.DataSource = bs;
        }

        
        //"Go" Button
        private void button2_Click(object sender, EventArgs e)
        {
            if (studentAge.Checked)
            {
                loadData1();
            }
            
            
                
            clearValue();
            LoadData();
            panel2.Show();
            this.panel2.Location = new System.Drawing.Point(2, 2);
            //this.dataGridView1.Location = new System.Drawing.Point(100, 300);
            panel2.SendToBack();
            panel1.Hide();

            if (studentGender.Checked)
            {
                

                studentGenderLabel.Show();
                studentGenderPanel.Show();
                this.studentGenderPanel.Location = new System.Drawing.Point(102, 170);
                this.studentGenderLabel.Location = new System.Drawing.Point(556, 27);
                
                studentAgePanel.Hide();
                studentAgeLabel.Hide();
                StudentCityPanel.Hide();
                StudentCityLabel.Hide();
                StudentPerGradePanel.Hide();
                StudentPerGradeLabel.Hide();

                comboBox13.Items.Add("Gender");

                comboBox3.Enabled = false;



            }
            else if (studentAge.Checked)
            {
                
                studentAgeLabel.Show();
                studentAgePanel.Show();
                this.studentAgeLabel.Location = new System.Drawing.Point(556, 27);
                this.studentAgePanel.Location = new System.Drawing.Point(102, 170);
                
                studentGenderPanel.Hide();
                studentGenderLabel.Hide();
                StudentCityPanel.Hide();
                StudentCityLabel.Hide();
                StudentPerGradePanel.Hide();
                StudentPerGradeLabel.Hide();

                comboBox13.Items.Add("Age");

                comboBox6.Enabled = false;




            }
            else if (studentCityAddress.Checked)
            {
               
                StudentCityLabel.Show();
                StudentCityPanel.Show();
                this.StudentCityLabel.Location = new System.Drawing.Point(556, 27);
                this.StudentCityPanel.Location = new System.Drawing.Point(102, 170);
                
                studentGenderPanel.Hide();
                studentGenderLabel.Hide();
                studentAgePanel.Hide();
                studentAgeLabel.Hide();
                StudentPerGradePanel.Hide();
                StudentPerGradeLabel.Hide();

                comboBox13.Items.Add("City Address");

                comboBox9.Enabled = false;


            }

            else 
            {

                
                StudentPerGradeLabel.Show();
                StudentPerGradePanel.Show();
                this.StudentPerGradeLabel.Location = new System.Drawing.Point(556, 27);
                this.StudentPerGradePanel.Location = new System.Drawing.Point(102, 170);
                
                studentGenderPanel.Hide();
                studentGenderLabel.Hide();
                studentAgePanel.Hide();
                studentAgeLabel.Hide();
                StudentCityPanel.Hide();
                StudentCityLabel.Hide();

                comboBox11.Enabled = false;



            }

           


        }
       

        //Back Button
        private void button3_Click(object sender, EventArgs e)
        {
            clearValue();
            textBox1.Clear();
            ShowChoices();
            panel2.Hide();
            studentGenderPanel.Hide();
            studentGenderLabel.Hide();
            studentAgePanel.Hide();
            studentAgeLabel.Hide();
            StudentCityPanel.Hide();
            StudentCityLabel.Hide();
            StudentPerGradePanel.Hide();
            StudentPerGradeLabel.Hide();
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            textBox3.Clear();
            textBox4.Clear();


        }

        private void clearValue ()
        {
            
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
           
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox9.SelectedIndex = -1;
            comboBox10.SelectedIndex = -1;
            comboBox9.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox12.SelectedIndex = -1;
            comboBox11.SelectedIndex = -1;
            comboBox13.SelectedIndex = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;


        }
        
        //SortBy Filter ComboBox
        private void sortByComboBoxItems ()
        {
            comboBox13.Items.Add("Name");
            comboBox13.Items.Add("Grade Level");
            comboBox13.Items.Add("Student Number");
        }


        //Grade Level ComboBox
        private void GradeLevelComboBoxItems()
        {
           
            comboBox1.Items.Add("Grade 7");
            comboBox1.Items.Add("Grade 8");
            comboBox1.Items.Add("Grade 9");
            comboBox1.Items.Add("Grade 10");
            comboBox1.Items.Add("All Grade Level");
            

            comboBox7.Items.Add("Grade 7");
            comboBox7.Items.Add("Grade 8");
            comboBox7.Items.Add("Grade 9");
            comboBox7.Items.Add("Grade 10");
            comboBox7.Items.Add("All Grade Level");

            comboBox10.Items.Add("Grade 7");
            comboBox10.Items.Add("Grade 8");
            comboBox10.Items.Add("Grade 9");
            comboBox10.Items.Add("Grade 10");
            comboBox10.Items.Add("All Grade Level");

            comboBox12.Items.Add("Grade 7");
            comboBox12.Items.Add("Grade 8");
            comboBox12.Items.Add("Grade 9");
            comboBox12.Items.Add("Grade 10");
            comboBox12.Items.Add("All Grade Level");
        }

        //Gender Combo Box
        private void GenderComboBoxItems()
        {
            comboBox2.Items.Add("Male");
            comboBox2.Items.Add("Female");
            comboBox2.Items.Add("Male and Female");

        }

        //City Combo Box
        private void CityItems()
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
                comboBox5.Items.Clear();
                while (reader.Read())
                {
                    comboBox5.Items.Add(reader.GetString("name"));

                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //To get values of combox 2 (section) from combo box 1 (g level)
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                textBox1.Text += comboBox1.SelectedItem.ToString();
                string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + textBox1.Text + "' ";
                FillCombobox(query);
                textBox1.Clear();
                textBox2.Clear();
                comboBox3.Enabled = true;
                
            }
                
        }

        //To get values of combox 2 (section) from combo box 1 (g level)
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox7.Text))
            {
                textBox1.Text += comboBox7.SelectedItem.ToString();
                string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + textBox1.Text + "' ";
                FillCombobox(query);
                textBox1.Clear();
                textBox2.Clear();
                comboBox6.Enabled = true;
            }
                
        }

        //To get values of combox 2 (section) from combo box 1 (g level)
        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox10.Text))
            {
                textBox1.Text += comboBox10.SelectedItem.ToString();
                string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + textBox1.Text + "' ";
                FillCombobox(query);
                textBox1.Clear();
                textBox2.Clear();
                comboBox9.Enabled = true;
            }

                
        }

        //To get values of combox 2 (section) from combo box 1 (g level)
        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox12.Text))
            {
                textBox1.Text += comboBox12.SelectedItem.ToString();
                string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
                "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
                "WHERE table_sy.status = '1' AND grade_level='" + textBox1.Text + "'";
                
                FillCombobox(query);
                textBox1.Clear();
                textBox2.Clear();
                comboBox11.Enabled = true;
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
                comboBox3.Items.Clear();
                comboBox6.Items.Clear();
                comboBox9.Items.Clear();
                comboBox11.Items.Clear();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString("section"));
                    comboBox6.Items.Add(reader.GetString("section"));
                    comboBox9.Items.Add(reader.GetString("section"));
                    comboBox11.Items.Add(reader.GetString("section"));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Storing Section Value
        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox3.Text))
            {
                textBox2.Clear();
                textBox2.Text += comboBox3.SelectedItem.ToString();
                
            }

                
            
            
        }
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox6.Text))
            {
                textBox2.Clear();
                textBox2.Text += comboBox6.SelectedItem.ToString();
            }
                
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox9.Text))
            {
                textBox2.Clear();
                textBox2.Text += comboBox9.SelectedItem.ToString();
            }
                
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox11.Text))
            {
                textBox2.Clear();
                textBox2.Text += comboBox11.SelectedItem.ToString();
            }
                
        }

        //Sorting by name/gender/city
        int numCounter;
        private void sortBy ()
        {
            
            if (comboBox13.Text == "Name" )
            {
                numCounter = 1;
            }
            else if (comboBox13.Text == "Student Number")
            {
                numCounter = 2;
            }
            else if (comboBox13.Text == "Grade Level")
            {
                numCounter = 3;
            }
            else if (comboBox13.Text == "Gender")
            {
                numCounter = 5;
            }
            else  if (comboBox13.Text == "City Address")
            {
                numCounter = 5;
            }

            if (checkBox1.Checked)
            {
                dataGridView1.Sort(dataGridView1.Columns[numCounter], System.ComponentModel.ListSortDirection.Ascending);

            }
            else if (checkBox2.Checked)
            {
                dataGridView1.Sort(dataGridView1.Columns[numCounter], System.ComponentModel.ListSortDirection.Descending);

            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }

        //AScending Descending checkbox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }

        }


        //Print
        int tb1=0;
        int tb2=0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (studentAge.Checked)
            {
                
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    tb1 = int.Parse(textBox3.Text);
                    
                }
                else
                {
                    tb1 = 0;
                }

                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    tb2 = int.Parse(textBox4.Text);
                }
                else
                {
                    tb2 = 100;
                }
                DateTime birthday;

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    birthday = Convert.ToDateTime(dataGridView2.Rows[i].Cells[5].Value.ToString());
                    String age = (DateTime.Today - birthday).TotalDays.ToString();
                    int ageInt = int.Parse(age) / 365;
                    dataGridView2[6, i].Value = ageInt;

                }

            }

               
            print1();

        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "  ^ [0-9]"))
            {
                textBox4.Text = "";
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       

        private void barangayComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
       
        public void print1 ()
        {
            if (studentAge.Checked)
            {
                if (tb2 < tb1)
                {
                    MessageBox.Show("Please input correct Maximum Value", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (String.IsNullOrEmpty(textBox3.Text))
                {
                    
                    MessageBox.Show("Please input minimun value", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (String.IsNullOrEmpty(textBox4.Text))
                {
                    MessageBox.Show("Please input maximum value", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    saveData();
                    LoadData();
                    searchData();
                }
            }

            LoadData();
            searchData();
            sortBy();
            label9.Text = dataGridView1.RowCount.ToString();
            var count7 = dataGridView1.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[3].Value.ToString().Trim() == "Grade 7");
            var count8 = dataGridView1.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[3].Value.ToString().Trim() == "Grade 8");
            var count9 = dataGridView1.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[3].Value.ToString().Trim() == "Grade 9");
            var count10 = dataGridView1.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[3].Value.ToString().Trim() == "Grade 10");
            

            
            if (studentAge.Checked)
            {//walapa
                label9.Text = dataGridView1.RowCount.ToString();
            }
            

            //Add Logo
            easyHTMLReports1.AddImage(piclogo.Image, "width=100");

            //Add the Title
            easyHTMLReports1.AddString("<center> Republic of The Philippines</center>");
            easyHTMLReports1.AddString("<center> Department of Education</center>");
            easyHTMLReports1.AddString("<center> Eulogio Rodriguez Integrated School</center>");
            easyHTMLReports1.AddString("<center> Cavo F. Sanchez St., Hagdan Bato-Itaas, Mandaluyong City</center>");
            easyHTMLReports1.AddLineBreak();

            if (studentGender.Checked)
            {
                var countMale = dataGridView1.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[5].Value.ToString().Trim() == "Male");
                var countFemale = dataGridView1.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[5].Value.ToString().Trim() == "Female");
                easyHTMLReports1.AddString("<center><h3> Student Gender Reports </h3></center>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p>Total Number of Students        :   " + dataGridView1.Rows.Count.ToString() + "</p>");
                if (comboBox1.Text == "All Grade Level" || comboBox2.Text == "Male and Female")
                {

                    easyHTMLReports1.AddString("<p>Total Number of Male Students   :   " + countMale.ToString() +
                                            "<br>Total Number of Female Students :   " + countFemale.ToString() + "</br> </p>");
                }

            }

            else if (studentAge.Checked)
            {
                easyHTMLReports1.AddString("<center><h3> Student Age Reports </h3></center>");
            }

            else if (studentCityAddress.Checked)
            {
                easyHTMLReports1.AddString("<center><h3> Student City Address Reports </h3></center>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p>Total Number of Students        :   " + dataGridView1.Rows.Count.ToString() + "</p>");

                if (comboBox10.Text == "All Grade Level")
                {

                    easyHTMLReports1.AddString("<p>Total Number of Grade 7 Students   :   " + count7.ToString() +
                                             "<br>Total Number of Grade 8 Students :   " + count8.ToString() +
                                             "<br>Total Number of Grade 9 Students   :   " + count9.ToString() +
                                            "<br>Total Number of Grade 10 Students :   " + count10.ToString() + "</br> </p>");
                }

            }

            else
            {
                easyHTMLReports1.AddString("<center><h3> Student per Grade/Year Level Report </h3></center>");
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddLineBreak();
                easyHTMLReports1.AddString("<p>Total Number of Students        :   " + label9.Text + " </p>");

                if (comboBox12.Text == "All Grade Level")
                {

                    easyHTMLReports1.AddString("<p>Total Number of Grade 7 Students   :   " + count7.ToString() +
                                            "<br>Total Number of Grade 8 Students :   " + count8.ToString() +
                                            "<br>Total Number of Grade 9 Students   :   " + count9.ToString() +
                                           "<br>Total Number of Grade 10 Students :   " + count10.ToString() + "</br> </p>");
                }
            }



            //add the line
            easyHTMLReports1.AddHorizontalRule();

            //Add the Datagrid
            easyHTMLReports1.AddDatagridView(dataGridView1);

            easyHTMLReports1.ShowPrintPreviewDialog();
            easyHTMLReports1.Clear();
        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        //Search Button
        private void button5_Click(object sender, EventArgs e)
        {




        }

        private void piclogo_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void piclogo_Click_1(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox3.Text, "  ^ [0-9]"))
            {
                textBox3.Text = "";
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

       

    }
}
