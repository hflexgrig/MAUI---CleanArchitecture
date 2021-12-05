using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubItemView : ContentPage
    {
        public SubItemView()
        {
            InitializeComponent();
        }
    }
}
