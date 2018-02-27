using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Registrar.Models
{
    public class Student
    {
        private int _id;
        private string _name;
        private string _rawDate;

        public Student(string name, string date, int Id = 0)
        {
            _id = Id;
            _name = name;
            _rawDate = date;
        }

        public string GetDate()
        {
            return _rawDate;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetDate(string newDate)
        {
            _rawDate = newDate;
        }

        public void SetName(string newName)
        {
            _name = newName;
        }

        public int GetId()
        {
            return _id;
        }

        public override bool Equals(System.Object otherStudent)
        {
            if (!(otherStudent is Student))
            {
                return false;
            }
            else
            {
                Student newStudent = (Student) otherStudent;
                bool idEquality = (this.GetId() == newStudent.GetId());
                bool nameEquality = (this.GetName() == newStudent.GetName());
                bool dateEquality = (this.GetDate() == newStudent.GetDate());
                return (idEquality && nameEquality && dateEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.GetName().GetHashCode();
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM students;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Student> GetAll()
        {
            List<Student> allStudents = new List<Student> {};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM students;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int studentId = rdr.GetInt32(0);
                string studentName = rdr.GetString(1);
                string studentDate = rdr.GetString(2);

                Student newStudent = new Student(studentName, studentDate, studentId);
                allStudents.Add(newStudent);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
                return allStudents;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `students` (`name`, `enroll_date`) VALUES (@studentName, @studentDate);";

            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@studentName";
            name.Value = this._name;
            MySqlParameter date = new MySqlParameter();
            date.ParameterName = "@studentDate";
            date.Value = this._rawDate;
            cmd.Parameters.Add(name);
            cmd.Parameters.Add(date);

            cmd.ExecuteNonQuery();
            _id = (int) cmd.LastInsertedId;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
