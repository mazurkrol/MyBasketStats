using AutoMapper;
using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;
using MyBasketStats.API.Services.DictionaryServices;
using MyBasketStats.API.Services.GameClockServices;
using MyBasketStats.API.Services.PlayerServices;
using MyBasketStats.API.Services.SeasonServices;
using MyBasketStats.API.Services.TeamServices;
using Microsoft.EntityFrameworkCore;

namespace MyBasketStats.API.Services.GameServices
{
    public class GameService : BasicService<GameDto, Game>, IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IDictionaryService _dictionaryService;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;
        private readonly ISeasonRepository _seasonRepository;
        public GameService(IMapper mapper, IBasicRepository<Game> basicRepository, 
            IGameRepository gameRepository, IDictionaryService dictionaryService, 
            IServiceScopeFactory scopeFactory, ITeamService teamService,
            IPlayerService playerService, ISeasonRepository seasonRepository) : base(mapper, basicRepository)
        {
            _gameRepository=gameRepository;
            _dictionaryService=dictionaryService;
            _scopeFactory=scopeFactory;
            _teamService =teamService;
            _playerService=playerService;
            _seasonRepository=seasonRepository;
        }

        public async Task<(GameDto,Game)> CreateGameAsync(GameForCreationDto game)
        {
            var gameToAdd = _mapper.Map<Game>(game);
            await _gameRepository.AddGameAsync(gameToAdd);
            return (_mapper.Map<GameDto>(gameToAdd),gameToAdd);
        }

        public async Task<OperationResult<GameDto>> StartGameAsync(int gameid)
        {
            var gameToStart = await _basicRepository.GetByIdAsync(gameid);
            if(gameToStart == null) 
            {
                return new OperationResult<GameDto>()
                {
                    IsSuccess = false,
                    HttpResponseCode = 404,
                    ErrorMessage = $"Game with id={gameid} could not be found"
                };
            }
            else
            if(gameToStart.GameState != GameStateEnum.Scheduled && (_dictionaryService.ActiveGamesIds.Contains(gameToStart.Id) || gameToStart.GameState == GameStateEnum.Finished))
            {
                return new OperationResult<GameDto>()
                {
                    IsSuccess = false,
                    HttpResponseCode = 409,
                    ErrorMessage = $"Game with id={gameid} is {gameToStart.GameState.ToString()}. Only Scheduled games can be started."
                };
            }
            else
            {

                _dictionaryService.ActiveGamesIds.Add(gameid);
                gameToStart.GameState = GameStateEnum.Active;
                await _basicRepository.SaveChangesAsync();
                return new OperationResult<GameDto>()
                {
                    IsSuccess = true,
                    HttpResponseCode = 200,
                    Data = _mapper.Map<GameDto>(gameToStart)
                };
            }
        }

        public async Task<OperationResult<GameDto>> FinishGameAsync(int gameid)
        {
            var gameToFinish = await _basicRepository.GetByIdAsync(gameid);
            if (gameToFinish == null)
            {
                return new OperationResult<GameDto>()
                {
                    IsSuccess = false,
                    HttpResponseCode = 404,
                    ErrorMessage = $"Game with id={gameid} could not be found"
                };
            }
            else
            if (gameToFinish.GameState != GameStateEnum.Active)
            {
                return new OperationResult<GameDto>()
                {
                    IsSuccess = false,
                    HttpResponseCode = 409,
                    ErrorMessage = $"Game with id={gameid} is {gameToFinish.GameState.ToString()}. Only Active games can be started."
                };
            }
            else
            {
                if(_dictionaryService._gameClocks.ContainsKey(gameid))
                {
                    await StopGameClock(gameid);
                }
                while(_dictionaryService._gameClocks.ContainsKey(gameid))
                {
                    await Task.Delay(100);
                }
                _dictionaryService.ActiveGamesIds.Remove(gameid);
                gameToFinish.GameState = GameStateEnum.Finished;
              
                await _basicRepository.SaveChangesAsync();
                return new OperationResult<GameDto>()
                {
                    IsSuccess = true,
                    HttpResponseCode = 200,
                    Data = _mapper.Map<GameDto>(gameToFinish)
                };
            }


        }

        public async Task<OperationResult<GameDto>> StartGameClock(int gameid)
        {
            if(!_dictionaryService.ActiveGamesIds.Contains(gameid))
            {
                return new OperationResult<GameDto>()
                {
                    IsSuccess = false,
                    HttpResponseCode = 404,
                    ErrorMessage = $"Game with id={gameid} could not be found among active games."
                };
            }
            else
            {
                var scope = _scopeFactory.CreateScope();

                var _gameClockService = scope.ServiceProvider.GetRequiredService<IGameClockService>();
                _gameClockService.StartGameClockAsync(gameid);
                return new OperationResult<GameDto>()
                {
                    IsSuccess = true,
                    HttpResponseCode = 200
                };
            }
        }

        public async Task<OperationResult<GameDto>> StopGameClock(int gameid)
        {
            if (!_dictionaryService.ActiveGamesIds.Contains(gameid))
            {               
                return new OperationResult<GameDto>()
                {
                    IsSuccess = false,
                    HttpResponseCode = 404,
                    ErrorMessage = $"Game with id={gameid} could not be found among active games."
                };
            }
            else
            {
                var scope = _scopeFactory.CreateScope();

                var _gameClockService = scope.ServiceProvider.GetRequiredService<IGameClockService>();
                _gameClockService.StopGameClock(gameid);
                return new OperationResult<GameDto>()
                {
                    IsSuccess = true,
                    HttpResponseCode = 200
                };
            }
        }

        public async Task<OperationResult<GameDto>> AddElapsedSecondsAsync(int gameid, int seconds)
        {
            if (!_dictionaryService.ActiveGamesIds.Contains(gameid))
            {
                return new OperationResult<GameDto>()
                {
                    IsSuccess = false,
                    HttpResponseCode = 404,
                    ErrorMessage = $"Game with id={gameid} could not be found among active games."
                };
            }
            else
            {
                var gameToModify = await _basicRepository.GetByIdAsync(gameid);
                gameToModify.TimeElapsedSeconds += seconds;
                await _basicRepository.SaveChangesAsync();
                return new OperationResult<GameDto>()
                {
                    IsSuccess = true,
                    HttpResponseCode = 200,
                    Data = _mapper.Map<GameDto>(gameToModify)
                };

            }
            
        }

        public async Task<OperationResult<GameDto>> SubtractElapsedSecondsAsync(int gameid, int seconds)
        {
            if (!_dictionaryService.ActiveGamesIds.Contains(gameid))
            {
                return new OperationResult<GameDto>()
                {
                    IsSuccess = false,
                    HttpResponseCode = 404,
                    ErrorMessage = $"Game with id={gameid} could not be found among active games."
                };
            }
            else
            {
                var gameToModify = await _basicRepository.GetByIdAsync(gameid);
                gameToModify.TimeElapsedSeconds -= seconds;
                await _basicRepository.SaveChangesAsync();
                return new OperationResult<GameDto>()
                {
                    IsSuccess = true,
                    HttpResponseCode = 200,
                    Data = _mapper.Map<GameDto>(gameToModify)
                };

            }
        }
        public async Task<OperationResult<GameDto>> ValidateGameData(int gameid, int playerid, int teamid)
        {
            if (!_dictionaryService.ActiveGamesIds.Contains(gameid))
            {
                return new OperationResult<GameDto>()
                {
                    IsSuccess = false,
                    HttpResponseCode = 404,
                    ErrorMessage = $"Game with id={gameid} could not be found among active games."
                };
            }
            else
            {
                var teamToCheck = await _teamService.GetEntityByIdWithEagerLoadingAsync(teamid, t => t.Players);
                var gameToCheck = await _basicRepository.GetByIdAsync(gameid);
                if (gameToCheck.HomeTeamId!=teamid&&gameToCheck.RoadTeamId!=teamid)
                {
                    return new OperationResult<GameDto>()
                    {
                        IsSuccess = false,
                        HttpResponseCode = 404,
                        ErrorMessage = $"Game with id={gameid} does not contain team with id={teamid}."
                    };
                }
                else
                if (teamToCheck.Players.Any(p => p.Id==playerid))
                {
                    return new OperationResult<GameDto>()
                    {
                        IsSuccess = true,
                        HttpResponseCode = 200
                    };
                }
                else
                {
                    return new OperationResult<GameDto>()
                    {
                        IsSuccess = false,
                        HttpResponseCode = 404,
                        ErrorMessage = $"Team with id={teamid} does not have player with id={playerid}."
                    };
                }
                    
            }
            

        }
        public async Task<OperationResult<GameDto>> ThreePointerAttemptAsync(int gameid, int playerid, int teamid, bool issuccessful)
        {
            var result = await ValidateGameData(gameid, playerid, teamid);
            if(!result.IsSuccess)
            {
                return result;
            }
            var playerToModify = await _playerService.GetEntityByIdWithEagerLoadingAsync(playerid, t => t.SeasonalStatsheets, c => c.TotalStatsheet);
            var gameToModify = await _basicRepository.GetByIdAsync(gameid);
            var IsHomeTeam = (bool)(gameToModify.HomeTeamId == teamid);
            if (issuccessful && IsHomeTeam)
            {
                gameToModify.HomeTeamPoints+=3;
                gameToModify.HomeTeamGameStatsheet.ThreePointersAttempted++;
                gameToModify.HomeTeamGameStatsheet.ThreePointersMade++;
            }
            else if(issuccessful)
            {
                gameToModify.RoadTeamPoints+=3;
                gameToModify.RoadTeamGameStatsheet.ThreePointersAttempted++;
                gameToModify.RoadTeamGameStatsheet.ThreePointersMade++;
            }
            else if(IsHomeTeam)
            {
                gameToModify.HomeTeamGameStatsheet.ThreePointersAttempted++;
            }
            else
            {
                gameToModify.RoadTeamGameStatsheet.ThreePointersAttempted++;
            }
            playerToModify.TotalStatsheet.ThreePointersAttempted++;
            var CurrentSeason = await _seasonRepository.GetSeasonByYearAsync((int)DateTime.Now.Year);
            var SeasonalStatsheet = playerToModify.SeasonalStatsheets.Where(s => s.SeasonId == CurrentSeason.Id).FirstOrDefault();
            SeasonalStatsheet.ThreePointersAttempted++;
            if (issuccessful)
            {                
                playerToModify.TotalStatsheet.ThreePointersMade++;
                SeasonalStatsheet.ThreePointersMade++;
            }
            await _basicRepository.SaveChangesAsync();
            return new OperationResult<GameDto>()
            {
                IsSuccess = true,
                HttpResponseCode = 200,
                Data=_mapper.Map<GameDto>(gameToModify)
            };
        }




    }
    
    
}
