using MAUI.CleanArchitecture.Application.Store.Queries;
using MAUI.CleanArchitecture.Domain.Entities;
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

        public Command LoginCommand { get; }
        private bool _notClicked = true;
        public MainPageViewModel(IMediator mediator, Utils.IPageManager pageManager)
        {
            _mediator = mediator;
            _pageManager = pageManager;
            LoginCommand = new Command(LoginCommandHandler, (x) => _notClicked);
            LoadItems();
        }

        private async void LoadItems()
        {
            StoreItems = await _mediator.Send(new GetStoreItemsQuery());
        }

        private async void LoginCommandHandler(object obj)
        {
            var loginPageRes = await _pageManager.StartPage<LoginPageViewModel>();
            _notClicked = false;
            LoginCommand.ChangeCanExecute();
        }



        private bool _isButtonEnabled = true;
        private IList<StoreItem> _storeItems;

        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set { _isButtonEnabled = value; OnPropertyChanged(); }
        }


        public ICommand CounterClickedCommand => new Command(() => CounterClickedHandlerAsync(), () => true);

        public IList<StoreItem> StoreItems
        {
            get => _storeItems; private set
            {
                _storeItems = value; 
                OnPropertyChanged();
            }
        }

        private async void CounterClickedHandlerAsync()
        {
            //IsButtonEnabled = true;
            //var mm = await _mediator.Send(new GetMainModelQuery());
            //SubItems = mm.SubItems;
            //CurrentCount = $"Current count: {mm.TotalQuantity}";
        }
    }
}
