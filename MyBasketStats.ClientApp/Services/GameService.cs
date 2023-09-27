using MyBasketStats.Client;
using MyBasketStats.ClientApp.Helpers;
using MyBasketStats.ClientApp.Models;
using System.Text.Json;

namespace MyBasketStats.ClientApp.Services
{
    public class GameService : IGameService
    {
        private readonly string _route = "api/games";
        private readonly JsonSerializerOptionsWrapper _jsonSerializerOptionsWrapper;
        private readonly MyBasketStatsAPIClient _moviesAPIClient;

        public GameService(JsonSerializerOptionsWrapper jsonSerializerOptionsWrapper,
             MyBasketStatsAPIClient MyBasketStatsAPIClient) 
        {
            _jsonSerializerOptionsWrapper = jsonSerializerOptionsWrapper ??
            throw new ArgumentNullException(nameof(jsonSerializerOptionsWrapper));
            _moviesAPIClient = MyBasketStatsAPIClient ??
                throw new ArgumentNullException(nameof(MyBasketStatsAPIClient));
        }

        public async Task TestAsync()
        {
            await GetGame(1);
        }
        public async Task<GameDto> GetGame(int id)
        {
            var content = await _moviesAPIClient.GetResourceAsync(_route, id);
            var game = JsonSerializer.Deserialize<GameDto>(content,
            _jsonSerializerOptionsWrapper.Options);
            return game;
        }
    }
}
