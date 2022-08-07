using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MAUI.CleanArchitecture
{
	[Register("AppDelegate")]
	public class AppDelegate : MauiUIApplicationDelegate
	{
        protected override MauiApp CreateMauiApp()
        {
            var app = MauiProgram.CreateMauiApp();
            return app;
        }
    }
}