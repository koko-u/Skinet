using Microsoft.EntityFrameworkCore;
using Skinet.Infrastructure.Data;

namespace Skinet.Api;

public static class ApplyMigrationExtensions
{
    public static async Task ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var dbContext = serviceProvider.GetRequiredService<StoreDbContext>();
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        try
        {
            await dbContext.Database.MigrateAsync();
            await StoreDbContextSeed.SeedAsync(dbContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Something wrong during migration");
            throw;
        }
    }
}