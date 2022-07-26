using EarlyMan.DL.Data;
using EarlyMan.DL.Entities;

namespace EarlyMan.DL.Services
{
    public class EFProductRepository : IProductRepository
    {
        public ApplicationDbContext Context { get; }

        public EFProductRepository(ApplicationDbContext cxt)
            => Context = cxt;

        public IQueryable<Product> Products { get => Context.Products; }

        public Product GetProductById(Guid productId)
        {
            if (Products == null)
                throw new NullReferenceException("The product repository is empty");
            var productToReturn = Products.Where(x =>
            x.ProductId == productId).FirstOrDefault();
            
            if (productToReturn == null)
                throw new NullReferenceException($"Product with id:{productId}" +
                    "does not exist");
            return productToReturn;
        }

        public IEnumerable<Product> GetProducts()
        {
            if (Products == null)
                throw new NullReferenceException("The product repository is empty");
            return Products.ToList();
        }

        public bool CheckAvailable(Guid productId)
        {
            if (Products == null)
                throw new NullReferenceException("The product repository is empty");
            var result = Products.Where(prod => prod.ProductId == productId)
                 .FirstOrDefault();
            if (result == null)
                return false;

            return result.AvailableUnits > 0;
        }
    }
}