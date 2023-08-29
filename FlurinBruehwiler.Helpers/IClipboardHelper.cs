namespace FlurinBruehwiler.Helpers;

public interface IClipboardHelper
{
    public void Write(string text);
    public string? Read();
}