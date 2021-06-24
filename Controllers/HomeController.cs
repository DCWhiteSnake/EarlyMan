using EarlyMan.Models;
using EarlyMan.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EarlyMan.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private HomepageItems HomePageVM { get; set; }

        public HomeController(IProductRepository product, IPromotionRepository promo)
        {
            HomePageVM = new HomepageItems
            {
                ProductRepository = product,
                PromotionRepository = promo,
            };
        }

        [AllowAnonymous]
        public ViewResult Index() => View(HomePageVM);

        [AllowAnonymous]
        public ViewResult ProductShowcase() => View(HomePageVM);

        [AllowAnonymous]
        [HttpGet]
        public ViewResult ShoppingCart() => View();

        // Insert method that handles checking out and payments here.
        [Authorize]
        [HttpPost]
        public ActionResult Checkout() => View();

        [AllowAnonymous]
        public ViewResult Error() => View();
    }
}