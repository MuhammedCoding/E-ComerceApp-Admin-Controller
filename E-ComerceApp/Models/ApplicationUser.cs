using Microsoft.AspNetCore.Identity;

namespace E_CommerceApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }

    }
}
