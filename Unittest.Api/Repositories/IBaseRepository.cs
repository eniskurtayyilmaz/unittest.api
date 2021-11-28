using System.Collections.Generic;
using System.Threading.Tasks;

namespace Unittest.Api.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(string id);
    }
}