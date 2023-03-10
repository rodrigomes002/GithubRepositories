using GithubReps.Domain;
using GithubReps.Domain.Filters;
using GithubReps.Domain.Reps;

namespace GithubReps.Application.Services
{
    public class RepositoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RepositoriesService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<PopularRep>> GetRepositoriesByFilterAsync(PopularRepFilter filter)
        {
            return await this._unitOfWork.PopularRepRepository.GetRepositoriesByFilterAsync(filter);
        }

        public async Task<List<PopularRep>> GetAllAsync()
        {
            return await this._unitOfWork.PopularRepRepository.GetAllAsync();
        }
    }
}
