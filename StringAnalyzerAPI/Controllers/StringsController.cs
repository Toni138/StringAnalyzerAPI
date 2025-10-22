using Microsoft.AspNetCore.Mvc;

namespace StringAnalyzerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StringsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from String Analyzer API 👋");
        }
    }
}
