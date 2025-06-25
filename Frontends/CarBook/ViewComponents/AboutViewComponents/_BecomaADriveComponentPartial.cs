using Microsoft.AspNetCore.Mvc;

namespace CarBook.ViewComponents.AboutViewComponents
{
    public class _BecomaADriveComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
