using MAUI.CleanArchitecture.Application.Common.Models;
using MAUI.CleanArchitecture.Application.Store.Queries;
using MAUI.CleanArchitecture.Domain.Entities;
using MAUI.CleanArchitecture.Utils;
using MAUI.CleanArchitecture.ViewModels.Base;
using MediatR;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI.CleanArchitecture.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotificationHandler<UserInfo>
    {
        private readonly IMediator _mediator;
        private readonly IPageManager _pageManager;

        public Command RegisterCommand { get; }
        public Command ToolbarItem1Command { get; }
        private bool _notClicked = true;
        public MainPageViewModel(IMediator mediator, IPageManager pageManager, UserInfo userInfo)
        {
            _mediator = mediator;
            _pageManager = pageManager;
            UserInfo = userInfo;
            ToolbarItem1Command = new Command(LoginCommandHandler, (x) => _notClicked);
            RegisterCommand = new Command(RegisterCommandHandler, (x) => _notClicked);
            LoadItems();
        }

        private async void LoadItems()
        {
            StoreItems = await _mediator.Send(new GetStoreItemsQuery());
        }

        private async void LoginCommandHandler(object obj)
        {
            var loginPageRes = await _pageManager.StartPageAsync<LoginPageViewModel>();
            loginPageRes.PropertyChanged += LoginPageRes_PropertyChanged;
            _notClicked = false;
            ToolbarItem1Command.ChangeCanExecute();
        }

        private void LoginPageRes_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var el = sender as INotifyPropertyChanged;
            el.PropertyChanged -= LoginPageRes_PropertyChanged;
            switch (e.PropertyName)
            {
                default:
                    ToolbarItem1Text = $"Welcome {UserInfo.User}";
                    ToolbarItem1Logo = "signup.png";
                    break;
            }
        }

        private async void RegisterCommandHandler(object obj)
        {
            var loginPageRes = await _pageManager.StartPageAsync<RegisterPageViewModel>();
            _notClicked = false;
            ToolbarItem1Command.ChangeCanExecute();
        }

        public Task Handle(UserInfo notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private bool _isButtonEnabled = true;
        private IList<StoreItem> _storeItems;

        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set { _isButtonEnabled = value; OnPropertyChanged(); }
        }

        private string _toolbarItem1Text = "SignIn";

        public string ToolbarItem1Text
        {
            get { return _toolbarItem1Text; }
            set { _toolbarItem1Text = value; OnPropertyChanged(); }
        }

        private string _ToolbarItem1Logo = "login.png";

        public string ToolbarItem1Logo
        {
            get { return _ToolbarItem1Logo; }
            set { _ToolbarItem1Logo = value; OnPropertyChanged(); }
        }


        public IList<StoreItem> StoreItems
        {
            get => _storeItems; private set
            {
                _storeItems = value;
                OnPropertyChanged();
            }
        }

        public UserInfo UserInfo { get; }
    }
}
