using CarBook.Dto.AboutDtos;
using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarWithBrandsDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7010/api/Brands");
            var jsonData = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDtos>>(jsonData);
            List<SelectListItem> brandList = (from x in values
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.BrandId.ToString()
                                              }).ToList();
            ViewBag.brandList = brandList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDtos createCarWDtos)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarWDtos);
            StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7010/api/Cars", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7010/api/Cars/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response1 = await client.GetAsync($"https://localhost:7010/api/Brands");
            var jsonData1 = await response1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultBrandDtos>>(jsonData1);
            List<SelectListItem> brandList = (from x in values1
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.BrandId.ToString()
                                              }).ToList();
            ViewBag.brandList = brandList;




          
            var response = await client.GetAsync($"https://localhost:7010/api/Cars/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
