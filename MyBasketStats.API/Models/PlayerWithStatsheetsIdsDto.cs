using MyBasketStats.API.Entities;

namespace MyBasketStats.API.Models
{
    public class PlayerWithStatsheetsIdsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int HeightInCm { get; set; }

        public int HeightInInches { get; set; }

        public string Position { get; set; }

        public int? TeamId { get; set; }

        public int TotalStatsheetId { get; set; }

        public int? ContractId { get; set; }
        public ICollection<StatsheetDto> SeasonalStatsheets { get; set; }
    }
}
