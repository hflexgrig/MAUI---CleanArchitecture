using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddHttpClient(nameof(FakeStoreApiService), t =>
            {
                t.BaseAddress = new Uri("https://fakestoreapi.com");
            }).AddTypedClient<IFakeStoreApiService, FakeStoreApiService>();

            return services;
        }
    }
}
