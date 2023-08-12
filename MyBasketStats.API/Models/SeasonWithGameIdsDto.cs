namespace MyBasketStats.API.Models
{
    public class SeasonWithGameIdsDto
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public TeamDto? ChampionshipTeam { get; set; }
        public int ChampionshipTeamId { get; set; }
        public PlayerDto? FinalsMvp { get; set; }
        public int FinalsMvpId { get; set; }
        public List<int>? GamesIds { get; set; }
    }
}
