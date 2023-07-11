using System.Text.Json;

namespace FlurinBruehwiler.Helpers;

public static class Helpers
{
    public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> callback)
    {
        foreach (var o in enumerable)
        {
            callback(o);
        }
    }
    
    public static void Print(this object obj)
    {
        Console.WriteLine(obj);
    }
    
    public static void Dump(this object obj)
    {
        Console.WriteLine(JsonSerializer.Serialize(obj, JsonSerializerOptions));
    }

    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        WriteIndented = true
    };
}