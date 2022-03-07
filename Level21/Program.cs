// See https://aka.ms/new-console-template for more information

using MonchoUtils;

// rectangle class with getter and setter for width/height
// methods for area

var arrow = new Arrow();
var quiver = new List<Arrow>();
var quiverDisplay = false;

Console.Write($"Input arrow length: ");
double arrowLengthInput = MoUtils.InputToDouble();
arrow.SetArrowLength(arrowLengthInput);
Console.Clear();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("'H' for Arrow Head Type, 'F' for Fletching Type, 'L' for Length");
    Console.WriteLine("'X' to save arrow to quiver and reset, 'Q' to show/hide quiver");
    Console.ResetColor();

    if (quiverDisplay) ArrowUI.QuiverShow(quiver);
    else ArrowUI.ArrowChoice(arrow);

    var input = Console.ReadKey(true);
    switch (input.Key)
    {
        case ConsoleKey.H:
            arrow.SetArrowHead(ArrowUI.ArrowHeadSwitcher(arrow.GetArrowHead()));
            break;
        case ConsoleKey.F:
            arrow.SetFletching(ArrowUI.FletchingSwitcher(arrow.GetFletching()));
            break;
        case ConsoleKey.L:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Input arrow length: ");
            arrowLengthInput = MoUtils.InputToDouble();
            arrow.SetArrowLength(arrowLengthInput);
            Console.ResetColor();
            break;
        case ConsoleKey.X:
            quiver.Add(arrow);
            arrow = new Arrow();
            break;
        case ConsoleKey.Q:
            quiverDisplay = !quiverDisplay;
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }

    Console.Clear();
    Console.ResetColor();
}

internal static class ArrowUI
{
    public static void QuiverShow(List<Arrow> quiverShow)
    {
        foreach (var arrowShow in quiverShow)
            Console.WriteLine($"{arrowShow.GetArrowLength()} |" +
                              $" {arrowShow.GetArrowHead()} |" +
                              $" {arrowShow.GetFletching()}");
    }

    public static ArrowHead ArrowHeadSwitcher(ArrowHead arrowHeadSwitcher)
    {
        return arrowHeadSwitcher switch
        {
            ArrowHead.Obsidian => arrowHeadSwitcher = ArrowHead.Steel,
            ArrowHead.Steel => arrowHeadSwitcher = ArrowHead.Wood,
            ArrowHead.Wood => arrowHeadSwitcher = ArrowHead.Obsidian,
            _ => throw new ArgumentOutOfRangeException(nameof(arrowHeadSwitcher), arrowHeadSwitcher, null)
        };
    }

    internal static Fletching FletchingSwitcher(Fletching fletchingSwitcher)
    {
        return fletchingSwitcher switch
        {
            Fletching.Plastic => fletchingSwitcher = Fletching.GooseFeathers,
            Fletching.GooseFeathers => fletchingSwitcher = Fletching.TurkeyFeathers,
            Fletching.TurkeyFeathers => fletchingSwitcher = Fletching.Plastic,
            _ => throw new ArgumentOutOfRangeException(nameof(fletchingSwitcher), fletchingSwitcher, null)
        };
    }

    public static void ArrowChoice(Arrow arrowChosen)
    {
        var arrowHead = arrowChosen.GetArrowHead();
        var arrowLength = arrowChosen.GetArrowLength();
        var fletching = arrowChosen.GetFletching();
        var cost = Arrow.GetCost(arrowHead, arrowLength, fletching);

        Console.WriteLine($"Arrow Head: \t\t{arrowHead}\n" +
                          $"Arrow Length: \t\t{arrowLength}\n" +
                          $"Arrow Fletching: \t{fletching}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Arrow Cost: \t\t{cost:C}");
    }
}


internal class Arrow
{
    private ArrowHead _arrowHead;
    private double _arrowLength;
    private Fletching _fletching;

    internal Arrow()
    {
        _arrowHead = ArrowHead.Obsidian;
        _arrowLength = 32.4;
        _fletching = Fletching.Plastic;
    }

    internal Arrow(ArrowHead arrowHead, double arrowLength, Fletching fletching)
    {
        _arrowHead = arrowHead;
        _arrowLength = arrowLength;
        _fletching = fletching;
    }

    public ArrowHead GetArrowHead() => _arrowHead;
    public double GetArrowLength() => _arrowLength;
    public Fletching GetFletching() => _fletching;

    public void SetArrowHead(ArrowHead arrowHead) => _arrowHead = arrowHead;
    public double SetArrowLength(double arrowLength) => _arrowLength = arrowLength;
    public void SetFletching(Fletching fletching) => _fletching = fletching;

    public static double GetCost(ArrowHead arrowHead, double arrowLength, Fletching fletching)
    {
        double arrowHeadCost = 0;
        var arrowLengthCost = arrowLength * 0.05;
        double fletchingCost = 0;

        arrowHeadCost = arrowHead switch
        {
            ArrowHead.Obsidian => 5.0,
            ArrowHead.Steel => 10.0,
            ArrowHead.Wood => 3.0,
            _ => arrowHeadCost
        };

        fletchingCost = fletching switch
        {
            Fletching.Plastic => 10.0,
            Fletching.GooseFeathers => 5.0,
            Fletching.TurkeyFeathers => 3.0,
            _ => fletchingCost
        };

        return arrowHeadCost + arrowLengthCost + fletchingCost;
    }
}

public enum ArrowHead
{
    Steel,
    Wood,
    Obsidian
}

public enum Fletching
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers
}