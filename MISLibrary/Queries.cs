using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace MISLibrary
{
    public class Queries
    {
        //frmFacultyAssignment -> TEACHER ASSIGNMENT
        public const string allGrLvl = "SELECT grade_level_id,grade_level FROM table_grade_level";
        public const string allSubj = "SELECT subject_id,subject,frequency FROM table_subject";
        public const string allTeacher = "SELECT teacher_id,last_name,first_name,middle_name FROM table_teacher";
        //public const string allAssign = "SELECT assignment_id, subject_id, grade_level_id, teacher_id FROM table_subject_assignment";

        public const string allAssign = "SELECT table_subject_assignment.assignment_id, table_subject_assignment.subject_id, table_subject_assignment.grade_level_id, table_subject_assignment.teacher_id, " +
            " table_teacher.last_name, table_teacher.first_name, table_teacher.middle_name " +
            " FROM table_subject_assignment" +
            " INNER JOIN table_teacher ON table_teacher.teacher_id = table_subject_assignment.teacher_id ";

        
    }
}
