namespace GithubReps.Application.DTOs
{
    public class RepositoriesResponseDTO
    {
        public int total_count { get; set; }
        public List<RepositoriesItemDTO> items { get; set; }
    }
}
