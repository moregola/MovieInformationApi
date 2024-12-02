using Domain.Model;

namespace Application.Service.Interface
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(int? pageSize, int? page);
        Task<bool> AddAsync(T modelT);
        Task<bool> UpdateAsync(T modelT);
        Task<bool> DeleteAsync(Guid id);
    }
}
