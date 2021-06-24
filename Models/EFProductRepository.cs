using System.Linq;

namespace EarlyMan.Models
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext cxt)
            => context = cxt;

        public IQueryable<Product> Products
            => context.Products;
    }
}