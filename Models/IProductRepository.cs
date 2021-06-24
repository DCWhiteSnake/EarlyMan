using System.Linq;

namespace EarlyMan.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}