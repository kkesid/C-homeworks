Console.WriteLine("Enter A: ");
string A = Console.ReadLine();
Console.WriteLine("Enter B: ");
string B = Console.ReadLine();

int a = int.Parse(A);
int b = int.Parse(B);

for (int i = a; i <= b; ++i)
{
    for (int j = 0; j < i; ++j)
    {
        Console.Write(i);

    }
    Console.Write("\n");
}
