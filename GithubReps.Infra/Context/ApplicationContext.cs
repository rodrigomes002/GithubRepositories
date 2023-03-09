using GithubReps.Domain.Reps;
using Microsoft.EntityFrameworkCore;

namespace GithubReps.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<PopularRep>? PopularRep { get; set; }
    }
}
