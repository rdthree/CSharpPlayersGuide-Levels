using System.Diagnostics;

namespace Level52_Final;

internal static class TeamSetup
{
    internal static Team Player(Team? playerTeam, List<CharacterNames> nameList, string? redName, int healthBoosts)
    {
        //Debug.Assert(playerTeam != null, nameof(playerTeam) + " != null");
        var playerCaptain = new Character(playerTeam,"noname", 10, true);
        
        playerTeam = new Team(TeamColor.Red, 3, healthBoosts);
        if (redName != null) playerCaptain = new Character(playerTeam, redName, 10, true);
        playerTeam.TeamList.Add(playerCaptain);
        for (var i = 0; i < playerTeam.Size; i++)
            playerTeam.TeamList.Add(new Character(playerTeam, Character.NamePicker(nameList),
                Random.Shared.Next(10)));

        return playerTeam;
    }

    internal static List<Team> Opponents(List<CharacterNames> nameList)
    {
        var otherTeams = new List<Team>();
        var teamDifficulty = 1;
        foreach (TeamColor teamColor in Enum.GetValues(typeof(TeamColor)))
        {
            if (teamColor == TeamColor.Red) continue;

            var team = new Team(teamColor, teamDifficulty);
            var captain = new Character(team, Character.NamePicker(nameList), 10 + teamDifficulty, true);
            team.TeamList.Add(captain);

            for (var i = 0; i < team.Size; i++)
                team.TeamList.Add(new Character(team, Character.NamePicker(nameList),
                    Random.Shared.Next(1, 5 + teamDifficulty)));

            otherTeams.Add(team);
            teamDifficulty++;
        }

        return otherTeams;
    }
}