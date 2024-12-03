using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class MovieEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public ICollection<ActorEntity> Actors { get; set; } = new List<ActorEntity>();
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public string Genre { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public MovieRatingEntity MovieRating { get; set; }

    }
}
