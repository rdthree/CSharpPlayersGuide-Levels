using System.Globalization;
using CsvHelper;
// ReSharper disable InconsistentNaming

namespace Level52_Final;

internal class Character
{
    internal string? Name { get; }
    internal int OriginalHp { get; }
    internal bool IsInGame { get; set; }
    internal bool IsCaptain { get; init; }

    // ReSharper disable once InconsistentNaming
    internal int HP { get; set; }
    internal Action Action { get; set; }
    internal Team Team { get; }
    //internal bool CurrentTurn { get; set; }
    
    internal bool HealthBoost { get; set; }
    internal int _healthBoosts = 1;

    protected internal Character(Team team, string? name, int hp = 5, bool isCaptain = false)
    {
        Team = team;
        Action = Action.DoNothing;
        OriginalHp = hp;
        HP = hp;
        IsInGame = true;
        IsCaptain = isCaptain;

        //name = CharacterNameChoice();
        Name = IsCaptain ? "Captain " + name : name;
    }

    internal static List<CharacterNames> CharacterNameList()
    {
        using var reader = new StreamReader("names.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<CharacterNames>();
        var recordList = records.ToList();
        return recordList;
        //return recordList[rnd.Next(0, recordList.Count)].name;
        // var item = rnd.Next(0, records.Count());
    }

    internal static string? NamePicker(List<CharacterNames> characterNamesList)
    {
        return characterNamesList[Random.Shared.Next(0, characterNamesList.Count)].name;
    }

    internal void HealthBooster()
    {
        if (HealthBoost && _healthBoosts >= 1) HP += 3;
    }
}