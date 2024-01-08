using System.Text.Json.Serialization;

namespace BulwarkOfTerra.Types;

public class MapInfo
{
    [JsonPropertyName("version")] public int Version { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }
}