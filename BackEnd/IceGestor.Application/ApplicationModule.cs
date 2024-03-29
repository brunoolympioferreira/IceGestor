﻿using IceGestor.Application.Authentication;
using IceGestor.Application.Services.Product;
using IceGestor.Application.Services.Product.Category;
using IceGestor.Application.Services.Product.Flavor.CreateFlavor;
using IceGestor.Application.Services.Product.Flavor.DeleteFlavor;
using IceGestor.Application.Services.Product.Flavor.GetFlavors;
using IceGestor.Application.Services.Product.Flavor.UpdateFlavor;
using IceGestor.Application.Services.Stock;
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
        AddProductModule(services);
        AddStockModule(services);
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

    private static IServiceCollection AddProductModule(this IServiceCollection services) 
    {
        services
            .AddScoped<ICreateFlavorService, CreateFlavorService>()
            .AddScoped<IGetFlavorsService, GetFlavorsService>()
            .AddScoped<IUpdateFlavorService, UpdateFlavorService>()
            .AddScoped<IDeleteFlavorService, DeleteFlavorService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<IProductService, ProductService>();

        return services;
    }

    private static IServiceCollection AddStockModule(this IServiceCollection services)
    {
        services
            .AddScoped<IProductStockService, ProductStockService>();

        return services;
    }
}
