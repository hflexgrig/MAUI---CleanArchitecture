using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Application.Settings;
using MAUI.CleanArchitecture.Infrastructure.BackgroundServices;
using MAUI.CleanArchitecture.Infrastructure.Persistence;
using MAUI.CleanArchitecture.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, AppSettings appSettings)
        {
            //new DbBackgroundService(null);
            services.AddSingleton<DbBackgroundService>();

            services.AddHttpClient(nameof(FakeStoreApiService), t =>
            {
                t.BaseAddress = new Uri("https://fakestoreapi.com");
            }).AddTypedClient<IFakeStoreApiService, FakeStoreApiService>();

            services.AddDbContext<IStoreDbContext, StoreDbContext>(options => {
                var folder = Environment.SpecialFolder.LocalApplicationData;
                var path = Path.Combine(Environment.GetFolderPath(folder), "Test");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var dbPath = string.Format(appSettings.ConnectionStrings.DefaultConnection, path);
                options.UseSqlite(dbPath);
            });
            return services;
        }
    }
}
