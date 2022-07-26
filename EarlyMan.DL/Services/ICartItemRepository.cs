using EarlyMan.DL.Entities;

namespace EarlyMan.DL.Services
{
    public interface ICartItemRepository
    {
        public void Add(CartItem item) { }
        public void Remove(Guid cartItemId) { }
        public void Update(Guid cartItemId) { }

        List<CartItem> GetItems(Guid userId);
    }
}
