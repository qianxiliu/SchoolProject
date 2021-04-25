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

//Qianxi

        HttpClient httpClient;

        static string BASE_URL = "https://developer.nps.gov/api/v1/";
        static string API_KEY = "MK0jIRuFSvPvWyoMXcN209Jj16DfwRMOWfB9KCFL"; //Add your API key here inside ""

        //static string BASE_URL = "https://opendata.arcgis.com/datasets/a15e8731a17a46aabc452ea607f172c0_0.geojson";
        // Obtaining the API key is easy. The same key should be usable across the entire
        // data.gov developer network, i.e. all data sources on data.gov.


        public AppDbContext dbContext; // linking db context to our controller

        public async Task<IActionResult> Index()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //string NATIONAL_PARK_API_PATH = BASE_URL + "/parks?limit=20";
            string schoolData = "https://opendata.arcgis.com/datasets/a15e8731a17a46aabc452ea607f172c0_0.geojson";

            schoolData school = null;

            //httpClient.BaseAddress = new Uri(NATIONAL_PARK_API_PATH);
            httpClient.BaseAddress = new Uri(BASE_URL);

            try
            {
                //HttpResponseMessage response = httpClient.GetAsync(NATIONAL_PARK_API_PATH)
                //                                        .GetAwaiter().GetResult();
                HttpResponseMessage response = httpClient.GetAsync(BASE_URL)
                                                        .GetAwaiter().GetResult();



                if (response.IsSuccessStatusCode)
                {
                    schoolData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!schoolData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    school = JsonConvert.DeserializeObject<school>(schoolData);
                }

                dbContext.school.Add(school);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return View(SchoolView);
        }
    



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

//QX
        public IActionResult aboutUs()
        {
            return View(aboutUs);
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
