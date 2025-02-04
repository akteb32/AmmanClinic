using Microsoft.AspNetCore.Mvc;

namespace AmmanClinic.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
