
using MyBasketStats.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class ContractDto
    {
        public int Id { get; set; }
        public int Salary { get; set; }
        public List<SeasonDto> Seasons { get; set; }
    }
}
