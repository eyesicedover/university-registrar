using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Registrar.Models;
using System;

namespace Registrar.Controllers
{
  public class StudentController : Controller
  {
    [HttpGet("/students")]
    public ActionResult Index()
    {
        List<Student> allStudents = Student.GetAll();
        return View(allStudents);
    }

    [HttpGet("/students/new")]
    public ActionResult CreateForm()
    {
        List<Course> allCourses = Course.GetAll();
        return View(allCourses);
    }

    [HttpPost("/students")]
    public ActionResult Create()
    {
        string name = Request.Form["studentName"];
        string date = Request.Form["studentDate"];
        string course = Request.Form["course"]
        List<Student> allStudents = Student.GetAll();
        return View("Index", allStudents);
    }
  }
}
