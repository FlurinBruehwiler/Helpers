
using FlurinBruehwiler.Helpers;

ClipboardHelper.Shared.Read().Print();

return;

using var _ = new Measurer("Main");

var enumerable = Enumerable.Range(0, 10);

enumerable.ForEach(x => x.Print());

var enumerable2 = Enumerable.Range(4, 9);
enumerable2.Dump();

foreach (var x in 4)
{
    x.Print();
}

foreach (var x in 3..5)
{
    x.Print();
}

if ("string".IsNullOrEmpty())
{
    "How can this be".Print();
}

if ("string".IsNullOrWhiteSpace())
{
    "Crazy".Print();
}

if ("4".TryParse(out var res))
{
    res.Print();
}

enumerable2.JoinString(" ").Print();
