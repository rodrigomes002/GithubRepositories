namespace GithubRepositories.API.Models
{
    public class RepositoriesResponse
    {
        public int total_count { get; set; }
        public List<RepositoriesItem> items { get; set; }
    }
}
