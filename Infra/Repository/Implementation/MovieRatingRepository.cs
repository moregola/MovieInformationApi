using Domain.Entity;
using Domain.Model;
using Infra.BuildConfig;
using Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Implementation
{
    internal class MovieRatingRepository : IMovieRatingRepository
    {
        private readonly ApplicationDbContext _context;
        public MovieRatingRepository(ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            _context = dbContext;
        }
        public async Task<MovieRatingEntity> AddAsync(MovieRatingEntity entity)
        {
            var addRating = await _context.MovieRatings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addRating.Entity;
        }

        public async Task<bool> DeleteAsync(MovieRatingEntity entity)
        {
            _context.MovieRatings.Remove(entity);
            var track = _context.Entry(entity);
            track.State = EntityState.Deleted;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<MovieRatingEntity>> GetAllAsync(int? pageSize, int? page)
        {
            return _context.MovieRatings.Skip(page ?? 0).Take(pageSize ?? 10);
        }

        public async Task<MovieRatingEntity> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<MovieRatingEntity>(id) 
                ?? throw new Exception("Invalid ID: Rating not found");
        }

        public async Task<MovieRatingEntity> GetByMovieId(Guid movieId)
        {
            return await _context.MovieRatings.FirstOrDefaultAsync(mr => mr.MovieId == movieId) 
                ?? throw new Exception("Invalid MovieID: Rating not found");
        }

        public async Task<bool> UpdateAsync(MovieRatingEntity entity)
        {
            _context.MovieRatings.Update(entity);
            var track = _context.Entry(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
