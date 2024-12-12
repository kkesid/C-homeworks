using System;
using System.Collections.Generic;
using System.IO;

class Student
{
    public int Number { get; set; }
    public List<int> Grades { get; set; }

    public Student(int number, List<int> grades)
    {
        Number = number;
        Grades = grades;
    }

    public override string ToString()
    {
        return $"Студент №{Number}: Оценки: {string.Join(", ", Grades)}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        string inputFilePath = "students.txt";

        try
        {
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"Файл {inputFilePath} не найден.");
                return;
            }

            string[] lines = File.ReadAllLines(inputFilePath);
            List<Student> students = new List<Student>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length > 1)
                {
                    int studentNumber = int.Parse(parts[0]);
                    List<int> grades = new List<int>();

                    for (int i = 1; i < parts.Length; i++)
                    {
                        grades.Add(int.Parse(parts[i]));
                    }

                    students.Add(new Student(studentNumber, grades));
                }
            }

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}