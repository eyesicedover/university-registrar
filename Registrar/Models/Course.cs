using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Registrar.Models
{
    public class Course
    {
        private int _id;
        private string _courseName;
        private string _courseNumber;
        private string _professor;

        public Course(string courseName, string courseNumber, string professor, int Id = 0)
        {
            _id = Id;
            _courseName = courseName;
            _courseNumber = courseNumber;
            _professor = professor;

        }
        public int GetId()
        {
            return _id;
        }

        public string GetProfessor()
        {
            return _professor;
        }

        public string GetCourseName()
        {
            return _courseName;
        }

        public void SetCourseName(string newCourseName)
        {
            _courseName = newCourseName;
        }

        public string GetCourseNumber()
        {
            return _courseNumber;
        }

        public void SetCourseNumber(string newCourseNumber)
        {
            _courseNumber = newCourseNumber;
        }

        public override bool Equals(System.Object otherCourse)
        {
            if(!(otherCourse is Course))
            {
                return false;
            }
            else
            {
                Course newCourse = (Course) otherCourse;
                bool idEquality = (this.GetId() == newCourse.GetId());
                bool courseNameEquality = (this.GetCourseName() == newCourse.GetCourseName());
                bool courseNumberEquality = (this.GetCourseNumber() == newCourse.GetCourseNumber());
                bool professorEquality = (this.GetProfessor() == newCourse.GetProfessor());
                return (idEquality && courseNameEquality && courseNumberEquality && professorEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetCourseName().GetHashCode();
        }

    }
}
