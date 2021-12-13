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
        private readonly UserInfo _userInfo;

        public RegisterCommandHandler(IAuthentication authentication, UserInfo userInfo)
        {
            _authentication = authentication;
            _userInfo = userInfo;
        }

        public async Task<SignupNotification> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var user = await _authentication.CreateUser(request);
            _userInfo.User = user;
            _userInfo.IsSignedIn = true;

            return new SignupNotification { UserInfo = _userInfo};
        }
    }
}
