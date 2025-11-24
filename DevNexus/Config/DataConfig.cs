using DevNexus.Application.Contexts;
using DevNexus.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;

namespace DevNexus.API.Config;

public static class DataConfig
{
    public static async Task AdminSeedDataConfigAsync(this WebApplication app) 
    {
        using var serviceScope = app.Services.CreateScope();

        var db = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>().Database;
       
        await db.MigrateAsync();

        var seeder = serviceScope.ServiceProvider.GetRequiredService<AdminSeeder>();
        await seeder.SeedAsync();
    }
}
