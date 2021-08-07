using System;
using AspNetCoreProje.Data;
using AspNetCoreProje.Data.Models;
using AspNetCoreProje.Service.BusinessService;
using AspNetCoreProje.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreProje.Configuration
{
    public static class AppServices
    {
        public static void AddDefaultServices(this IServiceCollection serviceCollection, IConfiguration Configuration)
        {
            serviceCollection.AddDbContext<AspNetCoreContext>();

            serviceCollection.AddHttpContextAccessor();

            serviceCollection.AddAuthentication();


            serviceCollection.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequiredLength = 1;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<AspNetCoreContext>();

            serviceCollection.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString("/Home/GirisYap");
                opt.Cookie.Name = "AspNetCoreProje";
                opt.Cookie.HttpOnly =
                    true;
                opt.Cookie.SameSite =
                    SameSiteMode
                        .Strict;
                opt.ExpireTimeSpan =
                    TimeSpan.FromMinutes(30);
            });

            serviceCollection
                .AddControllersWithViews().AddRazorRuntimeCompilation();

            serviceCollection.AddSession();
        }

        public static void AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ISepetService, SepetService>();
            serviceCollection.AddScoped<IKategoriService, KategoriService>();
            serviceCollection.AddScoped<IUrunService, UrunService>();
            serviceCollection.AddScoped<IUrunKategoriService, UrunKategoriService>();
        }
    }
}