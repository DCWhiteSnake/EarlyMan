using EarlyMan.Entities.Identity;
using EarlyMan.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EarlyMan.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        //private readonly IEmailSender _emailSender;
        private readonly ICartRepository _cartrepo;
        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ICartRepository cartRepo,
            ILogger<RegisterModel> logger)
            //,IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartrepo = cartRepo;
            _logger = logger;
            //_emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {

            [Required]
            [MaxLength(12)]
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Required]
            [MaxLength(12)]
            [Display(Name = "FirstName")]
            public string FirstName { get; set; }

            [Required]
            [MaxLength(12)]
            [Display(Name = "LastName")]
            public string LastName { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Please enter a valid phone number")]
            public string PhoneNo { get; set; }
        }

        public void OnGet(string returnUrl )
        {
            ReturnUrl = returnUrl;
        }

        // Todo: Email must be unique
        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            
            if (ModelState.IsValid)
            {
                // Todo: Give user a random name when user first creates account
                var user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = Input.UserName,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNo
                };


                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    _cartrepo.CreateCart(Guid.Parse(user.Id));

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return Page();
        }
    }
}