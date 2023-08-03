using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MyBasketStats.API.Models
{
    public class GameForCreationDto
    {
        [Required(ErrorMessage = "DateTime field is required.")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "HomeTeamId field is required.")]
        public int HomeTeamId { get; set; }
        [Required(ErrorMessage = "RoadTeamId field is required.")]
        public int RoadTeamId { get; set; }

    }
}
