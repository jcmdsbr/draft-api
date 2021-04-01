using System.Net;
using Core.Contracts;
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
        public IActionResult Index()
        {
            return Ok(_repository.FindAll());
        }
    }
}