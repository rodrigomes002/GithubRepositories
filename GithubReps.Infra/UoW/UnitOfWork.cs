using GithubReps.Domain;
using GithubReps.Domain.Reps.Interface;
using GithubReps.Infra.Context;
using GithubReps.Infra.PopularReps;

namespace GithubReps.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext applicationContext;
        public IPopularRepRepository PopularRepRepository { get; }

        public UnitOfWork(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
            this.PopularRepRepository = new PopularRepRepository(applicationContext);
        }

        public async Task CommitAsync()
        {
            await this.applicationContext.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await this.applicationContext.DisposeAsync();
        }
    }
}
