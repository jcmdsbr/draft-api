using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Entities;
using MongoDB.Driver;

namespace Infra.NoSQL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _collection;

        public ProductRepository(IMongoCollection<Product> collection)
        {
            _collection = collection;
        }

        public async Task AddAsync(Product obj, CancellationToken cancellationToken)
        {
            await _collection.InsertOneAsync(obj, cancellationToken: cancellationToken);
        }

        public async Task<List<Product>> FindAsync(CancellationToken cancellationToken)
        {
            return await _collection.Find(_ => true).ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(Product obj, CancellationToken cancellationToken)
        {
            await _collection.ReplaceOneAsync(x => x.Id == obj.Id, obj, cancellationToken: cancellationToken);
        }

        public async Task<Product> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _collection.Find(Builders<Product>.Filter.Eq(x => x.Id, id))
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _collection.DeleteOneAsync(x => x.Id == id, cancellationToken);
        }
    }
}