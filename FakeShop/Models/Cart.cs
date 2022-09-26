namespace FakeShop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<CartItem> Items { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
