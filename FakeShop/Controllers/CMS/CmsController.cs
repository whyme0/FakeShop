using Microsoft.AspNetCore.Mvc;

namespace FakeShop.Controllers
{
    public partial class CmsController : Controller
    {
        private readonly ILogger _logger;
        
        public CmsController(ILogger logger)
        {
            _logger = logger;
        }

        [Route("cms")]
        public IActionResult Home()
        {
            return View();
        }
    }
}
