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

			services.AddSingleton<IPageManager, PageManager>();
			services.AddApplication();
			services.AddInfrastructure();
			
			ViewModelLocator.Initialize(services);
			return builder.Build();
		}
	}
}