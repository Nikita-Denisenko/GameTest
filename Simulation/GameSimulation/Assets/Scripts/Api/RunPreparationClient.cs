using Assets.Scripts.Api.Interfaces;
using Assets.Scripts.GameData.Runs;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Api
{
    public class RunPreparationApiClient : IRunPreparationApiClient
    {
        private readonly HttpClient _httpClient;


        public RunPreparationApiClient(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<RunPreparationData> GetPreparationAsync(
            int arenaId,
            int playerUnitId,
            string token,
            CancellationToken ct = default)
        {
            using var request =
                new HttpRequestMessage(
                    HttpMethod.Get,
                    $"api/runs/preparation?playerUnitId={playerUnitId}&arenaId={arenaId}");


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


            var preparation =
                JsonUtility
                    .FromJson<RunPreparationData>(json);


            return preparation
                ?? throw new Exception(
                    "Run preparation is null.");
        }
    }
}
