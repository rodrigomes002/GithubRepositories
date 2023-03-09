using GithubRepositories.API.Models;
using Newtonsoft.Json;
using Quartz;

namespace GithubRepositories.API.Jobs
{
    [DisallowConcurrentExecution]
    public class JobGithub : IJob
    {
        private readonly ILogger<JobGithub> logger;

        public JobGithub(ILogger<JobGithub> logger)
        {
            this.logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            logger.LogInformation($"Iniciando rotina de busca de repositórios populares do github.");

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
            items.AddRange(repositories.items.OrderByDescending(r => r.stargazers_count).Take(10));

            logger.LogInformation($"Iniciando rotina de busca de repositórios populares do github.");

            return Task.CompletedTask;
        }
    }
}
