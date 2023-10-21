﻿using IceGestor.Application.Services.User.CreateUser;
using IceGestor.Core.RepositoriesInterfaces;
using IceGestor.Infra.Persistence.Repositories;

namespace IceGestor.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfraRepositories(this IServiceCollection services)
    {
        //Repositories
        services.AddScoped<IUserRepository, UserRepository>();

        //Services
        services.AddScoped<ICreateUserService, CreateUserService>();

        return services;
    }
}
