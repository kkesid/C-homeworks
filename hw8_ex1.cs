using System;
using System.Collections.Generic;
using System.Linq;

public abstract class RequestHandler<TRequest, TResponse>
{
    public abstract TResponse HandleRequest(TRequest request);
}

public class TimeRequest
{
    public DateTime Date1 { get; set; }
    public DateTime Date2 { get; set; }
}

public class TimeResponse
{
    public int DaysDifference { get; set; }
}

public class TimeRequestHandler : RequestHandler<TimeRequest, TimeResponse>
{
    public override TimeResponse HandleRequest(TimeRequest request)
    {
        int daysDifference = (int)(request.Date2 - request.Date1).TotalDays;
        return new TimeResponse { DaysDifference = daysDifference };
    }
}
public class StringConcatRequest
{
    public IEnumerable<string> StringsToConcat { get; set; }
}

public class StringConcatResponse
{
    public string Result { get; set; }
}

public class StringConcatRequestHandler : RequestHandler<StringConcatRequest, StringConcatResponse>
{
    public override StringConcatResponse HandleRequest(StringConcatRequest request)
    {
        string concatenatedResult = string.Join("", request.StringsToConcat);
        return new StringConcatResponse { Result = concatenatedResult };
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var timeHandler = new TimeRequestHandler();
        var timeRequest = new TimeRequest
        {
            Date1 = new DateTime(2023, 1, 1),
            Date2 = new DateTime(2024, 1, 1)
        };
        var timeResponse = timeHandler.HandleRequest(timeRequest);
        Console.WriteLine($"Разница в днях: {timeResponse.DaysDifference}");

        var stringHandler = new StringConcatRequestHandler();
        var stringRequest = new StringConcatRequest
        {
            StringsToConcat = new List<string> { "Hello", " ", "World", "!" }
        };
        var stringResponse = stringHandler.HandleRequest(stringRequest);
        Console.WriteLine($"Результат конкатенации: {stringResponse.Result}");
    }
}