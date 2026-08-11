using Assets.Scripts.Api.Interfaces;
using Assets.Scripts.GameData.Runs;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            int? catId,
            string token,
            CancellationToken ct = default)
        {
            var requestData = new
            {
                arenaId,
                playerUnitId,
                catId
            };

            var json = JsonUtility.ToJson(requestData);

            using var request = new HttpRequestMessage(
                HttpMethod.Post,
                "api/runs/prepare-run");

            request.Content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            request.Headers.Authorization =
                new AuthenticationHeaderValue(
                    "Bearer",
                    token);

            var response = await _httpClient.SendAsync(
                request,
                ct);

            response.EnsureSuccessStatusCode();

            var responseJson =
                await response.Content.ReadAsStringAsync();

            var preparation =
                JsonUtility.FromJson<RunPreparationData>(
                    responseJson);

            return preparation
                ?? throw new Exception(
                    "Run preparation is null.");
        }
    }
}