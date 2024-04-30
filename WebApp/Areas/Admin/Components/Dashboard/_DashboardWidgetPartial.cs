using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using WebApp.Models;

namespace WebApp.Areas.Admin.Components.Dashboard
{
    public class _DashboardWidgetPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardWidgetPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync(AboutViewModel aboutView,BookingViewModel bookingView)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/About/GetList");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<AboutViewModel>>(JObject.Parse(jsonData)["data"].ToString());
            var firstAbout = values.FirstOrDefault();

            var BookingMessage = await client.GetAsync("https://localhost:7199/api/Booking/GetList");
            var bookingData = await BookingMessage.Content.ReadAsStringAsync();
            var bookingList = JsonConvert.DeserializeObject<List<BookingViewModel>>(JObject.Parse(bookingData)["data"].ToString());
            ViewBag.BookingCount = bookingList.Count;


            return View(firstAbout);
        }
    }
   
}
