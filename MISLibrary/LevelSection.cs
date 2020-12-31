using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISLibrary
{
    public class LevelSection
    {
        public int Id { set; get; }

        public GradeLevel GradeLevel { set; get; }

        public string Section { set; get; }

        public string Display
        {
            get
            {
                return string.Format("{0} {1}", GradeLevel.Display, Section);
            }
        }

        public LevelSection()
        {
            GradeLevel = new GradeLevel();
        }
    }
}
