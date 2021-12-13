using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Maui;

namespace MAUI.CleanArchitecture
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : MauiAppCompatActivity
	{
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Java.Lang.JavaSystem.LoadLibrary("System.Security.Cryptography.Native.OpenSsl");
            base.OnCreate(savedInstanceState);
        }
    }
}