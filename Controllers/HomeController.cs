using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EarlyMan.Models;
using EarlyMan.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System;

namespace EarlyMan.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private HomepageItems HomePageVM { get; set; }
        private HttpContext Cxt { get; set; }

        public HomeController(IPrintRepository print, IPromotionRepository promo)
        {
            HomePageVM = new HomepageItems
            {
                PrintRepository = print,
                PromotionRepository = promo,
                Context = Cxt
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