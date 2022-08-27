using EarlyMan.DL.Entities.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EarlyMan.PL.Areas.Identity.Pages.Account.Admin
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
           _roleManager = roleManager;
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
            public string Username { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }


        }
       
        public async Task OnGetAsync(string returnUrl)
        { 
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError("", ErrorMessage);
            }

            //...
            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            if (ModelState.IsValid)
            {
                ApplicationUser preValidatedUser = 
                    await _userManager.FindByNameAsync(Input.Username);
                

                if (preValidatedUser != null)
                {

                    var preValidatedSignInResult = await _signInManager.PasswordSignInAsync(preValidatedUser, Input.Password, false, false);

                    if (preValidatedSignInResult.Succeeded)
                    {
                        
                        if (await _userManager.IsInRoleAsync(preValidatedUser, "Admins"))
                        {
                            _logger.LogInformation("Admin logged in.");
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {

                            
                            ModelState.AddModelError(string.Empty,
                                "Invalid login attempt");
                            await _signInManager.SignOutAsync();
                        }
                    }

                    //if (result.RequiresTwoFactor)
                    //{
                    //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, Input.RememberMe });
                    //}
                    if (preValidatedSignInResult.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty,
                        "Invalid login attempt");

                }
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
