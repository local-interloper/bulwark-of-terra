using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace BulwarkOfTerra.Types;

public class TileInfo
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public class TileSetInfo
{
    [JsonPropertyName("columns")]
    public int Columns { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("imageheight")]
    public int ImageHeight { get; set; }

    [JsonPropertyName("imagewidth")]
    public int ImageWidth { get; set; }

    [JsonPropertyName("margin")]
    public int Margin { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("spacing")]
    public int Spacing { get; set; }

    [JsonPropertyName("tilecount")]
    public int TileCount { get; set; }

    [JsonPropertyName("tiledversion")]
    public string TiledVersion { get; set; }

    [JsonPropertyName("tileheight")]
    public int TileHeight { get; set; }

    [JsonPropertyName("tiles")]
    public List<TileInfo> Tiles { get; set; }

    [JsonPropertyName("tilewidth")]
    public int TileWidth { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }
}

