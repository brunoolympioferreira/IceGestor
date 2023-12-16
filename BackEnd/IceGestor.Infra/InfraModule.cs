using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.Infra.Persistence;
using IceGestor.Infra.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IceGestor.Infra;
public static class InfraModule
{
    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services
            .AddScoped<IUnityOfWork, UnityOfWork>()
            .AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
