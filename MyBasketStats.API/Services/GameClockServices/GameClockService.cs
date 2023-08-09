using MyBasketStats.API.Services.GameServices;
using MyBasketStats.API.Services.DictionaryServices;
using System.Collections.Concurrent;
using Serilog;

namespace MyBasketStats.API.Services.GameClockServices
{
    public class GameClockService : IGameClockService
    {
        private readonly IDictionaryService _dictionaryService;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly PeriodicTimer _timer;

        public GameClockService( IDictionaryService dictionaryService, IServiceScopeFactory scopeFactory) 
        {
            _dictionaryService = dictionaryService;
            _timer = new PeriodicTimer(TimeSpan.FromMilliseconds(1000));
            _scopeFactory = scopeFactory;
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
            
            
                

                while (!cancellationToken.IsCancellationRequested)
                {
                    await _timer.WaitForNextTickAsync();
                    var scope = _scopeFactory.CreateScope();
                    var _gameClockRepository = scope.ServiceProvider.GetRequiredService<IGameClockRepository>();                
                    var game = await _gameClockRepository.GetGameEntityAsync(gameid);
                    game.TimeElapsedSeconds++;
                    await _gameClockRepository.SaveChangesAsync();
                    scope.Dispose();
                    if (game.TimeElapsedSeconds%720 == 0)                    //end of quarter
                    {
                        StopGameClock(gameid);
                    }
                }


        }

    }
}
