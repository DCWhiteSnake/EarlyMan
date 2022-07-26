using EarlyMan.DL.Data;
using EarlyMan.DL.Entities;
namespace EarlyMan.DL.Services
{
    public class EFCartRepository : ICartRepository
    {
        private ApplicationDbContext _Context { get; set; } 
        private ICartItemRepository _CaetItemRepository { get; set; }
        public EFCartRepository(ApplicationDbContext ctx, ICartItemRepository cartItemRepo)
        {
             _Context = ctx;
            _CaetItemRepository = cartItemRepo;
        }
           

        public IQueryable<Cart> Carts { get => _Context.Carts; }

  
        public bool AddItemToCart(CartItem item)
        {
            // Find user's cart not product Id.
            _CaetItemRepository.Add(item);    
            return true;

            
        }
        
        public Cart GetById(Guid cartId)
        {
          var cart = Carts.Where(cart => cart.CartId == cartId).FirstOrDefault();
            if (cart == null)
                throw new ArgumentException("CartItemDoesNotExist");
            
          return cart;
        }

        public bool CreateCart(Guid userId)
        {
            try
            {
                var cart = GetById(userId);
            }
            catch (ArgumentException)
            {
                _Context.Carts.Add(new Cart()
                {
                    CartId = userId,
                    IsValid = true,
                    ModificationDate = DateTimeOffset.UtcNow,
                    Total = 0,
                    CreationDate = DateTimeOffset.UtcNow

                }) ;
                _Context.SaveChanges();
               
            };

            return true;
        }



    }
}