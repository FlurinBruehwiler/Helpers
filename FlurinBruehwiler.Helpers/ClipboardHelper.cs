using System.Runtime.InteropServices;

namespace FlurinBruehwiler.Helpers;

public class ClipboardHelper : IClipboardHelper
{
    public static ClipboardHelper Shared = new();
    
    public void Copy(string text)
    {
        if (!External.OpenClipboard(IntPtr.Zero))
        {
            // _logger.LogError("Failed to open clipboard.");
            return;
        }

        External.EmptyClipboard();

        var hMem = Marshal.StringToHGlobalUni(text);

        if (External.SetClipboardData(13, hMem) == IntPtr.Zero)
        {
            // _logger.LogError("Failed to set clipboard data.");
        }

        External.CloseClipboard();
    } 
}