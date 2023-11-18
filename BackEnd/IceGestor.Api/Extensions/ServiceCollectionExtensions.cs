using IceGestor.Application.Authentication;
using IceGestor.Application.Services.User.CreateUser;
using IceGestor.Application.Services.User.Login;
using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.CrossCutting.Nlog;
using IceGestor.Infra.Persistence;
using IceGestor.Infra.Persistence.Repositories;

namespace IceGestor.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
    {
        //Repositories
        services.AddScoped<IUnityOfWork, UnityOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();

        //Services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICreateUserService, CreateUserService>();
        services.AddScoped<IUserLoginService, UserLoginService>();
        services.AddScoped<IloggerManager, LoggerManager>();

        return services;
    }
}
