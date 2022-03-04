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
 *
 * INFO: this helped with the readline issues on the console
 * https://stackoverflow.com/questions/37354142/c-sharp-console-how-to-readline-without-the-need-of-pressing-enter
*/

(FoodType foodType, FoodIngredient foodIngredient, FoodSeasoning foodSeasoning) aFood;
var foodType = FoodType.Soup;
var foodIngredientType = FoodIngredient.Mushrooms;
var foodSeasoningType = FoodSeasoning.Spicy;
aFood = (foodType, foodIngredientType, foodSeasoningType);

while (true)
{
    CanIHitItAndQuit();
    var input = Console.ReadKey();
    /*
    switch (input.Key)
    {
        case ConsoleKey.T when foodType == FoodType.Soup:
            foodType = FoodType.Stew;
            break;
        case ConsoleKey.T when foodType == FoodType.Stew:
            foodType = FoodType.Gumbo;
            break;
        case ConsoleKey.T:
            foodType = FoodType.Soup;
            break;
        case ConsoleKey.I when foodIngredientType == FoodIngredient.Mushrooms:
            foodIngredientType = FoodIngredient.Chicken;
            break;
        case ConsoleKey.I when foodIngredientType == FoodIngredient.Chicken:
            foodIngredientType = FoodIngredient.Carrots;
            break;
        case ConsoleKey.I when foodIngredientType == FoodIngredient.Carrots:
            foodIngredientType = FoodIngredient.Potatoes;
            break;
        case ConsoleKey.I:
            foodIngredientType = FoodIngredient.Mushrooms;
            break;
        case ConsoleKey.S when foodSeasoningType == FoodSeasoning.Spicy:
            foodSeasoningType = FoodSeasoning.Salty;
            break;
        case ConsoleKey.S when foodSeasoningType == FoodSeasoning.Salty:
            foodSeasoningType = FoodSeasoning.Sweet;
            break;
        case ConsoleKey.S:
            foodSeasoningType = FoodSeasoning.Spicy;
            break;
    }
        */
}

void CanIHitItAndQuit()
{
    aFood = (foodType, foodIngredientType, foodSeasoningType);
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
    Console.ForegroundColor = ConsoleColor.Green;
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