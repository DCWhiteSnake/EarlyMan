using EarlyMan.DL.Data;
using EarlyMan.DL.Entities.Identity;
using EarlyMan.DL.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EarlyMan.PL
{
    public class StartupDevelopment
    {
        public StartupDevelopment(IConfiguration configuration) =>
        Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {



            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EarlyManIdentity"),
            b => b.MigrationsAssembly("EarlyMan.PL")));

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("EarlyManDatabase"),
            b => b.MigrationsAssembly("EarlyMan.PL")));

            services.AddDefaultIdentity<ApplicationUser>()
                           .AddEntityFrameworkStores<AppIdentityDbContext>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<IPromotionRepository, EFPromotionRepository>();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddTransient<ICartRepository, EFCartRepository>();
            services.AddTransient<ICartItemRepository, EFCartItemRepository>();


            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute("product", "{controller=Product}/{action=Details}/{productId}");
                endpoints.MapControllerRoute("Catchall", "{*any}", new
                {
                    controller = "Error",
                    action = "Index"
                });
                endpoints.MapRazorPages();
            });


        }
    }
}