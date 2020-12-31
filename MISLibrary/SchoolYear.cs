using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISLibrary
{
    public class SchoolYear
    {
        public int Id { set; get; }

        public int StartYear { get; set; }
        public int EndYear { get; set; }


        public int StartMonth { get; set; }
        public int EndMonth { get; set; }

        public string Display
        {
            get
            {
                return string.Format("{0} - {1}", StartYear, EndYear);
            }
        }
        
    }
}
