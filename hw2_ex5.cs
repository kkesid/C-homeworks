Console.WriteLine("Введите строку:");
string text = Console.ReadLine();

string[] words = text.Split(' ');

Console.WriteLine($"Количество слов: {words.Length}");
Console.WriteLine("Список слов:");
foreach (string word in words)
{
    Console.WriteLine(word);
}