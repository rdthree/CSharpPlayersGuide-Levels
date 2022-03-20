// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using System.Security.Cryptography;

Console.WriteLine("Hello, World!");

Arrow arrow = new Arrow();
arrow.Volume();
arrow.Weight();

InventoryItem[] packItem = new InventoryItem[3];
foreach (var item in packItem)
{
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
    private readonly int _maxItems;
    public int _emptySlots { get; private set; }
    public double _currentWeight { get; private set; }
    public double _currentVolume { get; private set; }
    private readonly double _maxWeight;
    private readonly double _maxVolume;
    private readonly InventoryItem[] Items;

    internal Pack(int items = 5, double maxWeight = 10.0, double maxVolume = 20.0)
    {
        _maxItems = items;
        _maxWeight = maxWeight;
        _maxVolume = maxVolume;
        Items = new InventoryItem[items];
    }

    public bool Add(InventoryItem item)
    {
        int _emptySlots = 0;
        // general pack status, available slots, weight, volume
        foreach (var packItem in Items)
        {
            if (packItem == null)
                _emptySlots++;
            else if (packItem != null)
            {
                _currentWeight += packItem.Weight();
                _currentVolume += packItem.Volume();
            }
        }

        if (_emptySlots == 0)
        {
            Console.WriteLine($"pack full, no room for {item.GetType()}");
            return false;
        }

        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] == null)
            {
                if (item.Weight() + _currentWeight > _maxWeight)
                {
                    Console.WriteLine($"too heavy, can't carry {item.GetType()}");
                    return false;
                }

                if (item.Volume() + _currentVolume > _maxVolume)
                {
                    Console.WriteLine($"too large, can't fit {item.GetType()}");
                    return false;
                }

                Items[i] = item;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"added {item.GetType()}");
                Console.ResetColor();
                Console.WriteLine($"remaining slots: {_emptySlots} " +
                                  $"| available weight: {_maxWeight - _currentWeight} " +
                                  $"| available space: {_maxVolume - _currentVolume}");
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