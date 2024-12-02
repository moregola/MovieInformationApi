using Domain.Entity;
using Domain.Model;

namespace Infra.Repository.Interface
{
    public interface IMovieRatingRepository : IBaseRepository<MovieRatingEntity>
    {
        Task<MovieRatingEntity> GetByMovieId(Guid MovieId);
    }
}
