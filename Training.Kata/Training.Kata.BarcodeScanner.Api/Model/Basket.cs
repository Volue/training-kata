namespace Training.Kata.BarcodeScanner.Api.Model;

public class Basket
{
    public Decimal Sum
    {
        get
        {
            
            var productsSum = Products.Sum(p =>
            {
                if (BarcodeDiscounts.TryGetValue(p.Barcode, out var disount))
                {
                    var sum = p.Price - disount;
                    if (sum > 0)
                    {
                        return sum;
                    }
                    return 0;
                }
                return p.Price;
            });
            var discountsSum = Discounts.Sum(d => d);
            var sum = productsSum - discountsSum;
            if (sum > 0)
            {
                return sum;
            }
            return 0;
        }
    }

    public List<Product> Products { get; set; }
    
    public List<decimal> Discounts { get; set; }
    
    public Dictionary<string, decimal> BarcodeDiscounts { get; set; }
}