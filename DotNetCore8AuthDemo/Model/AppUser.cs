using Microsoft.AspNetCore.Identity;

namespace DotNetCore8AuthDemo.Model
{
    public class AppUser : IdentityUser
    {
        public string? Matricule { get; set; }
    }
}
