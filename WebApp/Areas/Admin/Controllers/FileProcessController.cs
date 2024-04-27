using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shareds.Utilities.Results;
using System.Net.Http.Headers;
using System.Text;
using WebApp.Areas.Admin.Models;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileProcessController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public FileProcessController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {

            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent,"file",file.FileName);
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.PostAsync("https://localhost:7199/api/FileProcess/Add", multipartFormDataContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            return View();
        }





    }
}
