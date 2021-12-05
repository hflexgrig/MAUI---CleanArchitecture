using MAUI.CleanArchitecture.Views;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

namespace MAUI.CleanArchitecture
{
	public partial class App : Microsoft.Maui.Controls.Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new MainPageView();
		}
	}
}
