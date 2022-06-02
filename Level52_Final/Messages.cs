namespace Level52_Final;

internal static class Messages
{
    internal static void HealthBoostMessage(Team team, Character character)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{team.Color} {character.Name} health boosted: " +
                          $"{character.HP}/{character.OriginalHp}");
        Console.WriteLine($"{team.Color} Team has: {team.HealthBoosts} boosts left");
        Console.ResetColor();
    }

    internal static void PlayerLose(Team player) => Console.WriteLine($"{player.Color} Team Loses");
    internal static void PlayerWin(Team player) => Console.WriteLine($"{player.Color} Team Wins");

    internal static void OpponentTeamLoses(Team opponent, List<Team> opponentList)
    {
        Console.WriteLine($"{opponent.Color} Team loses");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Next Opponents: {opponent.Color} Team");
        foreach (var character in opponent.TeamList) Console.WriteLine($"{character.Name}");
        Console.ResetColor();
    }

    internal static void GameStatus(Team player, Team opponent, List<Team> opponentList)
    {
        Console.WriteLine($"{player.Color}/{player.Size} vs {opponent.Color}/{opponent.Size}");
        Console.WriteLine($"Other Teams Left: {opponentList.Count}");
    }

    internal static void PlayOpponentCaptain(Character opponent) =>
        Console.WriteLine($"UH OH ITS THE {opponent.Team.Color} CAPTAIN {opponent.Name}");

    internal static void TakeTurnsActionStats(Character playingPlayer, Character opposingPlayer)
    {
        Console.WriteLine($"It is {playingPlayer.Team.Color} Team {playingPlayer.Name}'s turn.\n" +
                          $"{playingPlayer.Team.Color} Team {playingPlayer.Name} did a " +
                          $"{playingPlayer.Action} on {opposingPlayer.Name}\n");
    }

    internal static void TakeTurnsPlayerStats(Character character, Character otherCharacter, int hitPoints)
    {
        Console.WriteLine(
            $"{character.Team.Color} {character.Name} scores {hitPoints}, " +
            $"{otherCharacter.Team.Color} {otherCharacter.Name} is at: {otherCharacter.HP}");

        Console.WriteLine($"{character.Team.Color} {character.Name} is at: " +
                          $"{character.HP}/{character.OriginalHp}");
    }

    internal static void TakeTurnsTeamStats(Team player, List<Team> otherTeams)
    {
        var opponent = otherTeams.First();
        Console.ForegroundColor = ConsoleColor.Magenta;
        foreach (var teamPlayer in player.TeamList.ToList().Where(teamPlayer => !teamPlayer.IsInGame))
        {
            player.TeamList.Remove(teamPlayer);
            Console.WriteLine($"{teamPlayer.Name} from {TeamColor.Red} is out of the game.");
        }

        foreach (var teamPlayer in opponent.TeamList.ToList().Where(teamPlayer => !teamPlayer.IsInGame))
        {
            opponent.TeamList.Remove(teamPlayer);
            Console.WriteLine($"{teamPlayer.Name} from {opponent.Color} is out of the game.");
        }

        Console.WriteLine($"{player.Color} Team has {player.TeamList.Count} players");
        Console.WriteLine($"{opponent.Color} Team has {opponent.TeamList.Count} players");
        Console.ResetColor();
    }

    internal static void PlayerPickAction(Character character)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"Red Captain {character.Name}, pick action (1-9, k): ");
        Console.ResetColor();
    }

    internal static void PlayerPickActionStats(List<Team> opposingTeams)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Remaining Teams");
        foreach (var otherTeam in opposingTeams)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{otherTeam.Color} : {otherTeam.TeamList.Count}");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            foreach (var character1 in otherTeam.TeamList)
                Console.WriteLine($"{character1.Name}:{character1.HP}/{character1.OriginalHp}");
            Console.ResetColor();
        }

        Console.ResetColor();
    }
}