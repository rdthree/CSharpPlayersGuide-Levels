namespace Level52_Final;

internal class Menus
{
    internal void ActionPicker(Character character, List<Team> opposingTeams)
    {
        int choice;
        if (character.Team.Color is TeamColor.Red)
        {
            Messages.PlayerPickAction(character);
            var input = Console.ReadKey().KeyChar.ToString().ToLower();
            if(!int.TryParse(input, out choice));
            {
                
                char.TryParse(input, out var key);
                if (key == 'k')
                    Messages.PlayerPickActionStats(opposingTeams);
                else if (key == 's')
                    // some kinda double speed item, gives two action points
                else if (key == 'd')
                    // dodge item, gives extra HP
                else if (key == 'p')
                    // power item, gives extra action power
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