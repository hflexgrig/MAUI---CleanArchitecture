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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI.CleanArchitecture.ViewModels
{
    public class MainPageViewModel : ViewModelBase, 
        INotificationHandler<SigninNotification>,
        INotificationHandler<SignupNotification>,
        INotificationHandler<AddCardItemNotification>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        private readonly IPageManager _pageManager;
        private IList<CardItemViewModel> _cardItemViewModels;

        private string _toolbarItem1Text = "SignIn";
        private string _ToolbarItem1Logo = "login.png";

        public MainPageViewModel(IServiceProvider serviceProvider, IMediator mediator, IPageManager pageManager, UserInfo userInfo)
        {
            _serviceProvider = serviceProvider;
            _mediator = mediator;
            _pageManager = pageManager;
            UserInfo = userInfo;
            ToolbarItem1Command = new Command(LoginCommandHandler, (x) => UserInfo.IsSignedIn == false);
            LoadItems();
        }

        #region proeprties
        public Command ToolbarItem1Command { get; private set; }
        public UserInfo UserInfo { get; private set; }

        public string ToolbarItem1Text
        {
            get { return _toolbarItem1Text; }
            set { _toolbarItem1Text = value; OnPropertyChanged(); }
        }

        public string ToolbarItem1Logo
        {
            get { return _ToolbarItem1Logo; }
            set { _ToolbarItem1Logo = value; OnPropertyChanged(); }
        }

        public IList<CardItemViewModel> CardItemViewModels
        {
            get => _cardItemViewModels; private set
            {
                _cardItemViewModels = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region notifification handlers
        public Task Handle(SignupNotification notification, CancellationToken cancellationToken)
        {
            return ImplementSigninNotification(notification.UserInfo);
        }

        public Task Handle(SigninNotification notification, CancellationToken cancellationToken)
        {
            return ImplementSigninNotification(notification.UserInfo);
        }

        public Task Handle(AddCardItemNotification notification, CancellationToken cancellationToken)
        {
            //TODO: add to total for checkout
            return Task.CompletedTask;
        }
        #endregion


        private async void LoadItems()
        {
            var cardItems = await _mediator.Send(new GetCardItemsQuery());
            CardItemViewModels = cardItems.Select(x =>
            {
                var vm = _serviceProvider.GetService<CardItemViewModel>();
                vm.CardItem = x;
                return vm;
            }).ToList();
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

