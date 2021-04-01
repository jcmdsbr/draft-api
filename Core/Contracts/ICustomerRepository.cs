using Core.Entities;

namespace Core.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Customer GetByDocument(string document);
    }
}