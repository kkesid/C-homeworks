using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string sourceImagePath = "sourceImage.png"; 
        string destinationImagePath = "copyImage.png";

        try
        {
            if (!File.Exists(sourceImagePath))
            {
                Console.WriteLine($"Файл {sourceImagePath} не найден.");
                return;
            }
            using (FileStream inputStream = new FileStream(sourceImagePath, FileMode.Open, FileAccess.Read))
            using (FileStream outputStream = new FileStream(destinationImagePath, FileMode.Create, FileAccess.Write))
            {
                inputStream.CopyTo(outputStream);
            }

            Console.WriteLine($"Копия изображения успешно создана: {destinationImagePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
