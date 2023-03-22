using System;
using System.Collections.Generic;
using System.Linq;

namespace Training.Kata.ShoppingBasket;

public class CashRegister
{
    public List<Item> Items { get; set; } = new List<Item>();
    public List<Discount> Discounts { get; set; } = new List<Discount>();

    public void AddItem(Item item)
    {
        if (item is null)
        {
            throw new ArgumentNullException();
        }
        
        Items.Add(item);
    }
    
    public void AddDiscount(Discount discount)
    {
        if (discount is null)
        {
            throw new ArgumentNullException();
        }
        
        Discounts.Add(discount);
    }

    public decimal GetTotal()
    {
        return Items.Aggregate(0m, (accumulator, item) =>
        {
            var accumulatedItem = Discounts.Aggregate(item, (priceAccumulator, discount) =>
            {
                var discountedItem = new Item(item.Name, discount.Apply(priceAccumulator));
                return discountedItem;
            });
            return accumulatedItem.Price;
        });
    }
}