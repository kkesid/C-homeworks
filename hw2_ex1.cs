
List<string> list = new List<string>
{
            "One",
            "One two three",
            "Four five",
            "Six One Seven One",
            "Eleven One",
};

string search = "One";


List<string> firstlist = new List<string>();
List<string> secondlist = new List<string>();
List<string> thirdlist = new List<string>();


foreach (var item in list)
{
    int count = (item.Length - item.Replace(search, "").Length) / search.Length;

    if (count == 1)
        firstlist.Add(item);
    else if (count >= 2)
        secondlist.Add(item);
    else
        thirdlist.Add(item);
}

Console.WriteLine("Исходный список:");
Console.WriteLine(string.Join(", ", list));
Console.WriteLine("Cодержащие строку один раз:");
Console.WriteLine(string.Join(", ", firstlist));
Console.WriteLine("Cодержащие строку 2 и более раз:");
Console.WriteLine(string.Join(", ", secondlist));
Console.WriteLine("Не содержащие строку:");
Console.WriteLine(string.Join(", ", thirdlist));



