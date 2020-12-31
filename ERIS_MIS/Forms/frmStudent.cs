using ERIS_MIS.UserControls;
using ERIS_MIS.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ERIS_MIS.Config;


namespace ERIS_MIS.Forms
{
    public partial class frmStudent : Form
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        internal static frmStudent stud;
        string _title = "ERIS MIS";

        public frmStudent()
        {
            InitializeComponent();
            stud = this;
            
            ComboBoxItems();
            textBox31.Visible = false;
            piclogo.Hide();
            panel2.Hide();
            panel1.Hide();
            button1.Enabled = false;
            

        }
        private void frmStudent_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(895, 592);
            label7.Text = n2.ToString();
            LoadData();
            label7.Hide();
            dataGridView2.Hide();
            comboBox2.Enabled = false;
            button5.Hide();




        }
        private void ComboBoxItems()
        {
            
            comboBox1.Items.Add("Grade 7");
            comboBox1.Items.Add("Grade 8");
            comboBox1.Items.Add("Grade 9");
            comboBox1.Items.Add("Grade 10");
            
        }
        
        int n2 = 0;
        public void GetData (int newVar)
        {
            n2 = newVar;
        }

        private void showHideColumns(Boolean colHideStatus)
        {
            dataGridView1.Columns[0].Visible = colHideStatus;
            dataGridView1.Columns[1].Visible = colHideStatus;
            dataGridView1.Columns[2].Visible = colHideStatus;
        }

        //To load data on datagridview1
        public void LoadData()
        {
            

            //FormUser f = new FormUser();
            //string newVal1 = label5.Text.ToString();
            //label7.Text = newVal1;
            string query;

            //All Student
            if (n2 == 1)
            {
                //query = "SELECT file_status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_level_section.year_level as 'Year Level', table_level_section.section as 'Section'  " +
                //    "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                //    "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                //    "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                //    " ORDER BY year_level + 0, section, first_name, last_name, student_no, file_status";

                //query = "SELECT file_status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section'  " +
                //    "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                //    "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                //    "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                //    "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                //    "ORDER BY grade_level + 0, section, first_name, last_name, student_no, file_status";

                query = "SELECT file_status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.middle_name as 'Middle Name',  table_students.last_name as 'Last Name', table_students.date_of_birth as 'Birthday'  " +
                     "FROM table_students";

                button2.Hide();
                button1.Hide();
                label2.Hide() ;
                comboBox1.Hide();
                label3.Hide();
                comboBox2.Hide();

                
            }
            //Enrolled Student
             else if (n2 == 2)
            {
                query = "SELECT file_status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section'  " +
                     "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                     "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                     "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                     "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                     "INNER JOIN table_sy ON table_class.sy_id = table_sy.sy_id " +
                     "WHERE file_status  = 0  and table_sy.status = 1 ORDER BY grade_level + 0, section, first_name, last_name, student_no, file_status";
                button2.Hide();
                button1.Hide();

            }

            // Class List
            else 
            {
                query = "SELECT file_status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section'  " +
                     "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                     "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                     "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                     "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                     "INNER JOIN table_sy ON table_class.sy_id = table_sy.sy_id " +
                     "WHERE file_status  = 0 and table_sy.status = 1 ORDER BY grade_level + 0, section, first_name, last_name, student_no, file_status";

            }


            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView2.DataSource = table;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["colEdit"].DisplayIndex = 7;
            dataGridView1.Columns["colDelete"].DisplayIndex = 7;
            //this.panel1.Location = new System.Drawing.Point(24, 182);

        }

       
        
        //View Class List Button
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.panel3.Size = new System.Drawing.Size(867, 300);
            panel2.Show();
            panel1.Show();
            this.panel2.Location = new System.Drawing.Point(139, 190);
            button1.Enabled = true;
            ViewClassList();
            SubjectAdviser();



        }

        //To get values of combox 2 (section) from combo box 1 (g level)
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
                  "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                  "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
                  "WHERE table_sy.status = '1' AND grade_level='" + comboBox1.Text + "'";
            FillCombobox(query);
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                comboBox2.Enabled = true;
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
                comboBox2.Items.Clear();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("section"));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //pv to show class list (cmbbx1 and cmbbx2) filter
        private void ViewClassList()
        {
            LoadData();
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;


            string filter = "";

            // Check if text fields are not null before adding to filter. 
            if (!string.IsNullOrEmpty(comboBox1.Text))
            { 
               
             filter += "[Year Level] LIKE '%" + comboBox1.Text + "%' ";
                    
            }
            if (!string.IsNullOrEmpty(comboBox2.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Section] LIKE '%" + comboBox2.Text + "%' ";
            }


            bs.Filter = filter;
            dataGridView1.DataSource = bs;
            dataGridView2.DataSource = bs;
        }
        private void SubjectAdviser ()
        {
            gradeLevelTextbox.Text = comboBox1.Text.ToString();
            sectionTextbox.Text = comboBox2.Text.ToString();

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string query = "SELECT table_level_section.section,  table_grade_level.grade_level, CONCAT(table_teacher.last_name,', ',table_teacher.first_name,' ',table_teacher.middle_name) AS name " +
                    "FROM table_class INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                    "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
                    "INNER JOIN table_teacher ON table_class.teacher_id = table_teacher.teacher_id " +
                    "WHERE table_grade_level.grade_level='" + comboBox1.Text + "' AND table_level_section.section='" + comboBox2.Text + "' ";
                command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    AdviserTextbox.Text = reader.GetString("name");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //Search Button
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Show();
            //this.panel1.Location = new System.Drawing.Point(21, 287);
            //this.panel2.Location = new System.Drawing.Point(26, 182);
            panel2.Hide();

            LoadData();
            searchData();
        }

        //pv to filter search button
        public void searchData()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;

            string filter = "";

            // Check if text fields are not null before adding to filter. 
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                filter += "[First Name]  LIKE '%" + textBox1.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Last Name] LIKE '%" + textBox3.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Student Number] LIKE '%" + textBox2.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Year Level] LIKE '%" + comboBox1.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(comboBox2.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Section] LIKE '%" + comboBox2.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Status] LIKE '%" + status + "%' ";

            }


            bs.Filter = filter;
            dataGridView1.DataSource = bs;
        }

        public void retainEditValue ()
        {
            //frmStudentInfo f = new frmStudentInfo();
            //BindingSource bs = new BindingSource();
            //bs.DataSource = dataGridView1.DataSource;

            //string filter = "";

            //// Check if text fields are not null before adding to filter. 
            //if (!string.IsNullOrEmpty(f.studentNoTextBox.Text))
            //{
            //    filter = "[Student Number]  LIKE '%" + f.studentNoTextBox.Text + "%' ";
            //}

            //bs.Filter = filter;
            //dataGridView1.DataSource = bs;
        }
        // ClearButton
        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            LoadData();
            comboBox2.Enabled = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
           
            
            panel2.Hide();

            status = "";

        }



        //To check status
        string status;
        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
           
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

           
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        //Close Button
        private void button5_Click_1(object sender, EventArgs e)
        {
            

        }



        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            editButton();


        }

        
        private void editButton()
        {
            textBox31.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            DataTable dt = new DataTable();
            MySqlDataReader myReader = null;
            frmStudentInfo1 f = new frmStudentInfo1();
            f.studnoLabel.Focus();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM table_students  WHERE table_students.student_no='" + textBox31.Text + "'", connection);
            //MySqlCommand myCommand = new MySqlCommand("SELECT * FROM table_guardian INNER JOIN table_students ON table_guardian.student_id = table_students.student_id WHERE student_no='" + textBox31.Text + "'", connection);
            myReader = myCommand.ExecuteReader();
            myReader.Read();
            if (myReader.HasRows)
            {
                string guardian = (myReader["guardian_name"].ToString());
                
                if(guardian == "")
                {
                    f.panel4.Hide();
                    
                }
                else
                {
                    f.panel4.Show();
                    f.guardianNameTextBox.Text = (myReader["guardian_name"].ToString());
                    f.guardianOccupationTextBox.Text = (myReader["guardian_occupation"].ToString());
                    f.guardianContactTextBox.Text = (myReader["guardian_mobile"].ToString());
                }

                string lastSchool = (myReader["last_school"].ToString());

                if (lastSchool == "")
                {
                    f.panel5.Hide();
                }
                else
                {
                    f.panel5.Show();
                    f.lastGrade.Text = (myReader["last_grade"].ToString());
                    f.schoolName.Text = (myReader["last_school"].ToString());
                    f.schoolAddress.Text = (myReader["last_school_address"].ToString());
                    f.schoolId.Text = (myReader["last_school_id"].ToString());
                    f.lastSY.Text = (myReader["last_sy"].ToString());
                }
                string form9 = (myReader["form9"].ToString());
                if(form9 == "1")
                {
                    f.form138CheckBox.Checked = true;
                    f.form138CheckBox.AutoCheck = false;
                }
                

                string form10 = (myReader["form10"].ToString());
                if (form10 == "1")
                {
                    f.form137CheckBox.Checked = true;
                    f.form137CheckBox.AutoCheck = false;
                }

                string psa = (myReader["psa"].ToString());
                if (psa == "1")
                {
                    f.clearanceCheckBox.Checked = true;
                    f.clearanceCheckBox.AutoCheck = false;
                }

                string gmc = (myReader["good_moral"].ToString());
                if (gmc == "1")
                {
                    f.envelopeCheckBox.Checked = true;
                    f.envelopeCheckBox.AutoCheck = false;
                }
                string sex = (myReader["sex"].ToString());
                if (sex == "Male")
                {
                    f.maleRadioButton.Checked = true;
                    f.maleRadioButton.AutoCheck = false;
                    f.femaleRadioButton.AutoCheck = false;
                }
                else
                {
                    f.femaleRadioButton.Checked = true;
                    f.femaleRadioButton.AutoCheck = false;
                    f.maleRadioButton.AutoCheck = false;
                }
                f.studnoLabel.Text = textBox31.Text;
                f.lastNameTextBox.Text = (myReader["last_name"].ToString());
                f.firstNameTextBox.Text = (myReader["first_name"].ToString());
                f.middleNameTextBox.Text = (myReader["middle_name"].ToString());
                f.houseNoTextBox.Text = (myReader["house_no"].ToString());
                f.streetTextBox.Text = (myReader["street"].ToString());
                f.barangayTextBox.Text = (myReader["barangay"].ToString());
                f.cityCombobox.Text = (myReader["city"].ToString());
                f.zipCombobox.Text = (myReader["zip"].ToString());
                f.fatherNameTextBox.Text = (myReader["father_name"].ToString());
                f.fatherOccupationTextBox.Text = (myReader["father_occupation"].ToString());
                f.fatherContactTextBox.Text = (myReader["father_mobile"].ToString());
                f.motherNameTextBox.Text = (myReader["mother_name"].ToString());
                f.motherOccupationTextBox.Text = (myReader["mother_occupation"].ToString());
                f.motherContactTextBox.Text = (myReader["mother_mobile"].ToString());
                

            }
            myReader.Close();
            connection.Close();
            f.ShowDialog();
        }



        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox31.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                editButton();
            }
            else if (colName == "colDelete")
            {
                if (MessageBox.Show("Move to ARCHIVE this record? Click Yes to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    command = new MySqlCommand("UPDATE table_students SET file_status = 1  where student_no like'" + textBox31.Text + "'", connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Record has been succesfully moved to archive.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }

           
        }

        private void print1()
        {
            LoadData();
            ViewClassList();
            var count7 = dataGridView2.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[4].Value.ToString().Trim() == "Grade 7");
            var count8 = dataGridView2.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[4].Value.ToString().Trim() == "Grade 8");
            var count9 = dataGridView2.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[4].Value.ToString().Trim() == "Grade 9");
            var count10 = dataGridView2.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[4].Value.ToString().Trim() == "Grade 10");

            
            //Add Logo
            easyHTMLReports1.AddImage(piclogo.Image, "width=100");

            //Add the Title
            easyHTMLReports1.AddString("<center> Republic of The Philippines</center>");
            easyHTMLReports1.AddString("<center> Department of Education</center>");
            easyHTMLReports1.AddString("<center> Eulogio Rodriguez Integrated School</center>");
            easyHTMLReports1.AddString("<center> Cavo F. Sanchez St., Hagdan Bato-Itaas, Mandaluyong City</center>");
            easyHTMLReports1.AddLineBreak();

            easyHTMLReports1.AddString("<center><h3> Grade 7 Section A Class List </h3></center>");
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddLineBreak();
            easyHTMLReports1.AddString("<p>Total Number of Students        :   " + dataGridView2.Rows.Count.ToString() + " </p>");
           


            if (comboBox1.Text == "All Grade Level")
            {

                easyHTMLReports1.AddString("<p>Total Number of Grade 7 Students   :   " + count7.ToString()+
                                        "<br>Total Number of Grade 8 Students :   " + count8.ToString() +
                                        "<br>Total Number of Grade 9 Students   :   " + count9.ToString() +
                                       "<br>Total Number of Grade 10 Students :   " + count10.ToString() + "</br> </p>");
            }


            // add the line
            easyHTMLReports1.AddHorizontalRule();

            //Add the Datagrid
            easyHTMLReports1.AddDatagridView(dataGridView2);

            easyHTMLReports1.ShowPrintPreviewDialog();
            easyHTMLReports1.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            print1();
            


        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {



        }

        

        

        

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Left;
            panel1.Controls.Clear();
            panel1.Controls.Add(c);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showHideColumns(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
