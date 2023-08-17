using EarlyMan.Data;
using EarlyMan.Entities;
using System.Linq;
using System.Text.RegularExpressions;
namespace EarlyMan.Services
{
    public class EFProductRepository : IProductRepository
    {
        public ApplicationDbContext Context { get; }

        public EFProductRepository(ApplicationDbContext cxt)
            => Context = cxt;

        public IQueryable<Product> Products { get => Context.Products; }

        public Product GetProductById(Guid productId)
        {
                var productToReturn = Products.Where(x =>
                x.ProductId == productId).First();
                if (productToReturn == null)
                    throw new NullReferenceException($"Product with id:{productId}" +
                        "does not exist");
                return productToReturn;
        }

        public IEnumerable<Product> GetProducts(int pageNumber, int pageSize, string filter)
        {
            if (Products == null)
                throw new NullReferenceException("The product repository is empty");


            int defaultSkipCount = 0;
            int defaultPageSize = 12;
            var sanitizedFilter = "";

            try
            {
                sanitizedFilter = SanitizeFilter(filter);
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

            try
            {
                ValidatePageNumberAndSize(pageNumber, pageSize);
            }

            catch (ArgumentOutOfRangeException) { return Products.Skip(defaultSkipCount).Take(defaultPageSize).ToList(); }

            pageNumber = (pageNumber == 0) ? 1 : pageNumber;
            int skipCount = (pageNumber - 1) * pageSize;

            if (string.IsNullOrEmpty(sanitizedFilter))
                return Products.
                        Select(x => x).
                        Skip(skipCount).
                        Take(pageSize).ToList();



            return Products.
                Select(x => x).
                Where(x => x.Name.Contains(sanitizedFilter) || x.Description.Contains(sanitizedFilter)).
                Skip(skipCount).
                Take(pageSize).ToList();
        }

        public void ValidatePageNumberAndSize(int pageNumber, int pageSize)
        {
            if (pageSize < 0 || pageNumber < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

        }

        public string SanitizeFilter(string filter)
        {
            //string pattern_for_text_and_spaces = "[\\w*\\s*]*";
            //var collection = Regex.Matches(filter, pattern_for_text_and_spaces);

            //if (collection.Count == 0) { throw new ArgumentException($"Search term {filter} is not allowed"); }
            return filter;
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

        public int Size()
        {
            return Context.Products.Count();
        }
    }
}