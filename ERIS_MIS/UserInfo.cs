using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERIS_MIS
{

    //Since there is no session in C#
    public static class UserInfo
    {
        public static int userID;
        public static string teacherID;
        public static string teacherNo;
        public static string teacherMobile;
        public static string teacherLastName;
        public static string teacherFirstName;
        public static string teacherMiddleName;
        public static string teacherFullName;
        public static string teacherCityAddress;
        public static string teacherBirthDay;
        public static string teacherGradSchool;

        public static int accessID;
        public static int positionID;


        //pulic variables needed for all forms
        public static string schoolYear = "2018-2019";

        public static string prevSchoolYear = "2017-2018";
        public static string studentNoOfSelected;
    }
}
