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

        public ProductController(ILogger<ProductController> logger, ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [Route("")]
        public async Task<IActionResult> List()
        {
            return View("../Cms/ProductsList", await _productRepository.GetAll());
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View("../Cms/ProductCreate");
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(Product p)
        {
            if (!ModelState.IsValid)
            {
                return View("../Cms/ProductCreate", p);
            }

            await _productRepository.Insert(p);
            await _productRepository.DbContext.SaveChangesAsync();
            return Content($"Product \"{p.Name}\" created");
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
