using EarlyMan.Entities;

namespace EarlyMan.Services
{
    public interface IPromotionRepository
    {
        IQueryable<Promotion> Promos { get;}

        IEnumerable<Promotion> GetPromos();
    }

    public class InMemoryPromotionRepository : IPromotionRepository
    {
        public IQueryable<Promotion> Promos => throw new NotImplementedException();

        public IEnumerable<Promotion> GetPromos()
        {
            throw new NotImplementedException();
        }
    }
}