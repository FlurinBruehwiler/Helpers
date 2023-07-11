
using FlurinBruehwiler.Helpers;

Console.WriteLine("Hello, World!");

var enumerable = Enumerable.Range(0, 10);
    
enumerable.ForEach(x => x.Print());
enumerable.Dump();