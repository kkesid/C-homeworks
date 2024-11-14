List<int> numbers = new List<int>{ 1, 4, 5, 4, 7, 8, 1, 2, 4, 9, 1, 5, 10, 2, 2 };

Dictionary<int, int> counts = new Dictionary<int, int>();
List<int> duplicates = new List<int>();

foreach (int number in numbers)
{
    if (counts.ContainsKey(number))
    {
        counts[number]++;
    }
    else
    {
        counts[number] = 1;
    }
}

foreach (KeyValuePair<int, int> kvp in counts)
{
    if (kvp.Value > 1)
    {
        duplicates.Add(kvp.Key);
    }
}

Console.WriteLine("Повторяющиеся числа:");
foreach (int num in duplicates)
{
    Console.Write(num + " ");
}

