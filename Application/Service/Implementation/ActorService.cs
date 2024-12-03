using Application.Service.Interface;
using AutoMapper;
using Domain.Entity;
using Domain.Model;
using Infra.Repository.Interface;

namespace Application.Service.Implementation
{
    internal class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorService(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<Actor> AddAsync(Actor actor)
        {
            var entity = _mapper.Map<ActorEntity>(actor);
            var response = await _actorRepository.AddAsync(entity);
            return _mapper.Map<Actor>(response);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _actorRepository.GetByIdAsync(id);
            return await _actorRepository.DeleteAsync(entity);  
        }

        public async Task<IEnumerable<Actor>> GetAllAsync(int? pageSize, int? page)
        {
            var models = await _actorRepository.GetAllAsync(pageSize, page);
            return models.Select(model => _mapper.Map<Actor>(model));
        }

        public async Task<Actor> GetAsync(Guid id)
        {
            var entity = await _actorRepository.GetByIdAsync(id);
            return _mapper.Map<Actor>(entity);
        }

        public async Task<bool> UpdateAsync(Actor actor)
        {
            var entity = _mapper.Map<ActorEntity>(actor);
            return await _actorRepository.UpdateAsync(entity);
        }
    }
}
