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
    public partial class frmGradingViewClass : Form
    {
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        MySqlCommand command;
        MySqlDataAdapter adapter;
        SystemGeneralData data = new SystemGeneralData();

        public frmGradingViewClass()
        {
            InitializeComponent();
        }

        private void frmGradingViewClass_Load(object sender, EventArgs e)
        {
            label5.Text = data.GetActiveAcademicYear();
            label8.Text = data.GetActiveGradingPeriod();
            LoadAdvisoryStudents();
            LoadGradeLevelAndSection();
        }

        private void LoadAdvisoryStudents() {

            DataTable table;
            string query = "SELECT table_students.student_no AS 'Student Number', CONCAT(table_students.last_name,', ',table_students.first_name,' ',table_students.middle_name) AS Name FROM table_students INNER JOIN table_enrollment ON table_students.student_id = table_enrollment.student_id INNER JOIN table_class ON table_enrollment.class_id =table_class.class_id WHERE  table_class.sy_id = '"+data.GetActiveAcademicYearID()+"' AND table_class.teacher_id = '"+UserInfo.teacherID+"'";
            command = new MySqlCommand(query, connection);
            adapter = new MySqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //hide the last row
            this.dataGridView1.AllowUserToAddRows = false;

        }

        //To Load the Grade_Level and Section of the teacher_adviser
        private void LoadGradeLevelAndSection()
        {
            try
            {

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string sql = "Select DISTINCT table_grade_level.grade_level, table_level_section.section FROM table_level_section INNER JOIN table_class ON table_level_section.level_section_id = table_class.level_section_id INNER JOIN table_grade_level ON table_grade_level.grade_level_id = table_level_section.grade_level_id WHERE table_class.teacher_id = '" + UserInfo.teacherID + "' AND table_class.sy_id ='" + data.GetActiveAcademicYearID() + "'";//new
                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    gradeLevelLabel.Text = reader.GetString("grade_level");
                    sectionLabel.Text = reader.GetString("section");

                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void LoadStudentGrades(string selectedStudentNo) {
            try
            {
                
                //MessageBox.Show(selectedStudentNo);
                DataTable table1 = this.GetData("SELECT DISTINCT subject AS 'Subjects' FROM table_subject WHERE subject<>'Homeroom'");
                DataTable table2 = this.GetData("SELECT DISTINCT table_subject.subject AS 'Subjects', table_grades.student_grade AS '1st' FROM table_subject INNER JOIN table_subject_assignment ON table_subject.subject_id = table_subject_assignment.subject_id INNER JOIN table_grades ON table_subject_assignment.assignment_id = table_grades.assignment_id INNER JOIN table_students ON table_grades.student_id = table_students.student_id WHERE table_grades.sy_id ='"+data.GetActiveAcademicYearID()+"' AND table_students.student_no = '"+selectedStudentNo+"' AND table_subject.subject<>'Homeroom' AND table_grades.grading_period_id = '1'");
                DataTable table3 = this.GetData("SELECT DISTINCT table_subject.subject AS 'Subjects', table_grades.student_grade AS '2nd' FROM table_subject INNER JOIN table_subject_assignment ON table_subject.subject_id = table_subject_assignment.subject_id INNER JOIN table_grades ON table_subject_assignment.assignment_id = table_grades.assignment_id INNER JOIN table_students ON table_grades.student_id = table_students.student_id WHERE table_grades.sy_id ='" + data.GetActiveAcademicYearID() + "' AND table_students.student_no = '" + selectedStudentNo + "' AND table_subject.subject<>'Homeroom' AND table_grades.grading_period_id = '2'");
                DataTable table4 = this.GetData("SELECT DISTINCT table_subject.subject AS 'Subjects', table_grades.student_grade AS '3rd' FROM table_subject INNER JOIN table_subject_assignment ON table_subject.subject_id = table_subject_assignment.subject_id INNER JOIN table_grades ON table_subject_assignment.assignment_id = table_grades.assignment_id INNER JOIN table_students ON table_grades.student_id = table_students.student_id WHERE table_grades.sy_id ='" + data.GetActiveAcademicYearID() + "' AND table_students.student_no = '" + selectedStudentNo + "' AND table_subject.subject<>'Homeroom' AND table_grades.grading_period_id = '3'");
                DataTable table5 = this.GetData("SELECT DISTINCT table_subject.subject AS 'Subjects', table_grades.student_grade AS '4th' FROM table_subject INNER JOIN table_subject_assignment ON table_subject.subject_id = table_subject_assignment.subject_id INNER JOIN table_grades ON table_subject_assignment.assignment_id = table_grades.assignment_id INNER JOIN table_students ON table_grades.student_id = table_students.student_id WHERE table_grades.sy_id ='" + data.GetActiveAcademicYearID() + "' AND table_students.student_no = '" + selectedStudentNo + "' AND table_subject.subject<>'Homeroom' AND table_grades.grading_period_id = '4'");

                table1.PrimaryKey = new DataColumn[] { table1.Columns["Subjects"] };
                table2.PrimaryKey = new DataColumn[] { table2.Columns["Subjects"] };
                table3.PrimaryKey = new DataColumn[] { table3.Columns["Subjects"] };
                table4.PrimaryKey = new DataColumn[] { table4.Columns["Subjects"] };
                table5.PrimaryKey = new DataColumn[] { table5.Columns["Subjects"] };

                table4.Merge(table5);
                table4.AcceptChanges();
                table3.Merge(table4);
                table3.AcceptChanges();
                table2.Merge(table3);
                table2.AcceptChanges();
                table1.Merge(table2);
                table1.AcceptChanges();

                dataGridView2.DataSource = table1;
                dataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //hide the last row
                this.dataGridView2.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Display the data from the database to the dataGridView
        private DataTable GetData(string sql)
        {
            using (MySqlCommand cmd = new MySqlCommand(sql, connection))
            {
                cmd.CommandType = CommandType.Text;
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                string selectedStudentNo = Convert.ToString(selectedRow.Cells["Student Number"].Value);
                //MessageBox.Show(selectedStudentNo);
                dataGridView2.DataSource = null;
                dataGridView2.Columns.Clear();
                LoadStudentGrades(selectedStudentNo);
                addColumn();
                
            }
        }

        private void addColumn()
        {
           
            dataGridView2.Refresh();     
            DataGridViewTextBoxColumn aveColumn = new DataGridViewTextBoxColumn();
            aveColumn.HeaderText = "Average";
            aveColumn.Width = 100;
            aveColumn.Name = "Average";
            dataGridView2.Columns.Add(aveColumn);

            ////Add a ComboBox Column to the DataGridView.
            //DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            //comboBoxColumn.HeaderText = "Status";
            //comboBoxColumn.Width = 100;
            //comboBoxColumn.Name = "Status";
            //dataGridView2.Columns.Add(comboBoxColumn);

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                // Loop the computed average rows
                //Reference the TextBoxCell.
                DataGridViewTextBoxCell AverageBoxCell = (row.Cells[5] as DataGridViewTextBoxCell);


                if (AverageBoxCell != null)
                {
                    int[] arr = new int[4];
                    int total = 0, temp2 = 0;
                    int divisor = 0;
                    string temp, finalGrade = "";


                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (row.Cells[i + 1].Value != null)
                        {   //arr[i] = Int32.Parse(row.Cells[i + 3].Value.ToString());

                            temp = row.Cells[i + 1].Value.ToString();
                            if (int.TryParse(temp, out temp2))
                            {
                                //int a=0;
                                arr[i] = temp2;
                                total += arr[i];
                                divisor += 1;

                            }

                        }
                    }
                    ///////////////////////////////NOT OPTIMIZED /////////////////////////////////////////
                        DateTime now = DateTime.Now;
                     
                        string[] dateTimesFirstGrading = data.GetIsGradeEncodingActive(1);
                        string[] dateTimesSecondGrading = data.GetIsGradeEncodingActive(2);
                        string[] dateTimesThirdGrading = data.GetIsGradeEncodingActive(3);
                        string[] dateTimesFourthGrading = data.GetIsGradeEncodingActive(4);
                        string activeColumn = "";

                        if (now >= Convert.ToDateTime(dateTimesFirstGrading[0]) && now < Convert.ToDateTime(dateTimesFirstGrading[1]))
                        {
                        activeColumn = "1st"; 
                        }
                        else if (now >= Convert.ToDateTime(dateTimesSecondGrading[0]) && now < Convert.ToDateTime(dateTimesSecondGrading[1]))
                        {
                            activeColumn = "2nd"; 
                        }
                        else if (now >= Convert.ToDateTime(dateTimesThirdGrading[0]) && now < Convert.ToDateTime(dateTimesThirdGrading[1]))
                        {
                            activeColumn = "3rd";
                        }
                        else if (now >= Convert.ToDateTime(dateTimesFourthGrading[0]) && now < Convert.ToDateTime(dateTimesFourthGrading[1]))
                        {
                            activeColumn = "4th";
                        }
                        else
                        {
                            activeColumn = "1st";
                        }

                        //Compute for the average
                        if (activeColumn == "1st")
                        {
                            finalGrade = Convert.ToString((total / 1));
                        }
                        else if (activeColumn == "2nd")
                        {
                            finalGrade = Convert.ToString((total / 2));
                        }
                        else if (activeColumn == "3rd")
                        {
                            finalGrade = Convert.ToString((total / 3));
                        }
                        else if (activeColumn == "4th")
                        {
                            finalGrade = Convert.ToString((total / 4));
                        }
                        else
                        {
                            finalGrade = Convert.ToString((total / 1));
                        }

                        //Display the average in each row 
                        AverageBoxCell.Value = finalGrade;
                        }

                    //////////////////////////////////////
               
            }
    

        }


        private void button2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
