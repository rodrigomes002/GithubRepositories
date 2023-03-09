using GithubReps.Application.Services;
using Quartz;

namespace GithubReps.API.Jobs
{
    [DisallowConcurrentExecution]
    public class JobGithub : IJob
    {
        private readonly ILogger<JobGithub> logger;
        private readonly GithubService githubService;
        public JobGithub(ILogger<JobGithub> logger, GithubService githubService)
        {
            this.logger = logger;
            this.githubService = githubService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            logger.LogInformation($"Iniciando rotina de busca de repositórios populares do github.");

            var languages = new List<string>() { "JavaScript", "Java", "csharp", "c", "python" };

            this.githubService.GetRepositoriesMostPopularByLanguage(languages);

            logger.LogInformation($"Iniciando rotina de busca de repositórios populares do github.");

            return Task.CompletedTask;
        }
    }
}
