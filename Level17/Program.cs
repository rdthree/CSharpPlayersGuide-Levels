// See https://aka.ms/new-console-template for more information

using System.Runtime.Serialization.Json;
using MonchoUtils;

/*
 * define enumerations:
 *   - food
 *     - type: soup, stew, gumbo
 *     - main ingredient: mushrooms, chicken, carrots, potatoes
 *     - seasoning: spicy, salty, sweet
 * * use a tuple to represent of soup using the three enums
 * USER:
 *   - picks a type, main ingredient and seasoning
 *   - fill tuple with the results
 *   - give the user a menu to pick from
 * DISPLAY:
 *   - when done show contents of soup tuple as a description of the food
 *   - this should be possible by just showing the enum value, not converting it to a string again
*/

(FoodType foodType, FoodIngredient foodIngredient, FoodSeasoning foodSeasoning) aFood;
var foodType = FoodType.Soup;
var foodIngredientType = FoodIngredient.Mushrooms;
var foodSeasoningType = FoodSeasoning.Spicy;
aFood = (foodType, foodIngredientType, foodSeasoningType);

bool foodTypeSelector = true;
bool foodIngredientSelector = true;
bool foodSeasoningSelector = true;

while (foodTypeSelector)
{
    Console.Clear();
    Console.ResetColor();
    Console.Write("Which type of food would you like? <press 'T'> ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{foodType}");
    if (Console.ReadKey().Key == ConsoleKey.T)
    {
        if (foodType == FoodType.Soup) foodType = FoodType.Stew;
        else if (foodType == FoodType.Stew) foodType = FoodType.Gumbo;
        else foodType = FoodType.Soup;
    }
    else if (Console.ReadKey().Key == ConsoleKey.Enter) foodTypeSelector = false;
}

while (foodIngredientSelector)
{
    Console.Clear();
    Console.ResetColor();
    Console.Write("What main ingredient are looking for? <press 'I'> ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"{foodIngredientType}");
    if (Console.ReadKey().Key == ConsoleKey.I)
    {
        if (foodIngredientType == FoodIngredient.Mushrooms) foodIngredientType = FoodIngredient.Chicken;
        else if (foodIngredientType == FoodIngredient.Chicken) foodIngredientType = FoodIngredient.Carrots;
        else if (foodIngredientType == FoodIngredient.Carrots) foodIngredientType = FoodIngredient.Potatoes;
        else foodIngredientType = FoodIngredient.Mushrooms;
    }
    else if (Console.ReadKey().Key == ConsoleKey.Enter) foodIngredientSelector = false;
}

while (foodSeasoningSelector)
{
    Console.Clear();
    Console.ResetColor();
    Console.Write("How would you like it seasoned? <press 'S'> ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{foodSeasoningType}");
    if (Console.ReadKey().Key == ConsoleKey.S)
    {
        if (foodSeasoningType == FoodSeasoning.Spicy) foodSeasoningType = FoodSeasoning.Salty;
        else if (foodSeasoningType == FoodSeasoning.Salty) foodSeasoningType = FoodSeasoning.Sweet;
        else foodSeasoningType = FoodSeasoning.Spicy;
    }
    else if (Console.ReadKey().Key == ConsoleKey.Enter) foodSeasoningSelector = false;
}

Console.WriteLine($"Excellent Choice Sir, '{aFood.foodSeasoning} {aFood.foodType} with {aFood.foodIngredient}'");

void canIHitItAndQuit()
{
    Console.Clear();
    Console.ResetColor();
    Console.Write("Which type of food would you like? <press 'T'> ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{foodType}");
    Console.ResetColor();
    Console.Write("What main ingredient are looking for? <press 'I'> ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"{foodIngredientType}");
    Console.ResetColor();
    Console.Write("How would you like it seasoned? <press 'S'> ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{foodSeasoningType}");
    Console.WriteLine($"Excellent Choice Sir, '{aFood.foodSeasoning} {aFood.foodType} with {aFood.foodIngredient}'");
}

enum FoodType
{
    Soup,
    Stew,
    Gumbo
}

enum FoodIngredient
{
    Mushrooms,
    Chicken,
    Carrots,
    Potatoes
}

enum FoodSeasoning
{
    Spicy,
    Salty,
    Sweet
}