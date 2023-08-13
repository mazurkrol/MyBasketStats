using MyBasketStats.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Models
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
