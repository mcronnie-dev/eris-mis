using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISLibrary
{
    //table_teacher
    //    teacher_id
    //    teacher_no
    //    user_id
    //    teacher_mobile
    //    last_name
    //    first_name
    //    middle_name
    //    city_address
    //    date_of_birth
    //    graduate_school
    //    position
    //    user_acess
    //    added_date
    //    added_by
    //    updated_date
    //    updated_by
    //    deleted_date
    //    deleted_by

    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherNo { get; set; }
        public int UserId { get; set; }
        public string Mobile { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string CityAddress { get; set; }
        public string DateOfBirth { get; set; }
        public string GraduateSchool { get; set; }
        public bool IsAssigned { get; set; } //set to false as default. Change IsAssigned in Get

        public string Display
        {
            get
            {
                return string.Format(Id != 0 ? $"{LastName}, {FirstName} {MiddleName}" : "Teacher returned null value." );
            }
        }
            
        public string AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedDate { get; set; }
        public string DeletedBy { get; set; }

        
        public Teacher()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            MiddleName = "";
            IsAssigned = false;
        }
    }


    public class TeacherAsUser : Teacher
    {
        public string Position { get; set; }
        public string Access { get; set; }
        //properties (Position, UserAccess) above are prev in teacher class.
        
        public int PositionId { get; set; }
        public int AccessId { get; set; }


        public string Username { get; set; }
        public string Password { get; set; }

        public TeacherAsUser()
        {
        }

    
    }
}
