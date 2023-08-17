using EarlyMan.Data;
using EarlyMan.Entities;

namespace EarlyMan.Services
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
        
        public void Remove(Guid cartItemId)
        {
            CartItem cartItem =_Context.CartItems.Find(cartItemId) ?? throw new ArgumentException("That item does not exist");
            _Context.CartItems.Remove(cartItem);
            _Context.SaveChanges();
        }

        public CartItem Find(Guid cartItemId)
        {
            CartItem cartItem = _Context.CartItems.Find(cartItemId);
            
            if (cartItem== null)
                throw new ArgumentException("Cart item with that id does not exist");
            
            return cartItem;
        }
        public void Update(Guid cartItemId, CartItem updateItem) { }

        public List<CartItem> GetItems(Guid userId)
        {
            var items = _Context.CartItems.Select(x => x).Where(x => x.CartId == userId).ToList();

            return items;
        }


        public int Count(Guid cartId)
        {
            return _Context.CartItems.Count(x => x.CartId == cartId);
        }

        public void Checkout(Guid userId)
        {
            var itemsToRemove = _Context.CartItems.Where(x => x.CartId == userId);
           _Context.CartItems.RemoveRange(itemsToRemove);
            _Context.SaveChanges();
        }
    }
}
