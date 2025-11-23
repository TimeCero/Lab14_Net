using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab11.Domain.Interfaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> Repository<T>() where T : class;
        Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    }
}