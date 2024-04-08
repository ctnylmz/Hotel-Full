using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailerController : ControllerBase
    {
        private readonly ITrailerService _trailerService;

        public TrailerController(ITrailerService trailerService)
        {
            _trailerService = trailerService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Trailer trailer)
        {
            var result = _trailerService.Add(trailer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Trailer trailer)
        {
            var result = _trailerService.Delete(trailer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Trailer trailer)
        {
            var result = _trailerService.Update(trailer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var result = _trailerService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            var result = _trailerService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
