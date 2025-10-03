using AccessibilityHub.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccessibilityHub.WebApp.Extensions;

public static class ServiceExtensions
{
    public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AccessibilityDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("AccessibilityHubDb"))
        );
    }
}
