using EarlyMan.DL.Data;
using EarlyMan.DL.Entities;

namespace EarlyMan.DL.Services
{
    public class EFCartItemRepository : ICartItemRepository
    {
        public readonly ApplicationDbContext _Context;

        public EFCartItemRepository(ApplicationDbContext context)
        {
            _Context = context;
        }
        public void Add(CartItem item)
        {
            // don't know how null cart Item should get here tho.
            if (item.PurchaseQuantity < 0 || item.PurchasePrice <= 0) 
            { throw new ArgumentException("Faulty cart"); }


            
            _Context.CartItems.Add(item); 
        }
        public void Remove(Guid cartItemId, Guid cartId, Guid productId)
        {
            CartItem? cartItem = Find(cartItemId, cartId, productId);

            if(cartItem == null) { throw new ArgumentException("That item does not exist"); }

            _Context.CartItems.Remove(cartItem);
        }

        public CartItem Find(Guid cartItemId, Guid cartId, Guid productId)
        {
            CartItem? cartItem = _Context.CartItems.Select(x => x).
                Where(x => x.CartItemId == cartItemId
                && x.CartId == cartId
                && x.ProductId == productId).FirstOrDefault();

            return cartItem;
        }
        public void Update(Guid cartItemId, CartItem updateItem) { }

        public List<CartItem> GetItems(Guid userId)
        {
            var items = _Context.CartItems.Select(x => x).Where(x => x.CartId == userId).ToList();

            return items;
        }
    }
}
