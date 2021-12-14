using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Card.Queries.GetCardItems
{
    public class GetCardItemsQueryHandler : IRequestHandler<GetCardItemsQuery, List<CardItem>>
    {
        private readonly IStoreDbContext _storeDbContext;

        public GetCardItemsQueryHandler(IStoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public Task<List<CardItem>> Handle(GetCardItemsQuery request, CancellationToken cancellationToken)
        {
            return _storeDbContext.CardItems.AsNoTracking().Include(x => x.StoreItem)
                .Where(x => x.UserId == request.UserId || x.SessionId == request.SessionId)
                .ToListAsync(cancellationToken);
        }
    }
}
