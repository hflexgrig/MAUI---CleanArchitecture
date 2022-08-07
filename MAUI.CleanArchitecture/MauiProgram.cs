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
            var config = new ConfigurationBuilder()
                .AddJsonStream(appSettingsStream)
                .Build();
            builder.Configuration.AddConfiguration(config);
            builder.Services.AddSingleton<IPageManager, PageManager>();
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();
            ViewModelLocator.Initialize(builder.Services);
           
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