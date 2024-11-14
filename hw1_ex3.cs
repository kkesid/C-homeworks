Console.Write("Введите целое число N (больше 0): ");

int N = int.Parse(Console.ReadLine());
string reversedNumber = ReverseNumber(N);
Console.WriteLine("Число, прочитанное справа налево: " + reversedNumber);

static string ReverseNumber(int number)
{
    char[] digits = number.ToString().ToCharArray(); 
    Array.Reverse(digits); 
    return new string(digits);
}

        
