using Microsoft.AspNetCore.Identity;

namespace academia.Domain.Entities.Account
{
    public class Users : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
