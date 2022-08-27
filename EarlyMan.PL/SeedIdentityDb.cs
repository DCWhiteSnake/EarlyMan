using EarlyMan.DL.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace EarlyMan.PL
{
    public static class SeedIdentityDb
    {
        private static string Username { get;set; }
        private static string Email { get; set; }
        private static string Password { get;  set; }
        private static string FirstName { get;  set; }
        private static string HomeAddress { get; set; }
        private static string ShippingAddress1 { get; set; }
        private static string ShippingAddress2 { get ; set; }
        private static string LastName { get; set; }
        private static bool IsActive { get; set; }
        private static string Role { get; set; }

        public static async Task CreateDefaultAdminAccount(IApplicationBuilder app, IConfiguration config)
        {
            // If environment is development enivironment...
            GetAdminCredFromConfig(config);
            using (var scope = app.ApplicationServices.CreateScope())
            {
                UserManager<ApplicationUser> userManager =
                scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                RoleManager<IdentityRole> roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();



                if (await userManager.FindByNameAsync(Username) == null)
                {
                    if (await roleManager.FindByNameAsync(Role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(Role));
                    }
                    ApplicationUser user = new ApplicationUser
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        AccountActive = IsActive,
                        UserName = Username,
                        Email = Email,
                        HomeAddress = HomeAddress,
                        ShippingAddress1=ShippingAddress1,
                        ShippingAddress2=ShippingAddress2,

                    };
                    IdentityResult result = await userManager
                    .CreateAsync(user, Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, Role);
                    }
                }

            }
        }

        public static async Task CreateDefaultRegularUserAccount(IApplicationBuilder app, IConfiguration config)
        {
            // If environment is development enivironment...
            GetRegularUserCredFromConfig(config);
            using (var scope = app.ApplicationServices.CreateScope())
            {
                UserManager<ApplicationUser> userManager =
                scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                RoleManager<IdentityRole> roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();



                if (await userManager.FindByNameAsync(Username) == null)
                {
                    if (await roleManager.FindByNameAsync(Role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(Role));
                    }
                    ApplicationUser user = new ApplicationUser
                    {
                        FirstName = FirstName,
                        LastName = LastName,
                        AccountActive = IsActive,
                        UserName = Username,
                        Email = Email,
                        HomeAddress = HomeAddress,
                        ShippingAddress1 = ShippingAddress1,
                        ShippingAddress2 = ShippingAddress2,
                        

                    };
                    IdentityResult result = await userManager
                    .CreateAsync(user, Password);
                    if (result.Succeeded)
                    {
                       var _ = await userManager.AddToRoleAsync(user, Role);


                    }
                }

            }
        }

        public static void GetAdminCredFromConfig(IConfiguration config)
        {


            Username = config["Data:AdminUser:Username"];
            Email = config["Data:AdminUser:Email"];
            Password = config["Data:AdminUser:Password"];
            FirstName = config["Data:AdminUser:FirstName"];
            LastName = config["Data:AdminUser:LastName"];
            HomeAddress = config["Data:AdminUser:HomeAddress"];
            ShippingAddress1 = config["Data:AdminUser:ShippingAddress1"];
            ShippingAddress2 = config["Data:AdminUser:ShippingAddress2"];
            IsActive = true;//config["Data:AdminUser:IsActive"];
            Role = config["Data:AdminUser:Role"];
        }


        public static void GetRegularUserCredFromConfig(IConfiguration config)
        {


            Username = config["Data:RegularUser:Username"];
            Email = config["Data:RegularUser:Email"];
            Password = config["Data:RegularUser:Password"];
            FirstName = config["Data:RegularUser:FirstName"];
            LastName = config["Data:RegularUser:LastName"];
            HomeAddress = config["Data:RegularUser:HomeAddress"];
            ShippingAddress1 = config["Data:RegularUser:ShippingAddress1"];
            ShippingAddress2 = config["Data:RegularUser:ShippingAddress2"];
            IsActive = true;//config["Data:RegularUser:IsActive"];
            Role = config["Data:RegularUser:Role"];
        }
    }
}
