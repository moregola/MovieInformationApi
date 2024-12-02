using Domain.Model;

namespace Application.Service.Interface
{
    internal interface IBaseService<T> where T : class
    {
        Task<Actor> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(T actor);
        Task<bool> UpdateAsync(T actor);
        Task<bool> DeleteAsync(T actor);
    }
}
