using Microsoft.AspNetCore.Identity;

namespace Mango.Services.AuthApi.Models
{
    // adding more details to capture in Identity
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
