using AuthService.Handlers;
using AuthService.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AuthServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthServiceConfig(
             this IServiceCollection services, IConfiguration config)
        {
            return services;
        }

        public static IServiceCollection AddAuthServiceDependencyGroup(
             this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<UsersHandler>();

            return services;
        }
    }
}