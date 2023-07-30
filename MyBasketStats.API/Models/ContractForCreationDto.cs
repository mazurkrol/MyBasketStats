using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class ContractForCreationDto
    {
        [Required]
        [Range(500000,300000000)]
        public int SalaryInUsd { get; set; }
        [MinLength(1)]
        [MaxLength(4)]
        [Required]
        public List<int> SeasonIds { get; set; }
    }
}
