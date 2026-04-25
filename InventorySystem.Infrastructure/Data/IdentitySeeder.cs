using Microsoft.AspNetCore.Identity;

namespace InventorySystem.Infrastructure.Data;

public static class IdentitySeeder
{
    public static async Task SeedAsync(UserManager<IdentityUser> userManager)
    {
        const string email = "admin@demo.com";
        const string password = "Admin123*";

        var user = await userManager.FindByEmailAsync(email);

        if (user is null)
        {
            user = new IdentityUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(user, password);
        }
    }
}