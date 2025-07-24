using CarBook.Dto.BlogDtos;
using CarBook.Dto.TagCloudsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsTagCloudComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsTagCloudComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.BlogId = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7010/api/TagClouds/GetTagCloudsByBlogId?blogId=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetTagCloudsByBlogIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}