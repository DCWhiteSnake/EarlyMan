using EarlyMan.DL.Entities;

namespace EarlyMan.DL.Services
{
    public interface IPromotionRepository
    {
        IQueryable<Promotion>? Promos { get;}

        IEnumerable<Promotion> GetPromos();
    }
}