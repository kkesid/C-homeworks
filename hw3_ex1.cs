Student student = new Student("Ekaterina", "Andreevna", "Gruzdeva", "BV321");

student.AddGrade(Subject.Mathematics, 5);
student.AddGrade(Subject.Mathematics, 4);
student.AddGrade(Subject.History, 3);
student.AddGrade(Subject.English, 5);
student.AddGrade(Subject.English, 5);


Console.WriteLine(student.Print());

Console.WriteLine($"Средний балл по математике: {student.averageMark(Subject.Mathematics)}");
Console.WriteLine($"Средний балл по всем предметам: {student.averageMarkOverall()}");

student.changeGroup("NDJ-789");
Console.WriteLine($"Студент переведен в группу: {student.Group}");

public enum Subject
{
    Mathematics,
    Science,
    History,
    Geography,
    English,
    Art
}
public class Student
{
    public Student(string firstname, string secondname, string surname, string group)
    {
        FirstName = firstname;
        SecondName = secondname;
        Surname = surname;
        Group = group;
    }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Surname { get; set; }
    public string FullName => $"{FirstName} {SecondName} {Surname}";

    public string Group { get; set; }
    public Dictionary<Subject, List<int>> Marks { get; set; } = new Dictionary<Subject, List<int>>();


    public string Print()
    {
        return $"ФИО: {FullName}, Группа: {Group}, Оценки: {string.Join(", ", Marks.Select(g => $"{g.Key}: {string.Join(", ", g.Value)}"))}";

    }

    public double averageMark(Subject subject)
    {
        if (Marks.ContainsKey(subject) && Marks[subject].Count > 0)
        {
            return Marks[subject].Average();
        }
        throw new Exception("Error");
    }
    public double averageMarkOverall()
    {
        if (Marks.Count == 0) return 0; 

        return Marks.SelectMany(x => x.Value).Average();
    }
    public void AddGrade(Subject subject, int grade)
    {
        if (!Marks.ContainsKey(subject))
        {
            Marks[subject] = new List<int>();
        }
        Marks[subject].Add(grade);
    }

    public void changeGroup(string newGroup)
    {
        Group = newGroup;
    }
}


