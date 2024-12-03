namespace MovieInformationApi.DTO
{
    public class MovieDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public RatingDTO MovieRating { get; set; }
        public string Photo { get; set; } = string.Empty;
    }
}