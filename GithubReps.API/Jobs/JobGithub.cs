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

        public async Task Execute(IJobExecutionContext context)
        {
            logger.LogInformation($"Iniciando rotina de busca de repositórios populares do github.");

            await this.githubService.CreateRepositoriesMostPopularByLanguage();

            logger.LogInformation($"Rotina de busca de repositórios populares do github finalizada.");

            // return Task.CompletedTask;
        }
    }
}
