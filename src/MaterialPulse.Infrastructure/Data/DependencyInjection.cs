using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MaterialPulse.Application.Common;

namespace MaterialPulse.Infrastructure.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<IApplicationDbContext>(sp => 
            sp.GetRequiredService<ApplicationDbContext>());
        return services;
    }
}