using AutoMapper;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;
using MyBasketStats.API.Services.SeasonServices;

namespace MyBasketStats.API.Services.GameServices
{
    public class GameService : BasicService<GameDto, Game>, IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IMapper mapper, IBasicRepository<Game> basicRepository, IGameRepository gameRepository) : base(mapper, basicRepository)
        {
            _gameRepository=gameRepository;
        }

        public async Task<(GameDto,Game)> CreateGameAsync(GameForCreationDto game)
        {
            var gameToAdd = _mapper.Map<Game>(game);
            await _gameRepository.AddGameAsync(gameToAdd);
            return (_mapper.Map<GameDto>(gameToAdd),gameToAdd);
        }


    }
    
    
}
