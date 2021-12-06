using MAUI.CleanArchitecture.Application.Common.Interfaces;
using MAUI.CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.CleanArchitecture.Infrastructure.Services
{
    public class FakeStoreApiService:IFakeStoreApiService
    {
        private readonly HttpClient _httpClient;

        public FakeStoreApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<StoreItem>> GetStoreItems(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync("products", cancellationToken);
            return await response.Content.ReadFromJsonAsync<IList<StoreItem>>(cancellationToken: cancellationToken);
        }

    }
}
