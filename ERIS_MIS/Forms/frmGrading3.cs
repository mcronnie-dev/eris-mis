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
    public partial class frmGrading3 : Form
    {
        //private const string ConnectionString = "Server=localhost;Database=eris_mis;Uid=root;Pwd=;";
        //private const string ConnectionString = "datasource=localhost;port=3306;Initial Catalog='eris_mis';username=root;password=";
        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        internal static frmStudent stud;
        string _title = "ERIS MIS";
        SystemGeneralData data = new SystemGeneralData();
        DateTime now = new DateTime();


        private string selectedSubject = "";
        private string activeColumn="";
        
        public frmGrading3()
        {
            InitializeComponent();
        }

        private void frmGrading3_Load(object sender, EventArgs e)
        {
            //Display Active Academic Year and Active Grading Period
            label5.Text = data.GetActiveAcademicYear();

            string str = data.GetActiveGradingPeriod();
            switch(str){
                
                case "2nd":
                    label8.Text = "1st";
                    break;
                case "3rd":
                    label8.Text = "2nd";
                    break;
                case "4th":
                    label8.Text = "3rd";
                    break;
                default:
                    label8.Text = "";
                    break;
            }

            string[] arr=data.GetIsGradeEncodingActive(data.GetActiveGradingPeriodID()-1);
            label14.Text = arr[0];
            label16.Text = arr[1];


            button2.Enabled = false;

            //Prepare the Grade Level and Section handled by adviser
            LoadGradeLevelAndSection();

            //Place content to the subject dropdown
            FillSubjectCombobox();

            // ComboBoxItems();
            statusComboBox();
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
                string sql = "Select DISTINCT table_grade_level.grade_level, table_level_section.section FROM table_level_section INNER JOIN table_class ON table_level_section.level_section_id = table_class.level_section_id INNER JOIN table_grade_level ON table_grade_level.grade_level_id = table_level_section.grade_level_id WHERE table_class.teacher_id = '" + UserInfo.teacherID + "' AND table_class.sy_id ='"+data.GetActiveAcademicYearID()+"'";//new
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




        //To load Data
        public void LoadData()
        {
            int assignmentID = this.GetAssignmentID();
            try
            {
                //MessageBox.Show("This is the value of assignment ID ="+ assignmentID);
                DataTable dt = new DataTable();
                dt = this.GetData("SELECT DISTINCT table_students.student_no as 'Student Number',  CONCAT(table_students.last_name,', ',table_students.first_name,' ',table_students.middle_name) AS Name FROM table_students INNER JOIN table_enrollment ON table_students.student_id = table_enrollment.student_id INNER JOIN table_class ON table_enrollment.class_id=table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id=table_level_section.level_section_id INNER JOIN table_grade_level ON table_level_section.grade_level_id=table_grade_level.grade_level_id WHERE table_class.sy_id = '"+data.GetActiveAcademicYearID()+"' AND table_class.teacher_id ='"+UserInfo.teacherID+"' AND table_level_section.section = '"+sectionLabel.Text+"' AND table_grade_level.grade_level ='"+gradeLevelLabel.Text+"'");
                
                DataTable dt1 = new DataTable();
                dt1 = this.GetData("SELECT DISTINCT table_students.student_no as 'Student Number',  CONCAT(table_students.last_name,', ',table_students.first_name,' ',table_students.middle_name) AS Name, table_grades.student_grade AS '1st' FROM table_students INNER JOIN table_enrollment ON table_students.student_id = table_enrollment.student_id INNER JOIN table_class ON table_enrollment.class_id=table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id=table_level_section.level_section_id INNER JOIN table_grade_level ON table_level_section.grade_level_id=table_grade_level.grade_level_id INNER JOIN table_grades ON table_students.student_id=table_grades.student_id WHERE table_class.sy_id = '" + data.GetActiveAcademicYearID() + "' AND table_class.teacher_id ='" + UserInfo.teacherID + "' AND table_level_section.section = '" + sectionLabel.Text + "' AND table_grade_level.grade_level ='" + gradeLevelLabel.Text + "' AND table_grades.grading_period_id ='1' AND table_grades.assignment_id = '"+assignmentID+"'");

                DataTable dt2 = new DataTable();
                dt2 = this.GetData("SELECT DISTINCT table_students.student_no as 'Student Number',  CONCAT(table_students.last_name,', ',table_students.first_name,' ',table_students.middle_name) AS Name, table_grades.student_grade AS '2nd' FROM table_students INNER JOIN table_enrollment ON table_students.student_id = table_enrollment.student_id INNER JOIN table_class ON table_enrollment.class_id=table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id=table_level_section.level_section_id INNER JOIN table_grade_level ON table_level_section.grade_level_id=table_grade_level.grade_level_id INNER JOIN table_grades ON table_students.student_id=table_grades.student_id WHERE table_class.sy_id = '" + data.GetActiveAcademicYearID() + "' AND table_class.teacher_id ='" + UserInfo.teacherID + "' AND table_level_section.section = '" + sectionLabel.Text + "' AND table_grade_level.grade_level ='" + gradeLevelLabel.Text + "' AND table_grades.grading_period_id ='2' AND table_grades.assignment_id = '" +assignmentID+ "'");

                DataTable dt3 = new DataTable();
                dt3 = this.GetData("SELECT DISTINCT table_students.student_no as 'Student Number',  CONCAT(table_students.last_name,', ',table_students.first_name,' ',table_students.middle_name) AS Name, table_grades.student_grade AS '3rd' FROM table_students INNER JOIN table_enrollment ON table_students.student_id = table_enrollment.student_id INNER JOIN table_class ON table_enrollment.class_id=table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id=table_level_section.level_section_id INNER JOIN table_grade_level ON table_level_section.grade_level_id=table_grade_level.grade_level_id INNER JOIN table_grades ON table_students.student_id=table_grades.student_id WHERE table_class.sy_id = '" + data.GetActiveAcademicYearID() + "' AND table_class.teacher_id ='" + UserInfo.teacherID + "' AND table_level_section.section = '" + sectionLabel.Text + "' AND table_grade_level.grade_level ='" + gradeLevelLabel.Text + "' AND table_grades.grading_period_id ='3' AND table_grades.assignment_id = '" +assignmentID+ "'");

                DataTable dt4 = new DataTable();
                dt4 = this.GetData("SELECT DISTINCT table_students.student_no as 'Student Number',  CONCAT(table_students.last_name,', ',table_students.first_name,' ',table_students.middle_name) AS Name, table_grades.student_grade AS '4th' FROM table_students INNER JOIN table_enrollment ON table_students.student_id = table_enrollment.student_id INNER JOIN table_class ON table_enrollment.class_id=table_class.class_id INNER JOIN table_level_section ON table_class.level_section_id=table_level_section.level_section_id INNER JOIN table_grade_level ON table_level_section.grade_level_id=table_grade_level.grade_level_id INNER JOIN table_grades ON table_students.student_id=table_grades.student_id WHERE table_class.sy_id = '" + data.GetActiveAcademicYearID() + "' AND table_class.teacher_id ='" + UserInfo.teacherID + "' AND table_level_section.section = '" + sectionLabel.Text + "' AND table_grade_level.grade_level ='" + gradeLevelLabel.Text + "' AND table_grades.grading_period_id ='4' AND table_grades.assignment_id = '" +assignmentID+ "'");


                //Primary Keys
                dt.PrimaryKey = new DataColumn[] { dt.Columns["Student Number"] };
                dt1.PrimaryKey = new DataColumn[] { dt1.Columns["Student Number"] };
                dt2.PrimaryKey = new DataColumn[] { dt2.Columns["Student Number"] };
                dt3.PrimaryKey = new DataColumn[] { dt3.Columns["Student Number"] };
                dt4.PrimaryKey = new DataColumn[] { dt4.Columns["Student Number"] };

                //Merge all datatables
                dt3.Merge(dt4);
                dt3.AcceptChanges();
                dt2.Merge(dt3);
                dt2.AcceptChanges();
                dt1.Merge(dt2);
                dt1.AcceptChanges();
                dt.Merge(dt1);
                dt.AcceptChanges();

                //Bind the combined datatable to the dataGridView
                dataGridView1.DataSource = dt;


                //change the look of the dataGridView Column
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 12, FontStyle.Bold);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                //hide the last row
                this.dataGridView1.AllowUserToAddRows = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        //Add an unbound dataGridView Columns
        private void addColumn()
        {
            //Add a Average Column to the DataGridView.
            //((DataGridViewTextBoxColumn)dataGridView1.Columns[5]).MaxInputLength = 10;
            //dataGridView1.Columns["Average"].DefaultCellStyle.Format = "N2";
            dataGridView1.Refresh();
            
            DataGridViewTextBoxColumn aveColumn = new DataGridViewTextBoxColumn();
            aveColumn.HeaderText = "Average";
            aveColumn.Width = 100;
            aveColumn.Name = "Average";
            dataGridView1.Columns.Add(aveColumn);



            ////Add a ComboBox Column to the DataGridView.
            //DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            //comboBoxColumn.HeaderText = "Status";
            //comboBoxColumn.Width = 100;
            //comboBoxColumn.Name = "Status";
            //dataGridView1.Columns.Add(comboBoxColumn);


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                // Loop the computed average rows
                //Reference the TextBoxCell.
                DataGridViewTextBoxCell AverageBoxCell = (row.Cells[6] as DataGridViewTextBoxCell);


                if (AverageBoxCell != null)
                {
                    int[] arr = new int[4];
                    int total = 0, temp2 = 0;
                    string temp, finalGrade = "";


                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (row.Cells[i + 2].Value != null)
                        {   

                            temp = row.Cells[i + 2].Value.ToString();
                            if (int.TryParse(temp, out temp2))
                            {
                               
                                arr[i] = temp2;
                                total += arr[i];
                                

                            }



                        }
                    }

                    //Compute for the average
                    if (activeColumn == "1st")
                    {
                        finalGrade = Convert.ToString((total / 1));
                    }
                    else if (activeColumn == "2nd") {
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


                ////Loop the comboBox Rows
                ////Reference the ComboBoxCell.
                //DataGridViewComboBoxCell comboBoxCell = (row.Cells[7] as DataGridViewComboBoxCell);

                ////Insert the Default Item to ComboBoxCell.
                //if (comboBoxCell != null)
                //{
                //    comboBoxCell.Items.Add("Select Status");
                //    comboBoxCell.Items.Add("Promoted");
                //    comboBoxCell.Items.Add("Conditional");
                //    comboBoxCell.Items.Add("Failed");

                //    //Set the Default Value as the Selected Value.
                //    comboBoxCell.Value = "Select Status";
                //}
            }

        }



        //Display the data from the database to the dataGridView
        private DataTable GetData(string sql)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
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




        //Make the active grading editable
        private void dataReadOnly()
        {
            DateTime now = DateTime.Now;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            //dataGridView1.Columns[7].ReadOnly = true;
            string[] dateTimesFirstGrading = data.GetIsGradeEncodingActive(1);
            string[] dateTimesSecondGrading = data.GetIsGradeEncodingActive(2);
            string[] dateTimesThirdGrading = data.GetIsGradeEncodingActive(3);
            string[] dateTimesFourthGrading = data.GetIsGradeEncodingActive(4);

            if (now >= Convert.ToDateTime(dateTimesFirstGrading[0]) && now < Convert.ToDateTime(dateTimesFirstGrading[1]))
            {
                dataGridView1.Columns[2].ReadOnly = false;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
                activeColumn = "1st";
                button2.Enabled = true;
            }
            else if (now >= Convert.ToDateTime(dateTimesSecondGrading[0]) && now < Convert.ToDateTime(dateTimesSecondGrading[1]))
            {
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = false;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
                activeColumn = "2nd";
                button2.Enabled = true;
                //MessageBox.Show("It gets here");
            }
            else if (now >= Convert.ToDateTime(dateTimesThirdGrading[0]) && now < Convert.ToDateTime(dateTimesThirdGrading[1]))    
            {
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = false;
                dataGridView1.Columns[5].ReadOnly = true;
                activeColumn = "3rd";
                button2.Enabled = true;
            }
            else if (now >= Convert.ToDateTime(dateTimesFourthGrading[0]) && now < Convert.ToDateTime(dateTimesFourthGrading[1]))
            {
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = false;
                activeColumn = "4th";
                button2.Enabled = true;
            }
            else
            {
                dataGridView1.Columns[2].ReadOnly = true;
                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[4].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
                activeColumn = "1st";
                button2.Enabled = false;
                //MessageBox.Show(now.ToString());
                //MessageBox.Show("Hello World!");
            }
           

        }


        //Fill the subject combobox with data
        private void FillSubjectCombobox()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                //string query = "SELECT DISTINCT table_subject.subject from table_subject INNER JOIN table_subject_assignment ON table_subject.subject_id = table_subject_assignment.subject_id WHERE table_subject_assignment.teacher_id = '" + teacherID + "'";
                string query = "SELECT DISTINCT subject FROM table_subject  WHERE subject<>'Homeroom'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                subjectComboBox.Items.Clear();
                while (reader.Read())
                {
                    subjectComboBox.Items.Add(reader.GetString("subject"));
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                if (MessageBox.Show("Update Record? Click YES to confirm.", _title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {

                            int previousGrading = data.GetActiveGradingPeriodID() - 1;
                            string ud = (string)now.ToString();
                            //MessageBox.Show(Convert.ToString(row.Cells[activeColumn].Value));
                            MySqlCommand updateCmd = new MySqlCommand("UPDATE table_grades INNER JOIN table_students ON table_grades.student_id = table_students.student_id SET table_grades.student_grade =@student_grade, table_grades.update_date =@update_date, table_grades.update_by =@update_by WHERE table_students.student_no =@student_no AND table_grades.grading_period_id='" + previousGrading + "' AND table_grades.assignment_id='"+GetAssignmentID()+"'", connection);
                            updateCmd.Parameters.AddWithValue("@student_grade", row.Cells[activeColumn].Value);  
                            updateCmd.Parameters.AddWithValue("@update_date", ud);
                            updateCmd.Parameters.AddWithValue("@update_by", UserInfo.teacherID);
                            updateCmd.Parameters.AddWithValue("@student_no", row.Cells["Student Number"].Value);
                            updateCmd.ExecuteNonQuery();
                        

                    }

                    connection.Close();
                    MessageBox.Show("Record has been updated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                LoadData();
                dataGridView1.Refresh();
                addColumn();

            }

            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message, _title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }
        

        private void statusComboBox()
        {
            //DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn();
            //statusColumn.HeaderText = "Status";
            //statusColumn.Width = 100;
            //statusColumn.Name = "comboBoxColumn";
            //dataGridView1.Columns.Add(statusColumn);

            //statusColumn.Items.Add("Promoted");
            //statusColumn.Items.Add("Failed");
            //statusColumn.Items.Add("Conditional");


        }

        private void subjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSubject = subjectComboBox.GetItemText(subjectComboBox.SelectedItem);
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            LoadData();
            label10.Text =LoadSubjectTeacher();
            dataGridView1.Refresh();
            addColumn();
            dataReadOnly();
        }

        private int GetAssignmentID()
        {
            int assignmentID = 0;
            try
            {
                if (connection.State != ConnectionState.Open) {
                    connection.Open();
                }
                string query = "SELECT DISTINCT table_subject_assignment.assignment_id FROM table_subject_assignment INNER JOIN table_subject ON table_subject.subject_id = table_subject_assignment.subject_id INNER JOIN table_grade_level ON table_grade_level.grade_level_id=table_subject_assignment.grade_level_id WHERE table_subject.subject = '" + selectedSubject + "' AND table_grade_level.grade_level='" + gradeLevelLabel.Text + "'";
                //string query = "SELECT DISTINCT table_subject_assignment.assignment_id FROM table_subject_assignment INNER JOIN table_subject ON table_subject.subject_id = table_subject_assignment.subject_id WHERE table_subject.subject = '" + selectedSubject + "' ";
                MySqlCommand assIDcmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = assIDcmd.ExecuteReader();

                while (reader.Read())
                {
                   assignmentID = Convert.ToInt32(reader.GetString("assignment_id"));
                }
                reader.Close();
                //connection.Close();

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }

            return assignmentID;


        }


        private string LoadSubjectTeacher(){
            string subjectTeacherNAme = "";
            try {
                if (connection.State !=ConnectionState.Open)
                {
                    connection.Open();
                }
                string sql = "SELECT CONCAT(table_teacher.last_name,', ',table_teacher.first_name,' ',table_teacher.middle_name) AS Name FROM table_teacher INNER JOIN table_subject_assignment ON table_subject_assignment.teacher_id = table_teacher.teacher_id WHERE table_subject_assignment.assignment_id='"+this.GetAssignmentID()+"'";
                MySqlCommand com = new MySqlCommand(sql, connection);
                MySqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read()) {

                    subjectTeacherNAme = rdr.GetString("Name");   
                }
                rdr.Close();
                //connection.Close();

            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }

            return subjectTeacherNAme;


        }

        
    }
}
