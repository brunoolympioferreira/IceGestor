﻿using IceGestor.Application.Authentication;
using IceGestor.Application.Services.User.CreateUser;
using IceGestor.Application.Services.User.Login;
using IceGestor.Application.Services.User.UpdateUser;
using IceGestor.CrossCutting.Nlog;
using Microsoft.Extensions.DependencyInjection;

namespace IceGestor.Application;
public static class ApplicationModule
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddCrossCuttingModule(services);
        AddUserModule(services);
    }

    private static IServiceCollection AddCrossCuttingModule(this IServiceCollection services)
    {
        services
            .AddScoped<IAuthService, AuthService>()
            .AddScoped<IloggerManager, LoggerManager>();

        return services;
    }

    private static IServiceCollection AddUserModule(this IServiceCollection services)
    {
        services
            .AddScoped<ICreateUserService, CreateUserService>()
            .AddScoped<IUserLoginService, UserLoginService>()
            .AddScoped<IUpdateUserService, UpdateUserService>();

        return services;
    }
}
