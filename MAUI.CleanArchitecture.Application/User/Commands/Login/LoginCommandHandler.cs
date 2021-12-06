using MAUI.CleanArchitecture.Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.User.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseModel>
    {
        public Task<LoginResponseModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return request.Login == "admin" && request.Password == "admin" ? Task.FromResult(new LoginResponseModel { IsSucceeded = true})
              :  Task.FromResult(new LoginResponseModel { IsSucceeded = false, FailReason = "Wrong username or password." });
        }
    }
}
