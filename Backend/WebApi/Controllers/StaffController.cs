using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        [HttpPost("Add")]
        public IActionResult Add()
        {
            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpPost("Update")]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            return Ok();
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get()
        {
            return Ok();
        }


    }
}
