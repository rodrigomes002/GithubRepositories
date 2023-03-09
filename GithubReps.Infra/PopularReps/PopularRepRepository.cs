using GithubReps.Domain.Reps;
using GithubReps.Domain.Reps.Interface;
using GithubReps.Infra.Context;

namespace GithubReps.Infra.PopularReps
{
    public class PopularRepRepository : IPopularRepRepository
    {
        private readonly ApplicationContext _context;

        public PopularRepRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public Task CreateAsync(PopularRep popularRep)
        {
            throw new NotImplementedException();
        }

        public Task<List<PopularRep>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
