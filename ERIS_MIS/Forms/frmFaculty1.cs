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
    public partial class frmFaculty1: Form
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        internal static frmFaculty1 stud;
        string _title = "ERIS MIS";

        public frmFaculty1()
        {
            InitializeComponent();
            stud = this;
            

        }
        private void frmStudent_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(895, 592);
            LoadData();
            ComboBoxItems();
            textBox31.Visible = false;
            panel1.Hide();
            panel2.Hide();



        }
        private void ComboBoxItems()
        {
            comboBox1.Items.Add("Grade 7");
            comboBox1.Items.Add("Grade 8");
            comboBox1.Items.Add("Grade 9");
            comboBox1.Items.Add("Grade 10");
        }


        //To load data on datagridview1
        public void LoadData()
        {
            try
            {


                string query = "SELECT teacher_no as 'Teacher Number', first_name as 'First Name', last_name as 'Last Name', " +
                    "table_grade_level.grade_level as 'Year Level', table_subject.subject as 'Subject'" +
                    "FROM table_teacher INNER JOIN table_subject_assignment ON table_teacher.teacher_id = table_subject_assignment.teacher_id " +
                    "INNER JOIN table_subject ON table_subject_assignment.subject_id = table_subject.subject_id  " +
                    "INNER JOIN table_grade_level ON table_subject_assignment.grade_level_id = table_grade_level.grade_level_id " +
                    "ORDER BY table_grade_level.grade_level + 0  , last_name, first_name, teacher_no";
             
                command = new MySqlCommand(query, connection);
                adapter = new MySqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.Columns["colEdit"].DisplayIndex = 5;
                this.panel1.Location = new System.Drawing.Point(24, 182);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }





        //View Department List Button
        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        //To get values of combox 2 (section) from combo box 1 (g level)
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT DISTINCT table_grade_level.grade_level, table_subject.subject FROM  table_subject_assignment " +
                "INNER JOIN table_grade_level ON table_subject_assignment.grade_level_id = table_grade_level.grade_level_id " +
                "INNER JOIN table_subject ON table_subject_assignment.subject_id = table_subject.subject_id  WHERE grade_level='" + comboBox1.Text + "' ORDER BY table_subject.subject ASC";
            //string query = "SELECT table_level_section.year_level, table_subject.subject FROM table_subject INNER JOIN table_timesched ON table_subject.subject_id = table_timesched.subject_id INNER JOIN table_class ON table_timesched.class_id = table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id WHERE year_level='" + comboBox1.Text + "'";
            FillCombobox(query);
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
                    comboBox2.Items.Add(reader.GetString("subject"));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //pv to show class list (cmbbx1 and cmbbx2) filter
        private void ViewDepartmentList()
        {
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
                filter += "[Subject] LIKE '%" + comboBox2.Text + "%' ";
            }


            bs.Filter = filter;
            dataGridView1.DataSource = bs;
        }

        //Search Button
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Show();
            //this.panel1.Location = new System.Drawing.Point(24, 182);
            this.panel2.Location = new System.Drawing.Point(26, 182);
            panel2.Hide();

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
                filter += "[Teacher Number] LIKE '%" + textBox2.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Year Level] LIKE '%" + comboBox1.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(comboBox2.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Subject] LIKE '%" + comboBox2.Text + "%' ";
            }




            bs.Filter = filter;
            dataGridView1.DataSource = bs;
        }

        // ClearButton
        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            
            panel1.Hide();
            
            panel2.Hide();

           

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
            textBox31.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DataTable dt = new DataTable();
            MySqlDataReader myReader = null;
            frmFacultyInfo1 f = new frmFacultyInfo1();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            MySqlCommand myCommand = new MySqlCommand("SELECT * FROM table_teacher WHERE teacher_no='" + textBox31.Text + "'", connection);
            myReader = myCommand.ExecuteReader();
            myReader.Read();
            if (myReader.HasRows)
            {
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

                f.teacherNolabel.Text = textBox31.Text;
                f.lastNameTextBox.Text = (myReader["last_name"].ToString());
                f.firstNameTextBox.Text = (myReader["first_name"].ToString());
                f.middleNameTextBox.Text = (myReader["middle_name"].ToString());
                f.houseNoTextBox.Text = (myReader["house_no"].ToString());
                f.streetTextBox.Text = (myReader["street"].ToString());
                f.barangayTextBox.Text = (myReader["barangay"].ToString());
                f.cityCombobox.Text = (myReader["city_address"].ToString());
                f.zipCombobox.Text = (myReader["zip_code"].ToString());
                f.mobileNumberTextBox.Text = (myReader["teacher_mobile"].ToString());
                f.emailAddressTextBox.Text = (myReader["teacher_email"].ToString());
                //f.birthdaytxt.Text = (myReader["date_of_birth"].ToString());
                //f.GenderTextBox.Text = (myReader["gender"].ToString());

            }
            myReader.Close();
            connection.Close();
            f.ShowDialog();
        }



        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox31.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                editButton();
            }
           

           
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
