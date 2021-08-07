using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCoreProje.Configuration
{
    public static class AppConfiguration
    {
        public static void AddDefaultConfiguration(this IApplicationBuilder applicationBuilder,
            IWebHostEnvironment webHostEnvironment)
        {
            applicationBuilder.UseStatusCodePagesWithReExecute("/Home/NotFound", "?code={0}");

            applicationBuilder.UseExceptionHandler("/Error");

            applicationBuilder.UseRouting();

            applicationBuilder.UseStaticFiles();

            applicationBuilder.UseSession();

            applicationBuilder.UseAuthentication();
            applicationBuilder
                .UseAuthorization();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areas", pattern: "{area}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(name: "default", pattern:
                    "{Controller=Home}/{Action=Index}/{id?}");


            });
        }
    }
}
