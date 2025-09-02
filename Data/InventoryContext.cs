using Microsoft.EntityFrameworkCore;
using InventoryPro.Models;

namespace InventoryPro.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
