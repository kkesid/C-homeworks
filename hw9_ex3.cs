using System;
using System.Collections.Generic;

public delegate void ButtonPressedHandler(string message);

public class Button
{
    public event ButtonPressedHandler OnButtonPressed;

    public string Name { get; }
    public Button(string name)
    {
        Name = name;
    }
    public void Click()
    {
        OnButtonPressed.Invoke($"{Name} button was pressed!");
    }
}
public static class Extensions
{
    public static void ClickAll(this List<Button> buttons)
    {
        foreach (var button in buttons)
        {
            button.Click();
        }
    }
    public static List<char> GetFirstLetters(this List<string> strings)
    {
        var firstLetters = new List<char>();
        foreach (var str in strings)
        {
            if (!string.IsNullOrEmpty(str))
            {
                firstLetters.Add(str[0]);
            }
        }
        return firstLetters;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Button saveButton = new Button("Save");
        Button sendButton = new Button("Send");
        Button readButton = new Button("Read");

        saveButton.OnButtonPressed += ShowMessage;
        sendButton.OnButtonPressed += ShowMessage;
        readButton.OnButtonPressed += ShowMessage;

        List<Button> buttons = new List<Button> { saveButton, sendButton, readButton };
        buttons.ClickAll();

        List<string> names = new List<string> { "Alice", "Bob", "Charlie" };
        List<char> firstLetters = names.GetFirstLetters();

        Console.WriteLine("First letters:");
        foreach (char letter in firstLetters)
        {
            Console.WriteLine(letter);
        }
    }

    static void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}
