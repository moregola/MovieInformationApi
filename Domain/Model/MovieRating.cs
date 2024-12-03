using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class MovieRating
    {
        public Guid Id { get { return _Id; } }
        private Guid _Id { get; set; } = Guid.NewGuid();
        public Guid MovieId { get; set; } = Guid.Empty;
        public float Rating {  get; set; }
        public MovieRating(Guid id)
        {
            _Id = id;
        }
    }
}
