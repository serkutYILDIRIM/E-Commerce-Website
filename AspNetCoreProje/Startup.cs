using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using AspNetCoreProje.Configuration;
using AspNetCoreProje.Data.Models;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreProje
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultServices(Configuration);
            services.AddCustomServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager) //Identity iþlemler, için user manager ve role manager'ý kullandýk
        {
            app.AddDefaultConfiguration(env);

            IdentityInitializer.OlusturAdmin(userManager, roleManager);
        }
    }
}
