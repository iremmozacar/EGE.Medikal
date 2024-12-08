using EgeApp.Backend.Models;

namespace EgeApp.Backend.Entity.Concrete
{
    public class CartItem
    {
        public int Id { get; set; } // Benzersiz ID
        public int ProductId { get; set; } // İlgili ürünün ID'si
        public int Quantity { get; set; } // Ürün adedi
        public int CartId { get; set; } // İlgili sepetin ID'si (Foreign Key)
        public Cart Cart { get; set; } // İlgili sepet (Navigation Property)
        public Product Product { get; set; } // İlgili ürün (Navigation Property)
    }
}
