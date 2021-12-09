using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MAUI.CleanArchitecture.Application;
using MAUI.CleanArchitecture.ViewModels.Base;
using MAUI.CleanArchitecture.ViewModels;
using MAUI.CleanArchitecture.Utils;
using MAUI.CleanArchitecture.Infrastructure;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System;
using System.IO;
using System.Text.Json;
using MAUI.CleanArchitecture.Application.Settings;
using MAUI.CleanArchitecture.Infrastructure.BackgroundServices;

namespace MAUI.CleanArchitecture
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				});

			var services = builder.Services;


			//#if DEBUG
			//			var appSettingsStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MAUI.CleanArchitecture.Configuration.appsettings.debug.json");
			//#else
			//			var appSettingsStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("MAUI.CleanArchitecture.Configuration.appsettings.release.json");
			//#endif

			//			if (appSettingsStream == null)
			//			{
			//				throw new Exception("No appsettings json file");
			//			}

			//			AppSettings appSettings;
			//			using (var streamReader = new StreamReader(appSettingsStream))
			//			{
			//				var jsonString = streamReader.ReadToEnd();

			//				appSettings = JsonSerializer.Deserialize<AppSettings>(jsonString);
			//				if (appSettings is null)
			//				{
			//					throw new Exception("Can't deserialize appsettings.json file");
			//				}

			//				services.AddSingleton(appSettings);
			//			}
			var appSettings = new AppSettings() { ConnectionStrings = new ConnectionStrings { DefaultConnection = "Data Source={0}\\store.db" } };

			services.AddSingleton(appSettings);

			services.AddSingleton<IPageManager, PageManager>();
			services.AddApplication();
			services.AddInfrastructure(appSettings);

			ViewModelLocator.Initialize(services);
			return builder.Build();
		}
	}
}