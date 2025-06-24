using Microsoft.AspNetCore.Mvc;

namespace CarBook.ViewComponents.AboutViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
