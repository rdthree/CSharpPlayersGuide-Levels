// See https://aka.ms/new-console-template for more information


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
    CanIHitItAndQuit(foodType, foodIngredientType, foodSeasoningType);
    var input = Console.ReadKey();
    switch (input.Key)
    {
        case ConsoleKey.T:
            foodType = FoodTypeSwitcher(foodType);
            break;
        case ConsoleKey.I:
            foodIngredientType = FoodIngredientSwitcher(foodIngredientType);
            break;
        case ConsoleKey.S:
            foodSeasoningType = FoodSeasoningSwitcher(foodSeasoningType);
            break;
    }
}

FoodType FoodTypeSwitcher(FoodType foodTypeSwitch)
{
    return foodTypeSwitch switch
    {
        FoodType.Soup => foodTypeSwitch = FoodType.Stew,
        FoodType.Stew => foodTypeSwitch = FoodType.Gumbo,
        _ => foodTypeSwitch = FoodType.Soup
    };
}

FoodIngredient FoodIngredientSwitcher(FoodIngredient foodIngredientTypeSwitch)
{
    return foodIngredientTypeSwitch switch
    {
        FoodIngredient.Mushrooms => foodIngredientTypeSwitch = FoodIngredient.Chicken,
        FoodIngredient.Chicken => foodIngredientTypeSwitch = FoodIngredient.Carrots,
        FoodIngredient.Carrots => foodIngredientTypeSwitch = FoodIngredient.Potatoes,
        _ => foodIngredientTypeSwitch = FoodIngredient.Mushrooms
    };
}

FoodSeasoning FoodSeasoningSwitcher(FoodSeasoning foodSeasoningTypeSwitch)
{
    return foodSeasoningTypeSwitch switch
    {
        FoodSeasoning.Spicy => foodSeasoningTypeSwitch = FoodSeasoning.Salty,
        FoodSeasoning.Salty => foodSeasoningTypeSwitch = FoodSeasoning.Sweet,
        _ => foodSeasoningTypeSwitch = FoodSeasoning.Spicy
    };
}

void CanIHitItAndQuit(FoodType foodTypeParam, FoodIngredient foodIngredient, FoodSeasoning foodSeasoning)
{
    aFood = (foodTypeParam, foodIngredientType, foodSeasoningType);
    Console.Clear();
    Console.ResetColor();
    Console.Write("Which type of food would you like? <press 'T'> ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"{foodTypeParam}");
    Console.ResetColor();
    Console.Write("What main ingredient are looking for? <press 'I'> ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"{foodIngredientType}");
    Console.ResetColor();
    Console.Write("How would you like it seasoned? <press 'S'> ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"{foodSeasoningType}");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(
        $"Excellent Choice Sir, '{aFood.foodSeasoning} {aFood.foodType} with {aFood.foodIngredient}'");
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