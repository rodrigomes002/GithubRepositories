namespace GithubReps.Domain.Reps.Interface
{
    public interface IPopularRepRepository
    {
        Task CreateAsync(PopularRep popularRep);
        Task<List<PopularRep>> GetAllAsync();
    }
}
