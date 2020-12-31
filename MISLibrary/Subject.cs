using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// table_subject
///    subject_id
///    subject
///    frequency
///    department_id
/// </summary>
namespace MISLibrary
{
    

    public class Subject
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Frequency { set; get; }

        public string Display
        {
            get
            {
                return string.Format(Name != null ? $"{Name}" : "Subject return null value.");
            }
        }


        //used in Scheduling Feature.
        public int SubjectCount { set; get; }
        public int Remaining
        {
            get
            {
                return (Frequency - SubjectCount);
            }
        }
        
        public Subject()
        {
            SubjectCount = 0;
        }
    }
}
