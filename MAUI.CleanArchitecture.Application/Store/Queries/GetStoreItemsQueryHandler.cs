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
    public class GetStoreItemsQueryHandler : IRequestHandler<GetStoreItemsQuery, IList<StoreItem>>
    {
        private readonly IFakeStoreApiService _fakeStoreApiService;

        public GetStoreItemsQueryHandler(IFakeStoreApiService fakeStoreApiService)
        {
            _fakeStoreApiService = fakeStoreApiService;
        }

        public Task<IList<StoreItem>> Handle(GetStoreItemsQuery request, CancellationToken cancellationToken)
        {
            return _fakeStoreApiService.GetStoreItems(cancellationToken);
        }
    }
}
