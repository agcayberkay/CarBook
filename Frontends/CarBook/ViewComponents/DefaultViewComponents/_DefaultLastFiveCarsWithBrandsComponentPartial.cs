using CarBook.Dto.CarWithBrandsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.ViewComponents.DefaultViewComponents
{
    public class _DefaultLastFiveCarsWithBrandsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLastFiveCarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7010/api/Cars/GetLastFiveCarsWithBrandsQueryHandler");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLastFiveCarsWithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
