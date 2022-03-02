namespace MonchoUtils;

public static class MoUtils
{
    // this version just returns a double
    /// <summary>
    /// TryParse Console.ReadLine() until it can return a double
    /// </summary>
    /// <returns>double</returns>
    public static double InputToDouble()
    {
        double newInput;
        while (!double.TryParse(Console.ReadLine(), out newInput))
            Console.Write("please try again: ");
        return newInput;
    }

    /// <summary>
    /// TryParse Console.ReadLine() until it can return an unsigned integer
    /// </summary>
    /// <returns>uint</returns>
    public static uint InputToUint()
    {
        uint newInput;
        while (!uint.TryParse(Console.ReadLine(), out newInput))
            Console.Write("please try again: ");
        return newInput;
    }

    /// <summary>
    /// TryParse Console.ReadLine() until it can return an integer
    /// </summary>
    /// <returns>int</returns>
    public static int InputToInt()
    {
        int newInput;
        while (!int.TryParse(Console.ReadLine(), out newInput))
            Console.Write("please try again: ");
        return newInput;
    }
}