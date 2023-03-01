using System.Collections.Generic;

namespace Training.Kata.ShoppingBasket;

public class PriceDiscount : Discount
{
    public readonly decimal Value;

    public PriceDiscount(decimal value)
    {
        Value = value;
    }
    
    public override decimal Apply(IEnumerable<Item> items)
    {
        throw new System.NotImplementedException();
    }
}