using MAUI.CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Card.Commands.CreateCardItem
{
    public class CreateCardItemCommand:IRequest
    {
        public CardItem CardItem { get; set; }
    }
}
