using EarlyMan.Data;
using EarlyMan.Entities;

namespace EarlyMan.Services
{
    public class EFPromotionRepository : IPromotionRepository
    {
        private readonly ApplicationDbContext context;

        public EFPromotionRepository(ApplicationDbContext ctx)
            => context = ctx;

        public IQueryable<Promotion> Promos { get => context.Promos; }

        public IEnumerable<Promotion> GetPromos()
        {
            if (Promos == null)
                throw new NullReferenceException("The product repository is empty");
            return Promos;
        }

    }
}