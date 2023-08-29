using System.Runtime.InteropServices;
using System.Text;

namespace FlurinBruehwiler.Helpers;

public class ClipboardHelper : IClipboardHelper
{
    public static ClipboardHelper Shared = new();
    
    public void Write(string text, string? secondaryText = null)
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

        if (secondaryText is not null)
        {
            var hMem2 = Marshal.StringToHGlobalUni(secondaryText);

            External.SetClipboardData(0x0081, hMem2);
        }

        External.CloseClipboard();
    }

    public string? Read(bool secondary = false)
    {
        if (!External.IsClipboardFormatAvailable(External.CF_UNICODETEXT))
            return null;

        try
        {
            if (!External.OpenClipboard(IntPtr.Zero))
                return null;

            var handle = External.GetClipboardData(secondary ? 0x0081 : External.CF_UNICODETEXT);
            if (handle == IntPtr.Zero)
                return null;

            var pointer = IntPtr.Zero;

            try
            {
                pointer = External.GlobalLock(handle);
                if (pointer == IntPtr.Zero)
                    return null;

                var size = External.GlobalSize(handle);
                var buff = new byte[size];

                Marshal.Copy(pointer, buff, 0, size);

                return Encoding.Unicode.GetString(buff).TrimEnd('\0');
            }
            finally
            {
                if (pointer != IntPtr.Zero)
                    External.GlobalUnlock(handle);
            }
        }
        finally
        {
            External.CloseClipboard();
        }
    }
}
