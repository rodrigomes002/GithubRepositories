using GithubReps.Application.DTOs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GithubReps.Application.Services
{
    public class GithubService
    {
        private readonly ILogger<GithubService> logger;
        public GithubService(ILogger<GithubService> logger)
        {
            this.logger = logger;
        }

        public void GetRepositoriesMostPopularByLanguage(List<string> languages)
        {
            //var url = "https://api.github.com/search/repositories?q=language:JavaScript&sort=stars";
            //var url = "https://api.github.com/search/repositories?q=stars:%3E1&sort=stars";

            var items = new List<RepositoriesItemDTO>();

            //foreach (var language in languages)
            //{
            var url = $"https://api.github.com/search/repositories?q=language:{languages[0]}&sort=stars";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "request");

            var result = httpClient.GetAsync(url).Result;

            string content = result.Content.ReadAsStringAsync().Result;
            var repositories = JsonConvert.DeserializeObject<RepositoriesResponseDTO>(content);
            items.AddRange(repositories.items.OrderByDescending(r => r.stargazers_count).Take(10));
        }

    }
}
