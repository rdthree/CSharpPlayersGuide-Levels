// See https://aka.ms/new-console-template for more information

using MonchoUtils;

/*
 * arrows have three parts:
 *  - arrowhead (steel, wood, or obsidian)
 *  - shaft (length between 60cm and 100cm long)
 *  - fletching (plastic, turkey feathers, goose feathers)
 *
 * arrowhead costs:
 *  - steel:    10 gold
 *  - wood:     3 gold
 *  - obsidian: 5 gold
 *
 * fletching costs:
 *  - plastic:  10 gold
 *  - turkey feathers:  5 gold
 *  - goose feathers:   3 gold
 *
 * shaft costs:
 *  - 0.05 gold per centimeter
 */

// Arrow class with fields for arrowhead type, fletching type, length
// user can create new Arrow instance by picking arrowhead, fletching, length
// GetCost method returns cost as decimal based on numbers above
// display Arrow instance and cost

var arrow = new Arrow();
var quiver = new List<Arrow>();
var quiverDisplay = false;

Console.Write($"Input arrow length: ");
arrow.ArrowLength = MoUtils.InputToDouble();
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
            arrow.ArrowHead = ArrowUI.ArrowHeadSwitcher(arrow.ArrowHead);
            break;
        case ConsoleKey.F:
            arrow.Fletching = ArrowUI.FletchingSwitcher(arrow.Fletching);
            break;
        case ConsoleKey.L:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Input arrow length: ");
            arrow.ArrowLength = MoUtils.InputToDouble();
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
    internal static void QuiverShow(List<Arrow> quiverShow)
    {
        foreach (var arrowShow in quiverShow)
            Console.WriteLine($"{arrowShow.ArrowLength} | {arrowShow.ArrowHead} | {arrowShow.Fletching}");
    }

    internal static ArrowHead ArrowHeadSwitcher(ArrowHead arrowHeadSwitcher)
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
        var arrowHead = arrowChosen.ArrowHead;
        var arrowLength = arrowChosen.ArrowLength;
        var fletching = arrowChosen.Fletching;
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
    public ArrowHead ArrowHead { get; set; }
    public double ArrowLength { get; set; }
    public Fletching Fletching { get; set; }

    internal Arrow()
    {
        ArrowHead = ArrowHead.Obsidian;
        ArrowLength = 31.5;
        Fletching = Fletching.Plastic;
    }

    internal Arrow(ArrowHead arrowHead, double arrowLength, Fletching fletching)
    {
        ArrowHead = arrowHead;
        ArrowLength = arrowLength;
        Fletching = fletching;
    }

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

internal enum ArrowHead
{
    Steel,
    Wood,
    Obsidian
}

internal enum Fletching
{
    Plastic,
    TurkeyFeathers,
    GooseFeathers
}