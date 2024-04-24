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
    public class GuestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Guest/GetList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GuestViewModel>>(JObject.Parse(jsonData)["data"].ToString());

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
        public async Task<IActionResult> Add(GuestViewModel guest)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(guest);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7199/api/Guest/Add", stringContent);

                if (responseMessage.IsSuccessStatusCode)
                {
                    await UpdateAboutWithGuestCountAsync();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }



        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Guest/Get/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var guest = JsonConvert.DeserializeObject<GuestViewModel>(JObject.Parse(jsonData)["data"].ToString());

                var deleteData = JsonConvert.SerializeObject(guest);
                var stringContent = new StringContent(deleteData, Encoding.UTF8, "application/json");
                var responseDelete = await client.PostAsync("https://localhost:7199/api/Guest/Delete", stringContent);

                if (responseDelete.IsSuccessStatusCode)
                {
                    await UpdateAboutWithGuestCountAsync();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Guest/Get/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var guest = JsonConvert.DeserializeObject<GuestViewModel>(JObject.Parse(jsonData)["data"].ToString());

                return View(guest);

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(GuestViewModel guest)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(guest);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Guest/Update", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        private async Task UpdateAboutWithGuestCountAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            // Personel sayısını al
            var guestResponse = await httpClient.GetAsync("https://localhost:7199/api/Guest/GetList");
            var guesfData = await guestResponse.Content.ReadAsStringAsync();
            var guesList = JsonConvert.DeserializeObject<List<GuestViewModel>>(JObject.Parse(guesfData)["data"].ToString());
            var guesCount = guesList.Count;

            // About verilerini al ve ilk öğeye personel sayısını ekle
            var aboutResponse = await httpClient.GetAsync("https://localhost:7199/api/About/GetList");
            var aboutData = await aboutResponse.Content.ReadAsStringAsync();
            var aboutList = JsonConvert.DeserializeObject<List<AboutViewModel>>(JObject.Parse(aboutData)["data"].ToString());
            var firstAbout = aboutList.FirstOrDefault();

            if (firstAbout != null)
            {
                firstAbout.customerCount = guesCount;
                // About verilerini güncelle
                var GuestUpdatejsonData = JsonConvert.SerializeObject(firstAbout);
                var GuesUpdatestringContent = new StringContent(GuestUpdatejsonData, Encoding.UTF8, "application/json");
                var GuesUpdateresponseMessage = await httpClient.PostAsync("https://localhost:7199/api/About/Update", GuesUpdatestringContent);
            }

        }
    }

}
