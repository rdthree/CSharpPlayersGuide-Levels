// See https://aka.ms/new-console-template for more information



/*
 * using enums
 * create a chest that can be open, closed unlocked, closed locked
 * this is how to move between the states:
 * CLOSE->closed->LOCK->locked->UNLOCK->closed->OPEN->open...
 * nothing happens if events are triggered out of order
 */

BoxState box = BoxState.Closed;
#pragma warning disable CS0168
BoxAction boxMove;
#pragma warning restore CS0168


while (true)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("You have four options: ");
    Console.ResetColor();
    Console.Write($"Close, Lock, Unlock, and Open\n");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write($"The box is ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write($"{box}");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write($" what would you like to do? ");
    Console.ResetColor();
    var boxInput = Console.ReadLine()?.ToLower();

    if (boxInput == "open" && box == BoxState.Closed) box = BoxState.Open;
    else if (boxInput == "close" && box == BoxState.Open) box = BoxState.Closed;
    else if (boxInput == "lock" && box == BoxState.Closed) box = BoxState.Locked;
    else if (boxInput == "unlock" && box == BoxState.Locked) box = BoxState.Closed;
    else
        Console.WriteLine("");
    
}

enum BoxState
{
    Open,
    Closed,
    Locked
}

enum BoxAction
{
    Close,
    Lock,
    Unlock,
    Open
}