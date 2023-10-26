using Microsoft.AspNetCore.Mvc;

namespace Student.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController: ControllerBase
    {
        private ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }


        [HttpGet()]
        public IActionResult GetSample()
        {
            _logger.LogInformation("I am getting a sample");
            return Ok("Here is your sample");
        }
    }
}