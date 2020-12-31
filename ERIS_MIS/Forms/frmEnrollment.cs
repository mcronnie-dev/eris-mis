using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ERIS_MIS.Config;

namespace ERIS_MIS.Forms
{
    public partial class frmEnrollment : Form
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        SystemGeneralData data = new SystemGeneralData(); //new
        string g7 = "Grade 7";
        string g8 = "Grade 8";
        string g9 = "Grade 9";
        string g10 = "Grade 10";
        string _title = "ERIS MIS";
        public frmEnrollment()
        {
            InitializeComponent();
            this.AutoScroll = true;
            this.VerticalScroll.Visible = false;
            this.HorizontalScroll.Visible = false;
            checkVal();
            groupBox1.Hide();

        }
        
        

        private void frmEnrollment_Load(object sender, EventArgs e)
        {
            //new
            label2.Text = data.GetPreviousAcademicYear();
            label17.Text = data.GetActiveAcademicYear();
            label19.Hide();
            comboBox1.Focus();
            sectionComboBoxCurrent.Enabled = false; 
            ComboBoxItems();
            
        }

        private void showHideColumns(Boolean colHideStatus)
        {
            dataGridView2.Columns[0].Visible = colHideStatus;
        }


        private void ComboBoxItems()
        {
            comboBox1.Items.Add("Grade 7");
            comboBox1.Items.Add("Grade 8");
            comboBox1.Items.Add("Grade 9");

        }

        private void transfereeCombo()
        {
            comboBox1.Items.Add("Grade 7");
            comboBox1.Items.Add("Grade 8");
            comboBox1.Items.Add("Grade 9");
            comboBox1.Items.Add("Grade 10");

        }
        private void checkVal ()
        {
            frmEnrollmentStudentInfo f = new frmEnrollmentStudentInfo();
            if (f.testVal == 1)
            {
                
                panel4.Location = new System.Drawing.Point(35, 17);
                dataGridView2.Size = new System.Drawing.Size(1239, 507);
                dataGridView2.Location = new System.Drawing.Point(54, 126);
                button2.Location = new System.Drawing.Point(1038, 649);
                panel1.Hide();
                dataGridView1.Hide();
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchData();
            groupBox1.Show();
            sectionComboBoxCurrent.Enabled = true;
            label9.Show();
            label8.Show();
            label8.Text = comboBox2.Text.ToString();
            searchData();
            groupBox1.Show();
            panel4.Hide();
            dataGridView2.Hide();
            button2.Hide();
        }

        private void addGradeLEvelNo ()
        {
            if (comboBox1.Text == "Grade 7")
            {
                label18.Text = "8";
            }

            else if (comboBox1.Text == "Grade 8")
            {
                label18.Text = "9";
            }
            else 
            {
                label18.Text = "10";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Hide();
            comboBox2.SelectedIndex = -1;
            sectionComboBoxCurrent.SelectedIndex = -1;
            panel4.Hide();
            button2.Hide();
            groupBox1.Hide();
            label6.Show();
            label7.Show();
            label7.Text = comboBox1.Text.ToString();
            slotsEnrolledTextbox.Clear();
            dataGridView2.Hide();
            
            addGradeLEvelNo();

            string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
                "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
                "WHERE table_sy.status = '2' AND table_grade_level.grade_level='" + comboBox1.Text + "'";

            //string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + comboBox1.Text + "'";
            FillCombobox(query);
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                comboBox2.Enabled = true;
            }
            
            selectSection();
            sectionComboBoxCurrent.SelectedIndex = -1;
            dataGridView2.DataSource = null;
            //dataGridView2.Hide();
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

        public void searchData()
        {
            string query = "SELECT table_students.student_id as 'Student ID', table_class.class_id as 'Class ID', table_grade_level.grade_level_id as 'Grade Level ID', table_level_section.level_section_id as 'Level Section ID', table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section', table_students.sex as 'Gender'   " +
                   "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " + "AND (table_enrollment.status_inactive IS NULL OR table_enrollment.status_inactive = 0) " +
                   "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                   "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                   "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                   "ORDER BY grade_level + 0, section, first_name, last_name, student_no, sex";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.Columns["Student ID"].Visible = false;
            dataGridView1.Columns["Class ID"].Visible = false;
            dataGridView1.Columns["Grade Level ID"].Visible = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;

            string filter = "";

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
        }

        DataTable table1;
        BindingSource bs1;
        public void searchData1()
        {
            string query = "SELECT table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section', table_students.sex as 'Gender'   " +
                   "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " + "AND (table_enrollment.status_inactive IS NULL OR table_enrollment.status_inactive = 0) " +
                   "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                   "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                   "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                   "ORDER BY grade_level + 0, section, first_name, last_name, student_no, sex";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table1 = new DataTable();
            adapter.Fill(table1);
            dataGridView2.DataSource = table1;
            dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            bs1 = new BindingSource();
            bs1.DataSource = dataGridView2.DataSource;

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

            if (!string.IsNullOrEmpty(sectionComboBoxCurrent.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Section] LIKE '%" + sectionComboBoxCurrent.Text + "%' ";
            }

            bs1.Filter = filter;
            dataGridView2.DataSource = bs1;


        }

        private void selectSection()
        {
            if (comboBox1.Text == "")
            {
                //string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + g7 + "'";
                string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
               "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
               "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
               "WHERE table_sy.status = '1' AND grade_level='" + g7 + "'";
                FillComboboxForSelectSection(query);
                if (!string.IsNullOrEmpty(comboBox2.Text))
                {
                    sectionComboBoxCurrent.Enabled = true;
                }
            }

            if (comboBox1.Text == "Grade 7")
            {
                //string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + g8+ "'";
                string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
                "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
                "WHERE table_sy.status = '1' AND grade_level='" + g8 + "'";
                FillComboboxForSelectSection(query);
                if (!string.IsNullOrEmpty(comboBox2.Text))
                {
                    sectionComboBoxCurrent.Enabled = true;
                }
            }

            if (comboBox1.Text == "Grade 8")
            {
                //string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + g8+ "'";
                string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
                "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
                "WHERE table_sy.status = '1' AND grade_level='" + g9 + "'";
                FillComboboxForSelectSection(query);
                if (!string.IsNullOrEmpty(comboBox2.Text))
                {
                    sectionComboBoxCurrent.Enabled = true;
                }
            }

            if (comboBox1.Text == "Grade 9")
            {
                //string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + g8+ "'";
                string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
                "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
                "WHERE table_sy.status = '1' AND grade_level='" + g10 + "'";
                FillComboboxForSelectSection(query);
                if (!string.IsNullOrEmpty(comboBox2.Text))
                {
                    sectionComboBoxCurrent.Enabled = true;
                }
            }
        }

        protected void FillComboboxForSelectSection(string query)
        {

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                sectionComboBoxCurrent.Items.Clear();
                while (reader.Read())
                {
                    sectionComboBoxCurrent.Items.Add(reader.GetString("section"));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label26.Text = label18.Text.ToString();
            label11.Text = sectionComboBoxCurrent.Text.ToString();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            string query = "Select * from table_enrollment_settings INNER JOIN table_level_section  ON table_enrollment_settings.level_section_id = table_level_section.level_section_id  " +
             "WHERE table_level_section.section ='" + sectionComboBoxCurrent.Text + "'";
            command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                slotsMaxTextbox.Text = (reader.GetString("max_students"));
            }
            connection.Close();

            panel4.Show();
            dataGridView2.Show();
            button2.Show();
            searchData1();
            if (dataGridView2.Rows != null && dataGridView2.Rows.Count != 0)
            {
                slotsEnrolledTextbox.Text = dataGridView2.Rows.Count.ToString();
                int x = dataGridView2.Rows.Count;
                int maxstud = Convert.ToInt32(slotsMaxTextbox.Text);
                int y = maxstud - x;
                slotsAvailableTextbox.Text = y.ToString();
                var countMale = dataGridView2.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[6].Value.ToString().Trim() == "Male");
                var countFemale = dataGridView2.Rows.Cast<DataGridViewRow>().Count(r => r.Cells[6].Value.ToString().Trim() == "Female");
                slotsMaleTextbox.Text = countMale.ToString();
                slotsFemaleTextbox.Text = countFemale.ToString();
            }
            else
            {
                slotsEnrolledTextbox.Text = "0";
                slotsAvailableTextbox.Text = "50";
                slotsMaleTextbox.Text = "0";
                slotsFemaleTextbox.Text = "0";
            }
            

        }


        private void button2_Click(object sender, EventArgs e)
        {
            List<string> selectedStudentIdArray = new List<string>();
            List<int> selectedClassIdArray = new List<int>();
            List<object> enrolledDetailsArray = new List<object>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // if selected row
                if (row.Cells[0].Value != null)
                {

                    string studentId = row.Cells[1].Value.ToString();
                    int classId = Convert.ToInt32(row.Cells[2].Value.ToString());
                    int gradeLevelId = Convert.ToInt32(row.Cells[3].Value.ToString());

                    selectedStudentIdArray.Add(studentId);
                    selectedClassIdArray.Add(classId);

                    // Gets class ID for grade level to enroll to
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            connection.Open();
                        }

                        string sectionNameToEnroll = sectionComboBoxCurrent.Text;
                        string query = $"SELECT class_id FROM table_class LEFT JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id WHERE table_level_section.section = '{sectionNameToEnroll}'";
                        command = new MySqlCommand(query, connection);

                        Trace.WriteLine("GET CLASS ID OF CLASS TO ENROL QUERY: " + command.CommandText);

                        List<object> studentIdClassIdPair = new List<object>();
                        studentIdClassIdPair.Add("'" + studentId + "'");
                        var classIdToEnroll = command.ExecuteScalar();
                        studentIdClassIdPair.Add(classIdToEnroll);
                        studentIdClassIdPair.Add(0); // status_inactive

                        string newStudentClassPair = string.Join(",", studentIdClassIdPair.ToArray());
                        enrolledDetailsArray.Add("(" + newStudentClassPair + ")");

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to set inactive status of students selected: " + ex.Message);
                        connection.Close();
                    }
                }
            }

            string newSelectedStudentIdArray = string.Join(",", selectedStudentIdArray.ToArray());
            string newSelectedClassIdArray = string.Join(",", selectedClassIdArray.ToArray());
            string newEnrolledDetailsArray = string.Join(",", enrolledDetailsArray.ToArray());


            // Set inactive status to 0 of students in their current grade level
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = $"UPDATE table_enrollment SET status_inactive = 1 WHERE student_id IN ({newSelectedStudentIdArray}) AND class_id IN ({newSelectedClassIdArray})";
                command = new MySqlCommand(query, connection);

                Trace.WriteLine("UNENROLL TO CURRENT GRADE QUERY: " + command.CommandText);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to set inactive status of students selected: " + ex.Message);
                connection.Close();
            }

            // Set inactive status to 1 of students in their enrolled grade level
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = $"INSERT INTO table_enrollment(student_id, class_id, status_inactive ) VALUES {newEnrolledDetailsArray}";
                MySqlCommand command = new MySqlCommand(query, connection);

                Trace.WriteLine("ENROL TO NEXT GRADE QUERY: " + command.CommandText);

                command.ExecuteNonQuery();

                connection.Close();

                // Reload Data Grid Views 1 and 2
                searchData();
                searchData1();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to enroll students selected: " + ex.Message);
                connection.Close();
            }

            MessageBox.Show("Students has been succesfully enrolled!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
