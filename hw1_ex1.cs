class Program 
{
    static void Main()
    {
        Console.Write("Введите длину прямоугольника A: ");
        int A = int.Parse(Console.ReadLine());

        Console.Write("Введите ширину прямоугольника B: ");
        int B = int.Parse(Console.ReadLine());

        Console.Write("Введите сторону квадрата C: ");
        int C = int.Parse(Console.ReadLine());

        if (A <= 0 || B <= 0 || C <= 0)
        {
            Console.WriteLine("Все числа должны быть положительными.");
            return;
        }
           
        int squaresInRow = A / C;
        int squaresInColumn = B / C;
        int totalSquares = squaresInRow * squaresInColumn; 

        int rectangleArea = A * B; 
        int squaresArea = totalSquares * (C * C);

        int unoccupiedArea = rectangleArea - squaresArea;

        Console.WriteLine("Количество квадратов, размещенных на прямоугольнике:" + totalSquares);
        Console.WriteLine("Площадь незанятой части прямоугольника:"+ unoccupiedArea);
    }
}

