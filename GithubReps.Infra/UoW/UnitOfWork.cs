using GithubReps.Domain;
using GithubReps.Domain.Reps.Interface;
using GithubReps.Infra.Context;
using GithubReps.Infra.PopularReps;

namespace GithubReps.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public IPopularRepRepository PopularRepRepository { get; }

        public UnitOfWork(ApplicationContext context)
        {
            this._context = context;
            this.PopularRepRepository = new PopularRepRepository(context);
        }

        public async Task CommitAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await this._context.DisposeAsync();
        }
    }
}
