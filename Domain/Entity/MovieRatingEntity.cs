using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class MovieRatingEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("MovieId")]
        public Guid MovieId { get; set; } = Guid.Empty;
        public float Rating {  get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
