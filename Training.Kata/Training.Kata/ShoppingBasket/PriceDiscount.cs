using System.Collections.Generic;
using System.Linq;

namespace Training.Kata.ShoppingBasket;

public class PriceDiscount : Discount
{
    public readonly decimal Value;

    public PriceDiscount(decimal value)
    {
        Value = value;
    }
    
    public override decimal Apply(Item item)
    {
        var discountedPrice = item.Price - Value;
        return discountedPrice;
    }
}