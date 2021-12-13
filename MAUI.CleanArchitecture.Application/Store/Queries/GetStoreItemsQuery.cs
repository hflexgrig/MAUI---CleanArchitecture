using MAUI.CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Store.Queries
{
    public class GetStoreItemsQuery:IRequest<IList<CardItem>>
    {
    }
}
