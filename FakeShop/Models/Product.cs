using System.ComponentModel.DataAnnotations;

namespace FakeShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public int VendorCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public bool IsSelling { get; set; }
        [Required]
        public bool IsHidden { get; set; }
        [Required]
        public double CurrentPrice { get; set; }
        public double PreviousPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
