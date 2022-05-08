// See https://aka.ms/new-console-template for more information

// ReSharper disable UnusedVariable
Console.WriteLine("Hello, World!");

var tree = new CharberryTree();
var notifier = new Notifier(tree);
var harvester = new Harvester(tree);

while (true)
    tree.MaybeGrow();


internal class CharberryTree
{
    private readonly Random _random = new Random();
    internal bool Ripe { get; set; }
    internal event Action? Ripened;

    internal void MaybeGrow()
    {
        // tiny chance of ripening each time
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened?.Invoke();
        }
    }
}

internal class Notifier
{
    internal Notifier(CharberryTree charberryTree) => charberryTree.Ripened += OnRipened;
    private static void OnRipened() => Console.WriteLine("ripe on the vine so fine");
}

internal class Harvester
{
    private int _harvestCount;
    private readonly CharberryTree _charberryTree;

    public Harvester(CharberryTree charberryTree)
    {
        _charberryTree = charberryTree;
        _charberryTree.Ripened += OnRipened;
    }

    private void OnRipened()
    {
        _harvestCount++;
        _charberryTree.Ripe = !_charberryTree.Ripe;
        Console.WriteLine($"ripened {_harvestCount} times");
    }
}