using EarlyMan.DL.Entities;

namespace EarlyMan.DL.Services
{
    public interface ICartItemRepository
    {
        public void Add(CartItem item) { }
        public void Remove(Guid cartItemId) { }
        public void Update(Guid cartItemId) { }

        List<CartItem> GetItems(Guid userId);

        /// <summary>
        /// Returns the number of unique item batches in a user's cart, ie., the number of individual
        /// clicks to the "add to cart" button in the cartitem/details view.
        /// 
        /// </summary>
        /// <param name="cartId">
        /// Aka the user's id since cartId is equal to user's id
        /// </param>
        /// <returns></returns>
        int Count(Guid cartId);
    }
}
