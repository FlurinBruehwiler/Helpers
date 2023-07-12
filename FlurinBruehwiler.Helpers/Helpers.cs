using System.Diagnostics.CodeAnalysis;
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
    
    public static void Print(this object? obj)
    {
        Console.WriteLine(obj);
    }
    
    public static void Dump(this object? obj)
    {
        JsonSerializer.Serialize(obj, JsonSerializerOptions).Print();
    }

    public static IntEnumerator GetEnumerator(this Range range)
    {
        return new IntEnumerator(range);
    }
    
    public static IntEnumerator GetEnumerator(this int number)
    {
        return new IntEnumerator(new Range(0, number));
    }

    public static bool IsNullOrEmpty([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrEmpty(value);
    }
    
    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    public static bool TryParse([NotNullWhen(true)] this string? s, out int result)
    {
        return int.TryParse(s, out result);
    }

    public static string JoinString<T>(this IEnumerable<T> enumerable, string? seperator)
    {
        return string.Join(seperator, enumerable);
    }
    
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        WriteIndented = true
    };
}