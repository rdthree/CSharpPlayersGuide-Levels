// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

Arrow arrow = new Arrow();
arrow.Volume();
arrow.Weight();

InventoryItem[] packItem = new InventoryItem[3];
foreach (var item in packItem)
{
    // ReSharper disable once ConditionIsAlwaysTrueOrFalse
    if (item == null)
        Console.WriteLine("null");
}

Pack pack = new Pack();
pack.Add(new Arrow());
pack.Add(new Bow());
pack.Add(new Food());
pack.Add(new Rope());
pack.Add(new Arrow());
pack.Add(new Arrow());
pack.Add(new Arrow());
pack.Add(new Sword());
pack.Add(new Water());


internal class Pack
{
    // ReSharper disable once NotAccessedField.Local
    private readonly int _maxItems;
    public static int EmptySlots => 0;

    private double CurrentWeight { get; set; }
    private double CurrentVolume { get; set; }
    private readonly double _maxWeight;
    private readonly double _maxVolume;
    private readonly InventoryItem[] _items;

    internal Pack(int items = 5, double maxWeight = 10.0, double maxVolume = 20.0)
    {
        _maxItems = items;
        _maxWeight = maxWeight;
        _maxVolume = maxVolume;
        _items = new InventoryItem[items];
    }

    public bool Add(InventoryItem item)
    {
        int emptySlots = 0;
        // general pack status, available slots, weight, volume
        foreach (var packItem in _items)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (packItem == null)
                emptySlots++;
            else
            {
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (packItem != null)
                {
                    CurrentWeight += packItem.Weight();
                    CurrentVolume += packItem.Volume();
                }
            }
        }

        if (emptySlots == 0)
        {
            Console.WriteLine($"pack full, no room for {item.GetType()}");
            return false;
        }

        for (int i = 0; i < _items.Length; i++)
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (_items[i] == null)
            {
                if (item.Weight() + CurrentWeight > _maxWeight)
                {
                    Console.WriteLine($"too heavy, can't carry {item.GetType()}");
                    return false;
                }

                if (item.Volume() + CurrentVolume > _maxVolume)
                {
                    Console.WriteLine($"too large, can't fit {item.GetType()}");
                    return false;
                }

                _items[i] = item;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"added {item.GetType()}");
                Console.ResetColor();
                Console.WriteLine($"remaining slots: {emptySlots} " +
                                  $"| available weight: {_maxWeight - CurrentWeight} " +
                                  $"| available space: {_maxVolume - CurrentVolume}");
                return true;
            }
        }

        return false;
    }
}

internal class InventoryItem
{
    protected static (double _weight, double _volume) WeightVolume { get; set; }
    //public string Name { get; private protected set; }
    public double Weight() => WeightVolume._weight;
    public double Volume() => WeightVolume._volume;
}


internal class Arrow : InventoryItem
{
    internal Arrow() => WeightVolume = (0.1, 0.05);

}

internal class Bow : InventoryItem
{
    internal Bow() => WeightVolume = (1.0, 4.0);
}

internal class Rope : InventoryItem
{
    internal Rope() => WeightVolume = (1.0, 1.5);
}

internal class Water : InventoryItem
{
    internal Water() => WeightVolume = (2.0, 3.0);
}

internal class Food : InventoryItem
{
    internal Food() => WeightVolume = (1.0, 0.5);
}

internal class Sword : InventoryItem
{
    internal Sword() => WeightVolume = (5.0, 3.0);
}