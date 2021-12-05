using MAUI.CleanArchitecture.Domain;
using MAUI.CleanArchitecture.Utils;
using MAUI.CleanArchitecture.ViewModels.Base;
using MediatR;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Windows.Input;

namespace MAUI.CleanArchitecture.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IMediator _mediator;
        private readonly IPageManager _pageManager;

        public MainPageViewModel(IMediator mediator, Utils.IPageManager pageManager)
        {
            _mediator = mediator;
            _pageManager = pageManager;
        }

        private string _currentCount;

        public string CurrentCount
        {
            get => _currentCount;
            set { _currentCount = value; }
        }

        private IList<SubItem> _subItgems;

        public IList<SubItem> SubItems
        {
            get => _subItgems;
            set { _subItgems = value; OnPropertyChanged(); }
        }

        private bool _isButtonEnabled = true;

        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set { _isButtonEnabled = value;OnPropertyChanged(); }
        }


        public ICommand CounterClickedCommand => new Command(() => CounterClickedHandlerAsync(), () => true);

        private async void CounterClickedHandlerAsync()
        {
            var loginPageRes = await _pageManager.StartPage<LoginPageViewModel>();
            //IsButtonEnabled = true;
            //var mm = await _mediator.Send(new GetMainModelQuery());
            //SubItems = mm.SubItems;
            //CurrentCount = $"Current count: {mm.TotalQuantity}";
        }
    }
}
