using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P06.DotNetCoreMVC.WebApiDemo.Extensions;
using P06.DotNetCoreMVC.WebApiDemo.Models;

namespace P06.DotNetCoreMVC.WebApiDemo.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;

            if (_context.Products.Any()) return;

            ProductSeed.InitData(context);
        }


        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Product>> GetProducts()
        {
            var result = _context.Products as IQueryable<Product>;

            return Ok(result.OrderBy(p => p.ProductNumber));
        }



    }
}
