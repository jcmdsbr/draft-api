using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.SQL.Repositories
{
    public class CustomerRepository : ICustomerRepository, IAsyncDisposable
    {
        private readonly CustomContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomerRepository(CustomContext context)
        {
            _context = context;
            _customers = context.Customers;
        }

        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        public async Task AddAsync(Customer obj, CancellationToken cancellationToken)
        {
            await _customers.AddAsync(obj, cancellationToken);
        }

        public async Task<List<Customer>> FindAsync(CancellationToken cancellationToken)
        {
            return await _customers.AsNoTracking().ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(Customer obj, CancellationToken cancellationToken)
        {
            _customers.Update(obj);
            return Task.CompletedTask;
        }

        public async Task<Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _customers.FindAsync(new object[] {id}, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var customer = await GetByIdAsync(id, cancellationToken);
            _customers.Remove(customer);
            await Task.CompletedTask;
        }

        public async Task<Customer> GetByDocumentAsync(string document, CancellationToken cancellationToken)
        {
            return await _customers.SingleOrDefaultAsync(x => x.Document.Equals(document), cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}