using MyBasketStats.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class SeasonForCreationDto
    {
        [Required(ErrorMessage = "The Year field is required.")]
        [Range(2000, 2100, ErrorMessage = "The Year must be between 2000 and 2100.")]
        public int Year { get; set; }

    }
}
