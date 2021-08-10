using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Auth.Infrastructutre.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
