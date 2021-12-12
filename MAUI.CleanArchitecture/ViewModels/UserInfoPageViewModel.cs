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
    public class UserInfoPageViewModel : ViewModelBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMediator _mediator;
        private readonly IValidator<LoginCommand> _validator;
        private readonly IPageManager _pageManager;
        private LoginCommand _loginModel = new LoginCommand();
        private IServiceScope _scope;

        public UserInfoPageViewModel( UserInfo userInfo)
        {
            User = userInfo.User;
        }

        public Domain.Entities.User User { get; }

    }
}
