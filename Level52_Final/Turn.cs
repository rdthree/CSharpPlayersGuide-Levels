namespace Level52_Final;

internal static class Turn
{
    internal static void Play(Team team, Team playerTeam, List<Team> opposingTeamList)
    {
        var character = team.TeamList[Random.Shared.Next(team.TeamList.Count)];
        var otherCharacter = RandomOpposingPlayer(character, playerTeam, opposingTeamList);

        Menu.ActionPicker(character, opposingTeamList);

        if (otherCharacter.IsCaptain) Messages.PlayOpponentCaptain(otherCharacter);
        Messages.TakeTurnsActionStats(character, otherCharacter);

        var addedHitPoints = 0;
        if (character.Dash) addedHitPoints += 10; // TODO: improve so it gives TWO action moves
        else if (character.Dodge) character.HP += 2; // TODO: improve so its actually a dodge
        else if (character.PowerUp) character.HP += 10;

        var hitPoints = HitPoints(character) + addedHitPoints;
        otherCharacter.HP -= hitPoints;
        if (otherCharacter.HP < 1)
        {
            // loot system if other character out of game
            character.DashQty += otherCharacter.DashQty;
            character.DodgeQty += otherCharacter.DodgeQty;
            character.PowerUpQty += otherCharacter.PowerUpQty;
            otherCharacter.IsInGame = false;
        }

        Messages.TakeTurnsTeamStats(playerTeam, opposingTeamList);
        if (character.IsInGame) Messages.TakeTurnsPlayerStats(character, otherCharacter, hitPoints);

        character.ResetItems();
        Turn.NextTeamTurn(playerTeam, opposingTeamList);
    }

    private static void NextTeamTurn(Team playerTeam, List<Team> otherTeams)
    {
        var currentTeam = otherTeams[0];
        if (currentTeam.CurrentTurn)
        {
            currentTeam.CurrentTurn = false;
            playerTeam.CurrentTurn = true;
        }
        else if (playerTeam.CurrentTurn)
        {
            playerTeam.CurrentTurn = false;
            currentTeam.CurrentTurn = true;
        }
    }

    private static Character RandomOpposingPlayer(Character character, Team playerTeam, List<Team> opposingTeamList)
    {
        var opponentTeam = opposingTeamList.First();
        var randomOpponent = character.Team.Color == playerTeam.Color
            ? opponentTeam.TeamList[Random.Shared.Next(opponentTeam.TeamList.Count)]
            : playerTeam.TeamList[Random.Shared.Next(playerTeam.TeamList.Count)];
        return randomOpponent;
    }

    private static int HitPoints(Character character)
    {
        var hitPoints = character.Action switch
        {
            Action.DoNothing => 0,
            Action.FastThrow => Random.Shared.Next(0, 10),
            Action.CurveThrow => Random.Shared.Next(0, 9),
            Action.FakeThrow => Random.Shared.Next(0, 8),
            Action.BounceToss => 100,
            _ => Random.Shared.Next(0, 4),
        };

        return hitPoints;
    }
}