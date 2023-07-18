using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBasketStats.API.Entities
{
    public class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Team? ChampionshipTeam { get; set; }
        public int ChampionshipTeamId { get; set; }
        public Player? FinalsMvp { get; set; }
        public int FinalsMvpId { get; set; }
    }
}
