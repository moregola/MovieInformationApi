using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Actor
    {
        public Actor(Guid id)
        {
            _Id = id;
        }

        public Guid Id { get { return _Id; } }
        private Guid _Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public int Age { get; set; }
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = new List<Movie>();

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }

        public void RemoveMovie(Movie movie)
        {
            Movies.Remove(movie);
        }

        public void CalculateAge()
        {
            Age = (DateTime.Now.Year - BirthDate.Year) 
                + (DateTime.Now.Month - BirthDate.Month > 0 ? 0 : -1);
        }
    }
}
