namespace GithubReps.Domain.Filters
{
    public class PopularRepFilter : BaseFilter
    {
        public List<int> IdsRep { get; set; } = new List<int>();
        public List<string> Languages { get; set; } = new List<string>();
    }
}
