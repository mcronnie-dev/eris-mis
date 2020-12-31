using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISLibrary
{
    public class TimeSchedModified
    {
        //timesched_id
        public int Id { set; get; }

        public SubjectAssignment SubjectAssignment { set; get; }

        public DaySched Day { set; get; }

        public Time Time { set; get; }

        public int SchedLabelInd { set; get; } //get SchedLabel index from DayId and TimeId


        public string Display
        {
            get
            {
                //Display Subject and Teacher
                return string.Format("{0}\n\n{1}", SubjectAssignment.Subject.Display, SubjectAssignment.Teacher.Display);
            }
        }
       
    }
}
