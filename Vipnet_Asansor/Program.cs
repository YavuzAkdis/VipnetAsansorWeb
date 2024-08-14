using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Dil Desteði 
// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IBrandService, BrandManager>();
builder.Services.AddScoped<IBrandDal, EfBrandDal>();
builder.Services.AddScoped<IReferenceService, ReferenceManager>(); // veya uygun sýnýf
builder.Services.AddScoped<IReferenceDal, EfReferenceDal>(); // veya uygun sýnýf


// Add authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login"; // Giriþ yapýlmamýþsa yönlendirilecek sayfa
        options.AccessDeniedPath = "/Account/AccessDenied"; // Eriþim izni olmayan sayfa
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Admin")); // Admin rolü gerektiren bir politika
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Örneðin, 20 dakika
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor(); // Add this line




#region CultureConfiguration
var cultures = new List<CultureInfo>();
var trCulture = new CultureInfo("tr-TR");
var enCulture = new CultureInfo("en-US");
trCulture.NumberFormat.NumberDecimalSeparator = ".";
enCulture.NumberFormat.NumberDecimalSeparator = ".";
cultures.Add(trCulture);
cultures.Add(enCulture);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new("tr-TR");
    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
    options.RequestCultureProviders = new List<IRequestCultureProvider>()
      {
          new CookieRequestCultureProvider()
      };
});
#endregion
var app = builder.Build();

//// Configure the HTTP request pipeline. ERROR 500 hatasý verdi
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}

app.UseHttpsRedirection();
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();

// Find the cookie provider with LINQ
var cookieProvider = options.Value.RequestCultureProviders
    .OfType<CookieRequestCultureProvider>()
        .First();
// Set the new cookie name
cookieProvider.CookieName = "App.Constant";
app.UseRequestLocalization(options.Value);

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Authentication middleware'ýný ekleyin
app.UseAuthorization(); // Authorization middleware'ýný ekleyin
app.UseSession(); // Session middleware'ý ekleyin

// Route configurations


app.MapControllerRoute(
    name: "admin",
    pattern: "admin/{controller=Admin}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "account",
    pattern: "account/{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "about",
    pattern: "{language}/about",
    defaults: new { controller = "Default", action = "About" });



app.MapControllerRoute(
    name: "arge",
    pattern: "{language}/ar-ge",
    defaults: new { controller = "Default", action = "ArGe" });

app.MapControllerRoute(
    name: "gallery",
    pattern: "{language}/gallery",
    defaults: new { controller = "Default", action = "Gallery" });

app.MapControllerRoute(
    name: "contact",
    pattern: "{language}/contact",
    defaults: new { controller = "Default", action = "Contact" });

// Route sýrasý önemli Ürün Detaylarý en alt olsun
// Ürün detay
app.MapControllerRoute(
    name: "productDetails",
    pattern: "/{url}",
    defaults: new { controller = "Product", action = "Details" });


app.Run();
