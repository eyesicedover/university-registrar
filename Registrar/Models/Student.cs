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

        public Student(int Id = 0, string name, string date)
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


    }
}
