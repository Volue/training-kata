using System;

namespace Training.Kata.StringCalculator;

public class StringCalculator
{
    
    // 11 + 4
    public int Calculate(string expression)
    {
        var strings = expression.Split(' ');
        var a = int.Parse(strings[0]);

        if (strings.Length > 1)
        {
            var b = int.Parse(strings[2]);
            if (strings[1] == "+")
                return a + b;

            if (strings[1] == "-")
                return a - b;
            
            if (strings[1] == "*")
                return a * b;

            if (strings[1] == "/")
                return a / b;
        }
        
        return a;
    }
}