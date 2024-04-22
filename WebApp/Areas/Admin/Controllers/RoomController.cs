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
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Room/GetList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<RoomViewModel>>(JObject.Parse(jsonData)["data"].ToString());

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
        public async Task<IActionResult> Add(RoomViewModel room)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(room);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/Room/Add", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                await UpdateAboutWithRoomCountAsync();
                return RedirectToAction("Index");
            }

            return View();
        }



        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Room/Get/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var room = JsonConvert.DeserializeObject<RoomViewModel>(JObject.Parse(jsonData)["data"].ToString());

                var deleteData = JsonConvert.SerializeObject(room);
                var stringContent = new StringContent(deleteData, Encoding.UTF8, "application/json");
                var responseDelete = await client.PostAsync("https://localhost:7199/api/Room/Delete", stringContent);

                if (responseDelete.IsSuccessStatusCode)
                {
                    await UpdateAboutWithRoomCountAsync();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Room/Get/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var room = JsonConvert.DeserializeObject<RoomViewModel>(JObject.Parse(jsonData)["data"].ToString());

                return View(room);

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoomViewModel room)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(room);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/room/Update", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        private async Task UpdateAboutWithRoomCountAsync()
        {
            var httpClient = _httpClientFactory.CreateClient();

            // Personel sayısını al
            var roomResponse = await httpClient.GetAsync("https://localhost:7199/api/Room/GetList");
            var roomData = await roomResponse.Content.ReadAsStringAsync();
            var roomList = JsonConvert.DeserializeObject<List<RoomViewModel>>(JObject.Parse(roomData)["data"].ToString());
            var roomCount = roomList.Count;

            // About verilerini al ve ilk öğeye room sayısını ekle
            var aboutResponse = await httpClient.GetAsync("https://localhost:7199/api/About/GetList");
            var aboutData = await aboutResponse.Content.ReadAsStringAsync();
            var aboutList = JsonConvert.DeserializeObject<List<AboutViewModel>>(JObject.Parse(aboutData)["data"].ToString());
            var firstAbout = aboutList.FirstOrDefault();

            if (firstAbout != null)
            {
                firstAbout.roomCount = roomCount;
                // About verilerini güncelle
                var roomUpdatejsonData = JsonConvert.SerializeObject(firstAbout);
                var roomUpdatestringContent = new StringContent(roomUpdatejsonData, Encoding.UTF8, "application/json");
                var roomUpdateresponseMessage = await httpClient.PostAsync("https://localhost:7199/api/About/Update", roomUpdatestringContent);
            }

        }
    }

}
