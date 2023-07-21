using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class TeamForCreationDto
    {
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
