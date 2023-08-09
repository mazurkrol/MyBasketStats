using MyBasketStats.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class GameDto
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
        public int RoadTeamGameStatsheetId { get; set; }

        public int HomeTeamPoints { get; set; }
        public int RoadTeamPoints { get; set; }
    }
}
