UserAccount user = new UserAccount();

user.AddUser("user1", "user1@email.com", "password123", "1234567890");

if (user.Authenticate("user1", "password123"))
{
    Console.WriteLine("Аутентификация прошла успешно.");
}
else
{
    Console.WriteLine("Неверный логин или пароль.");
}

if (user.ChangePassword("1234567890", "newPassword"))
{
    Console.WriteLine("Пароль изменен.");
}
else
{
    Console.WriteLine("Неверный номер телефона.");
}

user.AddBirthDate("01.01.2000");

user.PrintUserData();

public class UserAccount
{
    private Dictionary<string, string> userData = new Dictionary<string, string>();

    public bool Authenticate(string login, string password)
    {
        if (userData["Login"]==login && userData["Password"] == password)
        {
            // Обновляем время последнего входа
            userData["LastLogin"] = DateTime.Now.ToString();
            return true;
        }
        return false;
    }

    public bool ChangePassword(string phoneNumber, string newPassword)
    {
        if (userData.ContainsKey("PhoneNumber") && userData["PhoneNumber"] == phoneNumber)
        {
            userData["Password"] = newPassword;
            return true;
        }
        return false;
    }
    public void AddBirthDate(string birthDate)
    {
        if (!userData.ContainsKey("BirthDate"))
        {
            userData["BirthDate"] = birthDate;
        }
        else
        {
            Console.WriteLine("Дата рождения уже добавлена.");
        }
    }
    public void AddUser(string login, string email, string password, string phoneNumber)
    {
        userData["Login"] = login;
        userData["Email"] = email;
        userData["Password"] = password;
        userData["PhoneNumber"] = phoneNumber;
        userData["LastLogin"] = DateTime.Now.ToString(); 
    }

    public void PrintUserData()
    {
        foreach (KeyValuePair<string, string> kvp in userData)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}

