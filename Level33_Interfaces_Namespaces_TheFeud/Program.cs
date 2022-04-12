using Level33_Interfaces_Namespaces_TheFeud.IField;
using Level33_Interfaces_Namespaces_TheFeud.McDroid;


internal class Program
{
    static void Main(string[] args)
    {
        var fieldSheep = new Sheep();
        var fieldPig = new Level33_Interfaces_Namespaces_TheFeud.IField.Pig();
        var droidCow = new Cow();
        var droidPig = new Level33_Interfaces_Namespaces_TheFeud.McDroid.Pig();
    }
}

namespace Level33_Interfaces_Namespaces_TheFeud.IField
{
    public class Sheep
    {
    }

    public class Pig
    {
    }
}

namespace Level33_Interfaces_Namespaces_TheFeud.McDroid
{
    public class Cow
    {
    }

    public class Pig
    {
    }
}