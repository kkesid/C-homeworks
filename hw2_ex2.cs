
int[] numbers = { 1, -2, 3, -4, 5, -6, 7, 8, -9, 10, 11, -12, 13, 14, -15 };

int num1 = 0, num2 = 0;

foreach (var number in numbers)
{
    if (number>0)
        num1 += number;
    else
        num2 += number;
}

Console.WriteLine("Сумма положительных чисел равна: "+num1);
Console.WriteLine("Сумма отрицательных чисел равна: "+num2);


