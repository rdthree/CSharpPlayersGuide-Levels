// See https://aka.ms/new-console-template for more information

using MonchoUtils;

var arrow = new Arrow();
var quiver = new List<Arrow>();
var quiverDisplay = false;
double arrowLengthInput;

//Console.Write($"Input arrow length: ");
//arrowLengthInput = MoUtils.InputToDouble();
//arrow = new Arrow(arrow.ArrowHead, startingArrowLength, arrow.Fletching);
//Console.Clear();

while (true)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("'B' for Beginner Arrow, 'N' for Elite Arrow, 'M' for Marksman Arrow");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("'H' for Arrow Head Type, 'F' for Fletching Type, 'L' for Length");
    Console.WriteLine("'X' to save arrow to quiver and reset, 'Q' to show/hide quiver");
    Console.ResetColor();

    if (quiverDisplay) ArrowUI.QuiverShow(quiver);
    else ArrowUI.ArrowChoice(arrow);

    var input = Console.ReadKey(true);
    switch (input.Key)
    {
        case ConsoleKey.B:
            arrow = Arrow.BeginnerArrow;
            break;
        case ConsoleKey.N:
            arrow = Arrow.EliteArrow;
            break;
        case ConsoleKey.M:
            arrow = Arrow.MarksmanArrow;
            break;
        case ConsoleKey.H:
            var newArrowHead = ArrowUI.ArrowHeadSwitcher(arrow.ArrowHead);
            arrow = new Arrow(newArrowHead, arrow.ArrowLength, arrow.Fletching);
            break;
        case ConsoleKey.F:
            var newFletching = ArrowUI.FletchingSwitcher(arrow.Fletching);
            arrow = new Arrow(arrow.ArrowHead, arrow.ArrowLength, newFletching);
            break;
        case ConsoleKey.L:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Input arrow length: ");
            arrowLengthInput = MoUtils.InputToDouble();
            var newArrowLength = arrowLengthInput;
            arrow = new Arrow(arrow.ArrowHead, newArrowLength, arrow.Fletching);
            Console.ResetColor();
            break;
        case ConsoleKey.X:
            quiver.Add(arrow);
            arrow = new Arrow();
            break;
        case ConsoleKey.Q:
            quiverDisplay = !quiverDisplay;
            break;
        // this is dorky, it needs to be something more elegant for accidental keypresses
        //default:
        //    throw new ArgumentOutOfRangeException();
    }

    Console.Clear();
    Console.ResetColor();
}

internal static class ArrowUI
{
    public static void QuiverShow(List<Arrow> quiverShow)
    {
        foreach (var arrowShow in quiverShow)
            Console.WriteLine($"{Arrow.GetCost(arrowShow.ArrowHead, arrowShow.ArrowLength, arrowShow.Fletching):C}: " +
                              $"{arrowShow.ArrowLength:##.00}cm, " +
                              $"{arrowShow.ArrowHead} Arrow Head, " +
                              $"{arrowShow.Fletching} Fletching");
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
        var arrowHead = arrowChosen.ArrowHead;
        var arrowLength = arrowChosen.ArrowLength;
        var fletching = arrowChosen.Fletching;
        var cost = Arrow.GetCost(arrowHead, arrowLength, fletching);

        Console.WriteLine($"Arrow Head: \t\t{arrowHead}\n" +
                          $"Arrow Length: \t\t{arrowLength:##.00}cm\n" +
                          $"Arrow Fletching: \t{fletching}");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Arrow Cost: \t\t{cost:C}");
    }
}


internal class Arrow
{
    public ArrowHead ArrowHead { get; }
    public double ArrowLength { get; }
    public Fletching Fletching { get; }

    internal Arrow()
    {
        ArrowHead = ArrowHead.Obsidian;
        ArrowLength = 32.4;
        Fletching = Fletching.Plastic;
    }

    internal Arrow(ArrowHead arrowHead, double arrowLength, Fletching fletching)
    {
        ArrowHead = arrowHead;
        ArrowLength = arrowLength;
        Fletching = fletching;
    }

    internal static Arrow EliteArrow => new Arrow(ArrowHead.Steel, 95.0, Fletching.Plastic);
    internal static Arrow BeginnerArrow => new Arrow(ArrowHead.Wood, 75.0, Fletching.GooseFeathers);
    internal static Arrow MarksmanArrow => new Arrow(ArrowHead.Steel, 65.0, Fletching.GooseFeathers);

    internal static double GetCost(ArrowHead arrowHead, double arrowLength, Fletching fletching)
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