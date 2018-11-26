using Checkout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Checkout
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ProductDetails[] ProductList { get; set; }

        public void OnGet()
        {
            ProductDetails productDetails = new ProductDetails();

            ProductList = productDetails.GetProductList();
        }
    }
}