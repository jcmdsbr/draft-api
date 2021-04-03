using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApi.Controllers
{
    [ApiController]
    [Route("/api/v1/customers")]
    public class ProductController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public ProductController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _repository.FindAsync(cancellationToken));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid customerId, CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetByIdAsync(customerId, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(customer, cancellationToken);
            return Created($"api/v1/products/{customer.Id}", customer);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> Put([FromRoute] Guid customerId, [FromBody] Customer customer,
            CancellationToken cancellationToken)
        {
            customer.Id = customerId;
            await _repository.UpdateAsync(customer, cancellationToken);
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid customerId, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(customerId, cancellationToken);
            return NoContent();
        }
    }
}