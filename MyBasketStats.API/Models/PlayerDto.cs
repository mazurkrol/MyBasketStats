using MyBasketStats.API.Entities;
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

        public TeamDto? Team { get; set; }
        public int TeamId { get; set; }

        public StatsheetDto TotalStatsheet { get; set; }
        public int TotalStatsheetId { get; set; }

        public ContractDto? Contract { get; set; }
        public int ContractId { get; set; }
    }
}
