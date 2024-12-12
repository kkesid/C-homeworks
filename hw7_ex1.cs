
class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "input.txt"; 
        string outputFilePath = "output.txt"; 

        try
        {
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"Файл {inputFilePath} не найден.");
                return;
            }

            string[] words = File.ReadAllLines(inputFilePath);

            var sortedWords = words.OrderBy(word => word).ToArray();

            File.WriteAllLines(outputFilePath, sortedWords);

            Console.WriteLine($"Слова успешно отсортированы и записаны в файл {outputFilePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
