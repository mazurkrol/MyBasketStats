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
        private readonly PeriodicTimer _timer;

        public GameClockService(IGameClockRepository gameClockRepository, IDictionaryService dictionaryService) 
        {
            _gameClockRepository = gameClockRepository;
            _dictionaryService = dictionaryService;
            _timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000));
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
                    await _timer.WaitForNextTickAsync();
                    game.TimeElapsedSeconds++;
                    await _gameClockRepository.SaveChangesAsync();
                    if (game.TimeElapsedSeconds%720 == 0)                    //end of quarter
                    {
                        StopGameClock(gameid);
                    }
                }


        }

    }
}
