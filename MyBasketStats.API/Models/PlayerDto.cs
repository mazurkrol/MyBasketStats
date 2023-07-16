using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyBasketStats.API.Models
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int HeightInCm { get; set; }
        public int HeightInInches { get; set; }
        public string Position { get; set; }


    }
}
