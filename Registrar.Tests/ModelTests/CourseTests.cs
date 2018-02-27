using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Registrar.Models;
using System;

namespace Registrar.Tests
{
    [TestClass]
    public class CourseTests : IDisposable
    {
        public void Dispose()
        {
            Student.DeleteAll();
        }

        public CourseTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=registrar_test;";
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfCoursesAreTheSame_Course()
        {
            //Arrange, act
            Course firstCourse = new Course("History", "101", "Mr.Schneider");
            Course secondCourse = new Course("History", "101", "Mr.Schneider");

            //Assert
            Assert.AreEqual(firstCourse, secondCourse);
        }
    }
}
