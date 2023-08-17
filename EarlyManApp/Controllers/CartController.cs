using AutoMapper;
using EarlyMan.Data;
using EarlyMan.Entities;
using EarlyMan.Entities.Identity;
using EarlyMan.Services;
using EarlyMan.ViewModels.CartViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EarlyMan.Controllers
{
    [Authorize(Roles ="Customer")]
    public class CartController : Controller
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly ApplicationDbContext _Context;
        private readonly IProductRepository _ProductRepository;
        private readonly ICartRepository _CartRepository;
        private readonly ICartItemRepository _cartItemRepo;
        public int _pageSize = 10;
        
        public CartController(IMapper mapper,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext cxt,
            IProductRepository productRepository,
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository)
        {
            _UserManager = userManager;
            _Context = cxt;
            _ProductRepository = productRepository;
            _CartRepository = cartRepository;
            _cartItemRepo = cartItemRepository;
        }

       
        public IActionResult Index(int pageNumber = 0)
        {


            CartIndexViewModel cartIndexViewModel = new();

            // Get the currently signed in user's Id
            var userId = new Guid(HttpContext.User.Claims.FirstOrDefault
                (c => c.Type == ClaimTypes.NameIdentifier).Value);

            var userCart = _CartRepository.GetById(userId);

            List<CartItem> cartItems = new();
            

            // If user isn't blacklisted
            if (userCart.IsValid)
            {

                cartItems = _Context.CartItems
                    .Select(x => x)
                    .Where(x => x.CartId.ToString().ToLower() == userId.ToString().ToLower())
                    .Skip(pageNumber * _pageSize)
                    .Take(_pageSize)
                    .ToList();
            }


            // Create a cart view item for each item and then substract the available units from the product
            // quantity in the product repository.
            foreach (var cartItem in cartItems)
            {
                var product = _ProductRepository.GetProductById(cartItem.ProductId);

                CartViewItem cvItem = new()
                {
                    ImageLocation = product.ImageLocation,
                    ProductName = product.Name,
                    ProductDescription = product.Description,
                    ProductId = cartItem.ProductId,
                    CartItemId = cartItem.CartItemId,
                    PurchasePrice = cartItem.PurchasePrice,
                    PurchaseQuantity = cartItem.PurchaseQuantity,
                    SubTotal = cartItem.SubTotal,
                    
                };

                product.AvailableUnits -= cartItem.PurchaseQuantity;

                cartIndexViewModel.Items.Add(cvItem);
            }

            ViewData["ItemCount"] = _cartItemRepo.Count(userId);

            return View("Index" , cartIndexViewModel);
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(Guid productId, int purchaseQuantity,
        decimal purchasePrice)
        {


            if (purchaseQuantity <= 0)
            {
                // pass validation error back to user
            }
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var userCart = _CartRepository.GetById(new Guid(userId));
           
            CartItem itemToCart = new()
            {
                CartItemId = Guid.NewGuid(),
                CartId = new Guid(userId),
                ProductId = productId,
                PurchaseQuantity = purchaseQuantity,
                PurchasePrice = purchasePrice,
                SubTotal = purchasePrice * purchaseQuantity,
                CreationDate = DateTime.Now,
                ModificationDate = DateTime.Now

            };

            userCart.IsValid = true;
            userCart.ModificationDate = DateTime.Now;
            userCart.Total += itemToCart.SubTotal;
           _cartItemRepo.Add(itemToCart);
           _Context.SaveChanges();

            return RedirectToAction("Index");

        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout()
        {
            var userId = new Guid(HttpContext.User.Claims.FirstOrDefault
               (c => c.Type == ClaimTypes.NameIdentifier).Value);

            _cartItemRepo.Checkout(userId);

            return RedirectToAction("Index");  
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult RemoveItem (Guid cartItemId)
        {
            _cartItemRepo.Remove(cartItemId);

            return RedirectToAction("Index");
        }
    }
}