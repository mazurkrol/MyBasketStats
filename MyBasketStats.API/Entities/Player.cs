using MyBasketStats.API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Entities
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Required]
        public int HeightInCm { get; set; }
        [Required]
        public int HeightInInches { get; set; }
        [Required]
        public string Position { get; set; }

        public Team? Team { get; set; }
        public int? TeamId { get; set; }

        public Statsheet TotalStatsheet { get; set; }
        public int TotalStatsheetId { get; set; }

        public Contract? Contract { get; set; }
        public int? ContractId { get; set; }

        public ICollection<Statsheet> SeasonalStatsheets { get; set; }
    }
}
