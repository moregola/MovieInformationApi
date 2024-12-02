using Domain.Entity;
using Infra.BuildConfig;
using Infra.Repository.Interface;

namespace Infra.Repository.Implementation
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;
        public ActorRepository(ApplicationDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            _context = dbContext;
        }
        public async Task<ActorEntity> AddAsync(ActorEntity entity)
        {
            var addActor = await _context.Actors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return addActor.Entity;
        }

        public async Task<bool> DeleteAsync(ActorEntity entity)
        {
            _context.Actors.Remove(entity);
            var track = _context.Entry(entity);
            track.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ActorEntity>> GetAllAsync(int? pageSize, int? page)
        {
            return _context.Actors.Skip(page ?? 0).Take(pageSize ?? 10);
        }

        public async Task<ActorEntity> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<ActorEntity>(id) ?? throw new Exception("Invalid ID Actor not found");
        }

        public async Task<bool> UpdateAsync(ActorEntity entity)
        {
            _context.Actors.Remove(entity);
            var track = _context.Entry(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
