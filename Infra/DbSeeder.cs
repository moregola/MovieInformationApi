using Domain.Entity;
using Infra.BuildConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
    public class DbSeeder
    {
        private readonly ApplicationDbContext _context;

        public DbSeeder(ApplicationDbContext context)
        {
            _context = context;
            Seed();
        }

        public void Seed()
        {
            // Check if any movies exist in the database
            if (_context.Movies.Any())
            {
                return; // Don't seed if data already exists
            }

            // Sample movie data
            var movie0 = new MovieEntity
            {
                Title = "O Resgate do Soldado Ryan",
                Genre = "Guerra",
                Director = "Steven Spielberg",
                Producer = "Mark Gordon",
                ReleaseDate = new DateTime(1998, 07, 24),
                Description = "Um grupo de soldados norte-americanos é enviado a uma missão perigosa para resgatar um paraquedista que está atrás das linhas inimigas.",
                MovieRating = new MovieRatingEntity { Rating = 8.6f },
                Actors = new List<ActorEntity>
                    {
                        new ActorEntity
                        {
                            Name = "Tom Hanks",
                            Nationality = "Americano",
                            BirthDate = new DateTime(1956, 07, 04),
                            City = "Concord",
                            State = "Califórnia",
                            Country = "Estados Unidos",
                            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fb/Tom_Hanks_2016.jpg/1024px-Tom_Hanks_2016.jpg"
                        },
                        new ActorEntity
                        {
                            Name = "Matt Damon",
                            Nationality = "Americano",
                            BirthDate = new DateTime(1970, 10, 08),
                            City = "Boston",
                            State = "Massachusetts",
                            Country = "Estados Unidos",
                            Photo = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/Matt_Damon_TIFF_2015.jpg/800px-Matt_Damon_TIFF_2015.jpg"
                        }
                    },
                Photo = "https://upload.wikimedia.org/wikipedia/pt/a/ac/Saving_Private_Ryan_poster.jpg"
            };
            var movie1 = new MovieEntity
            {
                Title = "O Senhor dos Anéis: A Sociedade do Anel",
                Genre = "Fantasia",
                Director = "Peter Jackson",
                Producer = "Peter Jackson",
                ReleaseDate = new DateTime(2001, 12, 19),
                Description = "Uma jornada épica para destruir o Um Anel e salvar a Terra Média.",
                MovieRating = new MovieRatingEntity { Rating = 8.8f },
                Actors = new List<ActorEntity>
                    {
                        new ActorEntity
                        {
                            Name = "Elijah Wood",
                            Nationality = "Americano",
                            BirthDate = new DateTime(1981, 01, 28),
                            City = "Cedar Rapids",
                            State = "Iowa",
                            Country = "Estados Unidos",
                            Photo = "https://upload.wikimedia.org/wikipedia/commons/c/c9/Elijah_Wood_%2847955397556%29_%28cropped%29.jpg"
                        },
                        new ActorEntity
                        {
                            Name = "Ian McKellen",
                            Nationality = "Britânico",
                            BirthDate = new DateTime(1939, 05, 25),
                            City = "Burnley",
                            State = "Lancashire",
                            Country = "Reino Unido",
                            Photo = "https://upload.wikimedia.org/wikipedia/commons/1/15/SDCC13_-_Ian_McKellen.jpg"
                        }
                    },
                Photo = "https://upload.wikimedia.org/wikipedia/pt/3/38/Lord_of_the_Rings_Fellowship_of_the_Ring.jpg"
            };
            // Add movies to the database context
            _context.Entry(movie0);
            _context.Entry(movie1);
            _context.Movies.AddAsync(movie0);
            _context.Movies.AddAsync(movie1);

            // Save changes to the database
            _context.SaveChanges();
        }
    }
}
