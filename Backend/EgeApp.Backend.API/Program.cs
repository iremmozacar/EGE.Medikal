using Microsoft.EntityFrameworkCore;
using EgeApp.Backend.Business.Abstract;
using EgeApp.Backend.Business.Concrete;
using EgeApp.Backend.Data;
using EgeApp.Backend.Data.Abstract;
using EgeApp.Backend.Data.Concrete.Repositories;
using EgeApp.Backend.Shared.Helpers;
using EgeApp.Backend.Shared.Helpers.Abstract;

var builder = WebApplication.CreateBuilder(args);

// DbContext'i ekleyin ve bağlantı dizesini doğru şekilde yapılandırın
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

// API controller'larını ekleyin
builder.Services.AddControllers();

// Swagger'ı ekleyin (geliştirme ortamında API belgeleri için)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repository ve Service bağımlılıklarını ekleyin
#region Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
#endregion

#region Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartItemService, CartItemService>();
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion

// Yardımcı servisleri ekleyin
builder.Services.AddScoped<IImageHelper, ImageHelper>();

// AutoMapper'ı ekleyin (model eşlemeleri için)
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Uygulamayı oluşturun
var app = builder.Build();

// Geliştirme ortamında Swagger'ı etkinleştirin
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Statik dosyaların (wwwroot) kullanılmasına izin verin
app.UseStaticFiles();

// HTTPS yönlendirmesini etkinleştirin
app.UseHttpsRedirection();

// Yetkilendirmeyi etkinleştirin
app.UseAuthorization();

// API controller'larını yönlendirin
app.MapControllers();

// Uygulamayı başlatın
app.Run();