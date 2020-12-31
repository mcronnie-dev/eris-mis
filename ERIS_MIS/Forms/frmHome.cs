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
using System.Windows.Forms.DataVisualization.Charting;
using ERIS_MIS.Config;

namespace ERIS_MIS.Forms
{
    public partial class frmHome : Form
    {

        MySqlConnection conn = new MySqlConnection(Config1.connectionString);
        private int i = 0;
        public frmHome()
        {
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        
            private void frmHome_Load(object sender, EventArgs e)
        {
            
            //pictureBox1.Image = Image.FromFile("image/" + pictures[0]);
            showLabel();
            countNum();
            CreateChart();
            label9.Hide();
            label10.Hide();
            label13.Hide();
            label14.Hide();
            displayData();
            
            firstLoadEventVal();
            bunifuImageButton1.Focus();
            eventDescription.ScrollBars = ScrollBars.Vertical;
            eventDescription.TextAlign = HorizontalAlignment.Left;
            eventDescription.ReadOnly = true;
            label6.Hide();
            //eventDescription.Enabled = false;

            label7.Hide();
            label2.Hide();
            label3.Hide();
           

        }
        private void countNum()
        {
            conn.Open();
            //string query = "Select COUNT(student_no) From table_students";
            //MySqlCommand command = new MySqlCommand(query, conn);
            //int count = Convert.ToInt32(command.ExecuteScalar());
            //label19.Text = count.ToString();
            

            string query1 = "Select COUNT(teacher_no) From table_teacher";
            MySqlCommand command1 = new MySqlCommand(query1, conn);
            int count1 = Convert.ToInt32(command1.ExecuteScalar());
            label16.Text = count1.ToString();
            conn.Close();
        }

        //Load Picture
        private int imageNumber = 1;
        private void loadNextImage ()
        {
            if(imageNumber == 7)
            {
                imageNumber = 1;
            }

            pictureBox1.ImageLocation = string.Format(@"Image\{0}.jpg", imageNumber);
            imageNumber++;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            loadNextImage();
        }

        
        private void timer2_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToString("hh:mm:ss ");
            label12.Text = DateTime.Now.ToLongDateString();
        }

       
        private void CreateChart()
        {
            this.Chart1.DataSource = GetData();
            this.Chart1.Series.Clear();
            Chart1.ChartAreas.Clear();
            Chart1.ChartAreas.Add("Area0");
            this.Chart1.Series.Add("Number of Students");
            Chart1.Series["Number of Students"].ChartType = SeriesChartType.Column;


            Chart1.Series[0].XValueMember = "Grade Level";
            Chart1.Series[0].YValueMembers = "Number";
            Chart1.Series[0].IsValueShownAsLabel = true;
            Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -90;
            Chart1.Series[0]["PieLabelStyle"] = "Outside";
            Chart1.Series[0].BorderWidth = 1;
            Chart1.Series[0].BorderColor = Color.Black;
            Chart1.Series[0].Color = Color.FromArgb(11, 83, 157);

            //Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            Chart1.Series[0].IsVisibleInLegend = false;
            Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            Chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            Chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;




        }
        int totalval = 0;
        public DataTable GetData()
        {
            int val1 = int.Parse(label9.Text);
            int val2 = int.Parse(label10.Text);
            int val3 = int.Parse(label13.Text);
            int val4 = int.Parse(label14.Text);
            totalval = val1 + val2 + val3 + val4;
            label19.Text = totalval.ToString(); 

            var dt = new DataTable();
            dt.Columns.Add("Grade Level", typeof(string));
            dt.Columns.Add("Number", typeof(int));
            //dt.Columns.Add("Physics", typeof(int));
            dt.Rows.Add("Grade 7", val1);
            dt.Rows.Add("Grade 8", val2);
            dt.Rows.Add("Grade 9", val3);
            dt.Rows.Add("Grade 10", val4);
            return dt;
        }

        private void showLabel()
        {
            try
            {

                //MySqlCommand cmd = new MySqlCommand("SELECT status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_level_section.year_level as 'Year Level', table_level_section.section as 'Section'  FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id WHERE year_level like 'Grade 9' ");
                string query = "SELECT file_status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section'  " +
                     "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                     "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                     "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                     "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                     "INNER JOIN table_sy ON table_class.sy_id = table_sy.sy_id " +
                "WHERE table_grade_level.grade_level like 'Grade 7' and table_sy.status = 1 " +
                "ORDER BY grade_level + 0, section, first_name, last_name, student_no ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd.CommandText, conn);
                DataSet ds = new DataSet();
                conn.Open();
                ap.Fill(ds);
                label9.Text = ds.Tables[0].Rows.Count.ToString();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {

                //MySqlCommand cmd = new MySqlCommand("SELECT status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_level_section.year_level as 'Year Level', table_level_section.section as 'Section'  FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id WHERE year_level like 'Grade 9' ");
                string query = "SELECT file_status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section'  " +
                       "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                       "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                       "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                       "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                       "INNER JOIN table_sy ON table_class.sy_id = table_sy.sy_id " +
                  "WHERE table_grade_level.grade_level like 'Grade 8' and table_sy.status = 1 " +
                "ORDER BY grade_level + 0, section, first_name, last_name, student_no ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd.CommandText, conn);
                DataSet ds = new DataSet();
                conn.Open();
                ap.Fill(ds);
                label10.Text = ds.Tables[0].Rows.Count.ToString();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            try
            {

                //MySqlCommand cmd = new MySqlCommand("SELECT status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_level_section.year_level as 'Year Level', table_level_section.section as 'Section'  FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id WHERE year_level like 'Grade 9' ");
                string query = "SELECT file_status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section'  " +
                      "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                      "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                      "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                      "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                      "INNER JOIN table_sy ON table_class.sy_id = table_sy.sy_id " +
                 "WHERE table_grade_level.grade_level like 'Grade 9' and table_sy.status = 1 " +
                "ORDER BY grade_level + 0, section, first_name, last_name, student_no ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd.CommandText, conn);
                DataSet ds = new DataSet();
                conn.Open();
                ap.Fill(ds);
                label13.Text = ds.Tables[0].Rows.Count.ToString();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {

                //MySqlCommand cmd = new MySqlCommand("SELECT status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_level_section.year_level as 'Year Level', table_level_section.section as 'Section'  FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id WHERE year_level like 'Grade 9' ");
                string query = "SELECT file_status as 'Status',  table_students.student_no as 'Student Number',  table_students.first_name as 'First Name', table_students.last_name as 'Last Name', table_grade_level.grade_level as 'Year Level', table_level_section.section as 'Section'  " +
                      "FROM table_enrollment INNER JOIN table_students ON table_enrollment.student_id= table_students.student_id " +
                      "INNER JOIN table_class ON table_enrollment.class_id = table_class.class_id " +
                      "INNER JOIN table_level_section ON table_class.level_section_id = table_level_section.level_section_id " +
                      "INNER JOIN table_grade_level ON table_level_section.grade_level_id= table_grade_level.grade_level_id " +
                      "INNER JOIN table_sy ON table_class.sy_id = table_sy.sy_id " +
                 "WHERE table_grade_level.grade_level like 'Grade 10' and table_sy.status = 1 " +
                "ORDER BY grade_level + 0, section, first_name, last_name, student_no ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter ap = new MySqlDataAdapter(cmd.CommandText, conn);
                DataSet ds = new DataSet();
                conn.Open();
                ap.Fill(ds);
                label14.Text = ds.Tables[0].Rows.Count.ToString();
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void displayData()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM table_settings", conn);
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();

                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            if (sdr["name"].ToString() == "Mission")
                            {
                                textBox1.Text = sdr["description"].ToString();
                                label7.Text = sdr["id"].ToString();
                            }
                            if (sdr["name"].ToString() == "Vision")
                            {
                                textBox2.Text = sdr["description"].ToString();
                                label2.Text = sdr["id"].ToString();
                            }
                            if (sdr["name"].ToString() == "Core Values")
                            {
                                textBox3.Text = sdr["description"].ToString();
                                label3.Text = sdr["id"].ToString();
                            }
                        }
                    }
                }
                conn.Close();
            }
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.TextAlign = HorizontalAlignment.Center;
            textBox1.ReadOnly = true;
            textBox1.BackColor = Color.White;
            textBox2.ReadOnly = true;
            textBox2.BackColor = Color.White;
            textBox3.ReadOnly = true;
            textBox3.BackColor = Color.White;

        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {


        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            FormAdmin.admin.openEvents();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            FormAdmin.admin.openStudents();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void firstLoadEventVal ()
        {
            frmEvents f = new frmEvents();
            f.LoadData();
            f.LoadData1();
            if (i < f.dataGridView2.Rows.Count)
            {
                eventTitle.Text = f.dataGridView2.Rows[i].Cells[1].Value.ToString();
                eventDescription.Text = f.dataGridView2.Rows[i].Cells[2].Value.ToString();
            }
            else
            {
                eventTitle.Text = "No Event on the List";
                eventDescription.Text = "";
            }
            
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            
            frmEvents f = new frmEvents();
            f.LoadData();
            f.LoadData1();
            if (i <f.dataGridView2.Rows.Count)
            {
                label6.Text = i.ToString();
                eventTitle.Text = f.dataGridView2.Rows[i].Cells[1].Value.ToString();
                eventDescription.Text = f.dataGridView2.Rows[i].Cells[2].Value.ToString();
                i++;
                if (i == f.dataGridView2.Rows.Count)
                {
                    i = 0;

                }

            }
            else
            {
                eventTitle.Text = "No Event on the List";
                eventDescription.Text = "";

            }
            

            //frmEvents.events.DisplayEvent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void eventDescription_MouseDown(object sender, MouseEventArgs e)
        {
            bunifuImageButton1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
