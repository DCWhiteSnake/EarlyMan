using Microsoft.EntityFrameworkCore;
using EarlyMan.Data;
using EarlyMan.Services;
using EarlyMan.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using EarlyMan;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetValue<string>("EarlyManDb");
builder.Services.AddDbContextPool<AppIdentityDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
     options => options.EnableRetryOnFailure())
    );
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
     options => options.EnableRetryOnFailure())
    );
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

builder.Services.AddScoped<IPromotionRepository, EFPromotionRepository>();
builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICartRepository, EFCartRepository>();
builder.Services.AddScoped<ICartItemRepository, EFCartItemRepository>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();


//Configure request pipeline
var app = builder.Build();
app.UseExceptionHandler("/Error");
app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    name: "product",
    pattern: "{controller=Product}/{action=Details}/{productId}");
app.MapControllerRoute(
    name: "admin_default",
    pattern: "{controller=Admin}/{action=Index}");
app.MapRazorPages();

if (app.Environment.IsDevelopment())
{
    await SeedIdentityDb.CreateDefaultAdminAccount(app);
    await SeedIdentityDb.CreateDefaultRegularUserAccount(app);
}

app.Run();

