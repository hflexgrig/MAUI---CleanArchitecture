using FluentValidation;
using MAUI.CleanArchitecture.Application.MainModel.Queries;
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

namespace MAUI.CleanArchitecture.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<LoginCommand> _validator;
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

        private void LoginHandlerAsync()
        {

        }
    }
}
