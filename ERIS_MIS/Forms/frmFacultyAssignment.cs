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
using MISLibrary;
using System.Collections;

using System.Diagnostics;

namespace ERIS_MIS.Forms
{
    public partial class frmFacultyAssignment : Form
    {

        MySqlConnection connection = new MySqlConnection(Config1.connectionString);

        static SetFacultyAssign data1 = new SetFacultyAssign();

        ForScheduling data = new ForScheduling();


        //AllAssign filtered to get only GrLvl Assignments/Subject Assignments.
        public List<SubjectAssignment> AssignedToSubj { get; set; }
        public List<SubjectAssignment> AssignedToGrLvl { get; set; }


        //Binding Source for Data.
        private BindingSource GrLvlBinding = new BindingSource();
        private BindingSource SubjectBinding = new BindingSource();

        private BindingSource BindingSource1 = new BindingSource();
        private BindingSource BindingSource2 = new BindingSource();
        private BindingSource BindingSource3 = new BindingSource();
        private BindingSource BindingSource4 = new BindingSource();




        public frmFacultyAssignment()
        {
            InitializeComponent();

            //get from database
            data.GradeLvls = data.GetAllGrLvl();
            data.Subjects = data.GetAllSubject();
            data.Teachers = data.GetAllTeacher();
            data.AllAssign = data.GetAllAssign();


            ApplyBinding();

            InitializeSortedFilteredBindingSource3();
            InitializeSortedFilteredBindingSource2();
            InitializeSortedFilteredBindingSource1();
            Summary();

            setTotalCountToLabels();
        }


        private void ApplyBinding()
        {
            GrLvlBinding.DataSource = data.GradeLvls;

            grLvlComboBox.DataSource = GrLvlBinding;
            grLvlComboBox.DisplayMember = "Display";
            grLvlComboBox.ValueMember = "Display";

            SubjectBinding.DataSource = data.Subjects;

            subjComboBox.DataSource = SubjectBinding;
            subjComboBox.DisplayMember = "Display";
            subjComboBox.ValueMember = "Display";

        }



        private void InitializeSortedFilteredBindingSource3()
        {
            // conn and reader declared outside try
            // block for visibility in finally block
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            List<int> assignedTeacherIdArray = new List<int>();
            string newSelectedTeacherIdArray = "";


            try
            {
                conn = new MySqlConnection(Config1.connectionString);
                conn.Open();

                string sql = $"SELECT DISTINCT teacher_id FROM table_subject_assignment";
                MySqlCommand command = new MySqlCommand(sql, conn);


                MySqlDataReader rdr = command.ExecuteReader();

                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        assignedTeacherIdArray.Add(rdr.GetInt32(0));
                    }
                    newSelectedTeacherIdArray = string.Join(",", assignedTeacherIdArray.ToArray());
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to select distinct teacher id: " + ex.Message);
                conn.Close();
            }

            string sql2 = "SELECT teacher_id, last_name, first_name, middle_name FROM table_teacher";

            if (newSelectedTeacherIdArray != "")
            {
                sql2 += $" WHERE teacher_id NOT IN ({newSelectedTeacherIdArray})";
            }


            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql2, conn);

                // get data stream
                reader = cmd.ExecuteReader();


                DataTable dt3 = new DataTable("Unassigned");
                dt3.Columns.Add(new DataColumn("TeacherId", typeof(string)));
                dt3.Columns.Add(new DataColumn("LastName", typeof(string)));
                dt3.Columns.Add(new DataColumn("FirstName", typeof(string)));
                dt3.Columns.Add(new DataColumn("MiddleName", typeof(string)));



                // write each record
                while (reader.Read())
                {
                    DataRow row = dt3.NewRow();
                    row["TeacherId"] = reader["teacher_id"].ToString();
                    row["LastName"] = reader["last_name"].ToString();
                    row["FirstName"] = reader["first_name"].ToString();
                    row["MiddleName"] = reader["middle_name"].ToString();

                    dt3.Rows.Add(row);
                }

                BindingSource3.DataSource = dt3;
                unassignedDgv.DataSource = BindingSource3;

            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        private void InitializeSortedFilteredBindingSource2()
        {
            // conn and reader declared outside try
            // block for visibility in finally block
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            try
            {
                // instantiate and open connection
                conn = new MySqlConnection(Config1.connectionString);
                conn.Open();

              string query3 = "SELECT table_subject_assignment.teacher_id, table_subject_assignment.grade_level_id, table_teacher.last_name,  table_teacher.first_name, table_teacher.middle_name, " +
                    "CASE WHEN subject_id <> 0 THEN COUNT(table_subject_assignment.assignment_id) ELSE 0 END AS \"assign_count\" " +
                    "FROM table_subject_assignment INNER JOIN table_teacher ON table_subject_assignment.teacher_id = table_teacher.teacher_id " +
                    "GROUP BY table_teacher.last_name ORDER BY table_teacher.teacher_id DESC";

                MySqlCommand cmd = new MySqlCommand(query3, conn);

                // get data stream
                reader = cmd.ExecuteReader();


                DataTable dt2 = new DataTable("GrLvlAssignment");
                dt2.Columns.Add(new DataColumn("TeacherId", typeof(string)));
                dt2.Columns.Add(new DataColumn("GradeLevel", typeof(string)));
                dt2.Columns.Add(new DataColumn("LastName", typeof(string)));
                dt2.Columns.Add(new DataColumn("FirstName", typeof(string)));
                dt2.Columns.Add(new DataColumn("MiddleName", typeof(string)));
                dt2.Columns.Add(new DataColumn("SubjHandled", typeof(string)));



                // write each record
                while (reader.Read())
                {
                    DataRow row = dt2.NewRow();
                    row["TeacherId"] = reader["teacher_id"].ToString();
                    row["GradeLevel"] = reader["grade_level_id"].ToString();
                    row["LastName"] = reader["last_name"].ToString();
                    row["FirstName"] = reader["first_name"].ToString();
                    row["MiddleName"] = reader["middle_name"].ToString();
                    row["SubjHandled"] = reader["assign_count"].ToString();

                    dt2.Rows.Add(row);
                }

                BindingSource2.DataSource = dt2;
                grLvlAssignedDgv.DataSource = BindingSource2;
                grLvlAssignedDgv.Columns["TeacherId"].Visible = false;
                grLvlAssignedDgv.Columns["GradeLevel"].Visible = false;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        private void InitializeSortedFilteredBindingSource1()
        {
            // conn and reader declared outside try
            // block for visibility in finally block
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            int selectedGrLvlId = ((GradeLevel)grLvlComboBox.SelectedItem).Id;
            try
            {
                // instantiate and open connection
                conn = new MySqlConnection(Config1.connectionString);
                conn.Open();

               string sql2 = "SELECT table_subject_assignment.teacher_id, table_subject.subject_id, table_subject_assignment.grade_level_id, table_teacher.last_name, " +
                    "table_teacher.first_name, table_teacher.middle_name " +
                    "FROM table_subject_assignment INNER JOIN table_teacher ON table_subject_assignment.teacher_id = table_teacher.teacher_id " +
                    "INNER JOIN table_subject ON table_subject_assignment.subject_id = table_subject.subject_id " +
                    "WHERE table_subject_assignment.grade_level_id = @GrLvlId ";

                // 1. declare command object with parameter
                MySqlCommand cmd = new MySqlCommand(sql2, conn);

                // 2. define parameters used in command object
                MySqlParameter param = new MySqlParameter();
                param.ParameterName = "@GrLvlId";
                param.Value = selectedGrLvlId;

                // 3. add new parameter to command object
                cmd.Parameters.Add(param);

                textBox1.Text = sql2;

                // get data stream
                reader = cmd.ExecuteReader();


                DataTable dt = new DataTable("Assignment");
                dt.Columns.Add(new DataColumn("TeacherId", typeof(string)));
                dt.Columns.Add(new DataColumn("LastName", typeof(string)));
                dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
                dt.Columns.Add(new DataColumn("MiddleName", typeof(string)));
                dt.Columns.Add(new DataColumn("Subject", typeof(string)));
                dt.Columns.Add(new DataColumn("GradeLevel", typeof(string)));
                DataRow row;


                // write each record
                while (reader.Read())
                {
                    row = dt.NewRow();
                    row["TeacherId"] = reader["teacher_id"].ToString();
                    row["LastName"] = reader["last_name"].ToString();
                    row["FirstName"] = reader["first_name"].ToString();
                    row["MiddleName"] = reader["middle_name"].ToString();
                    row["Subject"] = reader["subject_id"].ToString();
                    row["GradeLevel"] = reader["grade_level_id"].ToString();
                    dt.Rows.Add(row);
                }

                BindingSource1.DataSource = dt;
                subjectAssignedDgv.DataSource = BindingSource1;

            }
            finally
            {
                // close reader
                if (reader != null)
                {
                    reader.Close();
                }

                // close connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void Summary()
        {
            // conn and reader declared outside try
            // block for visibility in finally block
            MySqlConnection conn = null;
            MySqlDataReader reader = null;

            int selectedGrLvlId = ((GradeLevel)grLvlComboBox.SelectedItem).Id;
            try
            {
                // instantiate and open connection
                conn = new MySqlConnection(Config1.connectionString);
                conn.Open();

                string sql2 = "SELECT table_subject.subject, table_subject_assignment.grade_level_id, table_teacher.last_name,  table_teacher.first_name, table_teacher.middle_name, " +
                    "COUNT(table_subject_assignment.assignment_id) As \"assigned_count\" " +
                    "FROM table_subject_assignment " +
                    "INNER JOIN table_teacher ON table_subject_assignment.teacher_id = table_teacher.teacher_id " +
                    "INNER JOIN table_subject ON table_subject_assignment.subject_id = table_subject.subject_id " +
                    "INNER JOIN table_grade_level ON table_subject_assignment.grade_level_id = table_grade_level.grade_level_id " +
                    "WHERE table_subject_assignment.grade_level_id = @GrLvlId " +
                    "GROUP BY table_subject.subject ORDER BY table_subject.subject ASC "; //test1

                string sql3 = "SELECT table_subject.subject, table_subject_assignment.grade_level_id, " +
                    "CASE WHEN table_subject_assignment.subject_id <> 0 OR table_subject_assignment.subject_id<> NULL THEN COUNT(table_subject_assignment.assignment_id) " +
                    "ELSE 0 END AS \"assigned_count\" " +
                    "FROM table_subject " +
                    "LEFT JOIN table_subject_assignment ON table_subject_assignment.subject_id = table_subject.subject_id " +
                    "WHERE table_subject_assignment.grade_level_id = @GrLvlId "; //test2

                string sql4 = "SELECT table_subject.subject, " +
                    "CASE WHEN table_subject_assignment.subject_id <> 0 THEN(SELECT COUNT(table_subject_assignment.subject_id) FROM table_subject_assignment " +
                    "WHERE table_subject_assignment.grade_level_id = @GrLvlId AND table_subject_assignment.subject_id = table_subject.subject_id) " +
                    "ELSE 0 END AS \"assigned_count\" FROM table_subject_assignment " +
                    "RIGHT JOIN table_subject ON table_subject_assignment.subject_id = table_subject.subject_id GROUP BY table_subject.subject_id";


                // 1. declare command object with parameter
                MySqlCommand cmd = new MySqlCommand(sql4, conn);

                // 2. define parameters used in command object
                MySqlParameter param = new MySqlParameter();
                param.ParameterName = "@GrLvlId";
                param.Value = selectedGrLvlId;

                // 3. add new parameter to command object
                cmd.Parameters.Add(param);

                // get data stream
                reader = cmd.ExecuteReader();

                textBox1.Text = sql3;

                DataTable dt = new DataTable("Summary");
                dt.Columns.Add(new DataColumn("Subject", typeof(string)));
                dt.Columns.Add(new DataColumn("AssignedCount", typeof(string)));


                // write each record
                while (reader.Read())
                {
                    DataRow row = dt.NewRow();
                    row["Subject"] = reader["subject"].ToString();
                    row["AssignedCount"] = reader["assigned_count"].ToString();

                    dt.Rows.Add(row);
                }
                BindingSource4.DataSource = dt;
                grLvlSummaryDgv.DataSource = BindingSource4;

            }
            finally
            {
                // close reader
                if (reader != null)
                {
                    reader.Close();
                }

                // close connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void subjComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            GradeLevel selectedGrade = (GradeLevel)grLvlComboBox.SelectedItem; //get selected Grade
            Subject selectedSubject = (Subject)cb.SelectedItem; //get selected Subject

            //BindingSource1.Filter = $"GradeLevel='{selectedGrade.Id}'";
            BindingSource1.Filter = $"GradeLevel='{selectedGrade.Id}' AND Subject='{selectedSubject.Id}' ";
            subjectAssignedDgv.DataSource = BindingSource1;

            setTotalCountToLabels();
        }

        private void grLvlComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GradeLevel selectedGrade = (GradeLevel)grLvlComboBox.SelectedItem; //get selected Grade


            BindingSource2.Filter = $"GradeLevel='{selectedGrade.Id}' ";
            grLvlAssignedDgv.DataSource = BindingSource2;


            if (subjComboBox.SelectedItem != null)
            {
                Subject selectedSubject = (Subject)subjComboBox.SelectedItem; //get selected Subject

                InitializeSortedFilteredBindingSource1();
                BindingSource1.Filter = $"GradeLevel='{selectedGrade.Id}' AND Subject='{selectedSubject.Id}' ";
                subjectAssignedDgv.DataSource = BindingSource1;
            }

            //Refresh Summary.
            Summary();
            setTotalCountToLabels();
        }

        private void addToGradeLevelButton_Click(object sender, EventArgs e)
        {
            List<object> assignedDetailsArray = new List<object>();
            int gradeLevelIdToAssign = (data.GradeLvls.Find(x => x.Level.Equals(grLvlComboBox.Text))).Id;

            foreach (DataGridViewRow row in unassignedDgv.Rows)
            {
                // if selected row
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value != false)
                {
                    string teacherId = row.Cells[1].Value.ToString();


                    // Gets Grade Level ID for teacher to assign to

                    List<object> teacherIdGrLvlIdPair = new List<object>();
                    teacherIdGrLvlIdPair.Add("'" + teacherId + "'");
                    teacherIdGrLvlIdPair.Add(gradeLevelIdToAssign);

                    string newStudentClassPair = string.Join(",", teacherIdGrLvlIdPair.ToArray());
                    assignedDetailsArray.Add("(" + newStudentClassPair + ")");

                    textBox1.Text += teacherId + " " + gradeLevelIdToAssign + "    ";
                }
            }

            string newEnrolledDetailsArray = string.Join(",", assignedDetailsArray.ToArray());

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = $"INSERT INTO table_subject_assignment(teacher_id, grade_level_id) VALUES {newEnrolledDetailsArray}";

                textBox1.Text += query + "\n";

                MySqlCommand command = new MySqlCommand(query, connection);

                Trace.WriteLine("ASSIGN TO GRADE LEVEL QUERY: " + command.CommandText);

                command.ExecuteNonQuery();

                connection.Close();

                // Reload Data Grid Views 3 and 2
                InitializeSortedFilteredBindingSource3();
                InitializeSortedFilteredBindingSource2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to assign teachers selected: " + ex.Message);
                connection.Close();
            }

            setTotalCountToLabels();
        }



        private void addToDepartmentButton_Click(object sender, EventArgs e)
        {
            GradeLevel selectedGrade = (GradeLevel)grLvlComboBox.SelectedItem;  //get selected Grade
            Subject selectedSubject = (Subject)subjComboBox.SelectedItem;           //get selected Subject

            List<SubjectAssignment> subjAssignOfSelectedGrade = new List<SubjectAssignment>();
            subjAssignOfSelectedGrade = data.GetAllAssign(selectedGrade.Id);


            List<int> selectedTeacherAssignIdArray = new List<int>();
            List<object> assignedDetailsArray = new List<object>();


            textBox1.Text = "";
            foreach (DataGridViewRow row in grLvlAssignedDgv.Rows)
            {
                // if selected row
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value != false)
                {
                    int selectedTeacherId = Convert.ToInt32(row.Cells[1].Value.ToString());     //get selected Teacher

                    SubjectAssignment checker = subjAssignOfSelectedGrade.Find(x => x.Subject == selectedSubject && x.Teacher.Id == selectedTeacherId);
                    // para macheck kung may existing record na.

                    if (checker != null)
                    {
                        MessageBox.Show($"Teacher ({row.Cells[3].Value.ToString()}) is already assigned to {selectedSubject.Name}" );
                        //Nothing changes.
                    }
                    else // if wala pa sa list ang teacher, user will choose if he wants to proceed (ADD to Database) or not(Do Nothing)
                    {
                        textBox1.Text += string.Format("Proceed to add {0} to {1} {2}", selectedTeacherId, selectedGrade.Id, selectedSubject.Id);


                        SubjectAssignment checker2 = subjAssignOfSelectedGrade.Find(x => x.Subject == null && x.Teacher.Id == selectedTeacherId);
                        //Sa checker2 mapupunta ang assignId ni teacher na null pa ang subject.

                        if (checker2 != null)
                        {
                            selectedTeacherAssignIdArray.Add(checker2.Id);
                        }
                        else //pag null si getTeacherAssign
                        {
                            assignedDetailsArray.Add($"('{selectedSubject.Id}', '{selectedTeacherId}', '{selectedGrade.Id}')");
                        }
                    }
                }
            }

            string newSelectedTeacherAssignIdArray = "";
            if (selectedTeacherAssignIdArray != null)
            {
                newSelectedTeacherAssignIdArray = string.Join(",", selectedTeacherAssignIdArray.ToArray());
            }
            string newAssignedDetailsArray = "";
            if (assignedDetailsArray != null)
            {
                newAssignedDetailsArray = string.Join(",", assignedDetailsArray.ToArray());
            }


            if (newAssignedDetailsArray != "" || newSelectedTeacherAssignIdArray != "")
            {
                DialogResult dialogResult = MessageBox.Show("Proceed to assign teachers to subject?", "Subject Assignment", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (newSelectedTeacherAssignIdArray != "")
                    {
                        try
                        {
                            // Set inactive status to 0 of students in their current grade level
                            if (connection.State != ConnectionState.Open)
                            {
                                connection.Open();
                            }

                            string sql = $"UPDATE table_subject_assignment SET subject_id='{selectedSubject.Id}' WHERE assignment_id IN ({newSelectedTeacherAssignIdArray}) ";

                            textBox1.Text += sql + "\n";

                            MySqlCommand command = new MySqlCommand(sql, connection);

                            Trace.WriteLine("ASSIGN TO GRADE LEVEL QUERY: " + command.CommandText);

                            command.ExecuteNonQuery();

                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to UPDATE assign teachers selected: " + ex.Message);
                            connection.Close();
                        }
                    }
                    if (newAssignedDetailsArray != "")
                    {
                        try
                        {
                            if (connection.State != ConnectionState.Open)
                            {
                                connection.Open();
                            }

                            string sql = $"INSERT INTO table_subject_assignment(subject_id,teacher_id, grade_level_id) VALUES {newAssignedDetailsArray}";

                            textBox1.Text += sql + "\n";

                            MySqlCommand command = new MySqlCommand(sql, connection);

                            Trace.WriteLine("ASSIGN TO GRADE LEVEL QUERY: " + command.CommandText);

                            command.ExecuteNonQuery();

                            connection.Close();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to INSERT assign teachers selected: " + ex.Message);
                            connection.Close();
                        }
                    }
                    InitializeSortedFilteredBindingSource1();
                    Summary();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //Nothing changes.
                }
            }

        }

        private void setTotalCountToLabels()
        {
            GradeLevel selectedGrLvl = (GradeLevel)grLvlComboBox.SelectedItem;
            Subject selectedSubj = (Subject)subjComboBox.SelectedItem;
            unassignedTotalLabel.Text = $"{unassignedDgv.RowCount}"; // returns the total no. of unassigned teachers
            teachersTotalLabel.Text = $"/  {(data.Teachers.Count())}"; // returns the total no. of teachers

            int teachersTotal = data.Teachers.Count();
            int grlvlMaxAllowed = 0;
            if (selectedGrLvl.Id == 1) grlvlMaxAllowed = (data.Teachers.Count()/4) + (teachersTotal % 4 > 0 ? 1 : 0);
            else if (selectedGrLvl.Id == 2) grlvlMaxAllowed = (data.Teachers.Count()/4) + (teachersTotal % 4 > 1 ? 1 : 0);
            else if (selectedGrLvl.Id == 3) grlvlMaxAllowed = (data.Teachers.Count()/4) + (teachersTotal % 4 > 2 ? 1 : 0);
            else if (selectedGrLvl.Id == 4) grlvlMaxAllowed = (data.Teachers.Count()/4);

            grLvlAssignedTotalLabel.Text = $"{grLvlAssignedDgv.RowCount}"; //
            grLvlMaxAllowedTotalLabel.Text = $"/  {grlvlMaxAllowed}";

            if (selectedGrLvl != null)
            {
                grLvlAssignedLabel.Text = $"{selectedGrLvl.Level} Assigned :";
                summaryLabel.Text = $"{selectedGrLvl.Level} Summary :";
            }
            if (selectedSubj != null)
            {
                subjectAssignedLabel.Text = $"{selectedGrLvl.Level} {selectedSubj.Name} Department Assigned :";
            }

        }

        private void removeFromListButton_Click(object sender, EventArgs e)
        {
            GradeLevel selectedGrade = (GradeLevel)grLvlComboBox.SelectedItem;  //get selected Grade


            //get list of teachers assigned to specific grade level.
            List<SubjectAssignment> subjAssignOfSelectedGrade = new List<SubjectAssignment>();
            subjAssignOfSelectedGrade = data.GetAllAssign(selectedGrade.Id);


            List<int> selectedTeacherAssignIdArray = new List<int>();
            List<object> assignedDetailsArray = new List<object>();


            textBox1.Text = "";
            foreach (DataGridViewRow row in grLvlAssignedDgv.Rows)
            {
                // if selected row
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value != false)
                {
                    int selectedTeacherId = Convert.ToInt32(row.Cells[1].Value.ToString());     //get selected Teacher

                    selectedTeacherAssignIdArray.Add(selectedTeacherId);
                }
            }

            string newSelectedTeacherAssignIdArray = "";
            if (selectedTeacherAssignIdArray != null)
            {
                newSelectedTeacherAssignIdArray = string.Join(",", selectedTeacherAssignIdArray.ToArray());
            }
           

            if (newSelectedTeacherAssignIdArray != "")
            {
                DialogResult dialogResult = MessageBox.Show("Proceed to delete?", "Grade Level Assignment", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                        try
                        {
                            // Set inactive status to 0 of students in their current grade level
                            connection.Open();

                            string sql = $"DELETE FROM table_subject_assignment WHERE teacher_id  IN({newSelectedTeacherAssignIdArray})";

                            textBox1.Text += sql + "\n";

                            MySqlCommand command = new MySqlCommand(sql, connection);

                            Trace.WriteLine("REMOVE TEACHER FROM GRADE LEVEL ASSIGN DGV, DELETE QUERY: " + command.CommandText);

                            command.ExecuteNonQuery();

                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to DELETE teachers assigned selected: " + ex.Message);
                            connection.Close();
                        }
                   
                    InitializeSortedFilteredBindingSource1();
                    InitializeSortedFilteredBindingSource2();
                    Summary();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //Nothing changes.
                }
            }
        }

        private void frmFacultyAssignment_Load(object sender, EventArgs e)
        {
            grLvlComboBox.SelectedIndex = 0;
            subjComboBox.SelectedIndex = 0;
        }

        private void removeFromSubjAssignedListButton_Click(object sender, EventArgs e)
        {
            GradeLevel selectedGrade = (GradeLevel)grLvlComboBox.SelectedItem;  //get selected Grade
            Subject selectedSubject = (Subject)subjComboBox.SelectedItem;           //get selected Subject



            //get list of teachers assigned to specific grade level.
            List<SubjectAssignment> subjAssignOfSelectedGrade = new List<SubjectAssignment>();
            subjAssignOfSelectedGrade = data.GetAllAssign(selectedGrade.Id);


            List<int> selectedTeacherAssignIdArray = new List<int>();


            textBox1.Text = "";
            foreach (DataGridViewRow row in subjectAssignedDgv.Rows)
            {
                // if selected row
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value != false)
                {
                    int selectedTeacherId = Convert.ToInt32(row.Cells[1].Value.ToString());     //get selected Teacher

                    selectedTeacherAssignIdArray.Add(selectedTeacherId);
                }
            }

            string newSelectedTeacherAssignIdArray = "";
            if (selectedTeacherAssignIdArray != null)
            {
                newSelectedTeacherAssignIdArray = string.Join(",", selectedTeacherAssignIdArray.ToArray());
            }


            if (newSelectedTeacherAssignIdArray != "")
            {
                DialogResult dialogResult = MessageBox.Show("Proceed to delete?", "Grade Level Assignment", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        // Set inactive status to 0 of students in their current grade level
                        connection.Open();

                        string sql = $"DELETE FROM table_subject_assignment WHERE teacher_id  IN({newSelectedTeacherAssignIdArray}) AND subject_id IN ({selectedSubject.Id})";

                        textBox1.Text += sql + "\n";

                        MySqlCommand command = new MySqlCommand(sql, connection);

                        Trace.WriteLine("REMOVE TEACHER FROM SUBJECT ASSIGN DGV, DELETE QUERY: " + command.CommandText);

                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to DELETE teachers assigned selected: " + ex.Message);
                        connection.Close();
                    }

                    InitializeSortedFilteredBindingSource1();
                    InitializeSortedFilteredBindingSource2();
                    Summary();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //Nothing changes.
                }
            }
        }
    

        //end
    }
}