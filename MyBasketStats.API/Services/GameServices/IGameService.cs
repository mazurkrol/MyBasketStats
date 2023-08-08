using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.GameServices
{
    public interface IGameService : IBasicService<GameDto, Game>
    {
        Task<(GameDto,Game)> CreateGameAsync(GameForCreationDto game);
        Task<OperationResult<GameDto>> StartGameAsync(int gameid);
        Task<OperationResult<GameDto>> FinishGameAsync(int gameid);
        Task<OperationResult<GameDto>> StartGameClock(int gameid);
        Task<OperationResult<GameDto>> StopGameClock(int gameid);
    }
}
