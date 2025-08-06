using HelpDesk_Benedict.Models;
using Microsoft.AspNetCore.Identity;

namespace HelpDesk_Benedict.Data
{
    public class SeedAdmin {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider) {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var roles = new[] { "Admin", "Support", "Dozent" };
            foreach (var role in roles) {
                if (!await roleManager.RoleExistsAsync(role)) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            await CreateUserIfNotExists(userManager, "admin@system.local", "Admin123!", "Admin");

            await CreateUserIfNotExists(userManager, "support@system.local", "Support123!", "Support");

            await CreateUserIfNotExists(userManager, "dozent@system.local", "Dozent123!", "Dozent");

            
        }
        private static async Task CreateUserIfNotExists(UserManager<ApplicationUser> userManager, string email, string password, string role) {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null) {
                user = new ApplicationUser {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, role);
                } else {
                    // Optional: Logge Fehler hier
                    throw new Exception($"Fehler beim Erstellen des Users {email}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }
    }
}

