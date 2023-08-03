using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class PlayerForCreationDto
    {
        [Required(ErrorMessage = "Name field is required.")]
        [MaxLength(50,ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname field is required.")]
        [MaxLength(50, ErrorMessage = "Surname cannot exceed 50 characters.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "HeightInCm field is required.")]
        public int HeightInCm { get; set; }

        public int HeightInInches        
        {
            get
            {
                return (int)Math.Floor(HeightInCm/2.54);
            }
        }
        [Required(ErrorMessage = "Position field is required.")]
        public string Position { get; set; }

    }
}
