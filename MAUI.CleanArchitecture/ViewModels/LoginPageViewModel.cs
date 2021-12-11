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

namespace MAUI.CleanArchitecture.ViewModels
{
    public class LoginPageViewModel : ViewModelBase, INotificationHandler<UserInfo>
    {
        private readonly IMediator _mediator;
        private readonly IValidator<LoginCommand> _validator;
        private readonly IAuthentication _authentication;
        private LoginCommand _loginModel = new LoginCommand();
        public LoginPageViewModel(IMediator mediator, IValidator<LoginCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
            LoginCommand = new Command(() => LoginHandlerAsync(), () =>
            {
                var validationResult = _validator.Validate(_loginModel);
                Errors = validationResult.Errors;
                return validationResult.IsValid;
            });
        }

        public Command LoginCommand { get; private set; }

        public string Login
        {
            get { return _loginModel.Login; }
            set { _loginModel.Login = value;OnPropertyChanged();  LoginCommand.ChangeCanExecute(); }
        }

        public string Password
        {
            get { return _loginModel.Password; }
            set { _loginModel.Password = value; OnPropertyChanged();  LoginCommand.ChangeCanExecute(); }
        }

        public Task Handle(UserInfo notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async void LoginHandlerAsync()
        {
            try
            {
                await _mediator.Publish(new UserInfo());

                //var result = await _authentication.CreateUser(Login, Password);

            }
            catch (Application.Common.Exceptions.ValidationException ex)
            {
                CustomErrors = ex.ValidationErrors.Select(x => new ValidationFailure(x.Key, x.Value));
            }
        }
    }
}
