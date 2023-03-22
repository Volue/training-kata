using Microsoft.AspNetCore.Mvc;
using Training.Kata.BarcodeScanner.Api.Repository;

namespace Training.Kata.BarcodeScanner.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BarcodeController : ControllerBase
{
    private readonly BarcodeRepository _repository;

    public BarcodeController(BarcodeRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return NotFound();
    }

    [HttpGet("scan")]
    public IActionResult Scan(string barcode)
    {
        return NotFound();
    }
}