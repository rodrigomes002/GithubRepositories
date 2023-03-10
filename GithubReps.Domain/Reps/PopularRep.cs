namespace GithubReps.Domain.Reps
{
    public class PopularRep
    {
        public int Id { get; private set; }
        public int IdRep { get; private set; }
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public string Description { get; private set; }
        public int Stars { get; private set; }
        public string Url { get; private set; }
        public string Language { get; private set; }

        public PopularRep(int idRep, string name, string fullName, string description, int stars, string url, string language)
        {
            IdRep = idRep;
            Name = name;
            FullName = fullName;
            Description = description;
            Stars = stars;
            Url = url;
            Language = language;
        }
    }
}
