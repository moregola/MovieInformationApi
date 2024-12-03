using Application.Service.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Model;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Implementation
{
    internal class MovieRatingService : IMovieRatingService
    {
        private readonly IMovieRatingRepository _movieRatingRepository;
        private readonly IMapper _mapper;
        public MovieRatingService(IMovieRatingRepository movieRatingRepository, IMapper mapper)
        {
            _movieRatingRepository = movieRatingRepository;
            _mapper = mapper;
        }

        public async Task<MovieRating> AddAsync(MovieRating modelT)
        {
            var entity = _mapper.Map<MovieRatingEntity>(modelT);
            var response = await _movieRatingRepository.AddAsync(entity);
            return  _mapper.Map<MovieRating>(response);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _movieRatingRepository.GetByIdAsync(id);
            return await _movieRatingRepository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<MovieRating>> GetAllAsync(int? pageSize, int? page)
        {
            var models = await _movieRatingRepository.GetAllAsync(pageSize, page);
            return models.Select(model => _mapper.Map<MovieRating>(model));
        }

        public async Task<MovieRating> GetAsync(Guid id)
        {
            var entity = await _movieRatingRepository.GetByIdAsync(id);
            return _mapper.Map<MovieRating>(entity);
        }

        public async Task<MovieRating> GetByMovieId(Guid MovieId)
        {
            var entity = await _movieRatingRepository.GetByMovieId(MovieId);
            return _mapper.Map<MovieRating>(entity);
        }

        public async Task<bool> UpdateAsync(MovieRating modelT)
        {
            var entity = _mapper.Map<MovieRatingEntity>(modelT);
            return await _movieRatingRepository.UpdateAsync(entity);
        }
    }
}
