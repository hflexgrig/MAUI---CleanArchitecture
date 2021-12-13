using System;
using MAUI.CleanArchitecture.ViewModels.Base;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace MAUI.CleanArchitecture.Views
{
	public partial class MainPageView : ContentPage
	{

		public MainPageView()
		{
			InitializeComponent();
		}

        private void NumericStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {

        }

        private void NumericStepper_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}
