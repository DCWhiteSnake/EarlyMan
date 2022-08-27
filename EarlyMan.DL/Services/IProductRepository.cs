using EarlyMan.DL.Data;
using EarlyMan.DL.Entities;

namespace EarlyMan.DL.Services
{
    public interface IProductRepository
    {     
        public IQueryable<Product> Products { get; } 

        Product GetProductById(Guid id);

        IEnumerable<Product> GetProducts(int pageNumber, int pageSize, string filter);

        bool CheckAvailable(Guid ProductId);
        int Size();
    }

    public class InMemoryProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => throw new NotImplementedException();

        public bool CheckAvailable(Guid ProductId)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts(int pageNumber, int pageSize, string filter)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }
    }
}