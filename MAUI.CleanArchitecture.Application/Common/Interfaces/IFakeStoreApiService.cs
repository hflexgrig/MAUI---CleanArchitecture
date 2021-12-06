using MAUI.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Application.Common.Interfaces
{
    public interface IFakeStoreApiService
    {
        Task<IList<StoreItem>> GetStoreItems(CancellationToken cancellationToken);
    }
}
