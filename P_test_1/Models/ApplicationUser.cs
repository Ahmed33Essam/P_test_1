using Microsoft.AspNetCore.Identity;

namespace P_test_1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { set; get; }
    }
}
