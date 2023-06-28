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
    public IActionResult MakeMove(int x, int y, bool flagBomb)
    {
        if (_gameService.GameState != GameStateEnum.InProgress)
        {
            return StatusCode(402, "Game has ended. Insert coin to begin");
        }
        
        if (flagBomb)
        {
            var result = _gameService.FlagBomb(x, y);
            _gameService.IsGameAVictory();
            return result == true ? Ok() : Conflict("Cannot flag visible field");
        }
        _gameService.MakeMove(x, y);
        _gameService.IsGameAVictory();
        return Ok();
    }
    
    [HttpPost("insert-coin")]
    public IActionResult InsertCoin()
    {
        _gameService.NewGame();
        return Ok();
    }
}