using Microsoft.AspNetCore.Identity;

namespace FakeShop.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SexOptions Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public Cart Cart { get; set; }
    }

    public enum SexOptions
    {
        Male,
        Female
    }
}
