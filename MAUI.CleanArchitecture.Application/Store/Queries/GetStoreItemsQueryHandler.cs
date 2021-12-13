using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Store.Queries
{
    public class GetStoreItemsQueryHandler : IRequestHandler<GetCardItemsQuery, IList<CardItem>>
    {
        private readonly IFakeStoreApiService _fakeStoreApiService;
        private readonly IStoreDbContext _storeDbContext;

        public GetStoreItemsQueryHandler(IFakeStoreApiService fakeStoreApiService, IStoreDbContext storeDbContext)
        {
            _fakeStoreApiService = fakeStoreApiService;
            _storeDbContext = storeDbContext;
        }

        public async Task<IList<CardItem>> Handle(GetCardItemsQuery request, CancellationToken cancellationToken)
        {
            var cardItems = await _storeDbContext.CardItems.Include(x => x.StoreItem).ToListAsync(cancellationToken);
            if (!cardItems.Any())
            {
                var storeItems = await _fakeStoreApiService.GetStoreItems(cancellationToken);
                cardItems = storeItems.Select(x => new CardItem { StoreItem = x }).ToList();
                _storeDbContext.CardItems.AddRange(cardItems);
                await _storeDbContext.SaveChangesAsync(cancellationToken);
            }
            
            return cardItems;
        }
    }
}
