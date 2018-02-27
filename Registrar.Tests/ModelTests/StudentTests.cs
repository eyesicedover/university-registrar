
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Registrar.Models;
using System;

namespace Registrar.Tests
{
    [TestClass]
    public class StudentTests : IDisposable
    {
        public void Dispose()
        {
            Student.DeleteAll();
        }

        public StudentTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=registrar_test;";
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfStudentsAreTheSame_Student()
        {
            //Arrange, act
            Student firstStudent = new Student("Eric", "2018-02-27");
            Student secondStudent = new Student("Eric", "2018-02-27");

            //Assert
            Assert.AreEqual(firstStudent, secondStudent);
        }

        [TestMethod]
        public void GetAll_DatabaseEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = Student.GetAll().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_StudentList()
        {
            //Arrange
            Student testStudent = new Student("Eric", "2018-02-27");

            //Act
            testStudent.Save();
            List<Student> result = Student.GetAll();
            List<Student> testList = new List<Student>{testStudent};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }
    }
}
