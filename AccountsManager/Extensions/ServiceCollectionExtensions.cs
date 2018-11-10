using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using AccountsManager.Core.Configuration;
using AccountsManager.DataAccess.DataObjects;
using AccountsManager.DataAccess.Repositories;

namespace AccountsManager.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            AccountsManagerConfiguration config = new AccountsManagerConfiguration();
            configuration.Bind(nameof(AccountsManagerConfiguration), config);
            services.AddSingleton(config);

            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IAccountsRepository<SteamAccountEntity>, SteamAccountsRepository>();
        }
    }
}