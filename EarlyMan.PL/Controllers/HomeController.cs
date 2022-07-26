using AutoMapper;
using EarlyMan.BL.Models;
using EarlyMan.DL.Entities.Identity;
using EarlyMan.DL.Services;
using EarlyMan.PL.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace EarlyMan.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductRepository _prodRepo;
        private readonly IPromotionRepository _promoRepo;
        private readonly ICartRepository _cartRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        // todo: Move somewhere else to make pagination easier
        public int _pageSize = 12;

        public HomeController(IProductRepository prodRepo, IPromotionRepository promoRepo, ICartRepository cartRepo, IMapper mapper,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _promoRepo = promoRepo;
            _prodRepo = prodRepo;
            _cartRepo = cartRepo;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
     
        public ViewResult Index()
        {
            // extract claims from http request
            //ClaimsPrincipal principal = HttpContext.User;

            //if (_signInManager.IsSignedIn(principal))
            //{
            //    _signInManager.SignOutAsync().Wait();
            //}
            ViewBag.Title = "Home | EarlyMan";
            HomePageViewModel homePageItems = new()
            {
                Products = GetProductsAsDtos(_pageSize).ToList(),
                Promotions = GetPromotionAsDtos().ToList(),
                Count = GetCartSize()
            };
       
            return View(homePageItems);
        }

        [AllowAnonymous]
        public ViewResult ProductShowcase() => View();

        [AllowAnonymous]
       
        public ViewResult ShoppingCart() => View("Cart", "Index");

        // Insert method that handles checking out and payments here.
        [Authorize]
      
        public ActionResult Checkout() => View();

        [AllowAnonymous]
        public ViewResult Error() => View();

        [AllowAnonymous]
        public ViewResult Privacy() => View();

        #region utility functions

        public IEnumerable<ProductDto> GetProductsAsDtos(int pagesize = 0)
        { 
            IEnumerable<ProductDto> productsToPass;
            try
            {
                var products = _prodRepo.GetProducts();
                productsToPass = _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }

            return productsToPass;
        }

        public IEnumerable<PromotionDto> GetPromotionAsDtos()
        {
            IEnumerable<PromotionDto> promotionsToPass = new List<PromotionDto>();
            try
            {
                var promotions = _promoRepo.GetPromos().Take(1);
                promotionsToPass = _mapper.Map<IEnumerable<PromotionDto>>(promotions);
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }

            return promotionsToPass;
        }

        private int GetCartSize()
        {
            //int result = 0;
            //if (_signInManager.IsSignedIn(User))
            //{
            //    result = _cartRepo.GetById().CartItems.Count;
            //}
            return 5;
        }

        #endregion utility functions
    }
}