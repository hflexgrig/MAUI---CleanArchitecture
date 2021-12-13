using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Store.Queries
{
    public class GetStoreItemsQueryHandler : IRequestHandler<GetStoreItemsQuery, IList<CardItem>>
    {
        private readonly IFakeStoreApiService _fakeStoreApiService;
        private readonly IStoreDbContext _storeDbContext;

        public GetStoreItemsQueryHandler(IFakeStoreApiService fakeStoreApiService, IStoreDbContext storeDbContext)
        {
            _fakeStoreApiService = fakeStoreApiService;
            _storeDbContext = storeDbContext;
        }

        public async Task<IList<CardItem>> Handle(GetStoreItemsQuery request, CancellationToken cancellationToken)
        {
            var storeItems = await _fakeStoreApiService.GetStoreItems(cancellationToken);
            var cardItems = storeItems.Select(x => new CardItem { StoreItem = x });

        }
    }
}
