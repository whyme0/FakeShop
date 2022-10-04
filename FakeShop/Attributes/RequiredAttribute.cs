namespace FakeShop.Attributes
{
    public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute
    {
        public RequiredAttribute()
        {
            ErrorMessage = "This field is required";
        }
    }
}
