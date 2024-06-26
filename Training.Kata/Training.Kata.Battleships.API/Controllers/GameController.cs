using Microsoft.AspNetCore.Mvc;
using Training.Kata.Battleships.Core;

namespace Training.Kata.Battleships.API.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly GameService gameService;

        public GameController(GameService gameService) {
            this.gameService = gameService;
        }

        [HttpGet, Route("list")]
        public IActionResult GameList()
        {
            return Ok(gameService.Games);
        }

        [HttpPost, Route("new")]
        public IActionResult NewGame([ FromBody ] string name)
        {
            gameService.Games.Add(name);

            return Ok();
        }
    }
}
