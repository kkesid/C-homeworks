using System.Text;

Console.WriteLine("Введите строку:");
string inputString = Console.ReadLine();

StringBuilder newString = new StringBuilder();

foreach (char c in inputString)
{
    if (char.IsDigit(c))
    {
        int number = int.Parse(c.ToString());
        string word = ((Number)number).ToString();

        newString.Append(word);
        newString.Append(' ');
    }
    else
    {
        newString.Append(c);
    }
}

Console.WriteLine(newString.ToString());

public enum Number
{
    Zero,
    One,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine
}

