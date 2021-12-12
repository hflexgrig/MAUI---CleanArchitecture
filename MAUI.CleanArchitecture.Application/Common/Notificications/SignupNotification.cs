using MAUI.CleanArchitecture.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Common.Notificications
{
    public class SignupNotification : INotification
    {
        public UserInfo? UserInfo { get; internal set; }
    }
}
