using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.Models
{
    public class Student
    {

        public int StudentId { get; set; } //PK for students
        public String StudentName { get; set; }

        public double GPA { get; set; }

        public int SchoolId { get; set; } //FK for schools

    }


    public class School
    { //get data from API 
        public int SchoolId { get; set; } //PK for school

        public string SchoolName { get; set; }

        public List<Student> Students { get; set; } //creating list for 1 to many relationship with students class

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string County { get; set; }

        public int ZipCode { get; set; }

    }
}
