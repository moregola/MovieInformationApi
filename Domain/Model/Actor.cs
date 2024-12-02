using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Actor
    {
        public Guid Id { get { return _Id; } }
        private Guid _Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public Actor(Guid id)
        {
            _Id = id;
        }
    }
}
