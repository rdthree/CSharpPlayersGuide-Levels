// See https://aka.ms/new-console-template for more information
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