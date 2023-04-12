using Microsoft.AspNetCore.Mvc;
using Training.Kata.BarcodeScanner.Api.Model;
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
    
    [HttpPost("add")]
    public IActionResult AddToBasket(string barcode)
    {
        if (_repository.Barcodes.ContainsKey(barcode))
        {
            _repository.ScannedBarcodes.Add(barcode);
            var productsInBasket = _repository.ScannedBarcodes.Select(x => _repository.Barcodes[x]).ToList();
            var response = new Basket
            {
                Discounts = _repository.Discounts,
                Products = productsInBasket,
                BarcodeDiscounts = _repository.BarcodeDiscounts
            };
            return Ok(response);
        }

        return NotFound();
    }
    
    [HttpGet("basket")]
    public IActionResult GetBasket()
    {
        var productsInBasket = _repository.ScannedBarcodes.Select(x => _repository.Barcodes[x]).ToList();
        var response = new Basket
        {
            Discounts = _repository.Discounts,
            Products = productsInBasket,
            BarcodeDiscounts = _repository.BarcodeDiscounts
        };
        return Ok(response);
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
    
    // TODO: Napisz funkcje kontrolera BarcodeController która usunie ostatni dodany element z listy _repository.ScannedBarcodes
    
    [HttpPost("addDiscount")]
    public IActionResult AddDiscount(decimal value, string? barcode)
    {
        if (!string.IsNullOrWhiteSpace(barcode) && _repository.Barcodes.ContainsKey(barcode))
        {
            _repository.BarcodeDiscounts[barcode] = value;
            return Ok();
        }
        
        if (value < 0)
        {
            return BadRequest();
        }
        _repository.Discounts.Add(value);
        return Ok();
    }
}