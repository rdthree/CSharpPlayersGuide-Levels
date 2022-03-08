// See https://aka.ms/new-console-template for more information
using MonchoUtils;

/*
var choice = MoUtils.InputToUint();

switch (choice)
{
    case 1:
        Console.WriteLine("rest");
        break;
    case 2:
        Console.WriteLine("raid");
        break;
    case 3:
    case 4:
        Console.WriteLine("3 and 4 are the same thang thang");
        break;
    default:
        Console.WriteLine("way whut");
        break;
}

choice = MoUtils.InputToUint();
var response = choice switch
{
    1 => "rest",
    2 => "raid",
    3 or 4 => "3 and 4 are the same thang",
    _ => "say whuuut"
};
Console.WriteLine(response);
*/

/*
 * build a list for a stupid store
*/
//foreach (var item in Enum.GetNames(typeof(InventoryItems)))
//    Console.WriteLine($"{item.IndexOf(item)} - {item}");

var inventoryChoice = MoUtils.InputToUint();
var inventory = inventoryChoice switch
{
    1 => "rope",
    2 => "torches",
    3 or 4 or 5 => "carabiners",
    6 => "machete",
    7 => "ham",
    8 => "slugs",
    _ => "not in stock"
};

var inventoryCostChoice = inventoryChoice;
var inventoryCost = inventoryCostChoice switch
{
    1 => 10,
    2 => 30,
    3 or 4 or 5 => 4,
    6 => 25,
    7 => 18,
    8 => 22,
    _ => 0
};

Console.WriteLine($"{inventory} = {inventoryCost}");

