using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApp.Areas.Admin.Models;
using WebApp.Models;

namespace WebApp.Components.Default
{
    public class _SubscribePartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _SubscribePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(SubscribeViewModel subscribe)
        {
          
            return View();
        }

    }
}
