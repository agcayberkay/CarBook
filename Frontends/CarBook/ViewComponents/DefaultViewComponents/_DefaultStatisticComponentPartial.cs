using Microsoft.AspNetCore.Mvc;

namespace CarBook.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
