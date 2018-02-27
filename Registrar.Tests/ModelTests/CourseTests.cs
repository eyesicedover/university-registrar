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
            Course.DeleteAll();
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

        [TestMethod]
        public void Save_AssignsIdToCourse_CourseId()
        {
            //Arrange
            Course testCourse = new Course("History", "101", "Mr.Schneider");
            //Act
            testCourse.Save();
            Course savedCourse = Course. GetAll()[0];

            int result = savedCourse.GetId();
            int testId = testCourse.GetId();
            //Assert
            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FindsCourseId_ReturnsCourse()
        {
            //arrange
            Course testCourse = new Course("History", "101", "Mr.Schneider");
            testCourse.Save();

            //act
            Course foundCourse = Course.Find(testCourse.GetId());
            //assert
            Assert.AreEqual(testCourse, foundCourse);
        }
    }
}
