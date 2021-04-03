using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Contracts;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("/api/v1/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _repository.FindAsync(cancellationToken));
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetByIdAsync(productId, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product, CancellationToken cancellationToken)
        {
            await _repository.AddAsync(product, cancellationToken);
            return Created($"api/v1/products/{product.Id}", product);
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> Put([FromRoute] Guid productId, [FromBody] Product product,
            CancellationToken cancellationToken)
        {
            product.Id = productId;
            await _repository.UpdateAsync(product, cancellationToken);
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid productId, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(productId, cancellationToken);
            return NoContent();
        }
    }
}