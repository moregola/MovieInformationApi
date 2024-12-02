using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class MovieRatingEntity
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("MovieId")]
        public Guid MovieId { get; set; } = Guid.Empty;
        public MovieEntity Movie { get; set; } = new MovieEntity();
        public float Rating {  get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; } = DateTime.Now;
    }
}
