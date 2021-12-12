using MAUI.CleanArchitecture.Application.Common.Models;
using MAUI.CleanArchitecture.Application.Common.Notificications;
using MAUI.CleanArchitecture.Application.Store.Queries;
using MAUI.CleanArchitecture.Domain.Entities;
using MAUI.CleanArchitecture.Utils;
using MAUI.CleanArchitecture.ViewModels.Base;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI.CleanArchitecture.ViewModels
{
    public class MainPageViewModel : ViewModelBase, 
        INotificationHandler<SigninNotification>,
        INotificationHandler<SignupNotification>
    {
        private readonly IMediator _mediator;
        private readonly IPageManager _pageManager;

        public Command ToolbarItem1Command { get; private set; }
        public MainPageViewModel(IMediator mediator, IPageManager pageManager, UserInfo userInfo)
        {
            _mediator = mediator;
            _pageManager = pageManager;
            UserInfo = userInfo;
            ToolbarItem1Command = new Command(LoginCommandHandler, (x) => UserInfo.IsSignedIn == false);
            LoadItems();
        }

        private async void LoadItems()
        {
            StoreItems = await _mediator.Send(new GetStoreItemsQuery());
        }

        private async void LoginCommandHandler(object obj)
        {
            if (UserInfo.IsSignedIn)
            {
                await _pageManager.StartPageAsync<UserInfoPageViewModel>();
            }
            else
            {
                var loginPageRes = await _pageManager.StartPageAsync<LoginPageViewModel>();
                ToolbarItem1Command.ChangeCanExecute();
            }
        }

        #region handlers
        public Task Handle(SignupNotification notification, CancellationToken cancellationToken)
        {
            return ImplementSigninNotification(notification.UserInfo);
        }

        public Task Handle(SigninNotification notification, CancellationToken cancellationToken)
        {
            return ImplementSigninNotification(notification.UserInfo);
        }
        #endregion

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

        public UserInfo UserInfo { get; private set; }

        private async Task ImplementSigninNotification(UserInfo userInfo)
        {
            UserInfo = userInfo;
            OnPropertyChanged(nameof(UserInfo));
            await _pageManager.PopToRootPageAsync();
            ToolbarItem1Text = $"Welcome {userInfo.User.UserName}";
            ToolbarItem1Logo = "signup.png";
        }

    }
}
