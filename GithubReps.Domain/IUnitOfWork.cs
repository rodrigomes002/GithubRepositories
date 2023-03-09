using GithubReps.Domain.Reps.Interface;

namespace GithubReps.Domain
{
    public interface IUnitOfWork
    {
        IPopularRepRepository PopularRepRepository { get; }
        Task CommitAsync();
        Task DisposeAsync();
    }
}
