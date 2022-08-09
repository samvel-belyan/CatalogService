using IdentityManagement.Constants;
using Microsoft.AspNetCore.Identity;

namespace IdentityManagement.Seed;

public static class DefaultRoles
{
    public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Buyer.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));
    }
}
