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
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/About/GetList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AboutViewModel>>(JObject.Parse(jsonData)["data"].ToString());
                var firstAbout = values.FirstOrDefault();
                if(firstAbout == null)
                {
                    var about = new AboutViewModel
                    {
                        title = "",
                        description = "",
                        roomCount = 0,
                        customerCount = 0,
                        staffCount = 0,
                    };
                    var jsonDataAbout = JsonConvert.SerializeObject(about);
                    StringContent stringContent = new StringContent(jsonDataAbout, Encoding.UTF8, "application/json");
                    await client.PostAsync("https://localhost:7199/api/About/Add", stringContent);
                    return RedirectToAction("Index");
                }
                return View(firstAbout);
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(AboutViewModel aboutView)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(aboutView);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7199/api/About/Update", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }





    }
}
