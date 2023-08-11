using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Entities
{
    public enum GameStateEnum { Scheduled, Active, Finished }
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Team HomeTeam { get; set; }
        public int HomeTeamId { get; set; }
        public Team RoadTeam { get; set; }
        public int RoadTeamId { get; set; }
        public Team? WinningTeam { get; set; }
        public int? WinningTeamId { get; set; }
        public Team? LosingTeam { get; set; }
        public int? LosingTeamId { get; set; }
        public int TimeElapsedSeconds { get; set; } = 0;
        public GameStateEnum GameState { get; set; } = 0;
        public TeamGameStatsheet? HomeTeamGameStatsheet { get; set; } = new TeamGameStatsheet();
        public int? HomeTeamGameStatsheetId { get; set; }
        public TeamGameStatsheet? RoadTeamGameStatsheet { get; set; } = new TeamGameStatsheet();
        public int? RoadTeamGameStatsheetId { get; set; }

        public int HomeTeamPoints { get; set; }
        public int RoadTeamPoints { get; set; }

    }
}
