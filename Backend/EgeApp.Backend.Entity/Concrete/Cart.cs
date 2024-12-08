using System;

namespace EgeApp.Backend.Entity.Concrete
{
    public class Cart
    {
        public int Id { get; set; } // Benzersiz ID
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Sepet oluşturulma tarihi
        public string UserId { get; set; } // Kullanıcı ID'si
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
