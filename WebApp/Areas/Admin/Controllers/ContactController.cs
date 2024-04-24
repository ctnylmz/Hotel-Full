using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WebApp.Models;
using System.Text;
using WebApp.Areas.Admin.Models;
using Entities.Concrete;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Contact/GetList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ContactViewModel>>(JObject.Parse(jsonData)["data"].ToString());

                return View(values);
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Inbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/Contact/Get/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var service = JsonConvert.DeserializeObject<ContactViewModel>(JObject.Parse(jsonData)["data"].ToString());

                return View(service);

            }

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SendMessageViewModel sendMessageViewModel)
        {
            sendMessageViewModel.receiverName = "receiverName";
            sendMessageViewModel.senderName = "senderName";
            sendMessageViewModel.senderMail = "senderMail";
            sendMessageViewModel.date = DateTime.Now;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(sendMessageViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/SendMessage/Add", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Send");
            }

            return View();
        }

        public async Task<IActionResult> Send()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/SendMessage/GetList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SendMessageViewModel>>(JObject.Parse(jsonData)["data"].ToString());

                return View(values);
            }

            return View();
        }

 

        [HttpGet]
        public async Task<IActionResult> SendBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7199/api/SendMessage/Get/{id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var service = JsonConvert.DeserializeObject<SendMessageViewModel>(JObject.Parse(jsonData)["data"].ToString());

                return View(service);

            }

            return View();
        }
    }
}
