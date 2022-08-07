using AutoMapper;
using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Application.User.Commands.Login;
using MAUI.CleanArchitecture.Application.User.Commands.Register;
using MAUI.CleanArchitecture.Domain.Entities;
using MAUI.CleanArchitecture.Infrastructure.BackgroundServices;
using MAUI.CleanArchitecture.Infrastructure.Identity;
using MAUI.CleanArchitecture.Infrastructure.Persistence;
using MAUI.CleanArchitecture.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MAUI.CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHostedService<DbBackgroundService>();

            services.AddHttpClient(nameof(FakeStoreApiService), t =>
            {
                t.BaseAddress = new Uri("https://fakestoreapi.com");
            }).AddTypedClient<IFakeStoreApiService, FakeStoreApiService>();

            services.AddDbContext<IStoreDbContext, StoreDbContext>();
            // services.AddIdentity<ApplicationUser, IdentityRole>()
            //     .AddEntityFrameworkStores<StoreDbContext>()
            //     .AddDefaultTokenProviders();
            // services.AddScoped<IAuthentication, AuthenticationService>();


            services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<ApplicationUser, User>().ReverseMap();
                cfg.CreateMap<ApplicationUser, RegisterCommand>().ReverseMap();
                cfg.CreateMap<ApplicationUser, LoginCommand>().ReverseMap();
            });

            return services;
        }
    }
}
