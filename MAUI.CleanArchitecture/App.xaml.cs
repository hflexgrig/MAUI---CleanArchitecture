using MAUI.CleanArchitecture.ViewModels.Base;
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

            var mainPage = new MainPageView();
            Navigation = new NavigationPage(mainPage);
            mainPage.Navigation.InitializeNavigation();
        }

        public NavigationPage Navigation { get; }

        protected override Window CreateWindow(IActivationState activationState) =>
        new Window(Navigation) { Title = "MAUI.CleanArchitecture" };
    }
}
