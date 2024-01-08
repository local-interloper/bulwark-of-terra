using System.IO;
using System.Text.Json;
using BulwarkOfTerra.Types;

namespace BulwarkOfTerra;

public static class MapUtils
{
    public static MapInfo GetMapInfo(string mapName)
    {
        var stream = new StreamReader($"Streaming/maps/{mapName}/map.json");
        var text = stream.ReadToEnd();
        return JsonSerializer.Deserialize<MapInfo>(text);
    }

    public static TileSetInfo GetTileSetInfo(string mapName)
    {
        var stream = new StreamReader($"Streaming/maps/{mapName}/tileset.tsj");
        var text = stream.ReadToEnd();
        return JsonSerializer.Deserialize<TileSetInfo>(text);
    }

    public static TileMapInfo GetTileMapInfo(string mapName)
    {
        var stream = new StreamReader($"Streaming/maps/{mapName}/tilemap.tmj");
        var text = stream.ReadToEnd();
        return JsonSerializer.Deserialize<TileMapInfo>(text);
    }
}