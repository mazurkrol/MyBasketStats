namespace MyBasketStats.API.Services.BackgroundServicesManager
{
    public interface IBackgroundServiceManager
    {
        void StartBackgroundService();
        void StopBackgroundService();
    }
}
