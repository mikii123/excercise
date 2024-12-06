namespace MovieBE.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Movie()
        { }

        public Movie(Guid guid, string title, string description, DateTime releaseDate)
        {
            ReleaseDate = releaseDate;
            Description = description;
            Title = title;
            Id = guid;
        }
    }
}
