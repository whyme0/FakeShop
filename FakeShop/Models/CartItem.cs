using System.ComponentModel.DataAnnotations;

namespace FakeShop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        [Required]
        public int VendorCode { get; set; }
        [Required]
        public int Amount { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
