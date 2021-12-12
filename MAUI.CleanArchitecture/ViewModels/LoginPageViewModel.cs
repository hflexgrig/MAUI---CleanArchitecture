using FluentValidation;
using FluentValidation.Results;
using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Application.User.Commands.Login;
using MAUI.CleanArchitecture.Domain;
using MAUI.CleanArchitecture.ViewModels.Base;
using MediatR;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MAUI.CleanArchitecture.Application.Common.Exceptions;
using MAUI.CleanArchitecture.Application.Common.Models;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using MAUI.CleanArchitecture.Utils;

namespace MAUI.CleanArchitecture.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<LoginCommand> _validator;
        private readonly IPageManager _pageManager;
        private LoginCommand _loginModel = new LoginCommand();

        public LoginPageViewModel(IMediator mediator, IValidator<LoginCommand> validator, IPageManager pageManager)
        {
            _mediator = mediator;
            _validator = validator;
            _pageManager = pageManager;
            LoginCommand = new Command(() => LoginHandlerAsync(), () =>
            {
                var validationResult = _validator.Validate(_loginModel);
                Errors = validationResult.Errors;
                return validationResult.IsValid;
            });

            StartRegisterCommand = new Command(() => StartRegisterHandler());
        }

        private async void StartRegisterHandler()
        {
            // await _pageManager.PopPageAsync();
            await _pageManager.StartPageAsync<RegisterPageViewModel>();
        }

        public Command LoginCommand { get; private set; }
        public Command StartRegisterCommand { get; }

        public string Login
        {
            get { return _loginModel.Username; }
            set { _loginModel.Username = value; OnPropertyChanged(); LoginCommand.ChangeCanExecute(); }
        }

        public string Password
        {
            get { return _loginModel.Password; }
            set { _loginModel.Password = value; OnPropertyChanged(); LoginCommand.ChangeCanExecute(); }
        }

        private async void LoginHandlerAsync()
        {
            try
            {
                var signinNotification = await _mediator.Send(_loginModel);
                await _mediator.Publish(signinNotification);
            }
            catch (Application.Common.Exceptions.ValidationException ex)
            {
                CustomErrors = ex.ValidationErrors.Select(x => new ValidationFailure(x.Key, x.Value));
            }
        }

    }
}
