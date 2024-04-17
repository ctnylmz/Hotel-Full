using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using WebApp.Areas.Admin.Models;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Staff/GetList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(JObject.Parse(jsonData)["data"].ToString());

                return View(values);
            }

            return View();
        }



        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(StaffViewModel staff)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(staff);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Staff/Add", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                await UpdateAboutWithStaffCountAsync();
                return RedirectToAction("Index");
            }

            return View();
        }



        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Staff/Get/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var staff = JsonConvert.DeserializeObject<StaffViewModel>(JObject.Parse(jsonData)["data"].ToString());

                var deleteData = JsonConvert.SerializeObject(staff);
                var stringContent = new StringContent(deleteData, Encoding.UTF8, "application/json");
                var responseDelete = await client.PostAsync("https://localhost:7199/api/Staff/Delete", stringContent);

                if (responseDelete.IsSuccessStatusCode)
                {
                    await UpdateAboutWithStaffCountAsync();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Staff/Get/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var staff = JsonConvert.DeserializeObject<StaffViewModel>(JObject.Parse(jsonData)["data"].ToString());

                return View(staff);

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(StaffViewModel staff)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(staff);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Staff/Update", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        private async Task UpdateAboutWithStaffCountAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            // Personel sayısını al
            var staffResponse = await httpClient.GetAsync("https://localhost:7199/api/Staff/GetList");
            var staffData = await staffResponse.Content.ReadAsStringAsync();
            var staffList = JsonConvert.DeserializeObject<List<StaffViewModel>>(JObject.Parse(staffData)["data"].ToString());
            var staffCount = staffList.Count;

            // About verilerini al ve ilk öğeye personel sayısını ekle
            var aboutResponse = await httpClient.GetAsync("https://localhost:7199/api/About/GetList");
            var aboutData = await aboutResponse.Content.ReadAsStringAsync();
            var aboutList = JsonConvert.DeserializeObject<List<AboutViewModel>>(JObject.Parse(aboutData)["data"].ToString());
            var firstAbout = aboutList.FirstOrDefault();

            if (firstAbout != null)
            {
                firstAbout.staffCount = staffCount;
                // About verilerini güncelle
                var StaffUpdatejsonData = JsonConvert.SerializeObject(firstAbout);
                var StaffUpdatestringContent = new StringContent(StaffUpdatejsonData, Encoding.UTF8, "application/json");
                var StaffUpdateresponseMessage = await httpClient.PostAsync("https://localhost:7199/api/About/Update", StaffUpdatestringContent);
            }

        }
    }

}
