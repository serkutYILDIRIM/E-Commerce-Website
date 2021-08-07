using Microsoft.AspNetCore.Identity;
using AspNetCoreProje.Data.Models;

namespace AspNetCoreProje
{
    public class IdentityInitializer
    {
        public static void OlusturAdmin(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            AppUser appUser = new AppUser
            {
                Name = "Serkut",
                SurName = "Yıldırım",
                UserName = "serkut"
            };
            if (userManager.FindByNameAsync("Serkut").Result == null)
            {
                var identityResult = userManager.CreateAsync(appUser, "1").Result;
            }
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };
                var identityResult = roleManager.CreateAsync(role).Result;

                var Result = userManager.AddToRoleAsync(appUser, role.Name).Result;
            }
        }
    }
}
