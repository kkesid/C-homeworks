using System;

public delegate double Calculate(double x, double y);
public class Calculator
{
    public Calculate Operation { get; set; }

    public double DoCalculate(double x, double y)
    {
        if (Operation == null)
        {
            throw new InvalidOperationException("Операция не задана.");
        }
        return Operation(x, y);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var additionCalculator = new Calculator
        {
            Operation = (x, y) => x + y
        };

        var multiplicationCalculator = new Calculator
        {
            Operation = (x, y) => x * y
        };

        var subtractionCalculator = new Calculator
        {
            Operation = (x, y) => x - y
        };

        Console.WriteLine("Результат сложения: " + additionCalculator.DoCalculate(10, 5));
        Console.WriteLine("Результат умножения: " + multiplicationCalculator.DoCalculate(10, 5));
        Console.WriteLine("Результат вычитания: " + subtractionCalculator.DoCalculate(10, 5));
    }
}

