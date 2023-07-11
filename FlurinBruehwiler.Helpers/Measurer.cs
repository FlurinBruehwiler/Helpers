using System.Diagnostics;

namespace FlurinBruehwiler.Helpers;

public class Measurer : IDisposable
{
    private readonly string _message;
    private readonly long _startTimeStamp;
    
    public Measurer(string message)
    {
        _message = message;
        _startTimeStamp = Stopwatch.GetTimestamp();
    }
    
    public void Measure()
    {
        Dispose();
    }
    
    public void Dispose()
    {
        Console.WriteLine($"{_message} completed in {Stopwatch.GetElapsedTime(_startTimeStamp).Milliseconds}ms");
    }
}