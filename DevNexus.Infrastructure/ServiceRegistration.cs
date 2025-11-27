using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DevNexus.Infrastructure.Storage;
using DevNexus.Application.Storage; // Important: Import the Application namespace

namespace DevNexus.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        // Register the Application interface with the Infrastructure implementation
        services.AddSingleton<IStorage, LocalFileStorage>();
    }
}