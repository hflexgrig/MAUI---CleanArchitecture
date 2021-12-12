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

namespace MAUI.CleanArchitecture.Application.User.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, SignupNotification>
    {
        private readonly IAuthentication _authentication;

        public RegisterCommandHandler(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public async Task<SignupNotification> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _authentication.CreateUser(request);
            var userInfo = new UserInfo { User = user, IsSignedIn = true};
            return new SignupNotification { UserInfo = userInfo};
        }
    }
}
