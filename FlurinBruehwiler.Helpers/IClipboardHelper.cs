namespace FlurinBruehwiler.Helpers;

public interface IClipboardHelper
{
    public void Write(string text, string? secondaryText = null);
    public string? Read(bool secondary = false);
}
