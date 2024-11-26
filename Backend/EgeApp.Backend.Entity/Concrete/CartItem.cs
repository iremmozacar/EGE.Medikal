using EgeApp.Backend.Models;

namespace EgeApp.Backend.Entity.Concrete
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // Cart ile ilişki için yabancı anahtar
        public int CartId { get; set; }  // CartId ekleyin
        public Cart Cart { get; set; }  // Cart ile ilişkiyi kurmak için Cart nesnesi ekleyin

        public Product Product { get; set; }  // Sepetteki ürün ile ilişki
    }
}
