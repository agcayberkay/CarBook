using Microsoft.AspNetCore.Mvc;

namespace CarBook.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
