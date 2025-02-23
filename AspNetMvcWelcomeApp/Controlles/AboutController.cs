using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcWelcomeApp.Controlles
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
