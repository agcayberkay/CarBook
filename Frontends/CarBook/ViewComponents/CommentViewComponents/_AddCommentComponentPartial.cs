using Microsoft.AspNetCore.Mvc;

namespace CarBook.ViewComponents.CommentViewComponents
{
    public class _AddCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            return View();
        }
    }
}
