using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Entities
{
    public class TeamGameStatsheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TwoPointersMade { get; set; } = 0;
        public int TwoPointersAttempted { get; set; } = 0;
        public int ThreePointersMade { get; set; } = 0;
        public int ThreePointersAttempted { get; set; } = 0;
        public int FreeThrowsMade { get; set; } = 0;
        public int FreeThrowsAttempted { get; set; } = 0;
        public int Rebounds { get; set; } = 0;
        public int Steals { get; set; } = 0;
        public int Assists { get; set; } = 0;
        public int Blocks { get; set; } = 0;
        public int Turnovers { get; set; } = 0;
        public int Fouls { get; set; } = 0;
    }   
}
