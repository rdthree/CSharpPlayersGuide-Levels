namespace Level52_Final;

internal class Team
{
    internal List<Character> TeamList { get; } = new();
    internal int Size { get; }
    internal readonly TeamColor Color;
    internal bool CurrentTurn = false;
    internal int HealthBoosts { get; set; }

    internal Team(TeamColor color = TeamColor.Blue, int size = 10, int healthBoosts = 3)
    {
        Size = size;
        Color = color;
        HealthBoosts = healthBoosts;
    }
}