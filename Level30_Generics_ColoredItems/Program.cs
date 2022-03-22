// See https://aka.ms/new-console-template for more information
/*
 * use a generic class to associate a color with each item
 * generic class must have properties for the item itself and a ConsoleColor
 * include a void Display() with your colored item type, it will change the console color and show the item name
 * create a new colored item containing a blue sword, a red bow and a green axe.  then display them
 */

var colorThingSword = new ColoredItem<Sword>(ConsoleColor.Red);
var colorThingBow = new ColoredItem<Bow>(ConsoleColor.Green);
var colorThingAxe = new ColoredItem<Axe>(ConsoleColor.Magenta);

var swordy = new Sword();
var colorThingSwordTwo = new ColoredItem<Sword>(ConsoleColor.Blue, swordy);

colorThingSword.Display();
colorThingAxe.Display();
colorThingBow.Display();
colorThingSwordTwo.Display();


internal class ColoredItem<T> where T : new()
{
    public ConsoleColor Color { get; }
    public T Thing { get; }

    internal ColoredItem(ConsoleColor color)
    {
        Color = color;
        Thing = new T();
    }

    internal ColoredItem(ConsoleColor color, T thing) : this(color) => Thing = thing;


    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine($"{Thing?.GetType()}");
        Console.ResetColor();
    }
}

internal class Sword
{
}

internal class Bow
{
}

internal class Axe
{
}