using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Store.Queries.GetStoreItemsQuery
{
    public class GetStoreItemsQueryHandler : IRequestHandler<GetStoreItemsQuery, IList<StoreItem>>
    {
        private readonly IFakeStoreApiService _fakeStoreApiService;
        private readonly IStoreDbContext _storeDbContext;

        public GetStoreItemsQueryHandler(IFakeStoreApiService fakeStoreApiService, IStoreDbContext storeDbContext)
        {
            _fakeStoreApiService = fakeStoreApiService;
            _storeDbContext = storeDbContext;
        }

        public Task<IList<StoreItem>> Handle(GetStoreItemsQuery request, CancellationToken cancellationToken)
        {
            return _fakeStoreApiService.GetStoreItems(cancellationToken);
        }
    }
}
