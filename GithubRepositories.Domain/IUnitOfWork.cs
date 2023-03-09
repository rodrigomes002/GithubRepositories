using GithubRepositories.Domain.Reps.Interface;

namespace GithubRepositories.Domain
{
    public interface IUnitOfWork
    {
        IPopularRepRepository PopularRepRepository { get; }
        Task CommitAsync();
        Task DisposeAsync();
    }
}
