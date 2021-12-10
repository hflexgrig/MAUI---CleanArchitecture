using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Infrastructure.BackgroundServices;
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
            return services;
        }
    }
}
