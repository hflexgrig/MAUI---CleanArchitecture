using MAUI.CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Common.Notificications
{
    public class AddCardItemNotification : INotification
    {
        public CardItem CardItem { get; set; }
    }
}
