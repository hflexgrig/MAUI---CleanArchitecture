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
using MAUI.CleanArchitecture.Application.User.Commands.Register;
using MAUI.CleanArchitecture.Application.Common.Models;
using MAUI.CleanArchitecture.Utils;
using System.Threading;
using MAUI.CleanArchitecture.Application.Common.Notificications;
using Microsoft.Extensions.DependencyInjection;

namespace MAUI.CleanArchitecture.ViewModels
{
    public class RegisterPageViewModel : ViewModelBase
    {
        private readonly IMediator _mediator;
        private readonly IServiceProvider _serviceProvider;
        private readonly IValidator<RegisterCommand> _validator;
        private readonly UserInfo _userInfo;
        private RegisterCommand _registerModel = new RegisterCommand();
        public RegisterPageViewModel(IServiceProvider serviceProvider, IValidator<RegisterCommand> validator, UserInfo userInfo)
        {
            _serviceProvider = serviceProvider;
            _mediator = _serviceProvider.GetService<IMediator>();
            _validator = validator;
            _userInfo = userInfo;
            RegisterCommand = new Command(() => RegisterHandlerAsync(), () =>
            {
                var validationResult = _validator.Validate(_registerModel);
                Errors = validationResult.Errors;
                return validationResult.IsValid;
            });
        }

        public Command RegisterCommand { get; private set; }

        public string Username
        {
            get { return _registerModel.Username; }
            set
            {
                _registerModel.Username = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
            }
        }

        public string Email
        {
            get { return _registerModel.Email; }
            set
            {
                _registerModel.Email = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
            }
        }

        public string Password
        {
            get { return _registerModel.Password; }
            set
            {
                _registerModel.Password = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
            }
        }

        public string FirstName
        {
            get { return _registerModel.FirstName; }
            set
            {
                _registerModel.FirstName = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
            }
        }

        public string LastName
        {
            get { return _registerModel.LastName; }
            set
            {
                _registerModel.LastName = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
            }
        }


        public Task Handle(UserInfo notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async void RegisterHandlerAsync()
        {
            try
            {
                SignupNotification signUpNotification = null;
                using (var scope = _serviceProvider.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetService<IMediator>();
                    signUpNotification = await mediator.Send(_registerModel);
                }

                await _mediator.Publish(signUpNotification);
            }
            catch (Application.Common.Exceptions.ValidationException ex)
            {
                CustomErrors = ex.ValidationErrors.Select(x => new ValidationFailure(x.Key, x.Value));
            }
            catch(Exception ex)
            {

            }
        }
    }
}
