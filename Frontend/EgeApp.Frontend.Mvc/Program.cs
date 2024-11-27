using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EgeApp.Frontend.Mvc.Data;
using EgeApp.Frontend.Mvc.Data.Entities;
using EgeApp.Frontend.Mvc.Helpers.Abstract;
using EgeApp.Frontend.Mvc.Helpers.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Controllers ve Views için yapılandırma
builder.Services.AddControllersWithViews();

// DbContext ve Identity yapılandırması
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// ToastNotification yapılandırması
builder.Services.AddNotyf(config =>
{
    config.Position = NotyfPosition.TopRight;
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
});

// Session yapılandırması
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// E-posta gönderimi için bağımlılık ekleme
builder.Services.AddScoped<IEmailSenderHelper, EmailSenderSmtp>(options => new EmailSenderSmtp(
    builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:Host"],
    builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetValue<int>("EmailSender:Port"),
    builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetValue<bool>("EmailSender:EnableSSL"),
    builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:UserName"],
    builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:Password"]
));

// Razor Pages desteği (isteğe bağlı)
builder.Services.AddRazorPages();

var app = builder.Build();

// Hata yönetimi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

// Admin Area Rota
app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

// Varsayılan Rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Razor Pages (isteğe bağlı)
app.MapRazorPages();

app.Run();