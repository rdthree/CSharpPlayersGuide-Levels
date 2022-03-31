// create swords of wood, bronze, iron, steel, or binarium
// swords have a gemstone of emerald, amber, sapphire, diamond, bitstone, or none
// enum for sword materials and for gemstone option
// record for Sword, basic setting is iron and no gemstone
// create two variations using with expressions

var basic = new Sword(Material.Iron, Gemstone.None, 12.0f);

var badBoy = basic with { SwordMaterial = Material.Binarium, SwordGemstone = Gemstone.Bitstone };
var littleDog = basic with { SwordMaterial = Material.Wood, CrossguardWidth = 1.0f };
var wildOne = basic with { SwordGemstone = Gemstone.Amber, CrossguardWidth = 55.0f };

Console.WriteLine($"{basic}\n{littleDog}\n{wildOne}\n{badBoy}");
Console.WriteLine($"{basic.GetHashCode()}");

internal record Sword(Material SwordMaterial, Gemstone SwordGemstone, double CrossguardWidth);

internal enum Material
{
    Wood,
    Bronze,
    Iron,
    Steel,
    Binarium
}

internal enum Gemstone
{
    None,
    Emerald,
    Amber,
    Sapphire,
    Diamond,
    Bitstone
}