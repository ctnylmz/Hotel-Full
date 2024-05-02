using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;
using WebApp.Areas.Admin.Models;
using WebApp.Models;

namespace WebApp.Areas.Admin.Components.Dashboard
{
    public class _DashboardLastBookingPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardLastBookingPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7199/api/Booking/GetList");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BookingViewModel>>(JObject.Parse(jsonData)["data"].ToString());

                var lastFourBooking = values.Skip(Math.Max(0, values.Count - 6)).ToList();

                return View(lastFourBooking);
            }

            return View();

        }
    }
   
}
