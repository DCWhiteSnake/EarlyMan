using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EarlyMan.Entities.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EarlyMan.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<LoginModel> _logger;
        public LoginModel(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = "home")
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                if (await CheckIfUserInRoleAsync(Input.Email, "Customer"))
                {
                    var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password,
                        Input.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        var message = $"User {Input.Email} logged in.";
                        _logger.LogInformation("{message}", message);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var user = await _userManager.FindByEmailAsync(Input.Email);
                        if (user != null)
                        {
                            result = await _signInManager.PasswordSignInAsync(user.UserName, Input.Password,
                                Input.RememberMe, lockoutOnFailure: false);

                            if (result.Succeeded)
                            {
                                var message = $"User {Input.Email} logged in.";
                                _logger.LogInformation("{message}", message);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("All",
                                "Wrong Username/Password");
                            }
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty,
                        "Invalid login attempt");
                }

            }
            return Page();
        }

        public async Task<bool> CheckIfUserInRoleAsync(string identifier, string role)
        {
            var user = await _userManager.FindByNameAsync(identifier);
            user ??= await _userManager.FindByEmailAsync(identifier);
            if (user != null)
            {
                return (await _userManager.GetRolesAsync(user)).FirstOrDefault() == role;
            }
            return false;
        }


    }
}
