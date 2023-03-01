using System.Collections.Generic;

namespace Training.Kata.ShoppingBasket;

public class PercentDiscount : Discount
{
    public readonly int Value;

    public PercentDiscount(int value)
    {
        Value = value;
    }
    
    public override decimal Apply(IEnumerable<Item> items)
    {
        throw new System.NotImplementedException();
    }
}