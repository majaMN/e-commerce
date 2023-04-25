using Harambee.Core;
using Harambee.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Harambee.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IHarambeeApplication _application;

        public CustomersController(IHarambeeApplication application)
        {
            _application = application;
        }


        /// <summary>
        /// Search customer by system generated ID
        /// </summary>
        /// <param name="id">Systen generated unique identifier <param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _application.GetCartTotal(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);

        }



        [HttpPost("{customerId}/add-to-cart")]
        public async Task<ActionResult> AddToCart(int customerId, [FromBody] int productId)
        {
            var saveResult = await _application.AddProductToBasket(customerId, productId);
            if (saveResult == false)
            {
                return BadRequest();
            }
            return Ok();
        }



        /// <summary>
        /// Get total price in a customer's cart
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("customers/{id}/basket-total")]
        public async Task<ActionResult<decimal>> GetCartTotal(int id)
        {
            var total = await _application.GetCartTotal(id);
            if (total == null)
            {
                return BadRequest();
            }
            return Ok(total);
        }

    }
}
