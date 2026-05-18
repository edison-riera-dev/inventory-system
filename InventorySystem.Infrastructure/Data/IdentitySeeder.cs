using Microsoft.AspNetCore.Identity;

namespace InventorySystem.Infrastructure.Data;

public static class IdentitySeeder
{
    public static async Task SeedAsync(UserManager<IdentityUser> userManager)
    {
        const string email = "admin@demo.com";
        const string password = "Admin123*";

        var user = await userManager.FindByEmailAsync(email);

        if (user != null)
            return;

        var adminUser = new IdentityUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(adminUser, password);
    }
}