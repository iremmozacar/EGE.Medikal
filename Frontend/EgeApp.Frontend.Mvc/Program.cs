using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EgeApp.Frontend.Mvc.Data;
using EgeApp.Frontend.Mvc.Data.Entities;
using EgeApp.Frontend.Mvc.Helpers.Abstract;
using EgeApp.Frontend.Mvc.Helpers.Concrete;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddNotyf(config =>
{
    config.Position = NotyfPosition.TopRight;
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.HttpOnly = true;

});

builder.Services.AddScoped<IEmailSenderHelper, EmailSenderSmtp>(options => new EmailSenderSmtp(
    builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:Host"],
    builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetValue<int>("EmailSender:Port"),
    builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetValue<bool>("EmailSender:EnableSSL"),
    builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:UserName"],
    builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>()["EmailSender:Password"]
  ));

var app = builder.Build();

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

//localhost:5000/admin/home/index
app.MapAreaControllerRoute(
    name: "admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}",
    areaName: "Admin"
);


//localhost:5000/Product/Create
//localhost:5000/
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
