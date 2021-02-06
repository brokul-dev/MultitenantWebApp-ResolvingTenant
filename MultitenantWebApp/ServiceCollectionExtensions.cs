using Microsoft.Extensions.DependencyInjection;

namespace MultitenantWebApp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMultitenancy(this IServiceCollection services)
        {
            services.AddScoped<TenantContext>();

            services.AddScoped<ITenantContext>(provider => 
                provider.GetRequiredService<TenantContext>());

            services.AddScoped<ITenantSetter>(provider => 
                provider.GetRequiredService<TenantContext>());

            services.AddScoped<ITenantStore, TenantStore>();
            return services;
        }
    }
}