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
        SenseTypes.Hear => "the sound of water rushing",
        SenseTypes.Maelstrom => "the maelstrom rushes around you",
        SenseTypes.Nothing => "on the move",
        SenseTypes.See => "you see the fountain",
        SenseTypes.Smell => "the smell of fountain water fills your nostrils",
        _ => "on the move"
    };
}