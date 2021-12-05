using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using MAUI.Application;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.ViewModels;
using CleanArchitecture.ViewModels.Base;

namespace CleanArchitecture
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
			services.AddScoped(typeof(MainPageViewModel));

			services.AddApplication();

			var sp = services.BuildServiceProvider();
			
			ViewModelLocator.ServiceProvider = sp;
			return builder.Build();
		}
	}
}