using Assets.Scripts.Api.Interfaces;
using Assets.Scripts.GameData.StaticData;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Api
{
    public class CatalogApiClient : ICatalogApiClient
    {
        private readonly HttpClient _httpClient;


        public CatalogApiClient(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CatalogData> GetCatalogAsync(
            string token,
            CancellationToken ct = default)
        {
            using var request =
                new HttpRequestMessage(
                    HttpMethod.Get,
                    "api/catalog");


            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);


            var response =
                await _httpClient.SendAsync(
                    request,
                    ct);


            response.EnsureSuccessStatusCode();


            var json =
                await response.Content.ReadAsStringAsync();


            var catalog =
                JsonUtility
                    .FromJson<CatalogData>(json);


            return catalog
                ?? throw new Exception(
                    "Catalog data is null.");
        }
    }
}
