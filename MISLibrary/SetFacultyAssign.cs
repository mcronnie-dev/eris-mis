using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISLibrary
{
    public class SetFacultyAssign
    {
        //Get from database
        public List<GradeLevel> GradeLvls { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<SubjectAssignment> AllAssign { get; set; }


        public SetFacultyAssign()
        {
            GradeLvls = new List<GradeLevel>();
        	Subjects = new List<Subject>();
        	Teachers = new List<Teacher>();
         	AllAssign = new List<SubjectAssignment>();
        }

    }
}
