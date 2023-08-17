using EarlyMan.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EarlyMan.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController:Controller
    {

        public readonly UserManager<ApplicationUser> userManager;

        public AdminController(UserManager<ApplicationUser> usrMgr)
        {
            userManager = usrMgr;


        }

        
        public ViewResult Index() 
        {
            var users = userManager.Users;
            ; return View("ManageUsers/Index", users);
                
        }

    }
}
