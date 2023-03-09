using GithubRepositories.Domain.Reps;
using Microsoft.EntityFrameworkCore;

namespace GithubRepositories.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<PopularRep>? PopularRep { get; set; }
    }
}
