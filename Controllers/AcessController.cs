using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AcessController : ControllerBase
    {

        [HttpGet]
        [Authorize(Policy = "MinimumAge")]
        public IActionResult Get()
        {
            return Ok("Acesso permitido");
        }

    }
}
