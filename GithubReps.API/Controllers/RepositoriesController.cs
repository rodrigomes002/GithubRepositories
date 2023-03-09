
using Microsoft.AspNetCore.Mvc;

namespace GithubReps.API.Controllers
{
    [ApiController]
    [Route("api/v1/repositories")]
    public class RepositoriesController : ControllerBase
    {
        private readonly ILogger<RepositoriesController> _logger;

        public RepositoriesController(ILogger<RepositoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}