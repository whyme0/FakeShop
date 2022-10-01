using Microsoft.AspNetCore.Mvc;
using FakeShop.Models;
using FakeShop.Repositories;

namespace FakeShop.Controllers.CMS
{
    [Route("cms/products/")]
    public partial class ProductController : Controller
    {
        private readonly ILogger _logger;
        private readonly ProductRepository _productRepository;

        public ProductController(ILogger logger, ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [Route("")]
        public IActionResult List()
        {
            return Content("Hello");
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create(Product p)
        {
            throw new NotImplementedException();
        }

        [Route("edit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            throw new NotImplementedException();
        }

        [Route("edit/{id:int}")]
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            throw new NotImplementedException();
        }

        [Route("delete/{id:int}")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
