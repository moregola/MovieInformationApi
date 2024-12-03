namespace Domain.Model
{
    public class Movie
    {
        public Movie(Guid id)
        {
            _Id = id;
        }

        public Guid Id { get { return _Id; } }
        private Guid _Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public MovieRating MovieRating { get; set; }
    }
}
