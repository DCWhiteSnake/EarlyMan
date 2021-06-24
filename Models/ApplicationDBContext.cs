using Microsoft.EntityFrameworkCore;

namespace EarlyMan.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options) { }
    }
}