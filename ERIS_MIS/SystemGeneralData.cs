using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ERIS_MIS.Config;


namespace ERIS_MIS
{
    class SystemGeneralData
        {
            MySqlConnection connection = new MySqlConnection(Config1.connectionString);


            private string _title = "Activate Academic Year";
            private string activeAcademicYearID = "";
            private string activeGradingPeriodID = "";
            private string activeAcademicYear = "";
            private string previousAcademicYear = "";
            private string activeGradingPeriod = "";
            private int activeSYID;
            private int activeGPID;
            private int previousSYID;
            private string activeSY = "";
            private string previousSY = "";
            private string activeGP = "";
            private string endYEar = "";
        //private bool isIsGradeEncodingActive = false;
        private bool isIsEnrollmentActive = false;
            DateTime  enrollmentStartDate, enrollmentEndDate;
            private string startGradingDate, endGradingDate;//new
            DateTime now = new DateTime();


            //Get the ID of active academic year
            public int GetActiveAcademicYearID()
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string cmd = "SELECT sy_id FROM table_sy  WHERE status=1";
                    MySqlCommand command = new MySqlCommand(cmd, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        activeSYID = Convert.ToInt32(reader.GetString("sy_id"));

                    }
                    reader.Close();
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                return activeSYID;
            }
        public bool GetIsEnrollmentActive()
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            string cmd = "SELECT start_date, end_date FROM table_enrollment_period  WHERE  sy_id = '" + GetActiveAcademicYearID() + "'";
            MySqlCommand command = new MySqlCommand(cmd, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                enrollmentStartDate = Convert.ToDateTime(reader.GetString("start_date"));
                enrollmentEndDate = Convert.ToDateTime(reader.GetString("end_date"));

            }
            reader.Close();
            //if (connection.State != ConnectionState.Closed)
            //{
            //    connection.Close();
            //}



            if (now >= enrollmentStartDate && now < enrollmentEndDate)
            {

                isIsEnrollmentActive = true;
            }
            else
            {
                isIsEnrollmentActive = false;
            }
            return isIsEnrollmentActive;
        }

        public void SetIsEnrollmentActive(DateTime now, DateTime start, DateTime end)
        {
            try
            {
                
                string cmd = "";
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string selQuery = "SELECT * FROM table_enrollment_period WHERE sy_id='"+GetActiveAcademicYearID()+"'";
                
                bool nonZeroReturn = false;
                MySqlCommand countCmd = new MySqlCommand(selQuery, connection);
                MySqlDataReader rdr = countCmd.ExecuteReader();
                nonZeroReturn = rdr.HasRows;  
                rdr.Close();


                if (nonZeroReturn)
                {
                    cmd = "UPDATE table_enrollment_period SET start_date=@start_date, end_date=@end_date WHERE sy_id=@sy_id";

                    MySqlCommand command = new MySqlCommand(cmd, connection);
                    command.Parameters.AddWithValue("@start_date", start.ToString());
                    command.Parameters.AddWithValue("@end_date", end.ToString());
                    command.Parameters.AddWithValue("@sy_id", GetActiveAcademicYearID());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Enrollment has been updated!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    //string query = "INSERT INTO table_grade_encoding(start_date, end_date, grading_period_id, sy_id) SELECT " + start + ", " + end + ", " + getActiveGradingPeriodID() + ", " + getActiveAcademicYearID() + " FROM table_grading_period WHERE status = 1";
                    //string cmd ="INSERT INTO table_grade_encoding(start_date, end_date, grading_period_id, sy_id) VALUES (@start_date,  @end_date, @grading_period_id, @sy_id)";
                    cmd = "INSERT INTO table_enrollment_period" +
                                 "(start_date, end_date, sy_id) " +
                                 "VALUES (@start_date,  @end_date, @sy_id) ";
                    MySqlCommand command = new MySqlCommand(cmd, connection);
                    command.Parameters.AddWithValue("@start_date", start.ToString());
                    command.Parameters.AddWithValue("@end_date", end.ToString());
                    command.Parameters.AddWithValue("@sy_id", GetActiveAcademicYearID());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Enrollment has been scheduled!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public string GetActiveAcademicYear()
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        connection.Open();
                    }
                    string cmd = "SELECT CONCAT(start_year,' - ',end_year) as 'School Year' FROM table_sy  WHERE status=1";
                    MySqlCommand command = new MySqlCommand(cmd, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        activeSY = reader.GetString("School Year");
                    }
                    reader.Close();
                    //if (connection.State != ConnectionState.Closed)
                    //{
                    //    connection.Close();
                    //}
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }

                return activeSY;
            }
        

        public void SetActiveAcademicYearID(string startYear, string endYear, string startMonth, string endMonth)
        {
            try
            {   //new
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string sql = "INSERT INTO table_sy " +
                         "(start_year, end_year, start_month, end_month, status) " +
                         "VALUES (@start_year,  @end_year,@start_month, @end_month, @status) ";

                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@start_year", startYear);
                cmd.Parameters.AddWithValue("@end_year", endYear);
                cmd.Parameters.AddWithValue("@start_month", startMonth);
                cmd.Parameters.AddWithValue("@end_month", endMonth);
                cmd.Parameters.AddWithValue("@status", 1);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New academic year has been activated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void setActiveAcademicYear(string academicYear)
        {
            activeAcademicYearID = academicYear;

        }


        public void SetStudentFileStatus()
        {
            try {
                if (connection.State!=ConnectionState.Open) {
                    connection.Open();
                }

                string cmd = "SELECT COUNT(DISTINCT table_students.student_id) FROM table_students INNER JOIN table_enrollment  ON table_students.student_id = table_enrollment.student_id INNER JOIN table_class  ON table_enrollment.class_id = table_class.class_id   WHERE table_class.sy_id='" + GetPreviousAcademicYearID() + "'";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                int count = Convert.ToInt32(command.ExecuteScalar());

                string q = "SELECT DISTINCT table_students.student_id FROM table_students INNER JOIN table_enrollment  ON table_students.student_id = table_enrollment.student_id INNER JOIN table_class  ON table_enrollment.class_id = table_class.class_id   WHERE table_class.sy_id='"+GetPreviousAcademicYearID()+"'";
                MySqlCommand cod = new MySqlCommand(q, connection);
                MySqlDataReader reader = cod.ExecuteReader();
                
                MessageBox.Show(count.ToString());
                int[] studid = new int[count];
                int counter = 0;
                while (reader.Read())
                {
                    studid[counter] = Convert.ToInt32(reader.GetString("student_id"));
                    counter += 1;
                }
                reader.Close();



                for (int i = 0; i < count; i++)
                {
                    //string sql = "update s  set s.file_status=1 from table_students as s inner join table_enrollment as e on s.student_id=e.student_id inner join table_class as c on e.class_id =c.class_id where c.sy_id ='" + getpreviousacademicyearid()+"'";
                    string sql = "update table_students set file_status=1  where student_id ='" + studid[i] + "'";
                    MySqlCommand comm = new MySqlCommand(sql, connection);
                    comm.ExecuteNonQuery();
                }


            }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
            }

        }

        public int GetPreviousAcademicYearID()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string cmd = "SELECT sy_id FROM table_sy  WHERE status=2";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    previousSYID = Convert.ToInt32(reader.GetString("sy_id"));
                }
                reader.Close();
                //if (connection.State != ConnectionState.Closed)
                //{
                //    connection.Close();
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return previousSYID;
        }

        public string GetPreviousAcademicYear()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string cmd = "SELECT CONCAT(start_year,' - ',end_year) as 'School Year' FROM table_sy  WHERE status=2";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    previousSY = reader.GetString("School Year");
                }
                reader.Close();
                //if (connection.State != ConnectionState.Closed)
                //{
                //    connection.Close();
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return previousSY;
        }

        public void setPreviousAcademicYear()
        {

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                //previousAcademicYear = data.GetActiveAcademicYear();
                //data.setPreviousAcademicYear(academicSc);
                string qry = "UPDATE table_sy SET status = 0 WHERE status = '2'";
                MySqlCommand command1 = new MySqlCommand(qry, connection);
                command1.ExecuteNonQuery();


                string query = "UPDATE table_sy SET status = 2 WHERE sy_id = '" + this.GetActiveAcademicYearID() + "'";
                MySqlCommand command2 = new MySqlCommand(query, connection);
                command2.ExecuteNonQuery();
            }
            catch (Exception ex) { 
                MessageBox.Show(ex.Message);
            }
        }


        public int GetActiveGradingPeriodID()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string cmd = "SELECT grading_period_id FROM table_grading_period  WHERE status=1";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    activeGPID = Convert.ToInt32(reader.GetString("grading_period_id"));

                }
                reader.Close();
                //if (connection.State != ConnectionState.Closed)
                //{
                //    connection.Close();
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show(activeGPID.ToString());
            return activeGPID;

        }

        
        public string GetEndYear()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string cmd = "SELECT end_year FROM table_sy  WHERE status=1";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    endYEar = Convert.ToString(reader.GetString("end_year"));

                }
                reader.Close();
                //if (connection.State != ConnectionState.Closed)
                //{
                //    connection.Close();
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return endYEar;
        }

        public string GetActiveGradingPeriod()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string cmd = "SELECT grading_period FROM table_grading_period  WHERE status=1";
                MySqlCommand command = new MySqlCommand(cmd, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    activeGP = Convert.ToString(reader.GetString("grading_period"));

                }
                reader.Close();
                //if (connection.State != ConnectionState.Closed)
                //{
                //    connection.Close();
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return activeGP;
        }

        
        public void SetActiveGradingPeriodID(bool isNewSYActivated)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                //previousAcademicYear = data.GetActiveAcademicYear();
                //data.setPreviousAcademicYear(academicSc);
                
                string query = "";
                if (this.GetActiveGradingPeriodID() == 1 && !isNewSYActivated)
                {
                    query = "UPDATE table_grading_period SET status = 1 WHERE grading_period = '2nd'";
                }
                else if (this.GetActiveGradingPeriodID() == 2)
                {
                    query = "UPDATE table_grading_period SET status = 1 WHERE grading_period = '3rd'";
                }
                else if (this.GetActiveGradingPeriodID() == 3)
                {
                    query = "UPDATE table_grading_period SET status = 1 WHERE grading_period = '4th'";
                }
                else {
                    query = "UPDATE table_grading_period SET status = 1 WHERE grading_period = '1st'";

                }
                //////////////LAST    EDIT
                string qry = "UPDATE table_grading_period SET status = 0 WHERE grading_period_id = '" + this.GetActiveGradingPeriodID() + "'";
                MySqlCommand command1 = new MySqlCommand(qry, connection);
                command1.ExecuteNonQuery();
               

                MySqlCommand command2 = new MySqlCommand(query, connection);
                command2.ExecuteNonQuery();
                MessageBox.Show("New grading period has been activated succesfully!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SetActiveGradingPeriod(string gradingPeriod)
        {

            activeGradingPeriod = gradingPeriod;
        }

        public string[] GetIsGradeEncodingActive(int encodeGrade)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            string[] dateTimes = new string[2];
            string cmd = "SELECT start_date, end_date FROM table_grade_encoding  WHERE grading_period_id ='" +encodeGrade+ "' AND sy_id = '" + this.GetActiveAcademicYearID() + "'";
            MySqlCommand command = new MySqlCommand(cmd, connection);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                startGradingDate = reader.GetString("start_date").Trim();
                endGradingDate = reader.GetString("end_date").Trim();

            }
            reader.Close();
            dateTimes[0] = startGradingDate;
            dateTimes[1] = endGradingDate;
            
            return dateTimes;
        }

        public void SetIsGradeEncodingActive(DateTime now, DateTime start, DateTime end, string gradingPeriodText)
        {
            try
            {
                
                string cmd = "";
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string selQuery = "SELECT table_grade_encoding.grading_period_id FROM table_grade_encoding INNER JOIN table_grading_period ON table_grade_encoding.grading_period_id=table_grading_period.grading_period_id WHERE table_grading_period.grading_period='"+gradingPeriodText+"'";
                int selectedGPID = 0;
                bool nonZeroReturn = false;
                MySqlCommand countCmd = new MySqlCommand(selQuery,connection);
                MySqlDataReader rdr = countCmd.ExecuteReader();
                nonZeroReturn = rdr.HasRows;
                while (rdr.Read()) {
                    selectedGPID = Convert.ToInt32(rdr.GetString("grading_period_id"));
                    
                }
                rdr.Close();
                

                if (nonZeroReturn)
                {
                    cmd = "UPDATE table_grade_encoding SET start_date=@start_date, end_date=@end_date WHERE grading_period_id=@grading_period_id AND sy_id=@sy_id";
                                         
                    MySqlCommand command = new MySqlCommand(cmd, connection);
                    command.Parameters.AddWithValue("@start_date", start.ToString());
                    command.Parameters.AddWithValue("@end_date", end.ToString());
                    command.Parameters.AddWithValue("@grading_period_id", selectedGPID);
                    command.Parameters.AddWithValue("@sy_id", GetActiveAcademicYearID());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Date of Grade Encoding has been updated!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    cmd = "INSERT INTO table_grade_encoding" +
                                    "(start_date, end_date, grading_period_id, sy_id) " +
                                    "VALUES (@start_date,  @end_date, @grading_period_id, @sy_id) ";
                
                    MySqlCommand command = new MySqlCommand(cmd, connection);
                    command.Parameters.AddWithValue("@start_date", start.ToString());
                    command.Parameters.AddWithValue("@end_date", end.ToString());
                    command.Parameters.AddWithValue("@grading_period_id", GetActiveGradingPeriodID());
                    command.Parameters.AddWithValue("@sy_id", GetActiveAcademicYearID());
                    command.ExecuteNonQuery();
                    SetActiveGradingPeriodID(false);
                    MessageBox.Show("Date of Grade Encoding has been scheduled!", _title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Trace.WriteLine(command.CommandText);

                
                
                // MessageBox.Show("h " + result.ToString());
                //Trace.WriteLine(command);

                //string sql = "UPDATE table_grading_period SET status = 1 WHERE grading_period='" + gradingPeriodComboBox.Text + "'";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        }
            
    }

