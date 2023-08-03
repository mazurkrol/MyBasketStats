using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Entities
{
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
        public int TimeElapsedSeconds { get; set; } = 0;
        public bool IsFinished { get; set; } = false;

        public TeamGameStatsheet HomeTeamGameStatsheet { get; set; } = new TeamGameStatsheet();
        public int HomeTeamGameStatsheetId { get; set; }
        public TeamGameStatsheet RoadTeamGameStatsheet { get; set; } = new TeamGameStatsheet();
        public int RoadTeamGameStatsheetId { get; set; }

        public int HomeTeamPoints { get; set; }
        public int RoadTeamPoints { get; set; }

    }
}
