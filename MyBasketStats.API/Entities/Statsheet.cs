namespace MyBasketStats.API.Entities
{
    public class Statsheet
    {
        public int Id { get; set; }
        public Player Player { get; set; }  
        public int PlayerId { get; set; }
        public Season? Season { get; set; }
        public int? SeasonId { get; set; }
        public int GamesPlayed { get; set; }
        public int TwoPointersMade { get; set; }
        public int TwoPointersMissed { get; set; }
        public int ThreePointersMade { get; set; }
        public int ThreePointersMissed { get; set; }
        public int FreeThrowsMade { get; set; }
        public int FreeThrowsMissed { get; set; }
        public int Points { get; set; }
        public int Rebounds { get; set; }
        public int Steals { get; set; }
        public int Assists { get; set; }      
    }
}
