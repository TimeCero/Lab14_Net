using Lab11.Domain.Interfaces;
using Lab11.Infrastructure.Models; // <- DbLab08Context & User entity lives here
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11.Infrastructure.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly DbLab08Context _db;
        private readonly DbSet<T> _dbSet;

        public EfRepository(DbLab08Context context)
        {
            _db = context;
            _dbSet = _db.Set<T>();
        }

        public IQueryable<T> Query() => _dbSet.AsQueryable();

        public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
            => await _dbSet.FindAsync(new[] { id }, cancellationToken);

        public void Add(T entity) => _dbSet.Add(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Remove(T entity) => _dbSet.Remove(entity);
    }
}