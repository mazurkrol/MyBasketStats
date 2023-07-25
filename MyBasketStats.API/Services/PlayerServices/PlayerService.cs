using AutoMapper;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;

namespace MyBasketStats.API.Services.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        public PlayerService(IPlayerRepository playerRepository, IMapper mapper)
        {
            _playerRepository=playerRepository;
            _mapper=mapper;
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
