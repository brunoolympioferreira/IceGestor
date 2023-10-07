using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.Infra.Persistence.Repositories;

namespace IceGestor.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfraRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
