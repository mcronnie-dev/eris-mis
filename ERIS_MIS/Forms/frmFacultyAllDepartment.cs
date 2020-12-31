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
    public partial class frmFacultyAllDepartment : Form
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;
        DataTable table;
        public frmFacultyAllDepartment()
        {
            InitializeComponent();
        }

        private void frmAllDepartment_Load(object sender, EventArgs e)
        {
            LoadData();

            radioButton1.Checked = true;
            label1.Hide();
            textBox31.Hide();

        }

       
        private void AddControlsToPanel(Control c)
        {
            FormAdmin a = new FormAdmin();
            c.Dock = DockStyle.Left;
            a.DashboardPanel.Controls.Clear();
            a.DashboardPanel.Controls.Add(c);
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAdmin a = new FormAdmin();
            frmFaculty1 f = new frmFaculty1();
            f.TopLevel = false;
            a.DashboardPanel.Controls.Add(f);
            f.BringToFront();
            f.Show();
        }


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
                

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void checkSubject ()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;

            string filter = "";

            if (radioButton1.Checked)
            {
                filter += "[Subject]  LIKE '%Science%' ";
            }

            else if (radioButton2.Checked)
            {
                filter += "[Subject]  LIKE '%AP%' ";
            }

            else if (radioButton3.Checked)
            {
                filter += "[Subject]  LIKE '%ESP%' ";
            }

            else if (radioButton4.Checked)
            {
                filter += "[Subject]  LIKE '%Math%' ";
            }
            else if (radioButton5.Checked)
            {
                filter += "[Subject]  LIKE '%English%' ";
            }
            else if (radioButton6.Checked)
            {
                filter += "[Subject]  LIKE '%Filipino%' ";
            }
            else if (radioButton7.Checked)
            {
                filter += "[Subject]  LIKE '%TLE%' ";
            }
            else if (radioButton8.Checked)
            {
                filter += "[Subject]  LIKE '%SPED%' ";
            }
            else 
            {
                filter += "[Subject]  LIKE '%MAPEH%' ";
            }


            bs.Filter = filter;
            dataGridView1.DataSource = bs;

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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Science_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AP_Click(object sender, EventArgs e)
        {
           
        }

        private void EP_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkSubject();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            checkSubject();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkSubject();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            checkSubject();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            checkSubject();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            checkSubject();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            checkSubject();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            checkSubject();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            checkSubject();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editButton();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string colName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (colName == "colEdit")
            {
                editButton();
            }
        }
    }
}
