using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ERIS_MIS.Config;


namespace ERIS_MIS.Forms
{
    public partial class LogInForm : Form
    {


        MySqlConnection connection = new MySqlConnection(Config1.connectionString);
        SystemGeneralData data = new SystemGeneralData();


        public LogInForm()
        {
            InitializeComponent();
        }
        ErisDatabase con = new ErisDatabase();


        String userName = "", password = "";
        int success = 0;

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            userNameTextBox.Text = string.Empty;
        }


        private void ReadData()
        {

            string q = $"SELECT access_id, position_id FROM table_users WHERE user_id={UserInfo.userID}";

            con.OpenDBConnection();
            Config3.command = new MySqlCommand(q, Config3.connection);
            Config3.command.CommandTimeout = 60;


            try
            {
                con.OpenDBConnection();

                Config3.reader = Config3.command.ExecuteReader();

                if (Config3.reader.HasRows)
                {
                    while (Config3.reader.Read())
                    {

                        //Copy data to UserInfo class
                        UserInfo.accessID = Config3.reader.GetInt32(0);
                        UserInfo.positionID = Config3.reader.GetInt32(1);

                        success = 1;

                    }
                }
                else
                {
                    MessageBox.Show("Login Error.");
                    success = 0;

                }

                con.CloseConnection();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
                success = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //userTransac();
            string query = "SELECT table_users.username, table_users.password, table_users.user_id, table_teacher.teacher_id, table_teacher.teacher_no, table_teacher.teacher_mobile, table_teacher.last_name, table_teacher.first_name, table_teacher.middle_name, table_teacher.city_address, table_teacher.date_of_birth, table_teacher.graduate_school FROM table_users INNER JOIN table_teacher ON table_users.user_id = table_teacher.user_id WHERE table_users.username ='" + userNameTextBox.Text + "'";


            con.OpenDBConnection();
            Config3.command = new MySqlCommand(query, Config3.connection);
            Config3.command.CommandTimeout = 60;


            try
            {
                con.OpenDBConnection();

                Config3.reader = Config3.command.ExecuteReader();

                if (Config3.reader.HasRows)
                {
                    while (Config3.reader.Read())
                    {
                        userName = Config3.reader.GetString(0);
                        password = Config3.reader.GetString(1);

                        //MessageBox.Show(userName + "  " + password);

                        ///* Extract the bytes */
                        //byte[] hashBytes = Convert.FromBase64String(password);
                        ///* Get the salt */
                        //byte[] salt = new byte[16];
                        //Array.Copy(hashBytes, 0, salt, 0, 16);
                        ///* Compute the hash on the password the user entered */
                        //var pbkdf2 = new Rfc2898DeriveBytes(passwordTextBox.Text, salt, 10000);
                        //byte[] hash = pbkdf2.GetBytes(20);
                        ///* Compare the results */
                        //for (int i = 0; i < 20; i++)
                        //{
                        //    if (hashBytes[i + 16] != hash[i])
                        //    {

                        //        MessageBox.Show("ehem");
                        //        throw new UnauthorizedAccessException();

                        //        MessageBox.Show("ehem2");
                        //    }
                        //}

                        //Copy data to UserInfo class
                        UserInfo.userID = Config3.reader.GetInt32(2);
                        UserInfo.teacherID = Config3.reader.GetString(3);
                        UserInfo.teacherNo = Config3.reader.GetString(4);
                        UserInfo.teacherMobile = Config3.reader.GetString(5);
                        UserInfo.teacherLastName = Config3.reader.GetString(6);
                        UserInfo.teacherFirstName = Config3.reader.GetString(7);
                        UserInfo.teacherMiddleName = Config3.reader.GetString(8);
                        UserInfo.teacherFullName = UserInfo.teacherLastName + ", " + UserInfo.teacherFirstName + " " + UserInfo.teacherMiddleName;
                        UserInfo.teacherCityAddress = Config3.reader.GetString(9);
                        UserInfo.teacherBirthDay = Config3.reader.GetString(10);
                        UserInfo.teacherGradSchool = Config3.reader.GetString(11);

                        success = 1;

                    }
                }
                else
                {
                    MessageBox.Show("Login Error.");
                    success = 0;

                }

                con.CloseConnection();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
                success = 0;
            }



            if (success == 1)
            {
                ReadData();
                //MessageBox.Show(UserInfo.accessID + "   " + UserInfo.positionID);

                data.GetActiveAcademicYearID();
                data.GetActiveAcademicYear();
                data.GetActiveGradingPeriod();


                MessageBox.Show("Login successful. Welcome " + UserInfo.teacherFullName + "   userid = " + UserInfo.userID);
                LogInForm lf = new LogInForm();
                lf.Dispose();
                FormAdmin f = new FormAdmin();
                f.Show();
            }


        }




        private void textBox2_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = string.Empty;
        }

        private void LogInForm_Activated(object sender, EventArgs e)
        {
            userNameTextBox.Text = "Username";
            passwordTextBox.Text = "Password";
        }

        private void userTransac()
        {
            string MyConnection2 = "datasource=localhost;port=3306;Initial Catalog='eris';username=root;password=";
            string action = "Log In";
            string insertQuery = "INSERT INTO table_transaction ( teacher_no, time_stamp, function_performed) VALUES ('" + UserInfo.teacherNo + "','" + DateTime.Now + "','" + action + "');";
            MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
            MySqlCommand MyCommand2 = new MySqlCommand(insertQuery, MyConn2);
            MySqlDataReader MyReader2;
            MyConn2.Open();
            MyReader2 = MyCommand2.ExecuteReader();
            while (MyReader2.Read())
            {
            }
            MyConn2.Close();

        }
    }
}
