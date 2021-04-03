using System.Threading;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Task<Customer> GetByDocumentAsync(string document, CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
    }
}