using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBasketStats.API.Entities
{
    public class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Year field is required.")]
        [Range(2000, 2100, ErrorMessage = "The Year must be between 2000 and 2100.")]
        public int Year { get; set; }

        [ForeignKey("ChampionshipTeamId")]
        public Team? ChampionshipTeam { get; set; }
        public int? ChampionshipTeamId { get; set; }
        [ForeignKey("FinalsMvpId")]
        public Player? FinalsMvp { get; set; }
        public int? FinalsMvpId { get; set; }
    }
}
