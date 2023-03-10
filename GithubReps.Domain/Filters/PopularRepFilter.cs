namespace GithubReps.Domain.Filters
{
    public class PopularRepFilter : BaseFilter
    {
        public List<int> IdsRep { get; set; } = new List<int>();
    }
}
