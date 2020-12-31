using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace MISLibrary
{
    public class ForScheduling
    {
        public const string cs = "datasource=127.0.0.1;port=3306;username=root;password=;database=eris_mis;";

        //Get from database
        public List<GradeLevel> GradeLvls { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<SubjectAssignment> AllAssign { get; set; }

        public List<LevelSection> Sections { get; set; }
        public List<ClassInf> ClassesList { get; set; }
        public List<Time> TimeList { get; set; }
        public List<DaySched> Days { set; get; }


        public ForScheduling()
        {
            GradeLvls = new List<GradeLevel>();
            Subjects = new List<Subject>();
            Teachers = new List<Teacher>();
            AllAssign = new List<SubjectAssignment>();


            Sections = new List<LevelSection>();
            ClassesList = new List<ClassInf>();
            TimeList = new List<Time>();

        }




        public List<GradeLevel> GetAllGrLvl()
        {
            List<GradeLevel> list = new List<GradeLevel>();
            string sql = "SELECT grade_level_id,grade_level FROM table_grade_level";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                //Console.WriteLine("{0} {1} {2}", rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2));
                list.Add(new GradeLevel
                {
                    Id = rdr.GetInt32(0),
                    Level = rdr.GetString(1)
                });
            }

            con.Close();
            return list;
        }

        public List<Subject> GetAllSubject()
        {
            List<Subject> list = new List<Subject>();
            string sql = "SELECT subject_id,subject,frequency FROM table_subject";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Subject
                {
                    Id = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Frequency = rdr.GetInt32(2)
                });
            }

            con.Close();
            return list;
        }

        public List<Teacher> GetAllTeacher()
        {
            List<Teacher> list = new List<Teacher>();
            string sql = "SELECT teacher_id,last_name,first_name,middle_name FROM table_teacher";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Teacher
                {
                    Id = rdr.GetInt32(0),
                    LastName = rdr.GetString(1),
                    FirstName = rdr.GetString(2),
                    MiddleName = rdr.GetString(3)
                });
            }

            con.Close();
            return list;
        }

        public List<SubjectAssignment> GetAllAssign()
        {
            List<SubjectAssignment> list = new List<SubjectAssignment>();
            string sql = $"SELECT assignment_id, subject_id, grade_level_id, teacher_id FROM table_subject_assignment";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int subjectId = rdr.GetInt32(1);
                int gradeLevelId = rdr.GetInt32(2);
                int teacherId = rdr.GetInt32(3);

                list.Add(new SubjectAssignment
                {
                    Id = rdr.GetInt32(0),
                    Subject = Subjects.Find(x => x.Id == subjectId),
                    GradeLevel = GradeLvls.Find(x => x.Id == gradeLevelId),
                    Teacher = Teachers.Find(x => x.Id == teacherId)
                });
            }

            con.Close();
            return list;
        }


        public List<SubjectAssignment> GetAllAssign(int grLvlId)
        {
            string sql = "";

            List<SubjectAssignment> list = new List<SubjectAssignment>();
            if (grLvlId > 0) { sql = $"SELECT assignment_id, subject_id, grade_level_id, teacher_id FROM table_subject_assignment WHERE grade_level_id='{grLvlId}'"; }
            else { sql = $"SELECT assignment_id, subject_id, grade_level_id, teacher_id FROM table_subject_assignment"; }

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int subjectId = rdr.GetInt32(1);
                int gradeLevelId = rdr.GetInt32(2);
                int teacherId = rdr.GetInt32(3);

                list.Add(new SubjectAssignment
                {
                    Id = rdr.GetInt32(0),
                    Subject = Subjects.Find(x => x.Id == subjectId),
                    GradeLevel = GradeLvls.Find(x => x.Id == gradeLevelId),
                    Teacher = Teachers.Find(x => x.Id == teacherId)
                });
            }

            con.Close();
            return list;
        }

        public SchoolYear GetSy()
        {
            SchoolYear classSY = new SchoolYear();
            string sql = "SELECT sy_id,start_year,end_year FROM `table_sy` WHERE status = 1";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                classSY.Id = rdr.GetInt32(0);
                classSY.StartYear = rdr.GetInt32(1);
                classSY.EndYear = rdr.GetInt32(2);
            }

            con.Close();
            return classSY;
        }
        
}



    public class SchedulingQueries : ForScheduling
    {

        public SchedulingQueries()
        {
            Days = new List<DaySched>();
            Days.Add(new DaySched { Id = 1, Name = "Monday" });
            Days.Add(new DaySched { Id = 2, Name = "Tuesday" });
            Days.Add(new DaySched { Id = 3, Name = "Wednesday" });
            Days.Add(new DaySched { Id = 4, Name = "Thursday" });
            Days.Add(new DaySched { Id = 5, Name = "Friday" });


            //ALSO INITIALIZE WITH DATA FROM DB.
            GradeLvls = GetAllGrLvl();
            Subjects = GetAllSubject();
            Teachers = GetAllTeacher();

        }


        //data.GradeLvls.Clear();
        //data.GradeLvls = GetAllGrLvl();

        //data.Subjects.Clear();
        //data.Subjects = GetAllSubject();

        //data.Teachers.Clear();
        //data.Teachers = GetAllTeachers();

        //data.AllAssign.Clear();
        //data.AllAssign = GetAllAssign();

        //data.Sections.Clear();
        //data.Sections = GetAllSection();

        //data.TimeList.Clear();
        //data.TimeList = GetTimeList();

        //selectedClass.Clear();
        //selectedClass = GetClass();

        //selectedClass.Schedule.Clear();
        //selectedClass.Schedule = GetAllClassSchedule();

        //scheduleConflict = GetScheduleConflictChecker()

        //adviserConflict = GetAdviserConflictChecker()


        public List<LevelSection> GetAllSection(int grLvlId)
        {
            List<LevelSection> list = new List<LevelSection>();
            string sql = $"SELECT level_section_id, grade_level_id, section FROM table_level_section WHERE grade_level_id='{grLvlId}'";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int gradeLevelId = rdr.GetInt32(1);

                list.Add(new LevelSection
                {
                    Id = rdr.GetInt32(0),
                    GradeLevel = GradeLvls.Find(x => x.Id == gradeLevelId),
                    Section = rdr.GetString(2)
                });
            }

            con.Close();
            return list;
        }

        public List<Time> GetTimeList(int grLvlId)
        {
            List<Time> list = new List<Time>();
            string sql = $"SELECT table_time.time_id, table_time.time_name, table_time.level_schedule_id, table_time.is_recess FROM table_time " +
            $"LEFT JOIN table_level_schedule ON table_time.level_schedule_id = table_level_schedule.level_schedule_id " +
            $"WHERE table_level_schedule.grade_level_id='{grLvlId}' AND table_level_schedule.is_active=1";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new Time
                {
                    Id = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    GradeLevelId = rdr.GetInt32(2),
                    IsRecess = rdr.GetBoolean(3)
                });
            }

            con.Close();
            return list;
        }

        public ClassInf GetClass(int syId, int sectionId)
        {
            ClassInf classSelected = new ClassInf();
            string sql = $"SELECT class_id, teacher_id, level_section_id FROM table_class WHERE sy_id ='{syId}' AND level_section_id ='{sectionId}'";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int gradeLevelId = rdr.GetInt32(1);

                classSelected.Id = rdr.GetInt32(0);
                classSelected.Adviser = Teachers.Find(y => y.Id == rdr.GetInt32(1));
                classSelected.Section = Sections.Find(y => y.Id == rdr.GetInt32(2));
            }

            con.Close();
            return classSelected;
        }

        public bool GetClass(int syId, int sectionId, int checker)
        {
            bool isEmpty = true;
            string sql = $"SELECT class_id, teacher_id, level_section_id FROM table_class WHERE sy_id ='{syId}' AND level_section_id ='{sectionId}'";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                isEmpty = false;
            }
            else
            {
                isEmpty = true;
            }

            con.Close();
            return isEmpty;
        }




        //Class Schedule Query No. 8 - A
        public List<TimeSchedModified> GetClassSchedule(int classId)
        {
            List<TimeSchedModified> list = new List<TimeSchedModified>();
            string sql = $"SELECT timesched_id, time_id, assignment_id, day FROM table_timesched WHERE class_id='{classId}'";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                list.Add(new TimeSchedModified
                {
                    Id = rdr.GetInt32(0),
                    Time = TimeList.Find(y => y.Id == rdr.GetInt32(1)),
                    SubjectAssignment = AllAssign.Find(y => y.Id == rdr.GetInt32(2)),
                    Day = Days.Find(y => y.Id == rdr.GetInt32(3))
                });
            }

            con.Close();
            return list;
        }

        //Class Schedule Query No. 8 - B
        public bool GetClassSchedule(int classId, int checker)
        {
            bool isEmpty = true;
            string sql = $"SELECT timesched_id, time_id, assignment_id, day FROM table_timesched WHERE class_id='{classId}'";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                isEmpty = false;
            }
            else
            {
                isEmpty = true;
            }

            con.Close();
            return isEmpty;
        }


        //Query No. 9: Conflict checker in teacher's schedule. (Modify to get the result.)
        public bool GetScheduleConflictChecker(int classId, int teacherId, int timeId, int day, int syId)
        {
            bool isConflict = false;
            string sql = $"SELECT table_timesched.class_id, table_timesched.assignment_id FROM table_timesched " +
                $"INNER JOIN table_subject_assignment ON table_timesched.assignment_id = table_subject_assignment.assignment_id " +
                $"INNER JOIN table_class ON table_timesched.class_id = table_class.class_id " +
                $"WHERE table_timesched.day = {day} AND table_timesched.time_id = {timeId} AND table_subject_assignment.teacher_id = {teacherId} AND table_timesched.class_id != {classId} AND table_class.sy_id = {syId}";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    int conflictClassId = rdr.GetInt32(0);
                    int teacher = rdr.GetInt32(1);
                }

                isConflict = true;
            }
            else
            {
                isConflict = false;
            }

            con.Close();
            return isConflict;
        }



        //Query No. 10: Conflict checker in teacher's schedule. (Modify to get the result.)
        public bool GetAdviserConflictChecker(int classId, int teacherId)
        {
            bool isConflict = false;
            string sql = $"SELECT teacher_id, class_id from table_class WHERE teacher_id = {teacherId} AND class_id<> {classId}";

            MySqlConnection con = new MySqlConnection(cs);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    int conflictClassId = rdr.GetInt32(0);
                    int levelSectionId = rdr.GetInt32(1);
                }

                isConflict = true;
            }
            else
            {
                isConflict = false;
            }

            con.Close();
            return isConflict;
        }

        public SubjectAssignment InsertAndGetAssign(int grLvlId, int teacherId, int subjectId)
        {
            string query = $"INSERT INTO table_subject_assignment(subject_id, teacher_id, grade_level_id) VALUES('{subjectId}','{teacherId}','{grLvlId}')";


            ExecuteQuery(query);

            AllAssign = GetAllAssign();

            SubjectAssignment inserted = AllAssign.Find(x => x.Subject.Id == subjectId && x.Teacher == null && x.GradeLevel.Id == grLvlId);

            return inserted;
        }

        //OK
        private void ExecuteQuery(string query)
        {
            MySqlConnection con = new MySqlConnection(cs);
            
            try
            {
                con.Open();

                MySqlCommand command = new MySqlCommand(query, con);
                
                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception)
            {
                con.Close();
            }
        }

    }

}