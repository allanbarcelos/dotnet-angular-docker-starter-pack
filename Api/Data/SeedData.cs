using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bogus;
using Api.Models;

namespace Api.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()
            ))
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var environment = serviceProvider.GetRequiredService<IHostEnvironment>();

                var roles = new[] { "ADMIN", "STUDENT" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                if (userManager.Users.All(u => u.UserName != "admin@mail.com"))
                {
                    var adminUser = new ApplicationUser { UserName = "admin", Email = "admin@mail.com" };
                    await userManager.CreateAsync(adminUser, "AdminPassword123!");
                    await userManager.AddToRoleAsync(adminUser, "ADMIN");
                }

            }
        }
    }
}
