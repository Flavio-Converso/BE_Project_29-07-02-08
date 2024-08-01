using BE_Project_29_07_02_08.Context;
using BE_Project_29_07_02_08.Services.Auth;
using BE_Project_29_07_02_08.Services.Carts;
using BE_Project_29_07_02_08.Services.Orders;
using BE_Project_29_07_02_08.Services.Products;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

//AUTH
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Register";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
    });

//POLICY
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "admin");
    });
});

//DATACONTEXT
var conn = builder.Configuration.GetConnectionString("DB");
builder.Services
    .AddDbContext<DataContext>(opt => opt.UseSqlServer(conn));

//SERVIZI
builder.Services
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IAuthService, AuthService>()
    .AddScoped<ICartService, CartService>()
    .AddScoped<IOrderService, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
