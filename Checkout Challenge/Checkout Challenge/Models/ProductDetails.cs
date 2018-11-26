using System;
using System.ComponentModel.DataAnnotations;

namespace Checkout.Models
{
    public class ProductDetails
    {
        [Key]
        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        // Returns a list of products
        public ProductDetails[] GetProductList()
        {
            ProductDetails[] Products = new ProductDetails[]{
            new ProductDetails() { ProductID = new Guid("784BD289-B4F0-45FB-A2FD-0E11BDFB5293"), ProductName = "Visual Studio"},
            new ProductDetails() { ProductID = new Guid("54034C8C-C481-45E1-93F9-49489F233108"),ProductName = "Windows 10"},
            new ProductDetails() { ProductID = new Guid("4A208ECC-3669-44D3-9D92-8E7FCE9F59F1"),ProductName = "SQL Server"} };

            return Products;
        }
    }
}
