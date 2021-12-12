using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Application.Common.Models;
using MAUI.CleanArchitecture.Application.Common.Notificications;
using MAUI.CleanArchitecture.Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.User.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, SigninNotification>
    {
        private readonly IAuthentication _authentication;

        public LoginCommandHandler(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public async Task<SigninNotification> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _authentication.SignInAsync(request);
            var userInfo = new UserInfo { User = user, IsSignedIn = true};
            return new SigninNotification { UserInfo = userInfo };
        }
    }
}
