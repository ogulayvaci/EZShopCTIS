using BLL.DAL;
using BLL.Models;
using BLL.Services;
using BLL.Services.Bases;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(config =>
{
    config.LoginPath = "/Users/Login";
    config.AccessDeniedPath = "/Users/Login";
    config.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    config.SlidingExpiration = true;
});

// IOC (Inversion of Control) Container
var connectionString = builder.Configuration.GetConnectionString("Db");
builder.Services.AddDbContext<Db>(optionsAction =>
    optionsAction.UseNpgsql(connectionString));

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IStoreService, StoreService>();
// builder.Services.AddScoped(typeof(IService<user, UserModel>), typeof(UserService));
builder.Services.AddScoped<IService<user,UserModel>, UserService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<HttpServiceBase, HttpService>();

var section = builder.Configuration.GetSection("AppSettings");
section.Bind(new AppSettings());

builder.Services.AddSession(config =>
{
    config.IdleTimeout = TimeSpan.FromMinutes(60);
    // config.IOTimeout = TimeSpan.MaxValue;
});

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

// Authentication:
app.UseAuthentication();
app.UseAuthorization();

// Session : 
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();