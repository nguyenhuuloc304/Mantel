using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mantel.Common.Data.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
#if NET6_0_OR_GREATER
        Task<T?> FindById(object id);
#else
        Task<T> FindById(object id);
#endif
        Task<IEnumerable<T>> FindAll();
        Task<T> Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        Task Save();
    }
}
