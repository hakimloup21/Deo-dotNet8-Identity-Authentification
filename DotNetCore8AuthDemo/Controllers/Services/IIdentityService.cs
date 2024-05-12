using DotNetCore8AuthDemo.Model;
using Microsoft.AspNetCore.Identity;

namespace DotNetCore8AuthDemo.Controllers.Services
{
    public interface IIdentityService
    {
        public Task Register(IdentityUser user);
        
    }
    public class IdentityService : IIdentityService
    {
        private readonly ServiceProvider _serviceProvider;
        public IdentityService(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task Register(IdentityUser user)
        {
            var userManager =_serviceProvider.GetRequiredService<UserManager<AppUser>>();

            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                var newUser = new AppUser();
                newUser.UserName = user.Email;
                newUser.Email = user.Email;

                await userManager.CreateAsync(newUser, user.PasswordHash);
                await userManager.AddToRoleAsync(newUser, "Admin");
            }
        }
    }

}
