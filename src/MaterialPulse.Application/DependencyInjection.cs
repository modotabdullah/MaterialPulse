using MaterialPulse.Application.Inventory;
using Microsoft.Extensions.DependencyInjection;

namespace MaterialPulse.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IInventoryService, InventoryService>();
        return services;
    }
}