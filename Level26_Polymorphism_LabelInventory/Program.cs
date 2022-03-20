
Pack pack = new Pack();
pack.Add(new Arrow());
pack.Add(new Bow());
pack.Add(new Food());
pack.Add(new Rope());
//pack.Add(new Arrow());
//pack.Add(new Arrow());
//pack.Add(new Arrow());
//pack.Add(new Sword());
//pack.Add(new Water());

internal class Pack
{
    private readonly int _maxItems;
    public int EmptySlots { get; private set; }
    public double CurrentWeight { get; private set; }
    public double CurrentVolume { get; private set; }
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
        EmptySlots = 0;
        // general pack status, available slots, weight, volume
        foreach (var packItem in _items)
        {
            if (packItem == null)
                EmptySlots++;
            else if (packItem != null)
            {
                CurrentWeight += packItem.Weight();
                CurrentVolume += packItem.Volume();
            }
        }

        if (EmptySlots == 0)
        {
            Console.WriteLine($"pack full, no room for {item.ToString()}");
            Console.WriteLine(ToString());
            return false;
        }

        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
            {
                if (item.Weight() + CurrentWeight > _maxWeight)
                {
                    Console.WriteLine($"too heavy, can't carry {item.ToString()}");
                    return false;
                }

                if (item.Volume() + CurrentVolume > _maxVolume)
                {
                    Console.WriteLine($"too large, can't fit {item.ToString()}");
                    return false;
                }

                _items[i] = item;
                Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine($"added {item.GetType()}");
                Console.Write("added ");
                Console.WriteLine(item.ToString());
                Console.ResetColor();
                // Console.WriteLine($"remaining slots: {EmptySlots} " +
                //                   $"| available weight: {_maxWeight - CurrentWeight} " +
                //                   $"| available space: {_maxVolume - CurrentVolume}");
                Console.WriteLine(ToString());
                return true;
            }
        }


        return false;
    }

    public override string ToString()
    {
        var type = new string($"remaining slots: {EmptySlots} " +
                              $"| available weight: {_maxWeight - CurrentWeight:0.0} " +
                              $"| available space: {_maxVolume - CurrentVolume:0.0}");
        //return base.ToString();
        return type;
    }
}

internal class InventoryItem
{
    protected static (double _weight, double _volume) WeightVolume { get; set; }
    public double Weight() => WeightVolume._weight;
    public double Volume() => WeightVolume._volume;

    public override string ToString()
    {
        var thisType = this.GetType().ToString();
        return "inventory type: " + thisType;
    }
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