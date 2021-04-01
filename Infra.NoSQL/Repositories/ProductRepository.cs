using System.Collections.Generic;
using Core.Contracts;
using Core.Entities;

namespace Infra.NoSQL.Repositories
{
    public class ProductRepository :  IProductRepository
    {
        //TODO implementar crud no mongodb


        public void Add(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public Product GetById(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> FindAll()
        {
            throw new System.NotImplementedException();
        }
    }
}