using MyBasketStats.API.Entities;
using MyBasketStats.API.Models;
using MyBasketStats.API.Services.Basic;

namespace MyBasketStats.API.Services.StatsheetServices
{
    public interface ISeasonService : IBasicService<StatsheetDto, Statsheet>
    {
    }
}
