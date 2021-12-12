using MAUI.CleanArchitecture.Domain.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.User.Commands.Login
{
    public class LoginCommand:IRequest<Domain.Entities.User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
