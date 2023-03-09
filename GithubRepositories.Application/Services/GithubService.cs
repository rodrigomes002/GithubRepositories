using GithubRepositories.Domain;

namespace GithubRepositories.Application.Services
{
    public class GithubService
    {
        private readonly IUnitOfWork unitOfWork;
        public GithubService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
       

    }
}
