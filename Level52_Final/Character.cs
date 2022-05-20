namespace Level52_Final;

internal class Character
{
    internal string? Name { get; init; }
    internal int OriginalHp { get; init; }
    internal bool IsInGame { get; set; }

    // ReSharper disable once InconsistentNaming
    internal int HP { get; set; }
    internal Action Action { get; set; }
    internal Team Team { get; init; }
    internal bool CurrentTurn;

    protected internal Character(Team team, string? name = "Auto Generated Character", int hp = 5)
    {
        Team = team;
        Name = name;
        Action = Action.DoNothing;
        OriginalHp = hp;
        HP = hp;
        IsInGame = true;
    }
}