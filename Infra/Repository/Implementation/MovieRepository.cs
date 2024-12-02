using Domain.Entity;
using Infra.BuildConfig;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Implementation
{
    internal class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRepository(ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            _context = dbContext;
        }
        public async Task<MovieEntity> AddAsync(MovieEntity entity)
        {
            var addMovie = await _context.Movies.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addMovie.Entity;
        }

        public async Task<bool> DeleteAsync(MovieEntity entity)
        {
            _context.Movies.Remove(entity);
            var track = _context.Entry(entity);
            track.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<MovieEntity>> GetAllAsync(int? pageSize, int? page)
        {
            return _context.Movies.Skip(page ?? 0).Take(pageSize ?? 10);
        }

        public async Task<MovieEntity> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<MovieEntity>(id) ?? throw new Exception("Invalid ID Movie not found");
        }

        public async Task<bool> UpdateAsync(MovieEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
