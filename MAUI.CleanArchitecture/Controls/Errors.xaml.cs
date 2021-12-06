using FluentValidation.Results;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MAUI.CleanArchitecture.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Errors : ContentView
    {
        public Errors()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ForPropertyProperty = BindableProperty.Create(nameof(ForProperty), typeof(string), typeof(Errors), default(string));

        public string ForProperty
        {
            get => (string)GetValue(ForPropertyProperty);
            set => SetValue(ForPropertyProperty, value);
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<ValidationFailure>), typeof(Errors), new List<ValidationFailure>());

        public IEnumerable<ValidationFailure> ItemsSource
        {
            get
            {
                var fullList = (IEnumerable<ValidationFailure>)GetValue(ItemsSourceProperty);
                return fullList?.Where(x => string.IsNullOrEmpty(ForProperty) || x.PropertyName == ForProperty);
            }

            set => SetValue(ItemsSourceProperty, value);
        }

    }
}
