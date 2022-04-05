﻿using Level31_FountainOfObjects.RoomsEnemies;

namespace Level31_FountainOfObjects.GameEngine;

internal class Draw : IDraw
{
    private readonly Game _game;
    private readonly Player _player;

    internal Draw(Player player, Game game)
    {
        _game = game;
        _player = player;
    }

    public void DrawRoom()
    {
        for (var i = 0; i < _game.MainRoom.Rows; i++)
        {
            for (var j = 0; j < _game.MainRoom.Columns; j++)
                SpriteDrawOrder(i, j);

            Console.WriteLine();
        }
    }

    private void SpriteDrawOrder(int i, int j)
    {
        var coord = new IMainRoom.Coordinate(i, j);
        if (DrawPlayer(coord, _player.PlayerLocation, '@')) return;
        if (DrawItem(_player, _game.FountainRoom, coord)) return;
        if (_game.Amaroks.Any(amarok => DrawItem(_player, amarok, coord))) return;
        if (_game.PitRooms.Any(pitRoom => DrawItem(_player, pitRoom, coord))) return;
        if (_game.Maelstroms.Any(maelstrom => DrawItem(_player, maelstrom, coord))) return;
        DrawRoomGrid(ConsoleColor.Yellow, ':');
    }

    private static bool DrawPlayer(IMainRoom.Coordinate coord, IMainRoom.Coordinate playerCoord, char c = '+')
    {
        if (coord != playerCoord) return false;
        WriteResetChar(c, ConsoleColor.Red);
        return true;
    }

    private static bool DrawItem(Player player, SubRoom place, IMainRoom.Coordinate coord)
    {
        place.IsOn = SubRoomOnOff(player, place);
        if (!place.IsOn) return false;
        if (CheckIfCoordinateIsUsed(place, coord)) return false;

        if (DrawItemLocation(coord, place)) return true;
        if (DrawSense(coord, place.ItemCoords, place.ItemColor, place.ItemSymbol)) return true;
        if (DrawSense(coord, place.EdgeCoords, place.EdgeColor, place.EdgeSymbol)) return true;
        if (DrawSense(coord, place.FieldCoords, place.FieldColor, place.FieldSymbol)) return true;
        if (DrawSense(coord, place.OuterFieldCoords, place.OuterFieldColor, place.OuterFieldSymbol)) return true;
        return true;
    }

    private static bool CheckIfCoordinateIsUsed(SubRoom place, IMainRoom.Coordinate coord)
    {
        if (place.ItemCoords.All(coordinate => coord != coordinate) &&
            place.EdgeCoords.All(coordinate => coord != coordinate) &&
            place.FieldCoords.All(coordinate => coord != coordinate) &&
            place.OuterFieldCoords.All(coordinate => coord != coordinate)) return true;

        return false;
    }

    private static bool DrawItemLocation(IMainRoom.Coordinate coord, ISubRoom place)
    {
        if (coord != place.Location) return false;
        WriteResetChar(place.ItemSymbol, place.ItemColor);
        return true;
    }

    private static bool DrawSense(IMainRoom.Coordinate coord, IEnumerable<IMainRoom.Coordinate> listSense,
        ConsoleColor color,
        char c = '+')
    {
        if (listSense.All(coordinate => coord != coordinate)) return false;
        WriteResetChar(c, color);
        return true;
    }

    private static void DrawRoomGrid(ConsoleColor color, char c = '+') => WriteResetChar(c, color);

    private static void WriteResetChar(char c = '+', ConsoleColor color = ConsoleColor.Black)
    {
        Console.ForegroundColor = color;
        Console.Write(c.ToString());
        Console.ResetColor();
    }

    private static bool SubRoomOnOff(Player player, ISubRoom subRoom)
    {
        if (!player.Control.IsShoot) return subRoom.IsOn();
        {
            var subRoomRow = subRoom.Location.Row;
            var subRoomCol = subRoom.Location.Column;
            var playerRow = player.PlayerLocation.Row;
            var playerCol = player.PlayerLocation.Column;
            var playerDir = player.Control.Direction;

            if (playerDir == HeadingTypes.North && subRoomRow < playerRow && subRoomCol == playerCol) return false;
            if (playerDir == HeadingTypes.South && subRoomRow > playerRow && subRoomCol == playerCol) return false;
            if (playerDir == HeadingTypes.West && subRoomCol < playerCol && subRoomRow == playerRow) return false;
            if (playerDir == HeadingTypes.East && subRoomCol > playerCol && subRoomRow == playerRow) return false;
        }

        return subRoom.IsOn();
    }
}