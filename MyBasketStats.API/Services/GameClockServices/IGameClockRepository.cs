using Microsoft.EntityFrameworkCore;
using MyBasketStats.API.Entities;

namespace MyBasketStats.API.Services.GameClockServices
{
    public interface IGameClockRepository
    {
        Task<Game> GetGameEntityAsync(int gameid);

        Task SaveChangesAsync();

    }
}
