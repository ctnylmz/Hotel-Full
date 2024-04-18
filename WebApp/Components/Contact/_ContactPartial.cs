using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Components.Contact
{
    public class _ContactPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ContactPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
