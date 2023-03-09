using GithubRepositories.API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GithubRepositories.API.Controllers
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
            var languages = new List<string>() { "JavaScript", "Java", "csharp", "c", "python" };

            //var url = "https://api.github.com/search/repositories?q=language:JavaScript&sort=stars";
            //var url = "https://api.github.com/search/repositories?q=stars:%3E1&sort=stars";

            var items = new List<RepositoriesItem>();

            //foreach (var language in languages)
            //{
                var url = $"https://api.github.com/search/repositories?q=language:{languages[0]}&sort=stars";
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "request");

                var result = httpClient.GetAsync(url).Result;

                string content = result.Content.ReadAsStringAsync().Result;
                var repositories = JsonConvert.DeserializeObject<RepositoriesResponse>(content);
                items.AddRange(repositories.items.OrderByDescending(r=> r.stargazers_count).Take(10));
            //}

            return Ok(items);
        }
    }
}