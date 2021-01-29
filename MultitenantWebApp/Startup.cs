using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MultitenantWebApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMultitenancy();
        }
        
        public void Configure(IApplicationBuilder app)
        { 
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMiddleware<TenantResolutionMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
