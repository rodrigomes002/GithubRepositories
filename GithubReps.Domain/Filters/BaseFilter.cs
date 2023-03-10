namespace GithubReps.Domain.Filters
{
    public class BaseFilter
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool AllContent { get; set; } = false;
    }
}
