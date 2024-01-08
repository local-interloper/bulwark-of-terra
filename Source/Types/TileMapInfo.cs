namespace BulwarkOfTerra.Types;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Layer
{
    [JsonPropertyName("data")]
    public List<int> Data { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("opacity")]
    public double Opacity { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("visible")]
    public bool Visible { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }

    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }
}

public class TilesetInfo
{
    [JsonPropertyName("firstgid")]
    public int FirstGid { get; set; }

    [JsonPropertyName("source")]
    public string Source { get; set; }
}

public class TileMapInfo
{
    [JsonPropertyName("compressionlevel")]
    public int CompressionLevel { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("infinite")]
    public bool Infinite { get; set; }

    [JsonPropertyName("layers")]
    public List<Layer> Layers { get; set; }

    [JsonPropertyName("nextlayerid")]
    public int NextLayerId { get; set; }

    [JsonPropertyName("nextobjectid")]
    public int NextObjectId { get; set; }

    [JsonPropertyName("orientation")]
    public string Orientation { get; set; }

    [JsonPropertyName("renderorder")]
    public string RenderOrder { get; set; }

    [JsonPropertyName("tiledversion")]
    public string TiledVersion { get; set; }

    [JsonPropertyName("tileheight")]
    public int TileHeight { get; set; }

    [JsonPropertyName("tilesets")]
    public List<TilesetInfo> TileSets { get; set; }

    [JsonPropertyName("tilewidth")]
    public int TileWidth { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }
}

