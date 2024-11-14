string todayDate = DateTime.Now.ToShortDateString();
TimeSpan currentTime = DateTime.Now.TimeOfDay;

Console.WriteLine($"Сегодня: {todayDate}");
Console.WriteLine($"Текущее время: {currentTime}");