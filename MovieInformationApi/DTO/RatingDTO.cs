namespace MovieInformationApi.DTO
{
    public class RatingDTO
    {
        public Guid Id { get; set; } = Guid.Empty;
        public Guid MovieId { get; set; }
        public float Rating { get; set; }
    }
}
