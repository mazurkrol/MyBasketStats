using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class TeamGameStatsheetDto
    {
        public int Id { get; set; }
        public int TwoPointersMade { get; set; }
        public int TwoPointersAttempted { get; set; }
        public int ThreePointersMade { get; set; }
        public int ThreePointersAttempted { get; set; }
        public int FreeThrowsMade { get; set; }
        public int FreeThrowsAttempted { get; set; }
        public int Rebounds { get; set; }
        public int Steals { get; set; }
        public int Assists { get; set; }
        public int Blocks { get; set; }
        public int Turnovers { get; set; }
        public int Fouls { get; set; }
    }
}
