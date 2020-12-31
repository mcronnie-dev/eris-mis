using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISLibrary
{
    //table_class
    //    school_year
    //    class_id
    //    teacher_id
    //    room_id
    //    level_section_id
    //    created_date
    //    created_by
    //    updated_date
    //    updated_by
    //    deleted_date
    //    deleted_by
    public class ClassInf
    {

        public int Id { set; get; }
        public string SchoolYear { set; get; }
        public string CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public string UpdatedDate { set; get; }
        public string UpdatedBy { set; get; }
        public string DeletedDate { set; get; }
        public string DeletedBy { set; get; }



        public Teacher Adviser { set; get; }
        public LevelSection Section { set; get; }

        public List<Time> LevelSchedule { set; get; }
        public List<Subject> Subjects { set; get; }

        public List<TimeSchedModified> Schedule { get; set; }

        public ClassInf()
        {
            Schedule = new List<TimeSchedModified>();
            Subjects = new List<Subject>();

        }



    }
}

