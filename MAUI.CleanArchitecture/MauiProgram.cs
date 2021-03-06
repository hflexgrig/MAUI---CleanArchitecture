using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using MAUI.CleanArchitecture.Application;
using MAUI.CleanArchitecture.ViewModels.Base;
using MAUI.CleanArchitecture.ViewModels;
using MAUI.CleanArchitecture.Utils;
using MAUI.CleanArchitecture.Infrastructure;
using System.Reflection;
using System;
using System.IO;
using System.Text.Json;
using MAUI.CleanArchitecture.Application.Settings;
using MAUI.CleanArchitecture.Infrastructure.BackgroundServices;
using Microsoft.Extensions.Configuration;

namespace MAUI.CleanArchitecture
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
#if DEBUG
            var appSettingsStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MAUI.CleanArchitecture.Configuration.appsettings.debug.json");
#else
			var appSettingsStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MAUI.CleanArchitecture.Configuration.appsettings.release.json");
#endif
          
            var builder = MauiApp.CreateBuilder();
            builder.Configuration.AddJsonStream(appSettingsStream);
            builder.Services.AddSingleton<IPageManager, PageManager>();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();
            ViewModelLocator.Initialize(builder.Services);
            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Host.ConfigureAppConfiguration((prop, config) =>
            //    config.AddJsonStream(appSettingsStream)
            //);

            //builder.Host.ConfigureServices((context, services) =>
            //{
            //    services.AddSingleton<IPageManager, PageManager>();
            //    services.AddApplication();
            //    services.AddInfrastructure();

            //    ViewModelLocator.Initialize(services);

            //    var connString = context.Configuration.GetConnectionString("DefaultConnection");
            //});
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            return builder.Build();
        }
    }
}