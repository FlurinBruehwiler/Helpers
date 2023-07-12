using System.Diagnostics;

namespace FlurinBruehwiler.Helpers;

public class Measurer : IDisposable
{
    private readonly string _message;
    private readonly Stopwatch _stopwatch;
    
    public Measurer(string message)
    {
        _message = message;
        _stopwatch = Stopwatch.StartNew();
    }
    
    public void Measure()
    {
        Dispose();
    }
    
    public void Dispose()
    {
        Console.WriteLine($"{_message} completed in {_stopwatch.ElapsedMilliseconds}ms");
    }
}