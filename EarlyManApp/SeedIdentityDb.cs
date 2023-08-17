using EarlyMan.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace EarlyMan
{
    public static class SeedIdentityDb
    {
        public static async Task CreateDefaultAdminAccount(IApplicationBuilder app)
        {
            Dictionary<string, string> newAdminUser = new()
            {
                {"FirstName" , "Admin"},
                {"LastName" , "Admin"},
                {"Email" , "admin.a@testmail.com"},
                {"HomeAddress" , ""},
                {"ShippingAddress1" , ""},
                {"ShippingAddress2" , ""},
                {"Password" , "Secret123$"},
                {"Username" , "ADMIN"},
                {"IsActive" , "true"},
                {"Role" , "Admin"}
            };

            using var scope = app.ApplicationServices.CreateScope();
            UserManager<ApplicationUser> userManager =
            scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager =
            scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (await userManager.FindByNameAsync(newAdminUser["Username"]) == null)
            {
                if (await roleManager.FindByNameAsync(newAdminUser["Role"]) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(newAdminUser["Role"]));
                }
                ApplicationUser user = new()
                {
                    UserName = newAdminUser["Username"],
                    FirstName = newAdminUser["FirstName"],
                    LastName = newAdminUser["LastName"],
                    AccountActive = bool.Parse(newAdminUser["IsActive"]),
                    Email = newAdminUser["Email"],
                    HomeAddress = newAdminUser["HomeAddress"],
                    ShippingAddress1 = newAdminUser["ShippingAddress1"],
                    ShippingAddress2 = newAdminUser["ShippingAddress2"]
                };
                IdentityResult result = await userManager
                .CreateAsync(user, newAdminUser["Password"]);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, newAdminUser["Role"]);
                }
            }
        }

        public static async Task CreateDefaultRegularUserAccount(IApplicationBuilder app)
        {
            Dictionary<string, string> newAdminUser = new()
            {
                {"FirstName" , "Test"},
                {"LastName" , "Customer"},
                {"Email" , "testCustomer@testmail.com"},
                {"HomeAddress" , ""},
                {"ShippingAddress1" , ""},
                {"ShippingAddress2" , ""},
                {"Password" , "Secret123$"},
                {"Username" , "testCustomer"},
                {"IsActive" , "true"},
                {"Role" , "Customer"}
            };

            using var scope = app.ApplicationServices.CreateScope();
            UserManager<ApplicationUser> userManager =
            scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole> roleManager =
            scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            if (await userManager.FindByNameAsync(newAdminUser["Username"]) == null)
            {
                if (await roleManager.FindByNameAsync(newAdminUser["Role"]) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(newAdminUser["Role"]));
                }
                ApplicationUser user = new()
                {
                    UserName = newAdminUser["Username"],
                    FirstName = newAdminUser["FirstName"],
                    LastName = newAdminUser["LastName"],
                    AccountActive = bool.Parse(newAdminUser["IsActive"]),
                    Email = newAdminUser["Email"],
                    HomeAddress = newAdminUser["HomeAddress"],
                    ShippingAddress1 = newAdminUser["ShippingAddress1"],
                    ShippingAddress2 = newAdminUser["ShippingAddress2"]
                };
                IdentityResult result = await userManager
                .CreateAsync(user, newAdminUser["Password"]);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, newAdminUser["Role"]);
                }
            }
        }
    }
}