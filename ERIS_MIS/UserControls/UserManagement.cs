using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Collections.Generic;

using MySql.Data.MySqlClient; // for database
using MISLibrary;
using ERIS_MIS.Config;

namespace ERIS_MIS.UserControls
{
    public partial class UserManagement : UserControl
    {
        //List container for Teacher Selection in teacherComboBox.
        private List<TeacherAsUser> Teachers { get; set; }


        public UserManagement()
        {
            InitializeComponent();


            positionComboBox.Items.Add("Select Position");
            positionComboBox.Items.Add("Records In-Charge");
            positionComboBox.Items.Add("Grade Level Chair");
            positionComboBox.Items.Add("Adviser");


            gradeLevelComboBox.Items.Add("Select Grade Level");
            gradeLevelComboBox.Items.Add("Grade 7");
            gradeLevelComboBox.Items.Add("Grade 8");
            gradeLevelComboBox.Items.Add("Grade 9");
            gradeLevelComboBox.Items.Add("Grade 10");


            Teachers = new List<TeacherAsUser>();
        }


        public List<TeacherAsUser> GetTeachers(string sql)
        {
            List<TeacherAsUser> list = new List<TeacherAsUser>();

            MySqlConnection con = new MySqlConnection(Config1.connectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new TeacherAsUser
                {
                    Id = rdr.GetInt32(0),
                    TeacherNo = rdr.GetString(1),
                    LastName = rdr.GetString(2),
                    FirstName = rdr.GetString(3),
                    MiddleName = rdr.GetString(4),
                    Username = (rdr.GetInt32(8) != 0 ? rdr.GetString(5) : ""), //If UserId(rdr.GetInt32(8) == 0, then Username is equal to "". Else, Username = rdr.GetString(5).
                    
                    AccessId = (rdr.GetInt32(8) != 0 ? rdr.GetInt32(7) : 0),
                    UserId = (rdr.GetInt32(8) > 0 ? rdr.GetInt32(8) : 0)

                });
            }

            con.Close();
            return list;
        }


        private void ShowGrLvlCombo(bool show)
        {
            if (show == true) {
                label6.Show();
                gradeLevelComboBox.Show();
                gradeLevelComboBox.SelectedIndex = 0;
            }
            else {
                label6.Hide();
                gradeLevelComboBox.Hide();
                gradeLevelComboBox.SelectedIndex = 0;
            }
        }

        private void ShowTeacherCombo(bool show)
        {
            if (show == true) {
                label7.Show();
                teacherComboBox.Show();
                teacherComboBox.SelectedIndex = 0;
            } else {
                label7.Hide();
                teacherComboBox.Hide();
                //teacherComboBox.SelectedIndex = 0;
            }
        }

        private void ShowTeacherNo(bool show)
        {
            if (show == true) {
                label8.Show();
                teacherNoLabel.Show();
                teacherNoLabel.Text = "";

                teacherNoLabel2.Show();
                teacherNoLabel2.Text = "";
            } else {
                label8.Hide();
                teacherNoLabel.Hide();
                teacherNoLabel.Text = "";

                teacherNoLabel2.Hide();
                teacherNoLabel2.Text = "";
            }
        }

        private void positionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {


            //1. SELECT teachers depending on the selected Position.

            //2. After getting the result, add teachers to comboBox.


            if (positionComboBox.Text == "Records In-Charge")
            {
                //string sql = "SELECT teacher_id,last_name,first_name,middle_name FROM table_teacher";

                string sql = $"SELECT table_teacher.teacher_id, table_teacher.teacher_no, table_teacher.last_name, table_teacher.first_name, table_teacher.middle_name, " +
                 //$"table_teacher.date_of_birth, table_teacher.teacher_mobile, table_teacher.city_address, table_teacher.graduate_school," +
                 $"table_users.username, table_users.password, table_users.access_id, table_teacher.user_id " +
                 $"FROM table_teacher " +
                 $"LEFT JOIN table_users ON table_users.user_id = table_teacher.user_id ";

                Teachers.Clear();
                Teachers = GetTeachers(sql);
                addTeachersToCombo();

                ShowGrLvlCombo(false);
                ShowTeacherCombo(true);
                ShowTeacherNo(false);
            }

            else if (positionComboBox.Text == "Grade Level Chair" || positionComboBox.Text == "Adviser")
            {
                ShowGrLvlCombo(true);
                ShowTeacherCombo(false);
                ShowTeacherNo(false);
            }

            else
            {
                //Hide objects

                ShowGrLvlCombo(false);
                ShowTeacherCombo(false);
                ShowTeacherNo(false);
            }

        }




        private void addTeachersToCombo()
        {
            teacherComboBox.Items.Clear();
            teacherComboBox.Items.Add("Select Teacher");

            foreach (Teacher x in Teachers)
            {
                try
                {
                    teacherComboBox.Items.Add(x.Display);
                }
                catch
                {
                    MessageBox.Show($"Error in adding {positionComboBox.Text} teachers selection.");
                }
            }
            if (Teachers.Count <= 0) {
                teacherComboBox.SelectedIndex = -1;
            }
            else {
                teacherComboBox.SelectedIndex = 0;
            }
        }


        private void gradeLevelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gradeLevelComboBox.Text == "Select Grade Level")
            {
                ShowTeacherNo(false);
                // do nothing
            }

            else {

                if (positionComboBox.Text == "Grade Level Chair")
                {
                    string sql = "SELECT DISTINCT table_subject_assignment.teacher_id, table_teacher.teacher_no, table_teacher.last_name, table_teacher.first_name, table_teacher.middle_name, " +
                        "table_users.username, table_users.password, table_users.access_id, table_teacher.user_id " +
                        "FROM table_subject_assignment " +
                        "INNER JOIN table_teacher ON table_subject_assignment.teacher_id = table_teacher.teacher_id " +
                        "INNER JOIN table_grade_level ON table_subject_assignment.grade_level_id = table_grade_level.grade_level_id " +
                        "LEFT JOIN table_users ON table_users.user_id = table_teacher.user_id " +
                        $"WHERE table_grade_level.grade_level = '{gradeLevelComboBox.Text}' ";

                    Teachers.Clear();
                    Teachers = GetTeachers(sql);

                    addTeachersToCombo();
                    ShowTeacherCombo(true);
                }


                else if (positionComboBox.Text == "Adviser")
                {
                    string sql = "SELECT DISTINCT table_subject_assignment.teacher_id, table_teacher.teacher_no, table_teacher.last_name, table_teacher.first_name, table_teacher.middle_name, " +
                        "table_users.username, table_users.password, table_users.access_id, table_teacher.user_id, " +
                        "table_subject.subject, table_subject_assignment.grade_level_id " +
                        "FROM table_subject_assignment " +
                        "INNER JOIN table_teacher ON table_subject_assignment.teacher_id = table_teacher.teacher_id " +
                        "INNER JOIN table_subject ON table_subject_assignment.subject_id = table_subject.subject_id " +
                        "INNER JOIN table_grade_level ON table_subject_assignment.grade_level_id = table_grade_level.grade_level_id " +
                        "LEFT JOIN table_users ON table_users.user_id = table_teacher.user_id " +
                        $"WHERE table_grade_level.grade_level = '{gradeLevelComboBox.Text}' AND table_subject_assignment.subject_id = 1 ";

                    Teachers.Clear();
                    Teachers = GetTeachers(sql);

                    addTeachersToCombo();
                    ShowTeacherCombo(true);
                }
            }
        }


        private void teacherComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeacherAsUser teacherSelected = Teachers.Find(x => x.Display.Equals(teacherComboBox.Text));

            if (teacherSelected == null)
            {
                label8.Hide();
                teacherNoLabel.Hide();
                teacherNoLabel.Text = "";

                teacherNoLabel2.Hide();
                teacherNoLabel2.Text = "";

                passwordTextBox.Enabled = false;
                confirmPasswordTextBox.Enabled = false;
            }
            else
            {

                passwordTextBox.Enabled = true;
                confirmPasswordTextBox.Enabled = true;

                label8.Show();
                teacherNoLabel.Show();
                teacherNoLabel.Text = teacherSelected.TeacherNo.ToString();

                teacherNoLabel2.Show();
                teacherNoLabel2.Text = teacherSelected.TeacherNo.ToString();

            }
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            string userMgmtGuide = "Select the Position/Title. \n\n\n" +
                "Records In-Charge \n\n" +
                "* Only 1 teacher can be assigned as Records In-charge(Admin) choosing FROM the selection all teachers. \n\n" +
                "Grade Level Chairman \n\n" +
                "* A GradeLevel-ComboBox will be shown after selecting Grade Level Chair from the Position/Title-ComboBox.\n" +
                "* The Teachers assigned to a Grade Level in the Teacher Assignment Tab, will be populated to the Teacher's ComboBox. \n" +
                "* Only 1 teacher FROM each Grade Level can be assigned as Grade Level Chairman. \n\n" +
                "Adviser \n\n" +
                "* A GradeLevel-ComboBox will be shown after selecting Grade Level Chair from the Position/Title-ComboBox.\n" +
                "* The Teachers assigned to a Grade Level and Subject HOMEROOM in the Teacher Assignment Tab, will be populated to the Teacher's ComboBox. \n ";

            label10.Text = userMgmtGuide;

            //string usernameGuide1 = "username should be atleast 5 characters.";
            //string usernameGuide2 = "username is already taken.";
            string passwordGuide1 = "Password should be atleast 5 characters.";
            string passwordGuide2 = "Password do not match.";

            //label4.Text = usernameGuide1;
            label11.Text = passwordGuide1;
            label12.Text = passwordGuide2;
        }



        // BUTTONS

        private void addButton_Click(object sender, EventArgs e)
        {
            ////to check if username already exists
            TeacherAsUser teacherSelected = Teachers.Find(x => x.Display.Equals(teacherComboBox.Text));

            string checkerQuery = $"SELECT user_id FROM table_users WHERE username = '{teacherNoLabel2.Text}' AND user_id <> '{teacherSelected.UserId}'";

            var userIdExisting = (Convert.ToBoolean(executeScalarQuery(checkerQuery)) == false ? false : true);


            if (teacherSelected.UserId == 0 && userIdExisting == false) //if (!userExist)
            {   ///
                ///INSERT database table_users AND UPDATE table_teacher
                ///

                //default user access level
                int positionId = 0;
                int accessId = 0;

                if (positionComboBox.Text == "Records In-Charge")
                {
                    accessId = 1;
                    positionId = 1;
                }
                else if (positionComboBox.Text == "Grade Level Chair")
                {
                    accessId = 1;
                    positionId = 2;
                }
                else if (positionComboBox.Text == "Adviser")
                {
                    accessId = 2;
                    positionId = 3;
                }

                string savedPasswordHash = securePassword(passwordTextBox.Text);

                string insertQuery = $"INSERT INTO table_users(username, password, access_id, position_id) VALUES('{teacherNoLabel2.Text}', '{savedPasswordHash}', '{accessId}', {positionId})";
                var user = executeQuery(insertQuery);

                if (user)
                {
                    string selectQuery = $"SELECT user_id FROM table_users WHERE username = '{teacherNoLabel2.Text}'";
                    var userId = Convert.ToInt32(executeScalarQuery(selectQuery));

                    teacherSelected.UserId = userId;
                    //var teacherInsertQuery = $"INSERT INTO table_teacher(teacher_no, last_name, first_name, middle_name, date_of_birth, teacher_mobile, city_address, graduate_school, user_id) VALUES('{teacherNoTextBox.Text}', '{lastNameTextBox.Text}', '{firstNameTextBox.Text}', '{middleNameTextBox.Text}', '{dobTextBox.Text}', '{contactNoTextBox.Text}', '{cityAddressTextBox.Text}', '{graduateSchoolTextBox.Text}', {userId})";
                    //executeQuery(teacherInsertQuery);

                    string updateQuery = $"UPDATE table_teacher SET user_id = '{userId}' WHERE teacher_id = { teacherSelected.Id }";
                    executeQuery(updateQuery);

                    MessageBox.Show("User added succesfully.");
                }
            }
            else
            {
                MessageBox.Show("username already exists.");
            }

            EnableOrDisableButtons();
        }


        private void editButton_Click(object sender, EventArgs e)
        {   ///
            ///UPDATE table_users 
            ///
            TeacherAsUser teacherSelected = Teachers.Find(x => x.Display.Equals(teacherComboBox.Text));

            string checkerQuery = $"SELECT user_id FROM table_users WHERE username = '{teacherNoLabel2.Text}' AND user_id <> '{teacherSelected.UserId}'";

            var userIdExisting = (Convert.ToBoolean(executeScalarQuery(checkerQuery)) == false ? false : true);

            if (teacherSelected.UserId > 0 && userIdExisting == false) //if (userExist)
            {
                string savedPasswordHash = securePassword(passwordTextBox.Text);

                string updateQuery = $"UPDATE table_users SET username = '{teacherNoLabel2.Text}', password = '{savedPasswordHash}' WHERE user_id = { teacherSelected.UserId }";
                executeQuery(updateQuery);

                MessageBox.Show("User updated succesfully.");
            }
            else
            {
                MessageBox.Show("username already exists.");
            }

            EnableOrDisableButtons();
        }



        public string securePassword(String passwordText)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }

        public object executeScalarQuery(String query)
        {
            MySqlConnection con = new MySqlConnection(Config1.connectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandTimeout = 60;

            try
            {
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    //MessageBox.Show("Query Executed");
                    con.Close();
                    return result;
                }
                else
                {
                    //MessageBox.Show("Query Not Executed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return false;
        }


        public bool executeQuery(String query)
        {
            MySqlConnection con = new MySqlConnection(Config1.connectionString);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.CommandTimeout = 60;

            try
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    //MessageBox.Show("Query Executed");
                    con.Close();
                    return true;
                }
                else
                {
                    //MessageBox.Show("Query Not Executed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return false;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            TeacherAsUser teacherSelected = Teachers.Find(x => x.Display.Equals(teacherComboBox.Text));

            if (teacherSelected.UserId > 0) //if (userExist)
            {

                int resetUserId = 0;

                string updateQuery = $"UPDATE table_teacher SET user_id = '{resetUserId}' WHERE teacher_id = { teacherSelected.Id }";
                executeQuery(updateQuery);

                string deleteQuery = $"DELETE FROM table_users WHERE user_id = { teacherSelected.UserId }";
                executeQuery(deleteQuery);

                teacherSelected.UserId = resetUserId;
                teacherSelected.Username = "";
                teacherSelected.Password = "";

                teacherNoLabel2.Hide();
                passwordTextBox.Text = "";
                confirmPasswordTextBox.Text = "";

                MessageBox.Show("User deleted.");
            }

            EnableOrDisableButtons();
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Equals(""))
            {
                label11.Hide();
            }
            else if (passwordTextBox.Text.Length < 5 && passwordTextBox.Text.Length > 0)
            {
                label11.Show();
                
            }
            else
            {
                //valid
                label11.Hide();
            }

            EnableOrDisableButtons();
        }

        private void confirmPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            if (confirmPasswordTextBox.Text.Equals(""))
            {
                label12.Hide();
            }
            else if (confirmPasswordTextBox.Text != passwordTextBox.Text)
            {
                label12.Show();
            }
            else
            {
                //password match.
                label12.Hide();
            }

            EnableOrDisableButtons();
        }


        private void EnableOrDisableButtons()
        {
            TeacherAsUser teacherSelected = Teachers.Find(x => x.Display.Equals(teacherComboBox.Text));

            if (passwordTextBox.Text.Equals("") || confirmPasswordTextBox.Text.Equals(""))
            {
                //disable buttons
                addButton.Enabled = false;
                saveButton.Enabled = false;
                deleteButton.Enabled = false;
            }
            else if (teacherSelected.UserId > 0 && passwordTextBox.Text == confirmPasswordTextBox.Text && passwordTextBox.Text.Length >= 5) //if (userExist), password match, password textfield not empty
            {
                addButton.Enabled = false;
                saveButton.Enabled = true;
                deleteButton.Enabled = true;
            }
            else if (teacherSelected.UserId == 0 && passwordTextBox.Text == confirmPasswordTextBox.Text && passwordTextBox.Text.Length >= 5) //if (!userExist) AND controls are not empty.
            {
                addButton.Enabled = true;
                saveButton.Enabled = false;
                deleteButton.Enabled = false;
            }
            else
            {
                //
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            if (label10.Visible == true)
            {
                label10.Hide();
            }

            else
            {
                label10.Show();
            }
        }
    }
}