namespace Level31_FountainOfObjects.GameEngine;

internal static class Messages
{
    internal static string Senses(SenseTypes sense) => sense switch
    {
        SenseTypes.Amarok => "eaten. over",
        SenseTypes.Alert => "uh oh",
        SenseTypes.Blown => "the maelstrom sends you across the plains",
        SenseTypes.Chill => "a chill fills the air",
        SenseTypes.Fountain => "you have reached the fountain",
        SenseTypes.HearFountain => "the sound of water rushing",
        SenseTypes.Maelstrom => "the maelstrom rushes around you",
        SenseTypes.Nothing => "on the move",
        SenseTypes.SeeFountain => "you see the fountain",
        SenseTypes.SmellFountain => "the smell of fountain water fills your nostrils",
        SenseTypes.ChangedGround => "the ground seems different here",
        SenseTypes.End => "this is the end",
        SenseTypes.Pit => "you are stuck in a pit",
        _ => "void"
    };
}