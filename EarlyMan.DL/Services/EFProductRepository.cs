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

        public IEnumerable<Product> GetProducts(int pageNumber, int pageSize)
        {
            if (Products == null)
                throw new NullReferenceException("The product repository is empty");
            if (pageSize <= 0 || pageNumber <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            int skipCount = (pageNumber - 1) * pageSize;
            return Products.Skip(skipCount).Take(pageSize).ToList();
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