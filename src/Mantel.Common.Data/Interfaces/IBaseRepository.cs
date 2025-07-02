using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mantel.Common.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(Guid id, T entity);
        Task DeleteAsync(T entity);
    }
}
