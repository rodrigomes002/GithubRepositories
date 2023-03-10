namespace GithubReps.Application.DTOs
{

    public class RepositoriesItemDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string description { get; set; }
        public string html_url { get; set; }
        public int stargazers_count { get; set; }
        public string language { get; set; }

    }
}
