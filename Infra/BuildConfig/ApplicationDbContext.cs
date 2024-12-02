using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.BuildConfig
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ActorEntity> Actors { get; set; }
        
        public DbSet<MovieEntity> Movies { get; set; }
        
        public DbSet<MovieRatingEntity> MovieRatings { get; set; }

        #region CreateModel
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorEntity>()
                .HasMany(a => a.Movies)
                .WithMany(m => m.Actors)
                .UsingEntity(t => t.ToTable("ActorMovies"));

            modelBuilder.Entity<MovieEntity>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity(t => t.ToTable("ActorMovies"));

            modelBuilder.Entity<MovieRatingEntity>()
                .HasOne(m => m.Movie)
                .WithMany()
                .HasForeignKey(m => m.MovieId);

            base.OnModelCreating(modelBuilder);
        }
        #endregion

    }
}