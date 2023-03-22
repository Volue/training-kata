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
        return Ok(_repository.Barcodes);
    }

    [HttpGet("scan")]
    public IActionResult Scan(string barcode)
    {
        if (_repository.Barcodes.ContainsKey(barcode))
        {
            return Ok(_repository.Barcodes[barcode]);
        }

        return NotFound();
    }
    
    [HttpGet("search")]
    public IActionResult Search(
        [FromQuery]string? name, 
        [FromQuery]string? description)
    {
        if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(description))
        {
            return NotFound();
        }

        if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(description))
        {
            return Ok(_repository.Barcodes.Where(x =>
            {
                return x.Value.Name.Contains(name) 
                       && x.Value.Description.Contains(description);
            }));
        }
        
        if (!string.IsNullOrEmpty(description))
        {
            return Ok(_repository.Barcodes.Where(x =>
            {
                return x.Value.Description.Contains(description);
            }));
        }
        
        return Ok(_repository.Barcodes.Where(x => x.Value.Name.Contains(name)));
    }
}