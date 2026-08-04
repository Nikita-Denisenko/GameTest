using Assets.Scripts.Api.Interfaces;
using Assets.Scripts.GameData.StaticData;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Api
{
    public class CatalogApiClient : ICatalogApiClient
    {
        private readonly HttpClient _httpClient;

        public CatalogApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatalogData> GetCatalogAsync(
        CancellationToken ct = default)
        {
            var response = await _httpClient.GetAsync(
                "api/catalog",
                ct);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var catalog = JsonConvert.DeserializeObject<CatalogData>(json);

            return catalog
                ?? throw new Exception("Catalog not found");
        }
    }
}
