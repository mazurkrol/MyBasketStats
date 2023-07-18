using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBasketStats.API.Entities
{
    public class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Salary { get; set; }
        public List<Season> Seasons { get; set; }
        public Player Player { get; set; }
        public int PlayerId { get; set; }
    }
}
