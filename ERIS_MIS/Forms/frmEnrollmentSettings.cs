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
    public partial class frmEnrollmentSettings : Form
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;

        public frmEnrollmentSettings()
        {
            InitializeComponent();
        }

        private void frmEnrollmentSettings_Load(object sender, EventArgs e)
        {
            GradeLevelComboBox();
            //loadData();
            searchData();
        }
        private void searchData()
        {
            string query = "SELECT table_grade_level.grade_level as 'Grade Level', table_level_section.section as 'Section', table_enrollment_settings.max_students as 'Max Students' " +
                "FROM table_enrollment_settings INNER JOIN table_level_section ON table_enrollment_settings.level_section_id = table_level_section.level_section_id " +
                "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
                "INNER JOIN table_sy ON table_enrollment_settings.sy_id = table_sy.sy_id WHERE table_sy.status = '1'" +
                "ORDER BY grade_level + 0, section";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;   
            
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;

            string filter = "";

            if (!string.IsNullOrEmpty(comboBox1.Text))
            {
                filter += "[Grade Level] LIKE '%" + comboBox1.Text + "%' ";

            }

            if (!string.IsNullOrEmpty(comboBox2.Text))
            {
                if (filter.Length > 0) filter += "AND ";
                filter += "[Section] LIKE '%" + comboBox2.Text + "%' ";
            }

            bs.Filter = filter;
            dataGridView1.DataSource = bs;
        }
        private void GradeLevelComboBox()
        {
            comboBox1.Items.Add("Grade 7");
            comboBox1.Items.Add("Grade 8");
            comboBox1.Items.Add("Grade 9");
            comboBox1.Items.Add("Grade 10");
           
        }

        private void loadData()
        {
            string query = "SELECT table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_level_section.year_level as 'Year Level', table_level_section.section as 'Section', table_students.sex as 'Gender'  " +
                    "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                    "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                    "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                    " ORDER BY year_level + 0, section, first_name, last_name, student_no, sex";

            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);


        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "Select * from table_sy INNER JOIN table_class ON table_sy.sy_id = table_class.sy_id " +
              "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
              "INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id " +
              "WHERE table_sy.status = '1' AND grade_level='" + comboBox1.Text + "'";

            //string query = "SELECT * FROM table_level_section INNER JOIN table_grade_level ON table_level_section.grade_level_id = table_grade_level.grade_level_id WHERE grade_level='" + comboBox1.Text + "'";
            FillCombobox(query);
            if (!string.IsNullOrEmpty(comboBox2.Text))
            {
                comboBox2.Enabled = true;
            }

            searchData();
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEnrollmentInfo f = new frmEnrollmentInfo();
            
            f.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEnrollmentPeriod f = new frmEnrollmentPeriod();

            f.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchData();
        }
    }
}
