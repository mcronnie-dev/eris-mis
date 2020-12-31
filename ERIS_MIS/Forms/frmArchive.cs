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
    public partial class frmArchive : Form
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        
        
        string _title = "ERIS MIS";
        public frmArchive()
        {
            InitializeComponent();
            
            LoadData();
            ComboBoxItems();
            textBox31.Visible = false;
            panel2.Hide();
        }
        private void frmArchive_Load(object sender, EventArgs e)
        {

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
            string query = "SELECT status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_level_section.year_level as 'Year Level', table_level_section.section as 'Section'  FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id WHERE status like '1' ORDER BY year_level + 0, section, first_name, last_name, student_no, status";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns["colRestore"].DisplayIndex = 6;
            this.panel1.Location = new System.Drawing.Point(24, 182);

        }

        //To get values of combox 2 (section) from combo box 1 (g level)
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM table_level_section WHERE year_level='" + comboBox1.Text + "' AND school_year='" + UserInfo.schoolYear + "'";
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
                    comboBox2.Items.Add(reader.GetString("section"));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //search button
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Show();
            this.panel1.Location = new System.Drawing.Point(24, 182);
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
            


            bs.Filter = filter;
            dataGridView1.DataSource = bs;
        }

        //clear button
        private void button4_Click(object sender, EventArgs e)
        {
            LoadData();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            
            panel1.Show();
            this.panel1.Location = new System.Drawing.Point(24, 182);
            panel2.Hide();

            
        }

        //close button
        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Show();
            this.panel1.Location = new System.Drawing.Point(24, 182);
            panel2.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox31.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colRestore")
            {   
                if (MessageBox.Show("Move to ACTIVE STUDENTS this record? Click Yes to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    command = new MySqlCommand("UPDATE table_students SET status = 0  where student_no like'" + textBox31.Text + "'", connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Record has been succesfully moved to Active Students.", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
        }

        private void frmArchive_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
