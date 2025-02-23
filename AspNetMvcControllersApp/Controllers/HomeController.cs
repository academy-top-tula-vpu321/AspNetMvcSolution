using AspNetMvcControllersApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetMvcControllersApp.Controllers
{
    public class HomeController : Controller
    {
        //ITimeService _timeService;

        //public HomeController(ITimeService timeService)
        //{
        //    _timeService = timeService;
        //}

        //public string Index(User user)
        //{
        //    string actionName = ControllerContext.ActionDescriptor.ActionName;
        //    return $"Name: {user.Name}, Age: {user.Age}";
        //}

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Index(int a)
        {
            var form = Request.Form;
            string? name = form["name"];
            int? age = Int32.Parse(form["age"]);

            return $"Name: {name}, age: {age}";
            //return View("IndexPost");
        }

        public IActionResult User()
        {
            User user = new() {  Name = "Bobby", Age = 32  };
            return Json(user);
        }

        public IActionResult GetFile()
        {
            string path = Path.Combine(AppDomain.CurrentDomain
                                                .BaseDirectory, 
                                       "Files/ada.jpg");
            string type = "image/jpeg";
            string name = "ada-photo.jpg";

            //byte[] fileBuffer = System.IO.File.ReadAllBytes(path);
            FileStream stream = new FileStream(path, FileMode.Open);

            //return PhysicalFile(path, type, name);
            //return File(fileBuffer, type, name);
            return File(stream, type, name);
        }

        //public IActionResult GetTime([FromServices] ITimeService timeService)
        public IActionResult GetTime()
        {
            var timeService = HttpContext.RequestServices.GetService<ITimeService>();

            return Content(timeService.GetTime);
        }


        //[ActionName("Privacy")]
        //public IActionResult MyPrivacyExample()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult FlightsForm()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult FlightsFormWork()
        //{
        //    return View();
        //}
    }

    public class User
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
