using Assets.Scripts.Api.Interfaces;
using Assets.Scripts.GameData.Runs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Assets.Scripts.Api
{
    public class RunPreparationApiClient : IRunPreparationApiClient
    {
        private readonly HttpClient _httpClient;

        public RunPreparationApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RunPreparationData> GetPreparationAsync(
            int playerId,
            CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync(
                $"api/runs/preparation/{playerId}",
                cancellationToken);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RunPreparationData>(json)
                ?? throw new Exception("Run preparation is null");
        }
    }
}
