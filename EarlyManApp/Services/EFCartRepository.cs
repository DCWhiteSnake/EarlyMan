﻿using EarlyMan.Data;
using EarlyMan.Entities;
namespace EarlyMan.Services
{
    public class EFCartRepository : ICartRepository
    {
        private ApplicationDbContext _Context { get; set; }
        private ICartItemRepository _CartItemRepository { get; set; }
        public EFCartRepository(ApplicationDbContext ctx, ICartItemRepository cartItemRepo)
        {
            _Context = ctx;
            _CartItemRepository = cartItemRepo;
        }
        public IQueryable<Cart> Carts { get => _Context.Carts; }
        public bool AddItemToCart(CartItem item)
        {
            // Find user's cart not product Id.
            _CartItemRepository.Add(item);
            return true;
        }
        public Cart GetById(Guid cartId)
        {
            var cart = Carts.Where(cart => cart.CartId == cartId).FirstOrDefault();
            cart ??= CreateCart(cartId);
            return cart;
        }
        public Cart CreateCart(Guid userId)
        {
            Cart cart =
                new()
                {
                    CartId = userId,
                    IsValid = true,
                    ModificationDate = DateTimeOffset.UtcNow,
                    Total = 0,
                    CreationDate = DateTimeOffset.UtcNow
                };
            _Context.Carts.Add(cart);
            _Context.SaveChanges();
            return cart;
        }
    }
}
