using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.ViewModels.Base
{
    public static class ViewModelLocator
    {
        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static ServiceProvider ServiceProvider { get; internal set; }

        public static bool GetAutoWireViewModel(BindableObject bindableObject)
        {
            return (bool)bindableObject.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindableObject,bool value)
        {
            bindableObject.SetValue(AutoWireViewModelProperty, value);
        }

        

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view is null) return;

            var viewType = view.GetType();
            var viewModelName = $"{viewType.FullName.Replace(".Views.", ".ViewModels.")}Model";
            //var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            //var viewModelName
            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null) return;

            var viewModel = ServiceProvider.GetRequiredService(viewModelType);

            view.BindingContext = viewModel;
        }
    }
}
