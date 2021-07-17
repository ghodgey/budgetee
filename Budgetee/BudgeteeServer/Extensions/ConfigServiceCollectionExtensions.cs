using BudgeteeServer.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgeteeServer.Extensions
{
    public static class ConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddConfig(
             this IServiceCollection services, IConfiguration config)
        {
            services.Configure<BudgeteeOptions>(config);
            return services;
        }
    }
}
