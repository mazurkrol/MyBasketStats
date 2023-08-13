namespace MyBasketStats.API.Models
{
    public class TeamWithPlayersDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PlayerDto> Players { get; set; }
    }
}
