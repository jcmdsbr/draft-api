using System.Collections.Generic;
using Core.Contracts;
using Core.Entities;

namespace Infra.SQL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        // TODO implementar métodos do EF core / DbContext


        public void Add(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Customer GetById(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetByDocument(string document)
        {
            throw new System.NotImplementedException();
        }
    }
}