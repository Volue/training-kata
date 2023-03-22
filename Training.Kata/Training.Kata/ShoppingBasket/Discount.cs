using System.Collections.Generic;

namespace Training.Kata.ShoppingBasket;

public abstract class Discount
{
    public abstract decimal Apply(Item item);
}