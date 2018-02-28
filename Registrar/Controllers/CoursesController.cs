using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Registrar.Models;

namespace Registrar.Controllers
{
    public class CourseController : Controller
    {
        [HttpGet("/courses")]
        public ActionResult Index()
        {
            List<Course> allCourses = Course.GetAll();
            return View("Index", allCourses);
        }

        [HttpGet("/courses/new")]
        public ActionResult CreateForm()
        {
            return View("CreateForm");
        }

        [HttpPost("/courses")]
        public ActionResult Create()
        {
            string name = Request.Form["courseName"];
            string number = Request.Form["courseNumber"];
            string professor = Request.Form["professor"];
            Course newCourse = new Course(name, number, professor);
            newCourse.Save;
            List<Course> allCourses = Course.GetAll();
            return View("Index", allCourses);
        }
    }
}
