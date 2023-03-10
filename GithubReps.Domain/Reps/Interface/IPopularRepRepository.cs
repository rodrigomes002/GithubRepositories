using GithubReps.Domain.Filters;

namespace GithubReps.Domain.Reps.Interface
{
    public interface IPopularRepRepository
    {
        Task CreateAsync(PopularRep popularRep);
        Task<List<PopularRep>> GetRepositoriesByFilterAsync(PopularRepFilter filter);
    }
}
