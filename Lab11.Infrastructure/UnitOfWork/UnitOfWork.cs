using Lab11.Domain.Interfaces;
using Lab11.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbLab08Context _context;
        private readonly Dictionary<Type, object> _repos = new();

        public UnitOfWork(DbLab08Context context) => _context = context;

        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);
            if (!_repos.ContainsKey(type))
                _repos[type] = new Repositories.EfRepository<T>(_context);
            return (IRepository<T>)_repos[type]!;
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}