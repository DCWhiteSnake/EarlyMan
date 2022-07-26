using EarlyMan.DL.Data;
using EarlyMan.DL.Entities;

namespace EarlyMan.DL.Services
{
    public interface IProductRepository
    {
        public ApplicationDbContext Context { get;}
        
        public IQueryable<Product> Products { get; } 

        Product GetProductById(Guid id);

        IEnumerable<Product> GetProducts();

        bool CheckAvailable(Guid ProductId);
    }
}