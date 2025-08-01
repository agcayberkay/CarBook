using Microsoft.AspNetCore.Mvc;

namespace CarBook.Controllers
{
    public class AdminCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
