using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EgeApp.Backend.Entity.Concrete;
using EgeApp.Backend.Models;

namespace EgeApp.Backend.Data.Concrete.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("date('now')");

            builder.Property(x => x.ModifiedDate)
                .HasDefaultValueSql("date('now')");

            // Seeding Categories (Ana Kategoriler)
            List<Category> categories = new()
            {
                // 1. Ortopedik Ürünler
                new() { Id = 1, Name = "Ortopedik Ürünler", Description = "Ortopedik ürünler", IsActive = true, Url = "ortopedik-urunler" },

                // 2. Solunum Cihazları
                new() { Id = 2, Name = "Solunum Cihazları", Description = "Solunum cihazları", IsActive = true, Url = "solunum-cihazlari" },

                // 3. Solunum Maskeleri
                new() { Id = 3, Name = "Solunum Maskeleri", Description = "Solunum maskeleri", IsActive = true, Url = "solunum-maskeleri" },

                // 4. Hasta Bakım Ürünleri
                new() { Id = 4, Name = "Hasta Bakım Ürünleri", Description = "Hasta bakım ürünleri", IsActive = true, Url = "hasta-bakim-urunleri" },

                // 5. Tıbbi Test ve Sarf Malzemeleri
                new() { Id = 5, Name = "Tıbbi Test ve Sarf Malzemeleri", Description = "Tıbbi test ve sarf malzemeleri", IsActive = true, Url = "tibbi-test-ve-sarf-malzemeleri" },

                // 6. Tansiyon ve Nabız Ölçüm Cihazları
                new() { Id = 6, Name = "Tansiyon ve Nabız Ölçüm Cihazları", Description = "Tansiyon ve nabız ölçüm cihazları", IsActive = true, Url = "tansiyon-ve-nabiz-olcum-cihazlari" }
            };

            builder.HasData(categories);
            builder.ToTable("Categories");
        }
    }
}