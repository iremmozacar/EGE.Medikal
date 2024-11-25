using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EgeApp.Backend.Entity.Concrete;

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

            // Seeding Categories
            List<Category> categories = new()
            {
                // Solunum Cihazları Kategorisi ve Alt Kategorileri
                new() { Id = 1, Name = "Uyku ve Solunum", Description = "Uyku ve solunum cihazları", IsActive = true, Url = "uyku-ve-solunum" },
                new() { Id = 2, Name = "Konsantratörler", Description = "Oksijen konsantratörleri", IsActive = true, Url = "konsantratorler", ParentCategoryId = 1 },
                new() { Id = 3, Name = "Aspiratör Cihazları", Description = "Aspiratör cihazları", IsActive = true, Url = "aspirator-cihazlari", ParentCategoryId = 1 },
                new() { Id = 4, Name = "Oksimetre", Description = "Oksimetre cihazları", IsActive = true, Url = "oksimetre", ParentCategoryId = 1 },
                new() { Id = 5, Name = "Oksijen Tüpü ve Yardımcı Aletleri", Description = "Oksijen tüpleri ve yardımcı aletler", IsActive = true, Url = "oksijen-tupu-yardimci-aletler", ParentCategoryId = 1 },
                new() { Id = 6, Name = "Kanüller", Description = "Oksijen kanülleri", IsActive = true, Url = "kanuller", ParentCategoryId = 1 },
                new() { Id = 7, Name = "Pap Ürünleri", Description = "Pap cihazları ve ürünleri", IsActive = true, Url = "pap-urunleri", ParentCategoryId = 1 },

                // Tekerlekli Sandalyeler Kategorisi ve Alt Kategorileri
                new() { Id = 8, Name = "Tekerlekli Sandalyeler", Description = "Tekerlekli sandalye çeşitleri", IsActive = true, Url = "tekerlekli-sandalyeler" },
                new() { Id = 9, Name = "Banyo ve Tuvalet Tekerlekli Sandalyeleri", Description = "Banyo ve tuvalet kullanımına uygun tekerlekli sandalyeler", IsActive = true, Url = "banyo-ve-tuvalet-tekerlekli-sandalyeleri", ParentCategoryId = 8 },
                new() { Id = 10, Name = "Günlük Kullanım Tekerlekli Sandalyeler", Description = "Günlük kullanım için tekerlekli sandalyeler", IsActive = true, Url = "gunluk-kullanim-tekerlekli-sandalyeler", ParentCategoryId = 8 },

                // Konuşma Cihazları Kategorisi
                new() { Id = 11, Name = "Konuşma Cihazları", Description = "Konuşma cihazları", IsActive = true, Url = "konusma-cihazlari" },

                // Masaj - Muayene Masaları Kategorisi
                new() { Id = 12, Name = "Masaj - Muayene Masaları", Description = "Masaj ve muayene masaları", IsActive = true, Url = "masaj-muayene-masalari" },

                // Pusetler Kategorisi
                new() { Id = 13, Name = "Pusetler", Description = "Çeşitli pusetler", IsActive = true, Url = "pusetler" },

                // Yatan Hasta Kategorisi ve Alt Kategorileri
                new() { Id = 14, Name = "Yatan Hasta", Description = "Yatan hastalar için ürünler", IsActive = true, Url = "yatan-hasta" },
                new() { Id = 15, Name = "Hasta Karyolası", Description = "Motorlu hasta karyolası", IsActive = true, Url = "hasta-karyolasi", ParentCategoryId = 14 },
                new() { Id = 16, Name = "Hasta Yatakları", Description = "Hasta yatakları", IsActive = true, Url = "hasta-yataklari", ParentCategoryId = 14 },
                new() { Id = 17, Name = "Hasta Bezleri", Description = "Yatan hastalar için bezler", IsActive = true, Url = "hasta-bezleri", ParentCategoryId = 14 },
                new() { Id = 18, Name = "Yardımcı Aletler", Description = "Yatan hastalar için yardımcı aletler", IsActive = true, Url = "yardimci-aletler", ParentCategoryId = 14 },

                // Engelsiz Ürünler Kategorisi ve Alt Kategorileri
                new() { Id = 19, Name = "Engelsiz Ürünler", Description = "Engelsiz yaşam için ürünler", IsActive = true, Url = "engelsiz-urunler" },
                new() { Id = 20, Name = "Baston/Kanedyen", Description = "Baston ve kanedyen çeşitleri", IsActive = true, Url = "baston-kanedyen", ParentCategoryId = 19 },
                new() { Id = 21, Name = "Yürütücü ve Wolker", Description = "Yürütücü cihazlar ve walkerlar", IsActive = true, Url = "yurutucu-ve-wolker", ParentCategoryId = 19 },
                new() { Id = 22, Name = "Ek Ürünler", Description = "Engelsiz yaşam için ek ürünler", IsActive = true, Url = "ek-urunler", ParentCategoryId = 19 },
                
                // Devamı...
            };

            builder.HasData(categories);
            builder.ToTable("Categories");
        }
    }
}