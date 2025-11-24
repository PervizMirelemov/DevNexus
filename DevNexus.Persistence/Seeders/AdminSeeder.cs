using DevNexus.Domain.Entities.Identity;
using DevNexus.Application.Constans;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Authentication;

namespace DevNexus.Persistence.Seeders;

public class AdminSeeder(UserManager<AppUser> _userManager, IConfiguration _config)
{
    /// <summary> 
    /// Generate default admin credentials in database based on appsetting.json file. 
    /// (The appsettings file changes according to the environment)
    /// If credentials change anytime it will update the database when application restarted.
    /// </summary>
    /// <exception cref="AuthenticationException"></exception>
    public async Task SeedAsync()
    {

        string username = _config["AdminCredentials:UserName"]!;
        string password = _config["AdminCredentials:Password"]!;

        AppUser? admin = await _userManager.FindByNameAsync(username);
        if (admin is null)
        {
            admin = new()
            {
                Id = new Guid(1, 0, 0, new byte[8]),
                UserName = username,
                NormalizedUserName = username.ToUpper()
            };

            IdentityResult result = await _userManager.CreateAsync(admin, password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, ApplicationRoles.Admin);
            }
            else throw new AuthenticationException(result.Errors.First().Description);
        }
        else
        {
            admin.UserName = username;
            admin.PasswordHash = _userManager.PasswordHasher.HashPassword(admin, password);
            await _userManager.UpdateAsync(admin);
        }
    }
}
