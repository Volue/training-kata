using System;
using System.Collections.Generic;

namespace Training.Kata.ShoppingBasket;

public class CashRegister
{
    public List<Item> Items { get; set; }
    public List<Discount> Discounts { get; set; }

    public void AddItem(Item item)
    {
        throw new NotImplementedException();
    }
    
    public void AddDiscount(Discount discount)
    {
        throw new NotImplementedException();
    }

    public decimal GetTotal()
    {
        throw new NotImplementedException();
    }
}