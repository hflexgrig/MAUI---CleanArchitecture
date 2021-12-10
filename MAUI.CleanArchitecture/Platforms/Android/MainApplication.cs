using System;
using Android.App;
using Android.Runtime;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace MAUI.CleanArchitecture
{
	[Application]
	public class MainApplication : MauiApplication
	{
		public MainApplication(IntPtr handle, JniHandleOwnership ownership)
			: base(handle, ownership)
		{
		}

        protected override MauiApp CreateMauiApp()
        {
			var app = MauiProgram.CreateMauiApp();
			app.StartAsync().GetAwaiter().GetResult();
            return app;
        }
    }
}