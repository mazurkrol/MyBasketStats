using MyBasketStats.API.Services.BackgroundClockServices;
namespace MyBasketStats.API.Services.BackgroundServicesManager
{
    public class BackgroundServiceManager : IBackgroundServiceManager
    {
        private readonly BackgroundClockService _backgroundClockService;

        public BackgroundServiceManager(BackgroundClockService backgroundClockService)
        {
            _backgroundClockService = backgroundClockService;
        }

        public void StartBackgroundService()
        {
            _backgroundClockService.StartAsync(CancellationToken.None);
        }

        public void StopBackgroundService()
        {
            _backgroundClockService.StopAsync(CancellationToken.None);
        }
    }
}
