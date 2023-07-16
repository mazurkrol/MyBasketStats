using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Entities
{
    public class PlayerSeasonStatsheet
    {
        [Key]
        public int PlayerId { get; set; }
        [Key]
        public int SeasonId { get; set; }
        public Player Player { get; set; }     
        public Season Season { get; set; }        
        public Statsheet Statsheet { get; set; }

    }
}
