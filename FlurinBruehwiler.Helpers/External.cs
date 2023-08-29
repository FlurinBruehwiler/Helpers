using System.Runtime.InteropServices;

namespace FlurinBruehwiler.Helpers;

internal static class External
{
    public const uint WmHotkey = 0x312;
    public const uint PM_REMOVE = 1;
    public const uint CF_UNICODETEXT = 13U;
    
    [DllImport("User32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsClipboardFormatAvailable(uint format);

    [DllImport("User32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool OpenClipboard(IntPtr hWndNewOwner);

    [DllImport("User32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseClipboard();

    [DllImport("Kernel32.dll", SetLastError = true)]
    public static extern IntPtr GlobalLock(IntPtr hMem);

    [DllImport("Kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool GlobalUnlock(IntPtr hMem);

    [DllImport("Kernel32.dll", SetLastError = true)]
    public static extern int GlobalSize(IntPtr hMem);

    [DllImport("user32.dll")]
    public static extern bool EmptyClipboard();
    
    [DllImport("user32.dll")]
    public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
    
    [DllImport("user32.dll")]
    public static extern IntPtr GetClipboardData(uint uFormat);
    
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool RegisterHotKey(nint hWnd, int id, uint fsModifiers, uint virtualKeyCode);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool UnregisterHotKey(nint hWnd, int id);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int PeekMessageA(out Msg lpMsg, nint hWnd, uint wMsgFilterMin, uint wMsgFilterMax,
        uint wRemoveMsg);
}


public struct Msg
{
    public readonly nint Hwnd;
    public readonly uint Message;
    public readonly nint WParam;
    public readonly nint LParam;
    public readonly uint Time;
}

public enum Key
{
    Space = 0x20,
    P = 0x50,
    //More virtual keys at https://docs.microsoft.com/en-us/windows/win32/inputdev/virtual-key-codes
}

public enum Modifier : uint
{
    Alt = 1,
    Ctrl = 2,
    Shift = 4,
    None = 8,
}