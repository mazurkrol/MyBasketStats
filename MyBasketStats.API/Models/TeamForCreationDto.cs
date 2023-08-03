using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class TeamForCreationDto
    {
        [MaxLength(100,ErrorMessage = "Name cannot exceed 100 characters.")]
        [Required(ErrorMessage = "Name field is required.")]
        public string Name { get; set; }
    }
}
