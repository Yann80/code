using Checkout.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductDetailsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/ProductDetails
        [HttpGet]
        public IEnumerable<ProductDetails> GetProductDetails()
        {
            return _context.ProductDetails;
        }

        // DELETE: api/ProductDetails
        [HttpDelete]
        public async Task<IActionResult> ClearProductDetails()
        {
            var all = from c in _context.ProductDetails select c;
            _context.ProductDetails.RemoveRange(all);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/ProductDetails
        [HttpPost]
        public async Task<IActionResult> PostProductDetails([FromBody] Guid productID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ProductDetails productList = new ProductDetails();
            var productDetails = productList.GetProductList().First(e => e.ProductID == productID);

            _context.ProductDetails.Add(productDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductDetails", new { id = productDetails.ProductID }, productDetails);
        }

        // DELETE: api/ProductDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetails([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productDetails = await _context.ProductDetails.FindAsync(id);
            if (productDetails == null)
            {
                return NotFound();
            }

            _context.ProductDetails.Remove(productDetails);
            await _context.SaveChangesAsync();

            return Ok(productDetails);
        }
    }
}