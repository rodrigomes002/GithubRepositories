
using GithubReps.Application.Services;
using GithubReps.Domain.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GithubReps.API.Controllers
{
    [ApiController]
    [Route("api/v1/repositories")]
    public class RepositoriesController : ControllerBase
    {
        private readonly ILogger<RepositoriesController> _logger;
        private readonly RepositoriesService _repositoriesService;

        public RepositoriesController(ILogger<RepositoriesController> logger, RepositoriesService repositoriesService)
        {
            this._logger = logger;
            this._repositoriesService = repositoriesService;
        }

        [HttpPost]
        public async Task<IActionResult> GetRepositoriesByFilter(PopularRepFilter filter)
        {
            return Ok(await this._repositoriesService.GetRepositoriesByFilterAsync(filter));
        }
    }
}