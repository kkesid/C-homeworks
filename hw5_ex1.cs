
Printable[] printables = new Printable[]
        {
            new Book("Pride and Prejudice"),
            new Magazine("Vogue"),
            new Book("War and Peace"),
            new Magazine("Cosmopolitan")
        };

foreach (var printable in printables)
{
    printable.Print();
}

Console.WriteLine("\nPrinting only magazines:");
Magazine.PrintMagazines(printables);

Console.WriteLine("\nPrinting only books:");
Book.PrintBooks(printables);

public interface Printable
{
    void Print();
}

public class Book : Printable
{
    public string Title { get; set; }

    public Book(string title)
    {
        Title = title;
    }

    public void Print()
    {
        Console.WriteLine($"Book: {Title}");
    }

    public static void PrintBooks(Printable[] printables)
    {
        foreach (var printable in printables)
        {
            if (printable is Book book)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
public class Magazine : Printable
{
    public string Title { get; set; }

    public Magazine(string title)
    {
        Title = title;
    }

    public void Print()
    {
        Console.WriteLine($"Magazine: {Title}");
    }

    public static void PrintMagazines(Printable[] printables)
    {
        foreach (var printable in printables)
        {
            if (printable is Magazine magazine)
            {
                Console.WriteLine(magazine.Title);
            }
        }
    }
}