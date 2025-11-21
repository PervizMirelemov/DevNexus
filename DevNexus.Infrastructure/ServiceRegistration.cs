using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DevNexus.Infrastructure.Storage;

namespace DevNexus.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IFormFileStorage, LocalFileStorage>();
    }
}