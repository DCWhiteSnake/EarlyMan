using Microsoft.EntityFrameworkCore;
using EarlyMan.DL.Data;
using EarlyMan.DL.Services;
using EarlyMan.DL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using EarlyMan.PL;

var builder = WebApplication.CreateBuilder(args);


//Configure services
builder.Services.AddDbContextPool<AppIdentityDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EarlyManIdentity"), b => b.MigrationsAssembly("EarlyMan.DL")));


builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("EarlyManDatabase"), b => b.MigrationsAssembly("EarlyMan.DL")));


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
opts =>
{
    opts.User.RequireUniqueEmail = true;
    //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz_$";
})
.AddEntityFrameworkStores<AppIdentityDbContext>()
.AddDefaultTokenProviders();


// todo: Route links to admin page to admin login page.
//builder.Services.ConfigureApplicationCookie(opts => {
//opts.LoginPath = "/Admin/Login";
//opts.Validate()
            
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IPromotionRepository, EFPromotionRepository>();
builder.Services.AddTransient<IProductRepository, EFProductRepository>();
builder.Services.AddTransient<ICartRepository, EFCartRepository>();
builder.Services.AddTransient<ICartItemRepository, EFCartItemRepository>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


//Configure request pipeline
var app = builder.Build();

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
    endpoints.MapControllerRoute("admin_default", "{controller=Admin}/{action=Index}");
    
    //endpoints.MapControllerRoute("Catchall", "{*any}", new
    //{
    //    controller = "Error",
    //    action = "Index"
    //});
    endpoints.MapRazorPages();
});
SeedIdentityDb.CreateDefaultAdminAccount(app, app.Configuration).Wait();
SeedIdentityDb.CreateDefaultRegularUserAccount(app, app.Configuration).Wait();
app.Run();


