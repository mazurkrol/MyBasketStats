using Microsoft.AspNetCore.Mvc;
using MyBasketStats.ClientApp.Services;
using MyBasketStats.ClientApp.ViewModels;

namespace MyBasketStats.ClientApp.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService ??
                throw new ArgumentNullException(nameof(gameService));
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SearchGame(int id)
        {
            var game = await _gameService.GetGame(id);
            var homeViewModel = new HomeViewModel
            {
                Game = game
            };
            return View("~/Views/Home/Index.cshtml", homeViewModel);
        }
    }
}
