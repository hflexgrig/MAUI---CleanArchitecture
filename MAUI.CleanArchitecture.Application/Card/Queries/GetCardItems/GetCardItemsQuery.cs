using MAUI.CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Card.Queries.GetCardItems
{
    public class GetCardItemsQuery : IRequest<List<CardItem>>
    {
        public Guid SessionId { get; set; }
        public Guid? UserId { get; set; }
    }
}
