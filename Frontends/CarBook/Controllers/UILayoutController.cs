using Microsoft.AspNetCore.Mvc;

namespace CarBook.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
