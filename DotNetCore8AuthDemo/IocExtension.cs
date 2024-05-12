using DotNetCore8AuthDemo.Controllers.Services;

namespace DotNetCore8AuthDemo
{
    public static class IocExtension
    {
        public static void RegisterAllIoc(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
