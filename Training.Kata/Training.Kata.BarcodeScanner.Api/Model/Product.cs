namespace Training.Kata.BarcodeScanner.Api.Model;

public class Product
{
    public string Barcode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Decimal Price { get; set; }
}