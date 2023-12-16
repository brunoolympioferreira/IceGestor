using IceGestor.Application.Authentication;
using IceGestor.Application.Services.User.CreateUser;
using IceGestor.Application.Services.User.Login;
using IceGestor.CrossCutting.Nlog;
using Microsoft.Extensions.DependencyInjection;

namespace IceGestor.Application;
public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<ICreateUserService, CreateUserService>()
            .AddScoped<IUserLoginService, UserLoginService>()
            .AddScoped<IloggerManager, LoggerManager>();

        return services;
    }
}
