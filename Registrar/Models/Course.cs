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

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM courses;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Course> GetAll()
        {
            List<Course> allCourses = new List<Course> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM courses;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int courseId = rdr.GetInt32(0);
                string courseName = rdr.GetString(1);
                string courseNumber = rdr.GetString(2);
                string professor = rdr.GetString(3);

                Course newCourse = new Course(courseName, courseNumber, professor, courseId);
                allCourses.Add(newCourse);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
                return allCourses;
        }

        public static Course Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `courses` WHERE id = @thisId;";

            MySqlParameter thisId = new MySqlParameter();
            thisId.ParameterName = "@thisId";
            thisId.Value = id;
            cmd.Parameters.Add(thisId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int courseId = 0;
            string courseName = "";
            string courseNumber = "";
            string professor = "";

            while (rdr.Read())
            {
                courseId = rdr.GetInt32(0);
                courseName = rdr.GetString(1);
                courseNumber = rdr.GetString(2);
                professor = rdr.GetString(3);
            }

            Course foundCourse = new Course(courseName, courseNumber, professor, courseId);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

            return foundCourse;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `courses` (`course_name`, `course_number`, `professor`) VALUES (@CourseName, @CourseNumber, @Professor);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@CourseName";
            name.Value = this._courseName;

            MySqlParameter courseNumber = new MySqlParameter();
            courseNumber.ParameterName = "@CourseNumber";
            courseNumber.Value = this._courseNumber;

            MySqlParameter professor = new MySqlParameter();
            professor.ParameterName = "@Professor";
            professor.Value = this._professor;

            cmd.Parameters.Add(name);
            cmd.Parameters.Add(courseNumber);
            cmd.Parameters.Add(professor);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Student> GetStudents()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT student_id FROM students_courses WHERE course_id = @courseId;";

            MySqlParameter courseIdParameter = new MySqlParameter();
            courseIdParameter.ParameterName = "@courseId";
            courseIdParameter.Value = _id;
            cmd.Parameters.Add(courseIdParameter);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;

            List<int> studentIds = new List<int> {};
            while(rdr.Read())
            {
                int studentId = rdr.GetInt32(0);
                studentIds.Add(studentId);
            }
            rdr.Dispose();

            List<Student> students = new List<Student> {};
            foreach (int studentId in studentIds)
            {
                var studentQuery = conn.CreateCommand() as MySqlCommand;
                studentQuery.CommandText = @"SELECT * FROM students WHERE id = @StudentId;";

                MySqlParameter studentIdParameter = new MySqlParameter();
                studentIdParameter.ParameterName = "@StudentId";
                studentIdParameter.Value = studentId;
                studentQuery.Parameters.Add(studentIdParameter);

                var studentQueryRdr = studentQuery.ExecuteReader() as MySqlDataReader;
                while(studentQueryRdr.Read())
                {
                    int thisStudentId = studentQueryRdr.GetInt32(0);
                    string studentName = studentQueryRdr.GetString(1);
                    string studentDate = studentQueryRdr.GetString(2);
                    Student foundStudent = new Student(studentName, studentDate, studentId);
                    students.Add(foundStudent);
                }
                studentQueryRdr.Dispose();
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return students;
        }

        public void AddStudent(Student newStudent)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO students_courses (student_id, course_id) VALUES (@StudentId, @CourseId);";

            MySqlParameter studentId = new MySqlParameter();
            studentId.ParameterName = "@StudentId";
            studentId.Value = newStudent.GetId();
            cmd.Parameters.Add(studentId);

            MySqlParameter courseId = new MySqlParameter();
            courseId.ParameterName = "@CourseId";
            courseId.Value = _id;
            cmd.Parameters.Add(courseId);

            cmd.ExecuteNonQuery();
            conn.Close();

            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
