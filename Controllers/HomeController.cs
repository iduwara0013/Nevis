using Microsoft.AspNetCore.Mvc;

namespace RegistrationApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public IActionResult Index()
        {
            return View(); // Display the Home page
        }
    }
}
