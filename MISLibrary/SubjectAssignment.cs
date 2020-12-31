using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISLibrary
{
    //table_subject_assignment
    //    assignment_id
    //    subject_id
    //    teacher_id
    //    grade_level_id

    public class SubjectAssignment
    {
        public int Id { set; get; }
        public Subject Subject { get; set; }
        public Teacher Teacher { set; get; }
        public GradeLevel GradeLevel { set; get; }

        public string Display
        {
            get
            {
                if (Teacher != null && Subject != null && GradeLevel != null)
                    return string.Format($"{Teacher.Display} - {Subject.Name} {GradeLevel.Display}");
            else
                    return string.Format("Teacher/Subject/GradeLvl is null");
            }
        }

        public string DisplayGrLvl
        {
            get
            {
                return string.Format(Teacher != null && GradeLevel != null ? $"{Teacher.Display} - { GradeLevel.Display}" : "Teacher/GradeLvl is null");
            }
        }








        //scheduling1
        public string DisplayTeacher
        {
            get
            {
                return string.Format(Teacher != null ? Teacher.Display : "Teacher is null");
            }
        }

        public string DisplaySubject
        {
            get
            {
                return string.Format(Subject != null ? $"{Subject.Display} \n\n<Adviser>" : "Subject is null");
            }
        }


        public string DisplayTeacherAndSubject
        {
            get
            {
                return string.Format(Subject!=null && Teacher!= null ? $"{Subject.Display} \n\n{Teacher.Display}" : "Subject/Teacher is null");
            }
        }


    }
}
