using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZWebApiJWT.Models;

namespace ZWebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        [HttpGet("[action]")]
        public IActionResult Everyone()
        {
            return Ok(new CreateToken().TokenCreate());
        }

        [HttpGet("[action]")]
        public IActionResult Admin()
        {
            return Ok(new CreateToken().TokenCreateAdmin());
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public IActionResult AdminToLogin()
        {
            return Ok("Admin Hoşgeldiniz");
        }
    }
}
