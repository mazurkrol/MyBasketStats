namespace MyBasketStats.API.Models
{
    public class ContractWithSeasonIdsDto
    {
        public int Id { get; set; }
        public int SalaryInUsd { get; set; }
        public List<int> SeasonsIds { get; set; }
    }
}
