using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISLibrary
{
    //table_time
    //    time_id
    //    time_name

    public class Time
    {
        public int Id { set; get; }

        public string Name { get; set; }

        public string Display
        {
            get
            {
                return string.Format("{0}", Name);
            }
        }

        public string DisplayCheck
        {
            get
            {
                return string.Format("id: {0}\nname: {1}\n gradelevelid: {2} \n isrecess: = {3}", Id, Name, GradeLevelId, IsRecess);
            }
        }


        //added to database fields XD
        public int GradeLevelId { set; get; }

        public bool IsRecess { get; set; }
    }
}
