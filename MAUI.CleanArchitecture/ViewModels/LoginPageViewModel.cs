using MAUI.CleanArchitecture.Application.MainModel.Queries;
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
        public LoginPageViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public string Login { get; set; }
        public string Password { get; set; }



        public ICommand LoginCommand => new Command(() => LoginHandlerAsync(), () => true);

        private async void LoginHandlerAsync()
        {
            
        }
    }
}
