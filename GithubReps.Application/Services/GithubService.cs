using GithubReps.Application.DTOs;
using GithubReps.Domain;
using GithubReps.Domain.Filters;
using GithubReps.Domain.Reps;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GithubReps.Application.Services
{
    public class GithubService
    {
        private readonly ILogger<GithubService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public GithubService(ILogger<GithubService> logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        private async Task<List<RepositoriesItemDTO>> GetRepositoriesMostPopularByLanguage(List<string> languages)
        {
            var items = new List<RepositoriesItemDTO>();
            foreach (var language in languages)
            {
                var url = $"https://api.github.com/search/repositories?q=language:{language}&sort=stars";
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("User-Agent", "request");

                var result = await httpClient.GetAsync(url);

                string content = await result.Content.ReadAsStringAsync();

                var repositories = JsonConvert.DeserializeObject<RepositoriesResponseDTO>(content);
                items.AddRange(repositories.items.OrderByDescending(r => r.stargazers_count).Take(30));
            }

            return items;
        }

        public async Task CreateRepositoriesMostPopularByLanguage()
        {
            try
            {
                this._logger.LogInformation("Buscando dados dos repositórios no github");
                var items = await this.GetRepositoriesMostPopularByLanguage(new List<string>() { "JavaScript", "Java", "csharp", "c", "python" });
                var ids = items.Select(i => i.id).Distinct().ToList();
                var reps = await _unitOfWork.PopularRepRepository.GetRepositoriesByFilterAsync(new PopularRepFilter() { AllContent = true, IdsRep = ids });

                foreach (var item in items)
                {
                    if (reps.Any(r => r.IdRep == item.id))
                        continue;

                    var popuparRep = new PopularRep(item.id, item.name, item.full_name, item.description, item.stargazers_count, item.html_url, item.language);

                    this._logger.LogInformation("Cadastrando repositório...");
                    await this._unitOfWork.PopularRepRepository.CreateAsync(popuparRep);
                    await this._unitOfWork.CommitAsync();
                }

            }
            catch (Exception e)
            {
                this._logger.LogError(e.ToString());
                await this._unitOfWork.DisposeAsync();
                throw;
            }
        }
    }
}

