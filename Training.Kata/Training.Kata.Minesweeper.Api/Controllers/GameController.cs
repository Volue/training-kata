using Microsoft.AspNetCore.Mvc;
using Training.Kata.Minesweeper.Api.Models;
using Training.Kata.Minesweeper.Api.Services;

namespace Training.Kata.Minesweeper.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private GameService _gameService;

    public GameController(GameService gameService)
    {
        _gameService = gameService;
    }
    
    [HttpGet("board")]
    public IActionResult GetBoard()
    {
        return Ok(_gameService.GameBoard.Select(x => x.ToString()));
    }

    [HttpPost("move")]
    public IActionResult MakeMove(int x, int y)
    {
        _gameService.GameBoard.Single(field => field.X == x & field.Y == y).IsVisible = true;
        return Ok();
    }
}