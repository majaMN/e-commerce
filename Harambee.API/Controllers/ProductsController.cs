using Harambee.Core;
using Harambee.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Harambee.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IHarambeeApplication _application;

        public ProductsController(IHarambeeApplication application)
        {
            _application = application;
        }

        /// <summary>
        /// Load all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<Customer>> GetAllProducts()
        {
            var products = await _application.GetAllProducts();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);

        }

        ///// <summary>
        ///// save product details
        ///// </summary>
        ///// <param name="product"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<ActionResult> AddProduct(Product product)
        //{
        //    var saveResult = await _application.AddProduct(product);
        //    if (saveResult.Item1 == false)
        //    {
        //        return BadRequest(saveResult.Item2);
        //    }
        //    return Ok(product);
        
    }
}
