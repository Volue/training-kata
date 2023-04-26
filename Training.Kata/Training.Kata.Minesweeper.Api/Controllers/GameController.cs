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
        var groupsByY = _gameService.GameBoard.GroupBy(x => x.Y);
        var boardStrings = groupsByY.Select(x => x.Aggregate(string.Empty, (acc, v) => $"{acc} {v}"));
        return Ok(boardStrings);
    }

    [HttpPost("move")]
    public IActionResult MakeMove(int x, int y)
    {
        _gameService.MakeMove(x, y);
        return Ok();
    }
}