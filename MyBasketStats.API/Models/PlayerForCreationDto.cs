using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class PlayerForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        public int HeightInCm { get; set; }

        public int HeightInInches        
        {
            get
            {
                return (int)Math.Floor(HeightInCm/2.54);
            }
        }
        [Required]
        public string Position { get; set; }

    }
}
