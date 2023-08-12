using AutoMapper;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;
using MyBasketStats.API.Services.SeasonServices;

namespace MyBasketStats.API.Services.PlayerServices
{
    public class PlayerService : BasicService<PlayerDto, Player, PlayerWithStatsheetsIdsDto>, IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ISeasonService _seasonService;
        public PlayerService(IMapper mapper, IBasicRepository<Player> basicRepository, IPlayerRepository playerRepository, ISeasonService seasonService) : base(mapper, basicRepository)
        {
            _playerRepository=playerRepository;
            _seasonService=seasonService;
        }
        
        public async Task<PlayerDto> AddPlayerAsync(PlayerForCreationDto player)
        {
            var playerToAdd = _mapper.Map<Player>(player);
            playerToAdd.SeasonalStatsheets.Add(
                new Statsheet 
                { 
                    Season= await _seasonService.GetSeasonByYearAsync((int)DateTime.Now.Year) 
                });
                await _playerRepository.AddPlayerToDbAsync(playerToAdd);
                var playerToReturn = _mapper.Map<PlayerDto>(playerToAdd);
                return playerToReturn;
            
        }

        public async Task<OperationResult<ContractDto>> SignPlayerAsync(ContractForCreationDto contract, Player player, Team team)
        {
            Contract contractToAdd = new Contract();
            contractToAdd.SalaryInUsd = contract.SalaryInUsd;
            foreach(int id in contract.SeasonIds)
            {
                (bool,Season?) result = await _seasonService.CheckIfIdExistsAsync(id);
                if(result.Item1)
                {
                    contractToAdd.ContractSeasons.Add( new ContractSeason{Season = result.Item2 });
                }
                else
                {
                    return new OperationResult<ContractDto>
                    {
                        IsSuccess = false,
                        ErrorMessage = $"Season with id={id} doesn't exist.",
                        HttpResponseCode = 404
                    };
                }
            }
            await _playerRepository.AddNewPlayerContract(player, contractToAdd);

            return new OperationResult<ContractDto>
            {
                IsSuccess = true,
                Data = _mapper.Map<ContractDto>(contractToAdd),
                HttpResponseCode = 201
            };

        }
    }
}
