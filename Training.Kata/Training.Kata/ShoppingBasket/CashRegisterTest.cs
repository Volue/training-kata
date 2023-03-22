using System;
using FluentAssertions;
using Xunit;

namespace Training.Kata.ShoppingBasket;

public class CashRegisterTest
{
    private readonly CashRegister _cashRegister;
    private readonly Item _book = new("Clean Code Book", 29.99m);
    private readonly PriceDiscount _priceDiscount = new(5);
    private readonly PercentDiscount _percentDiscount = new(10);

    public CashRegisterTest()
    {
        _cashRegister = new CashRegister();
    }
    
    [Fact]
    public void AddItem_GivenNull_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => _cashRegister.AddItem(null));
    }
    
    [Fact]
    public void AddItem_GivenBook_AddsItToItems()
    {
        _cashRegister.AddItem(_book);
        _cashRegister.Items.Count.Should().Be(1);
    }
    
    [Fact]
    public void AddDiscount_GivenNull_Throws()
    {
        Assert.Throws<ArgumentNullException>(() => _cashRegister.AddItem(null));
    }
    
    [Fact]
    public void AddDiscount_GivenBook_AddsItToItems()
    {
        _cashRegister.AddDiscount(_priceDiscount);
        _cashRegister.Discounts.Count.Should().Be(1);
    }
    
    [Fact]
    public void GetTotal_WhenCartIsEmpty_Returns0()
    {
        _cashRegister.GetTotal().Should().Be(0);
    }
    
    [Fact]
    public void GetTotal_WhenCartContainsBook_ReturnsItsPrice()
    {
        _cashRegister.AddItem(_book);
        _cashRegister.GetTotal().Should().Be(_book.Price);
    }
    
    [Fact]
    public void GetTotal_WhenCartContainsBookAndPriceDiscount_ReturnsDiscountedPrice()
    {
        _cashRegister.AddItem(_book);
        _cashRegister.AddDiscount(_priceDiscount);
        _cashRegister.GetTotal().Should().Be(_book.Price - _priceDiscount.Value);
    }
    
    [Fact]
    public void GetTotal_WhenCartContainsTwoBooksAndPriceDiscount_ReturnsDiscountedPrice()
    {
        _cashRegister.AddItem(_book);
        _cashRegister.AddItem(_book);
        _cashRegister.AddDiscount(_priceDiscount);
        _cashRegister.GetTotal().Should().Be(_book.Price * 2 - _priceDiscount.Value * 2);
    }
    
    [Fact]
    public void GetTotal_WhenCartContainsBookAndPercentDiscount_ReturnsDiscountedPrice()
    {
        _cashRegister.AddItem(_book);
        _cashRegister.AddDiscount(_percentDiscount);
        _cashRegister.GetTotal().Should().Be(_book.Price * _percentDiscount.Value / 100);
    }
    
    [Fact]
    public void GetTotal_WhenCartContainsTwoBooksAndPercentDiscount_ReturnsDiscountedPrice()
    {
        _cashRegister.AddItem(_book);
        _cashRegister.AddItem(_book);
        _cashRegister.AddDiscount(_percentDiscount);
        _cashRegister.GetTotal().Should().Be((_book.Price + _book.Price) * _percentDiscount.Value / 100);
    }
    
    [Fact]
    public void GetTotal_WhenCartContainsBookAndPriceAndPercentDiscount_ReturnsDiscountedPrice()
    {
        _cashRegister.AddItem(_book);
        _cashRegister.AddDiscount(_priceDiscount);
        _cashRegister.AddDiscount(_percentDiscount);
        _cashRegister.GetTotal().Should().Be((_book.Price - _priceDiscount.Value) * _percentDiscount.Value / 100);
    }
    
    [Fact]
    public void GetTotal_WhenCartContainsTwoBooksAndPriceAndPercentDiscount_ReturnsDiscountedPrice()
    {
        _cashRegister.AddItem(_book);
        _cashRegister.AddItem(_book);
        _cashRegister.AddDiscount(_priceDiscount);
        _cashRegister.AddDiscount(_percentDiscount);
        _cashRegister.GetTotal().Should().Be((_book.Price * 2 - _priceDiscount.Value) * _percentDiscount.Value / 100);
    }
}