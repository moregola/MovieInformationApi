using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync(int? pageSize, int? page);
    }
}
