using EarlyMan.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EarlyMan.Areas.Identity.Pages.Account.Admin
{
    public class ChangePasswordModel : PageModel
    {

        private readonly UserManager<ApplicationUser> userManager;
        //private readonly IUserValidator<ApplicationUser> userValidator;
        private readonly IPasswordValidator<ApplicationUser> passwordValidator;
        private readonly IPasswordHasher<ApplicationUser> passwordHasher;

        public ChangePasswordModel(UserManager<ApplicationUser> usrMgr,
                //IUserValidator<ApplicationUser> usrVtor,
                IPasswordValidator<ApplicationUser> pswdVtor,
                IPasswordHasher<ApplicationUser> pswdHsr)
        {
            userManager = usrMgr;
            //userValidator = usrVtor;
            passwordValidator = pswdVtor;
            passwordHasher = pswdHsr;
        }
        
        
        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            /// Todo: Ask for and validate old password.
            //[Required]
            //[MaxLength(12)]
            //public string OldPassword { get; set; }

            [Required]
            [MaxLength(12)]
            [DataType(DataType.Password)]
            [Display(Name = "New Password")]
            public string NewPassword { get; set; }

            [Required]
            [MaxLength(12)]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

        }



        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var appUser = await userManager.GetUserAsync(User);


            var result = await passwordValidator.ValidateAsync(userManager, appUser, Input.NewPassword);

            if (result.Succeeded)
            {
                appUser.PasswordHash = passwordHasher.HashPassword(appUser, Input.NewPassword);

                IdentityResult updatePasswordResult = await userManager.UpdateAsync(appUser);

                if (updatePasswordResult.Succeeded)
                {
                    return RedirectToAction("Index", "UserAccount", new
                    {
                        pwd_ChangeSuccess = "true"
                    });
                }
            }
            else 
            { 
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return Page();

        }
       
    }
}
