using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISLibrary
{
    public class DaySched
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

    }
}
