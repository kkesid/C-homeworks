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
        string json = File.ReadAllText(filePath);

        var jsonObject = JsonSerializer.Deserialize<JsonElement>(json);
        var menu = jsonObject.GetProperty("menu");

        MainMenu mainMenu = new MainMenu
        {
            Id = menu.GetProperty("id").GetString(),
            Value = menu.GetProperty("value").GetString(),
            MenuItems = new List<MainMenu.MenuItem>()
        };

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
