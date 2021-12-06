using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Domain.User
{
    public class LoginResponseModel
    {
        public bool IsSucceeded { get; set; }
        public string? FailReason { get; set; }
    }
}
