using Application.Service.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Model;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;

namespace Application.Service.Implementation
{
    internal class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }
        public async Task<Movie> AddAsync(Movie actor)
        {
            var entity = _mapper.Map<MovieEntity>(actor);
            var response = await _movieRepository.AddAsync(entity);
            return _mapper.Map<Movie>(response);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _movieRepository.GetByIdAsync(id);
            return await _movieRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync(int? pageSize, int? page)
        {
            var models = await _movieRepository.GetAllAsync(pageSize, page);
            return models.Select(model => _mapper.Map<Movie>(model));
        }

        public async Task<Movie> GetAsync(Guid id)
        {
            var entity = await _movieRepository.GetByIdAsync(id);
            return _mapper.Map<Movie>(entity);
        }

        public async Task<bool> UpdateAsync(Movie actor)
        {
            var entity = _mapper.Map<MovieEntity>(actor);
            return await _movieRepository.UpdateAsync(entity);
        }
    }
}
