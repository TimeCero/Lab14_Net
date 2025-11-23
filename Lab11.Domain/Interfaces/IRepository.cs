using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Query();
        Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}