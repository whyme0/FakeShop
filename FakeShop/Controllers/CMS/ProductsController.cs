using Microsoft.AspNetCore.Mvc;
using FakeShop.Models;

namespace FakeShop.Controllers.CMS
{
    [Route("[controller]/products/")]
    public partial class CmsController : Controller
    {

        [Route("")]
        public IActionResult List()
        {
            throw new NotImplementedException();
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
