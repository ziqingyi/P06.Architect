using System;
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


        //[HttpGet]
        //[Route("")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public ActionResult<IQueryable<Product>> GetProducts()
        //{
        //    var result = _context.Products as IQueryable<Product>;

        //    return Ok(result.OrderBy(p => p.ProductNumber));
        //}


        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Product>> GetProducts([FromQuery] string department ,[FromQuery] ProductRequest request)
        {
            var result = _context.Products as IQueryable<Product>;
            
            if (!string.IsNullOrEmpty(department))
            {
                result = result.Where(p => p.Department.StartsWith(department,
                    StringComparison.InvariantCultureIgnoreCase));
            }
            
            Response.Headers["x-total-count"] = result.Count().ToString();

            return Ok(result
                .OrderBy(p => p.ProductNumber)
                .Skip(request.Offset)
                .Take(request.Limit));

        }















    }
}
