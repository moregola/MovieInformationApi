using Domain.Model;

namespace Application.Service.Interface
{
    public interface IMovieRatingService : IBaseService<MovieRating>
    {
        Task<MovieRating> GetByMovieId(Guid MovieId);
    }
}
