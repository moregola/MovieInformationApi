using System.ComponentModel.DataAnnotations;

namespace MovieInformationApi.DTO
{
    public class RatingDTO
    {
        public Guid Id { get; set; } = Guid.Empty;
        [Required]
        public Guid MovieId { get; set; }
        [Required]
        public float Rating { get; set; }
        public MovieDTO Movie { get; set; }
    }
}
