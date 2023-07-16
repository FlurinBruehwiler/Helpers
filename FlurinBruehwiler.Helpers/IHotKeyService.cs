namespace FlurinBruehwiler.Helpers;

public interface IHotKeyService
{
    public int RegisterHotKey(Action callback, Key key, params Modifier[] modifiers);
    public void UnregisterHotKey(int hotKeyId);
}