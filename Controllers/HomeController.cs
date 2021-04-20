using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SchoolProject.Models;
using SchoolProject.Data_Access;
using System.Net.Http;

namespace SchoolProject.Controllers
{
    public class HomeController : Controller
    {
        //HttpClient httpClient;

        //static string "https://opendata.arcgis.com/datasets/a15e8731a17a46aabc452ea607f172c0_0.geojson";

        public AppDbContext dbContext; // linking db context to our controller

        public HomeController(AppDbContext context) //linking our controller to the dbcontext for link commands
        {
            dbContext = context;
            //context.Database.EnsureCreated();
        }


        public IActionResult Index() // here's where we create the linq queries for the data ???
        {
            Student testStudent = new Student();
            //testStudent.StudentId = 101;
            testStudent.GPA = 3.97;
            testStudent.SchoolId = 1;
            testStudent.StudentName = "Mark Morey";


            //dbContext.SaveChanges();

            School testSchool = new School();
            //testSchool.SchoolId = 10001;
            testSchool.SchoolName = "University of SOuth Florida";
            testSchool.State = "Florida";
            testSchool.Street = "4202 E Fowler Ave";
            testSchool.City = "Tampa";
            testSchool.County = "Hillsborough";
            testSchool.ZipCode = 33620;


            dbContext.Students.Add(testStudent);
            dbContext.Schools.Add(testSchool);
            dbContext.SaveChanges();

            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }
        //// was put here by default


        //shows all students
        public IActionResult StudentView()
        {
            var studentData = dbContext.Students.ToList();

            return View(studentData);

        }

        public IActionResult SchoolView()
        {
            var schoolData = dbContext.Schools.ToList();

            return View(schoolData);
        }



        // private readonly ILogger<HomeController> _logger;

        // public HomeController(ILogger<HomeController> logger)
        // {
        //     _logger = logger;
        // }
        // //was put here bvy default



        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
        // //was put here by default
    }
}
