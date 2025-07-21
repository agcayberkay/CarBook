using Microsoft.AspNetCore.Mvc;

namespace CarBook.ViewComponents.BlogViewComponents
{
    public class _BlogDetailParagraphComponentPartail : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
