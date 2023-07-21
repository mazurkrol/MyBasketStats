using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBasketStats.API.Entities
{
    public class Statsheet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Season? Season { get; set; }
        public int? SeasonId { get; set; }
        public int GamesPlayed { get; set; }
        public int TwoPointersMade { get; set; }
        public int TwoPointersAttempted { get; set; }
        public int ThreePointersMade { get; set; }
        public int ThreePointersAttempted { get; set; }
        public int FreeThrowsMade { get; set; }
        public int FreeThrowsAttempted { get; set; }
        //public int Points
        //{
        //    get
        //    {
        //        return 3*ThreePointersMade+2*TwoPointersMade+FreeThrowsMade;
        //    }
        //}
        //public double TrueShootingPercentage
        //{
        //    get
        //    {
        //        return Points/2*(ThreePointersAttempted+TwoPointersAttempted+0.44*FreeThrowsAttempted);
        //    }
        //}
        public int Rebounds { get; set; }
        public int Steals { get; set; }
        public int Assists { get; set; }      
    }
}
