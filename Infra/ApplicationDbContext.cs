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
           .UsingEntity<Dictionary<string, object>>(
               "ActorMovies",
               j => j
                   .HasOne<MovieEntity>()
                   .WithMany()
                   .HasForeignKey("MovieId"),
               j => j
                   .HasOne<ActorEntity>()
                   .WithMany()
                   .HasForeignKey("ActorId"))
           .Property<DateTime>("CreateDate")
           .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<MovieEntity>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .UsingEntity<Dictionary<string, object>>(
               "ActorMovies",
               j => j
                   .HasOne<ActorEntity>()
                   .WithMany()
                   .HasForeignKey("MovieId"),
               j => j
                   .HasOne<MovieEntity>()
                   .WithMany()
                   .HasForeignKey("ActorId"))
                .Property<DateTime>("CreateDate")
                .HasDefaultValue(DateTime.Now);
            
            modelBuilder.Entity<MovieRatingEntity>()
                .Property(a => a.CreateDate)
                .HasDefaultValue(DateTime.Now);

            base.OnModelCreating(modelBuilder);
        }
        #endregion

    }
}