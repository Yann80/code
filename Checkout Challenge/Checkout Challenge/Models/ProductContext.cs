using Microsoft.EntityFrameworkCore;

namespace Checkout.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options) { }

        public DbSet<ProductDetails> ProductDetails { get; set; }
    }
}
