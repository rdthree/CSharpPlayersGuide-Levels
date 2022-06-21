namespace Level52_Final;

internal static class Menu
{
    internal static void ActionPicker(Character character, List<Team> opposingTeams)
    {
        var choice = 0;
        if (character.Team.Color is TeamColor.Red)
        {
            Messages.PlayerPickAction(character);
            var input = Console.ReadKey().KeyChar.ToString().ToLower();
            if (!int.TryParse(input, out choice))
            {
                char.TryParse(input, out var key);
                switch (key)
                {
                    case 'k':
                        Console.WriteLine("STATS");
                        Messages.PlayerPickActionStats(opposingTeams);
                        break;
                    case 's':
                        // dodge item, gives extra HP
                        break;
                    case 'd':
                        // power item, gives extra action power
                        break;
                    case 'p':
                        // some kinda double speed item, gives two action points
                        break;
                }
            }
        }

        character.Action = choice switch
        {
            1 => Action.DoNothing,
            2 => Action.FastThrow,
            3 => Action.CurveThrow,
            4 => Action.FakeThrow,
            5 => Action.HardThrow,
            6 => Action.FastToss,
            7 => Action.ScrewToss,
            8 => Action.UnderToss,
            9 => Action.BounceToss,
            _ => Action.DoNothing
        };
    }
}