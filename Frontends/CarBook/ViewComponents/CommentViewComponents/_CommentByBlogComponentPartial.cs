using Microsoft.AspNetCore.Mvc;

namespace CarBook.ViewComponents.CommentViewComponents
{
    public class _CommentByBlogComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
