using System;
using FluentAssertions;
using Xunit;

namespace Training.Kata.StringCalculator;

public class StringCalculatorTest
{
    private readonly StringCalculator _stringCalculator;

    public StringCalculatorTest()
    {
        _stringCalculator = new StringCalculator();
    }

    [Fact]
    public void Calculate_GivenText_ShouldThrow()
    {
        Assert.Throws<FormatException>(() => _stringCalculator.Calculate("Potato"));
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(7)]
    [InlineData(11)]
    public void Calculate_GivenNumber_ReturnsNumber(int input)
    {
        _stringCalculator.Calculate(input.ToString()).Should().Be(input);
    }
    
    [Fact]
    public void Calculate_Given2plus3_Returns5()
    {
        _stringCalculator.Calculate("2 + 3").Should().Be(5);
    }
    
    [Fact]
    public void Calculate_Given5minus3_Returns2()
    {
        _stringCalculator.Calculate("5 - 3").Should().Be(2);
    }
    
    [Fact]
    public void Calculate_Given3minus5_ReturnsNegative2()
    {
        _stringCalculator.Calculate("3 - 5").Should().Be(-2);
    }
    
    [Fact]
    public void Calculate_Given10dividedby2_ReturnsNegative5()
    {
        _stringCalculator.Calculate("10 / 2").Should().Be(5);
    }
    
    [Fact]
    public void Calculate_Given10dividedby0_Throws()
    {
        Assert.Throws<DivideByZeroException>(() => _stringCalculator.Calculate("10 / 0"));
    }
    
    [Fact]
    public void Calculate_Given2times2_Returns4()
    {
        _stringCalculator.Calculate("2 * 2").Should().Be(4);
    }
}