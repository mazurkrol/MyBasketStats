namespace MyBasketStats.API.Services.GameClockServices
{
    public interface IGameClockService
    {       
            Task StartGameClockAsync(int gameid);
            void StopGameClock(int gameid);       
    }
}
