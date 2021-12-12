using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Common.Models
{
    public class UserInfo
    {
        public bool IsSignedIn { get; internal set; }
        
        public Domain.Entities.User User { get; internal set; } = new Domain.Entities.User();
    }
}
