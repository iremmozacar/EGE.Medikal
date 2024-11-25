using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EgeApp.Backend.Entity.Concrete;

namespace EgeApp.Backend.Data.Concrete.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Properties)
                .IsRequired();

            builder.Property(x => x.ImageUrl)
                .IsRequired();

            builder.Property(x => x.Brand)
                .IsRequired(false);

            // Veritabanına önceden eklenmiş ürün verileri
            var products = new List<Product>
            {
                new()
                {
                    Id = 1,
                    Name = "Dorselumber Korse",
                    Price = 1000,
                    Properties = "Diz ve sırt destekleyici",
                    Url = "dorselumber-korse",
                    ImageUrl = "http://localhost:5200/images/products/dorselumberkorse.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    CategoryId = 1
                },
                new()
                {
                    Id = 2,
                    Name = "Devisbiss Oksijen Konsantratörü",
                    Price = 8000,
                    Properties = "Profesyonel solunum cihazı",
                    Url = "devisbiss-oksijen-konsantratoru",
                    ImageUrl = "http://localhost:5200/images/products/devisbissoksijen.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    CategoryId = 2
                },
                new()
                {
                    Id = 3,
                    Name = "Tam Yüz Maskesi",
                    Price = 500,
                    Properties = "Solunum desteği için maske",
                    Url = "tam-yuz-maskesi",
                    ImageUrl = "http://localhost:5200/images/products/tamyuzmaskesi.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    CategoryId = 3
                },
                new()
                {
                    Id = 4,
                    Name = "2 Motorlu Hasta Karyolası",
                    Price = 12000,
                    Properties = "Hasta bakım için motorlu yatak",
                    Url = "2-motorlu-hasta-karyolasi",
                    ImageUrl = "http://localhost:5200/images/products/motorluhastakaryolasi.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    CategoryId = 4
                },
                new()
                {
                    Id = 5,
                    Name = "W Cura C",
                    Price = 700,
                    Properties = "Hızlı tıbbi test malzemesi",
                    Url = "w-cura-c",
                    ImageUrl = "http://localhost:5200/images/products/wcuracdbg.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    CategoryId = 5
                },
                new()
                {
                    Id = 6,
                    Name = "Tansiyon Aleti",
                    Price = 500,
                    Properties = "Hassas tansiyon ölçer",
                    Url = "tansiyon-aleti",
                    ImageUrl = "http://localhost:5200/images/products/tansiyonaleti.webp",
                    Brand = null,
                    IsHome = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    CategoryId = 6
                }
            };

            builder.HasData(products);
            builder.ToTable("Products");
        }
    }
}