using AutoMapper;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.PlayerServices
{
    public class PlayerService : BasicService<PlayerDto, Player>, IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IMapper mapper, IBasicRepository<Player> basicRepository, IPlayerRepository playerRepository) : base(mapper, basicRepository)
        {
            _playerRepository=playerRepository;
        }
        
        public async Task<PlayerDto> AddPlayerAsync(PlayerForCreationDto player)
        {
            var playerToAdd = _mapper.Map<Player>(player);
           
                await _playerRepository.AddPlayerToDbAsync(playerToAdd);
                var playerToReturn = _mapper.Map<PlayerDto>(playerToAdd);
                return playerToReturn;
            
        }
    }
}
