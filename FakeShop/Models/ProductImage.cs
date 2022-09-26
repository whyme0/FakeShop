using System.ComponentModel.DataAnnotations.Schema;

namespace FakeShop.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
