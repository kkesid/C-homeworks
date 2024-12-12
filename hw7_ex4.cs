using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class MainMenu
{
    public string Id { get; set; }
    public string Value { get; set; }
    public List<MenuItem> MenuItems { get; set; }

    public class MenuItem
    {
        public string Value { get; set; }
        public string OnClick { get; set; }
    }
}

class Program
{
    static void Main()
    {
        string filePath = "menu.txt"; 

        MainMenu mainMenu = ReadMainMenuFromFile(filePath);
        Console.WriteLine($"Menu ID: {mainMenu.Id}");
        Console.WriteLine($"Menu Value: {mainMenu.Value}");
        Console.WriteLine("Menu items:");
        foreach (var item in mainMenu.MenuItems)
        {
            Console.WriteLine($" - {item.Value} (onclick: {item.OnClick})");
        }
    }

    static MainMenu ReadMainMenuFromFile(string filePath)
    {
        // Чтение JSON из файла с расширением .txt
        string json = File.ReadAllText(filePath);

        // Десериализация JSON в объект MainMenu с использованием System.Text.Json
        var jsonObject = JsonSerializer.Deserialize<JsonElement>(json);
        var menu = jsonObject.GetProperty("menu");

        // Создание объекта MainMenu
        MainMenu mainMenu = new MainMenu
        {
            Id = menu.GetProperty("id").GetString(),
            Value = menu.GetProperty("value").GetString(),
            MenuItems = new List<MainMenu.MenuItem>()
        };

        // Добавление элементов меню в список
        var menuItems = menu.GetProperty("popup").GetProperty("menuitem");
        foreach (var item in menuItems.EnumerateArray())
        {
            mainMenu.MenuItems.Add(new MainMenu.MenuItem
            {
                Value = item.GetProperty("value").GetString(),
                OnClick = item.GetProperty("onclick").GetString()
            });
        }

        return mainMenu;
    }
}
