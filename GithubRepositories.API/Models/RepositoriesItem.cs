namespace GithubRepositories.API.Models
{
    public class RepositoriesItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public int stargazers_count { get; set; }
        public string language { get; set; }

    }
}
