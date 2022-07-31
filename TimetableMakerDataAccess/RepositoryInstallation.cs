using Microsoft.Extensions.DependencyInjection;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Repository;

namespace TimetableMakerDataAccess;

public static class RepositoryInstallation
{
    public static IServiceCollection AddRepositoryApplication(this IServiceCollection services) {
        services.AddSingleton<IModeRepository, ModeRepository>();
        services.AddSingleton<ILocationRepository, LocationRepository>();
        services.AddSingleton<ILineRepository, LineRepository>();
        services.AddSingleton<IRouteRepository, RouteRepository>();
        return services;
    }
}
