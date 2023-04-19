using Microsoft.AspNetCore.Mvc;

namespace Training.Kata.Minesweeper.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return NoContent();
    }
}