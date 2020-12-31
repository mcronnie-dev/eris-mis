using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISLibrary
{
    //table_grade_level
    //    grade_level_id
    //    grade_level

    public class GradeLevel
    {
        public int Id { set; get; }
        public string Level { set; get; }

        public string Display
        {
            get
            {
                return string.Format(Level != null ? $"{Level}" : "Grade Level returned null value.");
            }
        }
    }

}

