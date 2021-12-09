using MAUI.CleanArchitecture.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static INavigation Navigation { get; private set; }

        internal static void InitializeNavigation(this INavigation navigation)
        {
            Navigation = navigation;
        }

        internal static void Initialize(IServiceCollection services)
        {
            Services = services;
            var watch = Stopwatch.StartNew();
            var viewsAndViewModels = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && x.GetInterface("INotifyPropertyChanged") != null).ToList();
            watch.Stop();

            Debug.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            var viewModels = viewsAndViewModels.Where(x => x.Name.EndsWith("ViewModel")).ToList();
            var views = viewsAndViewModels.Where(x => x.Name.EndsWith("View")).ToList();

            ViewToViewModelDict = Enumerable.Join<Type, Type, string, ValueTuple<Type, Type>>(views, viewModels, x => x.Name, y => y.Name, (view, viewModel) => (view, viewModel), new ViewToViewModelComparer()).ToDictionary(x => x.Item1, y => y.Item2);
            ViewModelToViewDict = ViewToViewModelDict.ToDictionary(x => x.Value, x => x.Key);

            foreach (Type vm in viewModels)
            {
                services.AddTransient(vm);
            }

            ServiceProvider = services.BuildServiceProvider();
            ViewModelsRegistered = true;
        }

        internal static async Task<bool> StartPage<TViewModel>()
        {
            var viewModelType = typeof(TViewModel);

            if (!viewModelType.Name.EndsWith("PageViewModel") || !ViewModelToViewDict.TryGetValue(viewModelType, out var viewType))
            {
                return false;
            }

            var viewInstance = Activator.CreateInstance(viewType);

            if (viewInstance is Page view)
            {
                await Navigation.PushAsync(view);
            }
            else
            {
                return false;
            }

            return true;
        }

        private static bool ViewModelsRegistered = false;

        private static ServiceProvider ServiceProvider;
        private static IServiceCollection Services;
        private static Dictionary<Type, Type> ViewToViewModelDict;
        private static Dictionary<Type, Type> ViewModelToViewDict;

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
            
            if (!ViewToViewModelDict.TryGetValue(viewType, out var viewModelType))
            {
                return;
            }

            while (!ViewModelsRegistered)
            {

            }
            var viewModel = ServiceProvider.GetRequiredService(viewModelType);

            view.BindingContext = viewModel;
        }

        public class ViewToViewModelComparer : IEqualityComparer<string>
        {
            public bool Equals(string l, string r)
            {
                return $"{l}Model" == r || $"{r}Model" == l;
            }

            public int GetHashCode(string obj)
            {
                return obj.EndsWith("Model") ? obj.Replace("Model", string.Empty).GetHashCode() : obj.GetHashCode();
            }
        }
    }
}
