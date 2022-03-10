// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using MonchoUtils;

// point class tests
var point1 = new Point(2.0, 3.0);
var point2 = new Point(-4.0, 0.0);
var origin = Point.Origin();
Console.WriteLine($"x = {point1.X}, y = {point1.Y}");
Console.WriteLine($"origin = ({origin.X},{origin.Y})");

// color class tests
var color1 = new Color(300, -3, 20);
var color2 = new Color(50, 30, 40);
var color3 = Color.Purple;
Console.WriteLine($"color1: R{color1.R}, G{color1.G}, B{color1.B}");
Console.WriteLine($"color2: R{color2.R}, G{color2.G}, B{color2.B}");
Console.WriteLine($"color3: R{color3.R}, G{color3.G}, B{color3.B}");

// card class tests
List<Card> deck = new List<Card>();
var cardNumber = 0;
foreach (var color in Enum.GetValues<CardColor>())
{
    foreach (var rank in Enum.GetValues<CardRank>())
    {
        // this is the only way the enum works
        deck.Add(new Card
        {
            Color = color,
            Rank = rank
        });
    }
}

foreach (var card in deck)
{
    Console.Write($"{card.Color}, {card.Rank}, {(int)card.Rank}");
    if (card.RankChecker()) Console.Write(": is a face card");
    Console.WriteLine("");
}

// door lock/unlock class tests
var door = new LockingDoor("mob");
while (true)
{
    Console.WriteLine("'o' to open or unlock, 'c' to close, 'l' to lock");
    Console.WriteLine($"door is: {door.State}");
    var command = Console.ReadLine();
    switch (command)
    {
        case "o" when door.State == DoorStates.ClosedUnlocked:
            door.State = DoorStates.Open;
            break;
        case "o":
        {
            if (door.State == DoorStates.ClosedLocked)
            {
                Console.Write("input current password");
                if (door.NewPass(Console.ReadLine()))
                    door.State = DoorStates.ClosedUnlocked;
            }
            break;
        }
        case "c":
        {
            if (door.State == DoorStates.Open) door.State = DoorStates.ClosedUnlocked;
            break;
        }
        case "l":
        {
            Console.Write("input password: ");
            if (door.IsPass(Console.ReadLine())) door.State = DoorStates.ClosedLocked;
            break;
        }
    }
}

/// <summary>
/// Point Class with X and Y coordinates
/// - includes static method for Origin
/// </summary>
internal class Point
{
    /// <summary>
    /// X coordinate
    /// </summary>
    public double X { get; }

    /// <summary>
    /// Y coordinate
    /// </summary>
    public double Y { get; }

    /// <summary>
    /// Point Constructor
    /// </summary>
    /// <param name="x">X coordinate</param>
    /// <param name="y">Y coordinate</param>
    internal Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Point at Origin
    /// </summary>
    /// <returns>Point at x,y = 0,0</returns>
    public static Point Origin() => new Point(0.0, 0.0);
}

/// <summary>
/// Color class with R, G and B channels.  Each 0 to 255.  Includes 8 built in colors.
/// </summary>
internal class Color
{
    public int R { get; }
    public int G { get; }
    public int B { get; }

    /// <summary>
    /// Color Constructor
    /// </summary>
    /// <param name="r">Red Channel 0 to 255</param>
    /// <param name="g">Green Channel 0 to 255</param>
    /// <param name="b">Blue Channel 0 to 255</param>
    internal Color(int r, int g, int b)
    {
        R = twoFiveFive(r);
        G = twoFiveFive(g);
        B = twoFiveFive(b);
    }

    public static Color White => new Color(255, 255, 0);
    public static Color Black => new Color(0, 0, 0);
    public static Color Red => new Color(255, 0, 0);
    public static Color Orange => new Color(255, 165, 0);
    public static Color Yellow => new Color(255, 255, 0);
    public static Color Green => new Color(0, 128, 0);
    public static Color Blue => new Color(0, 0, 255);
    public static Color Purple => new Color(128, 0, 128);

    private int twoFiveFive(int x)
    {
        if (x < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{x} changed to lowest possible value: 0");
            Console.ResetColor();
            x = 0;
        }
        else if (x > 255)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{x} changed to highest possible value: 255");
            Console.ResetColor();
            x = 255;
        }

        return x;
    }
}

/// <summary>
/// Card Class that has Colors and Ranks
/// </summary>
internal class Card
{
    public CardColor Color { get; init; }
    public CardRank Rank { get; init; }

    internal Card()
    {
    }

    internal Card(CardColor cardColor, CardRank cardRank)
    {
        Color = cardColor;
        Rank = cardRank;
    }

    public bool RankChecker() => (int)Rank > 10;
}

/// <summary>
/// 4 Color Cards R,G,B,Y
/// </summary>
public enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow
}

/// <summary>
/// 10 Number Cards and 4 Face Cards
/// </summary>
public enum CardRank
{
    One = 1,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Dollar,
    Percentage,
    Carat,
    Ampersand
}

internal class LockingDoor
{
    private string _password;
    public DoorStates State { get; set; } = DoorStates.Open;

    internal LockingDoor(string password) => _password = password;
    internal LockingDoor(string password, DoorStates state) => _password = password;

    public bool NewPass(string? password)
    {
        Console.WriteLine("input current password: ");
        if (password == _password)
        {
            string newPassword = Console.ReadLine();
            _password = newPassword;
            Console.WriteLine("Password has been changed");
            return true;
        }
        else
        {
            Console.WriteLine("incorrect password");
            return false;
        }
    }

    public bool IsPass(string? password)
    {
        Console.WriteLine("input current password: ");
        if (password == _password) return true;
        else
        {
            Console.WriteLine("wrong key");
            return false;
        }
    }
}

enum DoorStates
{
    Open,
    ClosedUnlocked,
    ClosedLocked,
}