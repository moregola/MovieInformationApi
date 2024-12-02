using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Movie
    {
        public Guid Id { get { return _Id; } }
        private Guid _Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;
        public List<Actor> Actors { get; set; } = new List<Actor>();
    }
}
