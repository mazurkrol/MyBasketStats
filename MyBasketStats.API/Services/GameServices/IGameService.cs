using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.GameServices
{
    public interface IGameService : IBasicService<GameDto, Game>
    {
        Task<(GameDto,Game)> CreateGameAsync(GameForCreationDto game);
    }
}
