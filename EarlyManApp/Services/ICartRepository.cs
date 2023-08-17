using EarlyMan.Entities;

namespace EarlyMan.Services
{
    public interface ICartRepository
    { 
        IQueryable<Cart> Carts { get; }

        Cart GetById(Guid cartId);
        
        /// <summary>
        /// Adds a cart item to the cart with a matching Id
        /// </summary>
        /// <param name="cartId">The id of the cart that will
        /// contain the item</param>
        /// <param name="item">The item to be added to the cart</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        bool AddItemToCart(CartItem cartItem);
        public Task<Cart> CreateCart(Guid cartId);
    }

    public class InMemoryCartRepository : ICartRepository
    {
        public IQueryable<Cart> Carts => throw new NotImplementedException();

        public bool AddItemToCart(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> CreateCart(Guid cartId)
        {
            throw new NotImplementedException();
        }

        public Cart GetById(Guid cartId)
        {
            throw new NotImplementedException();
        }
    }
}