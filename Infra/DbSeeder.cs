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
            var movies = new List<MovieEntity>()
            {
                new MovieEntity
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
                            Country = "Estados Unidos"
                        },
                        new ActorEntity
                        {
                            Name = "Matt Damon",
                            Nationality = "Americano",
                            BirthDate = new DateTime(1970, 10, 08),
                            City = "Boston",
                            State = "Massachusetts",
                            Country = "Estados Unidos"
                        }
                    }
                },
                new MovieEntity
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
                            Country = "Estados Unidos"
                        },
                        new ActorEntity
                        {
                            Name = "Ian McKellen",
                            Nationality = "Britânico",
                            BirthDate = new DateTime(1939, 05, 25),
                            City = "Burnley",
                            State = "Lancashire",
                            Country = "Reino Unido"
                        }
                    }
                },
            };

            // Add movies to the database context
            _context.Movies.AddRange(movies);

            // Save changes to the database
            _context.SaveChanges();
        }
    }
}
