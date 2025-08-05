using CarBook.Dto.AboutDtos;
using CarBook.Dto.CarWithBrandsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.Controllers
{
    public class AdminCarController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7010/api/Cars/GetCarWithBrand");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CarDetail(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7010/api/Cars/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarWithBrandsDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
