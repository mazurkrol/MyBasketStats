using MyBasketStats.API.Entities;

namespace MyBasketStats.API.Models
{
    public class GameWithStatsheetsDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HomeTeamId { get; set; }
        public int RoadTeamId { get; set; }
        public int TimeElapsedSeconds { get; set; }
        public GameStateEnum GameState { get; set; }
        public int WinningTeamId { get; set; }
        public int LosingTeamId { get; set; }
        public int HomeTeamGameStatsheetId { get; set; }
        public TeamGameStatsheetDto? HomeTeamStatsheet { get; set; }
        public int RoadTeamGameStatsheetId { get; set; }
        public TeamGameStatsheetDto? RoadTeamStatsheet { get; set; }

        public int HomeTeamPoints { get; set; }
        public int RoadTeamPoints { get; set; }
    }
}
