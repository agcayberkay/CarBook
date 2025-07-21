using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarPricingWithCarsDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController (IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Bloglarımız";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7010/api/Blogs/GetAllBlogsWithAuthorList");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
           
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            ViewBag.v1 = "Blog";
            ViewBag.v2 = "Blog Detay";     
            ViewBag.BlogId = id;
            return View();
        }
    }
}
