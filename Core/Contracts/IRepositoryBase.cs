using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Contracts
{
    public interface IRepositoryBase<T> where T : IEntityBase
    {
        Task AddAsync(T obj, CancellationToken cancellationToken);
        Task<List<T>> FindAsync(CancellationToken cancellationToken);
        Task UpdateAsync(T obj, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}