using GithubReps.Domain.Filters;
using GithubReps.Domain.Reps;
using GithubReps.Domain.Reps.Interface;
using GithubReps.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GithubReps.Infra.PopularReps
{
    public class PopularRepRepository : IPopularRepRepository
    {
        private readonly ApplicationContext _context;

        public PopularRepRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task CreateAsync(PopularRep popularRep)
        {
            await this._context.PopularRep.AddAsync(popularRep);
        }

        public async Task<List<PopularRep>> GetRepositoriesByFilterAsync(PopularRepFilter filter)
        {
            var query = this._context.PopularRep.AsQueryable();

            if (filter.IdsRep.Any())
                query = query.Where(q => filter.IdsRep.Contains(q.IdRep));

            if (filter.Languages.Any())
                query = query.Where(q => filter.Languages.Contains(q.Language));
            
            if (!filter.AllContent)
                query = query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);

            return await query.OrderByDescending(q=> q.Stars).ToListAsync();
        }
    }
}
