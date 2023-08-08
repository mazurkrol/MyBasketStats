using Microsoft.EntityFrameworkCore;
using MyBasketStats.API.Services.DictionaryServices;
using MyBasketStats.API.Services.GameClockServices;

namespace MyBasketStats.API.Services.BackgroundClockServices
{
    public class BackgroundClockService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IDictionaryService _dictionaryService;
       

        public BackgroundClockService(IServiceScopeFactory scopeFactory, IDictionaryService dictionaryService)
        {
            _scopeFactory = scopeFactory;
            _dictionaryService = dictionaryService;
            
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
                while (!stoppingToken.IsCancellationRequested)
                {

                    foreach (int id in _dictionaryService._startClockIds)
                    {
                        var scope = _scopeFactory.CreateScope();
                        
                        var _gameClockService = scope.ServiceProvider.GetRequiredService<IGameClockService>();
                        _gameClockService.StartGameClockAsync(id);
                        
                        
                    }
                    _dictionaryService._startClockIds.Clear();
                    foreach (int id in _dictionaryService._stopClockIds)
                    {
                        var scope = _scopeFactory.CreateScope();
                        
                        var _gameClockService = scope.ServiceProvider.GetRequiredService<IGameClockService>();
                        _gameClockService.StopGameClock(id);
                                              
                    }
                    _dictionaryService._stopClockIds.Clear();
                    await Task.Delay(300);
                }
            
        }
    }
}
