using MyBasketStats.API.Services.GameServices;
using MyBasketStats.API.Services.DictionaryServices;
using System.Collections.Concurrent;
using Serilog;

namespace MyBasketStats.API.Services.GameClockServices
{
    public class GameClockService : IGameClockService
    {
        private readonly IGameClockRepository _gameClockRepository;
        private readonly IDictionaryService _dictionaryService;

        public GameClockService(IGameClockRepository gameClockRepository, IDictionaryService dictionaryService) 
        {
            _gameClockRepository = gameClockRepository;
            _dictionaryService = dictionaryService;
        }
        public async Task StartGameClockAsync(int gameid)
        {
            if (!_dictionaryService._gameClocks.ContainsKey(gameid))
            {
                var cancellationTokenSource = new CancellationTokenSource();
                _dictionaryService._gameClocks.TryAdd(gameid, cancellationTokenSource);

                await UpdateGameClockAsync(gameid, cancellationTokenSource.Token);
            }
        }

        public void StopGameClock(int gameid)
        {
            if (_dictionaryService._gameClocks.TryGetValue(gameid, out var cancellationTokenSource))
            {
                cancellationTokenSource.Cancel();
                _dictionaryService._gameClocks.TryRemove(gameid, out _);
            }
        }

        private async Task UpdateGameClockAsync(int gameid, CancellationToken cancellationToken)
        {
            
            
                var game = await _gameClockRepository.GetGameEntityAsync(gameid);

                while (!cancellationToken.IsCancellationRequested)
                {
                    game.TimeElapsedSeconds++;
                    var time = DateTime.UtcNow;
                    await _gameClockRepository.SaveChangesAsync();
                    await Task.Delay(time.AddSeconds(1)-DateTime.UtcNow);
                    if (game.TimeElapsedSeconds%720 == 0)                    //end of quarter
                    {
                        StopGameClock(gameid);
                    }
                }


        }
    }
}
