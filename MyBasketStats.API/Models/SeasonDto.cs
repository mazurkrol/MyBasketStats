using MyBasketStats.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class SeasonDto
    {
        public int Id { get; set; }
        public TeamDto? ChampionshipTeam { get; set; }
        public int ChampionshipTeamId { get; set; }
        public PlayerDto? FinalsMvp { get; set; }
        public int FinalsMvpId { get; set; }
    }
}
